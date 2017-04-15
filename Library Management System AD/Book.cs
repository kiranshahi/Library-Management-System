using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Library_Management_System_AD
{
    public class Book
    {
        public int CreateBook(String title, String overview, String isbn, Int32 publisherId, DateTime publishedDate, Int32 edition)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CK5EETK;Initial Catalog=LMSdb;Integrated Security=True");
            string sql = "insert into books values(@a,@b, @c, @d, @e, @f)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@a", title);
            cmd.Parameters.AddWithValue("@b", overview);
            cmd.Parameters.AddWithValue("@c", isbn);
            cmd.Parameters.AddWithValue("@d", publisherId);
            cmd.Parameters.AddWithValue("@e", publishedDate);
            cmd.Parameters.AddWithValue("@f", edition);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}