using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Library_Management_System_AD
{
    public class BookCopy
    {
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
    }
}