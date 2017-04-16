using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Library_Management_System_AD
{
    public class Loan
    {
        public int AddToLoan(Int32 loanType, Int32 bookCopy, Int32 member, Int32 user, DateTime issuedDate, DateTime returnDate, String location)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CK5EETK;Initial Catalog=LMSdb;Integrated Security=True");
            string sql = "insert into loans values(@a,@b,@c,@d,@e,@f,@g)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@a", loanType);
            cmd.Parameters.AddWithValue("@b", bookCopy);
            cmd.Parameters.AddWithValue("@c", member);
            cmd.Parameters.AddWithValue("@d", user);
            cmd.Parameters.AddWithValue("@e", issuedDate);
            cmd.Parameters.AddWithValue("@f", returnDate);
            cmd.Parameters.AddWithValue("@g", location);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}