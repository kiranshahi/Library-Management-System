using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD.Admin
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// @class  BookCopyLoans
    ///
    /// @brief  Book copy displayer
    ///
    /// @date   21/04/2017
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class BookCopyLoans : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null)
            {
                Response.Redirect("~/Login");
            }
            if (!IsPostBack) 
            {
                this.info.Text = "Select Copy Number to display loans for."; 
            }
            lblUserName.Text = Session["name"].ToString();
            lblUserName1.Text = Session["name"].ToString();
            try
            {
                this.populateTable();
            }
            catch (Exception ex)
            {
                this.info.CssClass = "text-danger";
                if (ex is SqlException || ex is IndexOutOfRangeException)
                {
                    this.info.Text = "Database Error Occurred";
                    return;
                }
                if (ex is Win32Exception)
                {
                    this.info.Text = "Database is not installed or not started.";
                    return;
                }
                throw;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn private void populateTable ()
        ///
        /// @brief  Populate display table with data
        ///
        /// @date   21/04/2017
        ///
        /// @exception  FormatException Thrown when the format of the copyNumber provided is incorrect.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void populateTable () 
        {
            if (!IsPostBack) return;
            
            int copyNumber;
            try 
            {
                copyNumber = Convert.ToInt16(this.copyNumber.Text);
                if(copyNumber == 0) throw new FormatException();
            }
            catch (FormatException)
            {
                this.info.Text = "Invalid Copy Number provided";
                if (!this.info.CssClass.Contains("text-danger"))
                {
                    this.info.CssClass += " text-danger";
                }
                return;
            }
            this.bookId.InnerText = "for Copy Number: " + copyNumber.ToString();
            if (!BookCopy.exists(copyNumber))
            {
                this.info.Text = "Given Copy Number does not exist";
                if (!this.info.CssClass.Contains("text-danger"))
                {
                    this.info.CssClass += " text-danger";
                }
                return;
            }
            if (!Loan.existsForCopy(copyNumber))
            {
                this.info.Text = "No Loans For Copy";
                if (!this.info.CssClass.Contains("text-danger"))
                {
                    this.info.CssClass += " text-danger";
                }
            }
            List<CopyLoan> loans = CopyLoan.GetLoans(copyNumber);

            if (loans.Count == 0)
            {
                this.info.Text = "No Loans for specified copy";
                if (!this.info.CssClass.Contains("text-danger"))
                {
                    this.info.CssClass += " text-danger";
                }
            }
            else
            {
                this.info.Text = this.info.Text.Replace("text-danger", "");
                this.info.Text = "Total records displayed: " + loans.Count.ToString();
            }
            this.LoanLister.DataSource = loans;
            this.LoanLister.DataBind();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @class  CopyLoan
        ///
        /// @brief  A loan for a particular book copy
        ///
        /// @date   21/04/2017
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class CopyLoan 
        {
            public string Book { get; set; }
            public string Isbn { get; set; }
            public string Borrower { get; set; }
            public string IssuedDate { get; set; }
            public string ReturnedDate { get; set; }
            public string DueDate { get; set; }

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                /// @fn public static List<CopyLoan> GetLoans(int copyId)
                ///
                /// @brief  Gets the loans of given book copy
                ///
                /// @date   21/04/2017
                ///
                /// @param  copyId  Identifier for the copy
                ///
                /// @return The loans.
                ////////////////////////////////////////////////////////////////////////////////////////////////////

                public static List<CopyLoan> GetLoans(int copyId)
                {

                    List<CopyLoan> loans = new List<CopyLoan>();
                    using (SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString))
                    {
                        SqlCommand cmd = new SqlCommand("GetCopyLoans", con);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@id", copyId));

                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                loans.Add(CopyLoan.CreateFromReader(reader));
                            }
                        }
                    }
                    return loans;
                }

                ////////////////////////////////////////////////////////////////////////////////////////////////////
                /// @fn private static CopyLoan CreateFromReader(SqlDataReader reader)
                ///
                /// @brief  Creates and instance of CopyLoan from given sql reader
                ///
                /// @date   21/04/2017
                ///
                /// @param  reader  SqlDataReader containing result of query
                ///
                /// @return The new from reader.
                ////////////////////////////////////////////////////////////////////////////////////////////////////

                private static CopyLoan CreateFromReader(SqlDataReader reader)
                {
                    CopyLoan loan = new CopyLoan();
                    loan.Book = reader["book"].ToString();
                    loan.Isbn = reader["isbn"].ToString();
                    loan.Borrower = reader["borrower"].ToString();
                    loan.IssuedDate = Convert.ToDateTime(reader["issued_date"].ToString()).ToShortDateString();
                    loan.DueDate = Convert.ToDateTime(reader["due_date"].ToString()).ToShortDateString();
                    loan.ReturnedDate = DBNull.Value.Equals(reader["returned_date"])
                        ? null : Convert.ToDateTime(reader["returned_date"]).ToShortDateString();
                    ;
                    return loan;
                }

        }
    }
}