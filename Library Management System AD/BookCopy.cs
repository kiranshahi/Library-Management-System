using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Library_Management_System_AD
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// @class  BookCopy
    ///
    /// @brief  A book copy.
    ///
    /// @date   21/04/2017
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class BookCopy
    {
        public int CopyNumber { get; set; }
        public string Title { get; set; }
        public string PurchasedDate { get; set; }
        public string Location { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn public int CreateBookCopies( Int32 copyNo, Int32 bookId, DateTime purchaseDate, String location)
        ///
        /// @brief  Creates book copies.
        ///
        /// @date   21/04/2017
        ///
        /// @param  copyNo          The copy no.
        /// @param  bookId          Identifier for the book.
        /// @param  purchaseDate    The purchase date.
        /// @param  location        The location.
        ///
        /// @return The new book copies.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int CreateBookCopies( Int32 copyNo, Int32 bookId, DateTime purchaseDate, String location)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
            string sql = "insert into book_copies values(@a,@b, @c, @d)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@a", copyNo);
            cmd.Parameters.AddWithValue("@b", bookId);
            cmd.Parameters.AddWithValue("@c", purchaseDate);
            cmd.Parameters.AddWithValue("@d", location);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn public static bool exists(int copyNumber)
        ///
        /// @brief  Determine if 'copyNumber' exists.
        ///
        /// @date   21/04/2017
        ///
        /// @param  copyNumber  The copy number.
        ///
        /// @return True if it succeeds, false if it fails.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool exists(int copyNumber)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
            string sql = "select * from book_copies where copy_number = @cn";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@cn", copyNumber);
            con.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    return true;
                }
                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn public static List<BookCopy> GetOldCopies()
        ///
        /// @brief  Gets old copies.
        ///         -- copies older than 1 year.
        ///
        /// @date   21/04/2017
        ///
        /// @return The old copies.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static List<BookCopy> GetOldCopies()
        {
            List<BookCopy> books = new List<BookCopy>();
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("GetOldBooks", con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(BookCopy.CreateFromReader(reader));
                    }
                }
                con.Close();
            }
            return books;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn private static BookCopy CreateFromReader(SqlDataReader reader)
        ///
        /// @brief  Creates from sql data reader
        ///
        /// @date   21/04/2017
        ///
        /// @param  reader  The reader with data from database.
        ///
        /// @return The new from reader.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static BookCopy CreateFromReader(SqlDataReader reader)
        {
            BookCopy member = new BookCopy();
            member.CopyNumber = Convert.ToInt32(reader["copy_number"].ToString());
            member.Title = reader["title"].ToString();
            member.PurchasedDate = Convert.ToDateTime(reader["purchased_date"].ToString()).ToShortDateString();

            member.Location = reader["location"].ToString();
            return member;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn internal static int DeleteOldCopies()
        ///
        /// @brief  Deletes all old copies 
        ///          - copies older than 1 years.
        ///
        /// @date   21/04/2017
        ///
        /// @return An int.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        internal static int DeleteOldCopies()
        {
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
            {
                string sql = "UPDATE book_copies SET deleted = 1 WHERE purchased_date < CURRENT_TIMESTAMP-365 AND deleted IS NULL";
                SqlCommand cmd = new SqlCommand("DeleteOldCopies", con);
                cmd.CommandType = CommandType.StoredProcedure;


                con.Open();

                int affectedRows = cmd.ExecuteNonQuery();
                
                con.Close();

                return affectedRows;
            }
        }
    }
}