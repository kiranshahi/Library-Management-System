using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Library_Management_System_AD
{
    
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MemberType { get; set; }
        public string Address { get; set; }
        public int BooksAllowed { get; set; }
        public int TotalLoans { get; set; }
        public int ActiveLoans { get; set; }


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

        public static List<Member> GetMembers(string searchTerm) 
        {
            List<Member> memList = new List<Member>();
             using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
             {
                SqlCommand cmd = new SqlCommand("GetMembers", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@searchTerm", searchTerm));

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        memList.Add(Member.CreateFromReader(reader));
                    }
                }
            }
            return memList;
        }

        private static Member CreateFromReader(SqlDataReader reader)
        {
            Member member = new Member();
            member.Id = Convert.ToInt32(reader["id"].ToString());
            member.Name = reader["name"].ToString();
            member.Email = DBNull.Value.Equals(reader["email"]) ? 
                        null: reader["email"].ToString();
            member.Phone = reader["phone"].ToString();
            
            member.MemberType = reader["type"].ToString();
            member.Address = reader["address"].ToString();
            member.BooksAllowed = Convert.ToInt16(reader["books_allowed"].ToString());
            member.TotalLoans = Convert.ToInt16(reader["total_loans"].ToString());
            member.ActiveLoans = Convert.ToInt16(reader["active_loans"].ToString());
            return member;
        }

        public static List<InactiveMember> GetInactiveMembers()
        {
            List<InactiveMember> memList = new List<InactiveMember>();
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("GetInactiveMembers", con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        memList.Add(Member.CreateInactiveMemberFromReader(reader));
                    }
                }
            }
            return memList;
        }

        private static InactiveMember CreateInactiveMemberFromReader(SqlDataReader reader)
        {
            InactiveMember member = new InactiveMember();
            member.Id = Convert.ToInt16(reader["id"].ToString());
            member.Name = reader["name"].ToString();
            member.Email = DBNull.Value.Equals(reader["email"]) ?
                        null : reader["email"].ToString();
            member.Phone = reader["phone"].ToString();

            member.LastBorrowedBook = reader["book"].ToString();
            member.Address = reader["address"].ToString();
            member.LastBorrowedDate = DBNull.Value.Equals(reader["issued_date"])
                ? null : Convert.ToDateTime(reader["issued_date"]).ToShortDateString();
            ;
            return member;
        }

        public int UpdateMemberDetails(Int32 memberId, String name, String email, String mobile, String address)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString);
            string sql = "UPDATE members SET name=@name, email=@email, phone=@mobile, address=@address WHERE id=@memberId;";
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@memberId", memberId);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@mobile", mobile);
//            cmd.Parameters.AddWithValue("@membershipId", membershipType);
            cmd.Parameters.AddWithValue("@address", address);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;


        }
    }
}