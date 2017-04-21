using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Library_Management_System_AD
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// @class  MemberType
    ///
    /// @brief  A member type.
    ///
    /// @date   21/04/2017
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class MemberType
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn public int AddMemberType(String type, Int32 booksAllowed, Int32 penaltyCharge)
        ///
        /// @brief  Adds a member type.
        ///
        /// @date   21/04/2017
        ///
        /// @param  type            The type.
        /// @param  booksAllowed    The books allowed.
        /// @param  penaltyCharge   The penalty charge.
        ///
        /// @return An int.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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