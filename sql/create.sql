CREATE DATABASE library_management_system;


USE library_management_system;



CREATE TABLE authors (
  id int NOT NULL IDENTITY(1,1),
  name varchar(255) NOT NULL,
  location varchar(255)  DEFAULT NULL
);



CREATE TABLE author_book (
  id int NOT NULL IDENTITY(1,1),
  author_id int NOT NULL,
  book_id int NOT NULL
);



CREATE TABLE books (
  id int NOT NULL IDENTITY(1,1),
  title varchar(255)  NOT NULL,
  overview varchar(255)  DEFAULT NULL,
  isbn varchar(255)  NOT NULL,
  publisher_id int NOT NULL,
  published_date date DEFAULT NULL,
  edition int NOT NULL,
  age_restricted BIT DEFAULT 0
);



CREATE TABLE book_copies (
  id int NOT NULL IDENTITY(1,1),
  copy_number int NOT NULL,
  book_id int NOT NULL,
  purchased_date date NOT NULL,
  location varchar(255)  NOT NULL,
  deleted bit DEFAULT NULL
);



CREATE TABLE loans (
  id int NOT NULL IDENTITY(1,1),
  loan_type_id int NOT NULL,
  book_copy_id int NOT NULL,
  member_id int NOT NULL,
  user_id int NOT NULL,
  issued_date date NOT NULL,
  returned_date date DEFAULT NULL,
);



CREATE TABLE loan_types (
  id int NOT NULL IDENTITY(1,1),
  type varchar(255)  NOT NULL,
  max_duration int NOT NULL
);



CREATE TABLE members (
  id int NOT NULL IDENTITY(1,1),
  name varchar(255)  NOT NULL,
  address varchar(255)  NOT NULL,
  email varchar(255)  DEFAULT NULL,
  phone varchar(255)  NOT NULL,
  membership_type_id int NOT NULL,
  joined_date date NOT NULL
);



CREATE TABLE membership_types (
  id int NOT NULL IDENTITY(1,1),
  type varchar(255)  NOT NULL,
  books_allowed int NOT NULL,
  penalty_charge int  NOT NULL
);




CREATE TABLE publishers (
  id int NOT NULL IDENTITY(1,1),
  name varchar(255)  NOT NULL,
  location varchar(255)  NOT NULL
);



CREATE TABLE users (
  id int NOT NULL IDENTITY(1,1),
  name varchar(255)  NOT NULL,
  username varchar(255) NOT NULL,
  email varchar(255)  DEFAULT NULL,
  phone varchar(255)  NOT NULL,
  password varchar(255)  NOT NULL,
  role varchar(255)  NOT NULL,
  registered_date date NOT NULL
);


CREATE TABLE logs (
  id int IDENTITY(1,1),
  user_id int,
  action int,
  table_name varchar(255),
  row_identity int,
  description text,
  action_date date
);



ALTER TABLE authors
  ADD CONSTRAINT authors_pk PRIMARY KEY (id);


ALTER TABLE author_book
  ADD CONSTRAINT author_book_pk PRIMARY KEY (author_id, book_id);

ALTER TABLE books
  ADD CONSTRAINT books_pk PRIMARY KEY (id),
      CONSTRAINT books_isbn_unique UNIQUE (isbn);

ALTER TABLE book_copies
  ADD CONSTRAINT book_copies_pk PRIMARY KEY (id);

ALTER TABLE loans
  ADD CONSTRAINT loans_pk PRIMARY KEY (id);

ALTER TABLE loan_types
  ADD CONSTRAINT loan_types_pk PRIMARY KEY (id);

ALTER TABLE members
  ADD CONSTRAINT members_pk PRIMARY KEY (id);

ALTER TABLE membership_types
  ADD CONSTRAINT membership_types_pk PRIMARY KEY (id);


ALTER TABLE publishers
  ADD CONSTRAINT publishers_pk PRIMARY KEY (id);

ALTER TABLE users
  ADD CONSTRAINT users_pk PRIMARY KEY (id);

ALTER TABLE logs 
  ADD CONSTRAINT logs_pk PRIMARY KEY (id);



ALTER TABLE author_book
  ADD CONSTRAINT author_book_author_id_foreign FOREIGN KEY (author_id) REFERENCES authors (id),
      CONSTRAINT author_book_book_id_foreign FOREIGN KEY (book_id) REFERENCES books (id);

ALTER TABLE books
  ADD CONSTRAINT books_publisher_id_foreign FOREIGN KEY (publisher_id) REFERENCES publishers (id);

ALTER TABLE book_copies
  ADD CONSTRAINT book_copies_book_id_foreign FOREIGN KEY (book_id) REFERENCES books (id);

ALTER TABLE loans
  ADD CONSTRAINT loan_book_copy_id_foreign FOREIGN KEY (book_copy_id) REFERENCES book_copies (id),
      CONSTRAINT loan_loan_type_id_foreign FOREIGN KEY (loan_type_id) REFERENCES loan_types (id),
      CONSTRAINT loan_member_id_foreign FOREIGN KEY (member_id) REFERENCES members (id),
      CONSTRAINT loan_user_id_foreign FOREIGN KEY (user_id) REFERENCES users (id);

ALTER TABLE members
  ADD CONSTRAINT members_membership_type_id_foreign FOREIGN KEY (membership_type_id) REFERENCES membership_types (id);

  
ALTER TABLE logs 
  ADD CONSTRAINT logs_user_id_foreign FOREIGN KEY (user_id) REFERENCES users (id);

ALTER TABLE book_copies
  ADD CONSTRAINT copy_no_unique UNIQUE (copy_number);