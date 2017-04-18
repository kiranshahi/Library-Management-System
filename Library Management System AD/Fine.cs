using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Library_Management_System_AD
{
    public class Fine
    {
        public int ChargeFine(Int32 rate, Int32 days, Int32 loan)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
            string sql = "insert into fines values(@a,@b,@c)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@a", rate);
            cmd.Parameters.AddWithValue("@b", loan);
            cmd.Parameters.AddWithValue("@c", days);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}