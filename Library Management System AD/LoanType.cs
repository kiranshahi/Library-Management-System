using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Library_Management_System_AD
{
    public class LoanType
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn public int AddLoanType(String type, Int32 maxDuration)
        ///
        /// @brief  Adds a loan type to database.
        ///
        /// @date   21/04/2017
        ///
        /// @param  type        The type.
        /// @param  maxDuration The maximum duration.
        ///
        /// @return An int.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int AddLoanType(String type, Int32 maxDuration)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
            string sql = "insert into loan_types values(@a,@b)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@a", type);
            cmd.Parameters.AddWithValue("@b", maxDuration);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}