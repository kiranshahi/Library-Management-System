using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Microsoft.Ajax.Utilities;

namespace Library_Management_System_AD
{
    public class Book
    {
        public int CreateBook(String title, String overview, String isbn, Int32 publisherId, String publishedDate, Int32 edition)
        {
            Boolean hasPd =false;
            DateTime pd;
            if (publishedDate.IsNullOrWhiteSpace())
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
    }
}