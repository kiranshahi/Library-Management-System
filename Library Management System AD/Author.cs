using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Library_Management_System_AD
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// @class  Author
    ///
    /// @brief  An author.
    ///
    /// @date   21/04/2017
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class Author
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn public int CreateAuthor(String name, String address)
        ///
        /// @brief  Creates an author.
        ///
        /// @date   21/04/2017
        ///
        /// @param  name    The name of author
        /// @param  address The address of author
        ///
        /// @return The new author.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int CreateAuthor(String name, String address)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
            string sql = "insert into authors values(@a,@b)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@a", name);
            cmd.Parameters.AddWithValue("@b", address);
            
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn public bool CheckAuthor(string name)
        ///
        /// @brief  Check author int the db from the name given
        ///
        /// 
        /// @date   21/04/2017
        ///
        /// @param  name    The name.
        ///
        /// @return True if it succeeds, false if it fails.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool CheckAuthor(string name)
        {
            bool isAuthorExisted = false;
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
            string sql = "select name from authors where name=@name";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name", name);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr.HasRows == true)
                {
                    isAuthorExisted = true;
                    break;
                }
            }
            return isAuthorExisted;
        }
    }
}