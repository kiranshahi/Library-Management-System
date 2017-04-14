using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Library_Management_System_AD
{
    public class Author
    {
        public int CreateAuthor(String name, String address)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CK5EETK;Initial Catalog=LMSdb;Integrated Security=True");
            string sql = "insert into authors values(@a,@b)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@a", name);
            cmd.Parameters.AddWithValue("@b", address);
            
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}