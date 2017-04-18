using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Library_Management_System_AD
{
    public class Member
    {
        public int AddMember(String name, String email, String phone, Int32 memberType, DateTime joinedDate, String address)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
            string sql = "insert into members values(@a,@b, @c, @d, @e, @f)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@a", name);
            cmd.Parameters.AddWithValue("@b", email);
            cmd.Parameters.AddWithValue("@c", phone);
            cmd.Parameters.AddWithValue("@d", memberType);
            cmd.Parameters.AddWithValue("@e", joinedDate);
            cmd.Parameters.AddWithValue("@f", address);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}