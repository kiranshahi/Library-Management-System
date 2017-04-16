using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Library_Management_System_AD
{
    public class BookCopy
    {
        public int CreateBookCopies(Int32 bookId, DateTime purchaseDate, String location)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
            string sql = "insert into book_copies values(@a,@b, @c)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@a", bookId);
            cmd.Parameters.AddWithValue("@b", purchaseDate);
            cmd.Parameters.AddWithValue("@c", location);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}