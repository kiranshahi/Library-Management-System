using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using Microsoft.Ajax.Utilities;
using System.Collections.Generic;
using System.Data;

namespace Library_Management_System_AD
{
    public class Loan
    {
        public int Id { get; set; }
        public string Book { get; set; }
        public int CopyNumber { get; set; }
        public string Isbn { get; set; }
        public string IssuedDate { get; set; }
        public string ReturnedDate { get; set; }
        public string DueDate { get; set; }
        public string LoanType { get; set; }

    
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

        public static List<Loan> GetMemberLoans(int memberId)
        {

            List<Loan> loans = new List<Loan>();
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("GetMemberLoans", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", memberId));

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        loans.Add(Loan.CreateFromReader(reader));
                    }
                }
            }
            return loans;
        }

        private static Loan CreateFromReader(SqlDataReader reader)
        {
            Loan loan = new Loan();
            loan.Id = Convert.ToInt32(reader["id"].ToString());
            loan.CopyNumber = Convert.ToInt32(reader["copy_number"].ToString());
            loan.Book = reader["book"].ToString();
            loan.Isbn = reader["isbn"].ToString();
            loan.IssuedDate = Convert.ToDateTime(reader["issued_date"].ToString()).ToShortDateString();
            loan.DueDate = Convert.ToDateTime(reader["due_date"].ToString()).ToShortDateString();
            loan.ReturnedDate = DBNull.Value.Equals(reader["returned_date"])
                ? null : Convert.ToDateTime(reader["returned_date"]).ToShortDateString();
            ;
            loan.LoanType = reader["type"].ToString();
            return loan;
        }

        public static bool existsForCopy (int copyNumber) 
        {
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT id from book_copies where copy_number = @copyNumber", con);

               cmd.Parameters.Add(new SqlParameter("@copyNumber", copyNumber));

                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        con.Close();
                        return true;
                    }
                    con.Close();
                    return false;
                }
            }
        }


        public static List<Loan> GetActiveLoans()
        {

            List<Loan> loans = new List<Loan>();
            using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("GetActiveLoans", con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        loans.Add(Loan.CreateFromReader(reader));
                    }
                }
                con.Close();
            }
            return loans;
        }
    }
}