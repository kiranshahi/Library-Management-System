using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Library_Management_System_AD
{
    public class User
    {
        public int CreateUser(string name, string username, string email, string phone, string password, string role, DateTime registeredDate)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
            string sql = "insert into users values(@a,@b,@c,@d,@e,@f,@g)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@a", name);
            cmd.Parameters.AddWithValue("@b", username);
            cmd.Parameters.AddWithValue("@c", email);

            cmd.Parameters.AddWithValue("@d", phone);
            cmd.Parameters.AddWithValue("@e", password);
            cmd.Parameters.AddWithValue("@f", role);
            cmd.Parameters.AddWithValue("@g", registeredDate);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }
        public DataTable CheckUserLogin(string username, string password)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
            string sql = "select *from users where username=@username and password=@password";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public bool UsernameCheck(string username, string email)
        {
            bool isUserExisted = false;
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
            string sql = "select username, email from users where username=@username or email=@email";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@email", email);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.HasRows == true)
                {
                    isUserExisted = true;
                    break;
                }
            }
            return isUserExisted;
        }

        public int ResetPassword(string email,string password)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
            string sql = "UPDATE users SET password=@pass WHERE email=@email;";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pass", password);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int UpdateUserDetails(string username, string name, string email, string mobile, string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
                string sql = "UPDATE users SET name=@name, email=@email, phone=@mobile WHERE username=@username;";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@mobile", mobile);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
            else
            {
                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
                string sql = "UPDATE users SET name=@name, email=@email, phone=@mobile, password=@pass WHERE username=@username;";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@pass", password);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
        }
    }
}