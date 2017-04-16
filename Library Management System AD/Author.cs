﻿using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Library_Management_System_AD
{
    public class Author
    {
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