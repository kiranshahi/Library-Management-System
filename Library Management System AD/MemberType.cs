using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Library_Management_System_AD
{
    public class MemberType
    {
        public int AddMemberType(String type, Int32 booksAllowed, Int32 penaltyCharge)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
            string sql = "insert into membership_types values(@a,@b, @c)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@a", type);
            cmd.Parameters.AddWithValue("@b", booksAllowed);
            cmd.Parameters.AddWithValue("@c", penaltyCharge);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}