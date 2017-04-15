using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Library_Management_System_AD
{
    public class BookCopy
    {
        public int CreateBookCopies(Int32 bookId, DateTime purchaseDate, String location)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CK5EETK;Initial Catalog=LMSdb;Integrated Security=True");
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