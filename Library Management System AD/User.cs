using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Library_Management_System_AD
{
    public class User
    {
        public User()
        {
            
        }
        public int CreateUser(string name, string username, string email, string phone, string password, string role, DateTime joined_date)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CK5EETK;Initial Catalog=LMSdb;Integrated Security=True");
            string sql = "insert into users values(@a,@b,@c,@d,@e,@f,@g)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@a", name);
            cmd.Parameters.AddWithValue("@b", username);
            cmd.Parameters.AddWithValue("@c", email);

            cmd.Parameters.AddWithValue("@d", phone);
            cmd.Parameters.AddWithValue("@e", password);
            cmd.Parameters.AddWithValue("@f", role);
            cmd.Parameters.AddWithValue("@g", joined_date);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }
        public DataTable CheckUserLogin(string username, string password)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CK5EETK;Initial Catalog=LMSdb;Integrated Security=True");
            string sql = "select *from users where username=@username and password=@password";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}