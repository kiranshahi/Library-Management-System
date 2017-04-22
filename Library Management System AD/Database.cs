using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Library_Management_System_AD
{
    public class Database
    {
        public SqlConnection Connection { get; set; }
        public string Query {get; set;}
        public SqlCommand Cmd {get;set;}

        public Database(string query)
        {
            this.Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
            this.Query = query;
            this.Cmd = new SqlCommand(this.Query, this.Connection);
        }

        public List<SqlDataReader> ExecuteQuery () 
        {
            List<SqlDataReader> dataList = new List<SqlDataReader>();

            this.Connection.Open();
            using (SqlDataReader reader = this.Cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    dataList.Add(reader);
                }
            }
            this.Connection.Close();
            return dataList;
        }

        public void AddParameter(string name, object value)
        {
            this.Cmd.Parameters.Add(new SqlParameter(name, value));
        }

        public int ExecuteNonQuery()
        {
            this.Connection.Open();
            int exec = this.Cmd.ExecuteNonQuery();
            this.Connection.Close();
            return exec;
        }
    }


}