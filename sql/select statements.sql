


-------------------- QUESTION NO 1---------------------------
-----------NEED TO CONCAT AUTHOR NAMES IN THE PROGRAM
SELECT b.id, b.title, a.name, b.edition, b.isbn, b.published_date, p.name, (select COUNT(bc.id) FROM book_copies bc where bc.book_id = b.id) quantity
		FROM books b

		INNER JOIN publishers p
		ON b.publisher_id=p.id

		INNER JOIN author_book ab
		ON b.id = ab.book_id

		INNER JOIN 
		(
			SELECT name, id
			FROM authors
			--if author name is searched
			WHERE name LIKE '%SEARCH TERM%'
		) a 
		on ab.author_id = a.id
		WHERE 
		( 
			--if book name is searched
			(b.title LIKE '%SEARCH TERM%' OR b.isbn = 'SEARCH TERM')
			--if publisher is searched
			AND p.name LIKE '%SEARCH TERM%'
		)
		
		







-------------------- QUESTION NO 2---------------------------
-----------NEED TO FILETER available>0 in program---------
SELECT b.id, b.title, a.name, b.edition, b.isbn, b.published_date, p.name, 
	available = (
		SELECT COUNT(bc.id) - COUNT(l.id) as qty
		FROM book_copies bc
		LEFT JOIN loans l
		ON l.book_copy_id = bc.id
		AND l.returned_date = '2017-02-02'
		WHERE bc.book_id = b.id
	)


		FROM books b

		INNER JOIN publishers p
		ON b.publisher_id=p.id

		INNER JOIN author_book ab
		ON b.id = ab.book_id

		INNER JOIN 
		(
			SELECT name, id
			FROM authors
			--if author name is searched
			WHERE name LIKE '%%'
		) a 
		on ab.author_id = a.id
		WHERE 
		( 
			--if book name is searched
			(b.title LIKE '%%' OR b.isbn = '')
			--if publisher is searched
			AND p.name LIKE '%%'
		)

		

-------------------question no 3--------------------------
-----------NEED TO CONCAT AUTHOR NAMES IN THE PROGRAM
SELECT b.id, b.title, a.name, b.edition, b.isbn, b.published_date, p.name, l.issued_date, ISNULL(l.returned_date, 'Not Returned') as returned_date--------if null change it to NOT RETURNED

		FROM books b

		INNER JOIN publishers p
		ON b.publisher_id=p.id

		INNER JOIN author_book ab
		ON b.id = ab.book_id

		INNER JOIN 
		(
			SELECT name, id
			FROM authors
		) a 
		ON ab.author_id = a.id

		INNER JOIN book_copies bc
		ON bc.id = b.id

		INNER JOIN loans l 
		ON l.book_copy_id = bc.id

		INNER JOIN members m
		ON m.id = l.member_id

		WHERE 
		( 
			l.issued_date < CURRENT_TIMESTAMP-31---before 31 days
			AND  
			(
				m.id = 3
				OR m.name = 'safj'
			)
		)

		

-----------QUESTION NO 4	
-----------NEED TO CONCAT AUTHORS IN THE PROGRAM
SELECT b.id, b.title, a.name, b.edition, b.isbn, b.published_date, p.name
FROM books b

JOIN author_book ab
ON ab.book_id = b.id

JOIN authors a
ON a.id = ab.author_id

JOIN publishers p
ON p.id = b.publisher_id

ORDER BY b.published_date



--------------------------QUESTION NO 5---
----!!!!!!!!!!!!!!!!!!NOT COMPLETE !!!! SHOULD RETURN THE LAST ENTRY FOR GIVEN BOOK COPY ID
SELECT b.title, m.name, l.issued_date, ISNULL(l.returned_date, 'Not Returned') returned_date, DATEADD(DAY, lt.max_duration, l.issued_date) as "due_date"
FROM book_copies bc

JOIN books b
ON b.id = bc.book_id

JOIN loans l
ON l.book_copy_id = bc.id

JOIN loan_types lt
ON lt.id = l.loan_type_id

JOIN members m
ON m.id = l.member_id

WHERE bc.id = SEARCH ID










---------------QUESTION NO 8
SELECT m.name, m.email, m.phone, m.joined_date, mt.type, mt.books_allowed, mt.penalty_charge, 
(
	SELECT COUNT(l.id) 
	FROM loans l
	WHERE l.member_id = m.id
) 'total loans',
(
	SELECT COUNT(l.id) 
	FROM loans l
	WHERE l.returned_date IS NULL
	AND l.member_id = m.id
) 'active loans'
FROM members m

JOIN membership_types mt
ON m.membership_type_id = mt.id



-----------------QUESTION NO 10
SELECT b.title, bc.purchased_date, bc.location, bc.copy_number
FROM book_copies bc

JOIN books b
ON b.id = bc.book_id


WHERE bc.purchased_date < CURRENT_TIMESTAMP-365
AND bc.id NOT IN 
(
	SELECT book_copy_id FROM LOANS WHERE returned_date IS NULL
)





-----------------QUESTION NO 11
SELECT l.id, b.title book, b.isbn, bc.copy_number, l.issued_date, DATEADD(DAY, lt.max_duration, l.issued_date) as due_date
FROM book_copies bc

JOIN books b
ON b.id = bc.book_id

JOIN loans l
ON l.book_copy_id = bc.id

JOIN loan_types lt
ON l.loan_type_id = lt.id

ORDER BY l.issued_date




----------------QUESTION 12 --------old solution ---couldn't retrieve book and loan details

SELECT m.id, m.name, m.phone, 
(
	SELECT MAX(issued_date) FROM loans WHERE loans.member_id = m.id
) last_loaned_date
FROM members m
WHERE 
(
	SELECT MAX(issued_date) FROM loans WHERE loans.member_id = m.id
)
 < CURRENT_TIMESTAMP-31
OR
(
	SELECT MAX(issued_date) FROM loans WHERE loans.member_id = m.id
)
IS NULL



-----------------------question no 12  --------new solution
SELECT m.name, m.address, m.email, m.phone, b.title, l.issued_date from members m

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


-------------------QUESTION NO 13
SELECT b.title, b.isbn, a.name author, p.name publisher, b.published_date, b.edition, 
(
	SELECT count(*) from book_copies bc where bc.book_id = b.id
) total_books

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