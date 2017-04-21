using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Library_Management_System_AD
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// @class  User
    ///
    /// @brief  An user.
    ///
    /// @date   21/04/2017
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string RegisteredDate { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn public int CreateUser(string name, string username, string email, string phone, string password, string role, DateTime registeredDate)
        ///
        /// @brief  Creates a user.
        ///
        /// @date   21/04/2017
        ///
        /// @param  name            The name.
        /// @param  username        The username.
        /// @param  email           The email.
        /// @param  phone           The phone.
        /// @param  password        The password.
        /// @param  role            The role.
        /// @param  registeredDate  The registered date.
        ///
        /// @return The new user.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn public DataTable CheckUserLogin(string username, string password)
        ///
        /// @brief  Checks user login.
        ///
        /// @author Sirjan
        /// @date   21/04/2017
        ///
        /// @param  username    The username.
        /// @param  password    The password.
        ///
        /// @return A DataTable.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn public bool UsernameCheck(string username, string email)
        ///
        /// @brief  Checks username
        ///
        /// @date   21/04/2017
        ///
        /// @param  username    The username.
        /// @param  email       The email.
        ///
        /// @return True if it succeeds, false if it fails.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn public int ResetPassword(string email,string password)
        ///
        /// @brief  Resets the password.
        ///
        /// @date   21/04/2017
        ///
        /// @param  email       The email.
        /// @param  password    The password.
        ///
        /// @return changed row number.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn public int UpdateUserDetails(int userid, string name, string email, string mobile, string password)
        ///
        /// @brief  Updates the user details.
        ///
        /// @date   21/04/2017
        ///
        /// @param  userid      The userid.
        /// @param  name        The name.
        /// @param  email       The email.
        /// @param  mobile      The mobile.
        /// @param  password    The password.
        ///
        /// @return An int.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int UpdateUserDetails(int userid, string name, string email, string mobile, string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
                string sql = "UPDATE users SET name=@name, email=@email, phone=@mobile WHERE id=@userid;";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@userid", userid);
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
                string sql = "UPDATE users SET name=@name, email=@email, phone=@mobile, password=@pass WHERE id=@userid;";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@pass", password);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn internal static List<User> GetUsers()
        ///
        /// @brief  Gets all users from the database.
        ///
        /// @date   21/04/2017
        ///
        /// @return The users.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        internal static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
            {
   
                string sql = "SELECT * FROM users";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(User.CreateFromReader(reader));
                    }
                }
                con.Close();
            }
            return users;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn private static User CreateFromReader(SqlDataReader reader)
        ///
        /// @brief  Creates new user instance from sql reader.
        ///
        /// @date   21/04/2017
        ///
        /// @param  reader  The reader.
        ///
        /// @return The new from reader.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static User CreateFromReader(SqlDataReader reader)
        {
            User user = new User();
            user.Id = Convert.ToInt32(reader["id"].ToString());
            user.Name = reader["name"].ToString();
            user.Email = DBNull.Value.Equals(reader["email"]) ?
                        null : reader["email"].ToString();
            user.Phone = reader["phone"].ToString();

            user.Id = Convert.ToInt32(reader["Id"].ToString());
            user.Username = reader["username"].ToString();
            user.RegisteredDate = Convert.ToDateTime(reader["registered_date"].ToString()).ToShortDateString();
            return user;
        }
    }
}