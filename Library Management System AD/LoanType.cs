using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Library_Management_System_AD
{
    public class LoanType
    {
        public int ChargeFine(Int32 rate, Int32 loan)
        {
            SqlConnection connStr = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            string sql = "insert into fines values(@a,@b)";
            SqlCommand cmd = new SqlCommand(sql, connStr);
            cmd.Parameters.AddWithValue("@a", rate);
            cmd.Parameters.AddWithValue("@b", loan);

            connStr.Open();
            int i = cmd.ExecuteNonQuery();
            connStr.Close();
            return i;
        }
    }
}