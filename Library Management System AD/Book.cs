using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;



namespace Library_Management_System_AD
{   
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Authors { get; set; }
        public string Publisher { get; set; }
        public string PublishedDate { get; set; }
        public int Edition { get; set; }
        public int Quantity { get; set; }


        public int CreateBook(String title, String overview, String isbn, Int32 publisherId, String publishedDate, Int32 edition)
        {
            Boolean hasPd =false;
            DateTime pd;
            if (String.IsNullOrEmpty(publishedDate))
            {
                hasPd = false;
            }
            else
            {
                hasPd = true;
            }

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
            string sql = "insert into books values(@a,@b, @c, @d, @e, @f)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@a", title);
            cmd.Parameters.AddWithValue("@b", overview);
            cmd.Parameters.AddWithValue("@c", isbn);
            cmd.Parameters.AddWithValue("@d", publisherId);
            if (hasPd)
            {
                pd = Convert.ToDateTime(publishedDate);
                cmd.Parameters.AddWithValue("@e", pd);

            }
            else
            {
                cmd.Parameters.AddWithValue("@e", DBNull.Value);

            }
            cmd.Parameters.AddWithValue("@f", edition);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public static List<Book> GetBooks(String searchBook, String searchAuthor, String searchPublisher)
        {
            List<Book> bookList = new List<Book>();

            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("GetBooks", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@book", searchBook));
                cmd.Parameters.Add(new SqlParameter("@author", searchAuthor));
                cmd.Parameters.Add(new SqlParameter("@publisher", searchPublisher));

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookList.Add(Book.CreateFromReader(reader));
                    }
                }
            }
            bookList = Book.concatAuthors(bookList);
            return bookList;
        }

        public static List<Book> GetAvailableBooks(String searchBook, String searchAuthor, String searchPublisher)
        {
            List<Book> bookList = new List<Book>();


            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAvailableBooks", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@book", searchBook));
                cmd.Parameters.Add(new SqlParameter("@author", searchAuthor));
                cmd.Parameters.Add(new SqlParameter("@publisher", searchPublisher));

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookList.Add(Book.CreateFromReader(reader));
                    }
                }
            }
            bookList = Book.concatAuthors(bookList);

            return bookList;
        }

        private static Book CreateFromReader(SqlDataReader reader)
        {
            Book book= new Book();
            book.Id = Convert.ToInt32(reader["id"].ToString());
            book.Title = reader["title"].ToString();
            book.Isbn = reader["isbn"].ToString();
            book.Publisher = reader["publisher"].ToString();
            book.PublishedDate = DBNull.Value.Equals(reader["published_date"])
                ? null : Convert.ToDateTime(reader["published_date"]).ToShortDateString();
                ;
            book.Edition = Convert.ToInt16(reader["edition"].ToString());
            book.Authors = reader["author"].ToString();
            book.Quantity = Convert.ToInt16(reader["quantity"].ToString());
            return book;
        }

        public static List<Book> concatAuthors(List<Book> bookList) 
        {
            if (bookList.Count == 0) return bookList;
            List<Book> newList = new List<Book>();
            newList.Add(bookList[0]);
            foreach (Book book in bookList)
	        {
                int count = newList.Count;
                for (int i=0; i<count; i++)
                {
                    Book mergedBook = newList[i];
                    if(book.Isbn == mergedBook.Isbn)
                    {
                        if(!mergedBook.Authors.Contains(book.Authors)) 
                        {
                            mergedBook.Authors += ", " + book.Authors;
                        }
                        break;
                    }
                    else if (i==count-1)
                    {
                        newList.Add(book);
                    }
                }
	        }
            return newList;
        }


        internal static List<Book> GetInactiveBook()
        {
            List<Book> bookList = new List<Book>();


            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("GetInactiveBooks", con);

                cmd.CommandType = CommandType.StoredProcedure;
              
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookList.Add(Book.CreateFromReader(reader));
                    }
                }
            }
            bookList = Book.concatAuthors(bookList);

            return bookList;
        }

        public int UpdateBook(Int32 bookid, String title, String overview, String isbn, Int32 publisher, String publishedDate, Int32 edition)
        {
            Boolean hasPd = false;
            DateTime pd;
            if (String.IsNullOrEmpty(publishedDate))
            {
                hasPd = false;
            }
            else
            {
                hasPd = true;
            }

            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
                string sql = "UPDATE users SET title=@title, overview=@overview, isbn=@isbn, publisher_id=@publisher, published_date=@pd, edition=@edition WHERE id=@bookid;";
                SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@bookid", bookid);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@overview", overview);
            cmd.Parameters.AddWithValue("@isbn", isbn);
            cmd.Parameters.AddWithValue("@publisher", publisher);
            if (hasPd)
            {
                pd = Convert.ToDateTime(publishedDate);
                cmd.Parameters.AddWithValue("@pd", pd);

            }
            else
            {
                cmd.Parameters.AddWithValue("@pd", DBNull.Value);

            }
            cmd.Parameters.AddWithValue("@edition", edition);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }


}