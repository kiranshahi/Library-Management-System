﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Library_Management_System_AD
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// @class  Publisher
    ///
    /// @brief  A publisher.
    ///
    /// 
    /// @date   21/04/2017
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class Publisher
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn public int AddPublisher(string name, string location)
        ///
        /// @brief  Adds a publisher 
        ///
        ///
        /// @date   21/04/2017
        ///
        /// @param  name        The name.
        /// @param  location    The location.
        ///
        /// @return An int.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int AddPublisher(string name, string location)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
            string sql = "insert into publishers values(@a,@b)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@a", name);
            cmd.Parameters.AddWithValue("@b", location);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }
    }
}