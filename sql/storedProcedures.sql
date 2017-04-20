-------------------QUESTION NO 1---------------------
CREATE PROCEDURE GetBooks
@book varchar(20),
@author varchar(20),
@publisher varchar(20)
AS
	BEGIN 
		SELECT b.id, b.title title, a.name author, b.edition edition, b.isbn isbn, b.published_date published_date, p.name publisher, 
		(
			SELECT COUNT(bc.id) 
			FROM book_copies bc 
			WHERE bc.book_id = b.id
		) quantity


		FROM books b

		JOIN publishers p
		ON b.publisher_id=p.id

		LEFT JOIN author_book ab
		ON b.id = ab.	book_id

		LEFT JOIN 
		(
			SELECT name, id
			FROM authors
			--if author name is searched
			WHERE name LIKE '%'+@author+'%'
		) a 
		on ab.author_id = a.id
		WHERE 
		( 
			--if book name is searched
			(b.title LIKE '%'+@book+'%' OR b.isbn = @book)
			--if publisher is searched
			AND p.name LIKE '%'+@publisher+'%'
			AND
			(
				SELECT COUNT(bc.id) 
				FROM book_copies bc 
				WHERE bc.book_id = b.id
			) > 0
		)
		
		ORDER BY b.published_date

	END


GO-------------------QUESTION NO 2---------------------
CREATE PROCEDURE GetAvailableBooks
@book varchar(20),
@author varchar(20),
@publisher varchar(20)
AS
	BEGIN 
		SELECT b.id, b.title title, a.name author, b.edition edition, b.isbn isbn, b.published_date published_date, p.name publisher, 
		quantity = 
		(
			SELECT COUNT(bc.id) - COUNT(l.id) as qty
			FROM book_copies bc
			LEFT JOIN loans l
			ON l.book_copy_id = bc.id
			AND l.returned_date IS NULL
			WHERE bc.book_id = b.id
		)


			FROM books b

			INNER JOIN publishers p
			ON b.publisher_id=p.id

			LEFT JOIN author_book ab
			ON b.id = ab.book_id

			LEFT JOIN 
			(
				SELECT name, id
				FROM authors
				--if author name is searched
				WHERE name LIKE '%' + @author + '%'
			) a 
			on ab.author_id = a.id
			WHERE 
			( 
				--if book name is searched
				(b.title LIKE '%' +@book +'%' OR b.isbn = @book)
				--if publisher is searched
				AND p.name LIKE '%' + @publisher + '%'
			)
			AND
			(
				SELECT COUNT(bc.id) - COUNT(l.id)
				FROM book_copies bc
				LEFT JOIN loans l
				ON l.book_copy_id = bc.id
				AND l.returned_date IS NULL
				WHERE bc.book_id = b.id
			) > 0
		ORDER BY b.published_date
	END 


GO
-- CREATE PROCEDURE GetMembers
-- @search VARCHAR(20)
-- AS
-- 	BEGIN
-- 		SELECT m.id, m.name, m.email, m.phone, mt.type, m.joined_date, m.address
-- 		FROM members m
-- 		JOIN membership_types mt
-- 		ON m.membership_type_id = mt.id;
-- 	END

GO
CREATE PROCEDURE GetMembers
@searchTerm VARCHAR(20)
AS
	BEGIN
		IF (ISNUMERIC(@searchTerm)=1)
			BEGIN
				SELECT m.id, m.name, m.email, m.phone, mt.type, m.address, mt.books_allowed,
				(
					SELECT COUNT(l.id) 
					FROM loans l
					WHERE l.member_id = m.id
				) total_loans,
				(
					SELECT COUNT(l.id) 
					FROM loans l
					WHERE l.returned_date IS NULL
					AND l.member_id = m.id
				) active_loans
				FROM members m
				LEFT JOIN 
				membership_types mt
				ON mt.id = m.membership_type_id
				WHERE m.id = CAST(@searchTerm as int)
				ORDER BY m.name;
			END
		ELSE
			BEGIN
				SELECT m.id, m.name, m.email, m.phone, mt.type, m.address, mt.books_allowed,
				(
					SELECT COUNT(l.id) 
					FROM loans l
					WHERE l.member_id = m.id
				) total_loans,
				(
					SELECT COUNT(l.id) 
					FROM loans l
					WHERE l.returned_date IS NULL
					AND l.member_id = m.id
				) active_loans
				FROM members m
				LEFT JOIN 
				membership_types mt
				ON mt.id = m.membership_type_id
				WHERE m.name LIKE '%' + @searchTerm + '%'
				ORDER BY m.name;
			END
	END

GO
CREATE PROCEDURE GetMemberLoans
@id int
AS
BEGIN
	SELECT l.id, b.title book, bc.copy_number, b.isbn, l.issued_date, lt.type, l.returned_date, DATEADD(DAY, lt.max_duration, l.issued_date ) as 'due_date'

			FROM books b

			INNER JOIN book_copies bc
			ON bc.id = b.id

			INNER JOIN loans l 
			ON l.book_copy_id = bc.id

			INNER JOIN members m
			ON m.id = l.member_id

			INNER JOIN loan_types lt
			ON lt.id = l.loan_type_id

			WHERE 
			( 
				l.issued_date < CURRENT_TIMESTAMP-31---before 31 days
				OR l.returned_date IS NULL
				AND m.id = @id
			)
END

GO
CREATE PROCEDURE GetCopyLoans
@id int
AS
	BEGIN
		SELECT b.title book, b.isbn, m.name borrower, l.issued_date,  l.returned_date, DATEADD(DAY, lt.max_duration, l.issued_date) as "due_date"
		FROM book_copies bc

		JOIN books b
		ON b.id = bc.book_id

		JOIN loans l
		ON l.book_copy_id = bc.id

		JOIN loan_types lt
		ON lt.id = l.loan_type_id

		JOIN members m
		ON m.id = l.member_id

		WHERE bc.id = @id

		ORDER BY issued_date DESC

	END


GO
CREATE PROCEDURE GetOldBooks
AS
	BEGIN
		SELECT b.title, bc.purchased_date, bc.location, bc.copy_number
		FROM book_copies bc

		JOIN books b
		ON b.id = bc.book_id


		WHERE bc.purchased_date < CURRENT_TIMESTAMP-365
		AND bc.id NOT IN 
		(
			SELECT book_copy_id FROM LOANS WHERE returned_date IS NULL
		)
	END

GO

CREATE PROCEDURE GetInactiveMembers
AS
	BEGIN
		SELECT m.id, m.name, m.address, m.email, m.phone, b.title book, l.issued_date from members m

		LEFT JOIN --------------- to get only one entry for 1 user
		(
			SELECT MAX(issued_date) as issued_date, member_id, book_copy_id 
			FROM loans 
			GROUP BY member_id, book_copy_id
		) l
		ON l.member_id = m.id
		LEFT JOIN book_copies bc
		ON bc.id = l.book_copy_id

		LEFT JOIN books b
		ON b.id = bc.book_id

		WHERE 
		(
			SELECT MAX(issued_date) 
			FROM loans 
			WHERE member_id = m.id
		) < CURRENT_TIMESTAMP-31
		OR
		(
			SELECT 
			MAX(issued_date) 
			FROM loans 
			WHERE member_id = m.id
		) IS NULL

	END

GO
CREATE PROCEDURE GetInactiveBooks 
AS
	BEGIN
		SELECT b.id, b.title, b.isbn, a.name author, p.name publisher, b.published_date, b.edition, 
		(
			SELECT count(*) from book_copies bc where bc.book_id = b.id
		) quantity

		FROM books b

		LEFT JOIN author_book ab
		ON ab.book_id = b.id

		LEFT JOIN authors a
		ON a.id = ab.author_id

		JOIN publishers p
		ON p.id = b.publisher_id

		WHERE 
		(
			SELECT MAX(issued_date) from loans l inner join book_copies bc on bc.id = l.book_copy_id WHERE book_id=b.id
		) < CURRENT_TIMESTAMP-31
		OR
		(
			SELECT MAX(issued_date) from loans l inner join book_copies bc on bc.id = l.book_copy_id WHERE book_id=b.id
		) IS NULL

	END
GO
CREATE PROCEDURE GetActiveLoans
AS
	BEGIN
		SELECT l.id, b.title book, b.isbn, bc.copy_number, l.issued_date, DATEADD(DAY, lt.max_duration, l.issued_date) as due_date, l.returned_date, lt.type
		FROM book_copies bc

		JOIN books b
		ON b.id = bc.book_id

		JOIN loans l
		ON l.book_copy_id = bc.id

		JOIN loan_types lt
		ON l.loan_type_id = lt.id

		ORDER BY l.issued_date
	END

	