﻿using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Library_Management_System_AD
{
    public class Fine
    {
        public int ChargeFine(Int32 rate, Int32 loan)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
            string sql = "insert into fines values(@a,@b)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@a", rate);
            cmd.Parameters.AddWithValue("@b", loan);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}