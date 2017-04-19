-------------------QUESTION NO 1---------------------
CREATE PROCEDURE GetBooks
@book varchar(20),
@author varchar(20),
@publisher varchar(20)
AS
	BEGIN 
		SELECT b.title title, a.name author, b.edition edition, b.isbn isbn, b.published_date published_date, p.name publisher, (select COUNT(bc.id) FROM book_copies bc where bc.book_id = b.id) quantity
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
		)
		
		ORDER BY b.published_date

	END
GO


-------------------QUESTION NO 2---------------------
CREATE PROCEDURE GetAvailableBooks
@book varchar(20),
@author varchar(20),
@publisher varchar(20)
AS
	BEGIN 
		SELECT b.title title, a.name author, b.edition edition, b.isbn isbn, b.published_date published_date, p.name publisher, 
		available_quantity = 
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