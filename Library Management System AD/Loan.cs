using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using Microsoft.Ajax.Utilities;

namespace Library_Management_System_AD
{
    public class Loan
    {
        public int AddToLoan(Int32 loanType, Int32 bookCopy, Int32 member, Int32 user, DateTime issuedDate, String returnDate)
        {
            Boolean hasReturnDate = false;
            DateTime returnDate1;
            if (returnDate.IsNullOrWhiteSpace())
            {
                hasReturnDate = false;
            }
            else
            {
                hasReturnDate = true;
            }
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
            string sql = "insert into loans values(@a,@b,@c,@d,@e,@f)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@a", loanType);
            cmd.Parameters.AddWithValue("@b", bookCopy);
            cmd.Parameters.AddWithValue("@c", member);
            cmd.Parameters.AddWithValue("@d", user);
            cmd.Parameters.AddWithValue("@e", issuedDate);
            if (hasReturnDate)
            {
                returnDate1 = Convert.ToDateTime(returnDate);
                cmd.Parameters.AddWithValue("@f", returnDate1);

            }
            else
            {
                cmd.Parameters.AddWithValue("@f", DBNull.Value);

            }

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}