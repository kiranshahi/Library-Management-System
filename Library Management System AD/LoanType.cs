using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Library_Management_System_AD
{
    public class LoanType
    {
        public int AddLoanType(String type, Int32 maxDuration)
        {
            SqlConnection connStr = new SqlConnection(WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
            string sql = "insert into loan_types values(@a,@b)";
            SqlCommand cmd = new SqlCommand(sql, connStr);
            cmd.Parameters.AddWithValue("@a", type);
            cmd.Parameters.AddWithValue("@b", maxDuration);

            connStr.Open();
            int i = cmd.ExecuteNonQuery();
            connStr.Close();
            return i;
        }
    }
}