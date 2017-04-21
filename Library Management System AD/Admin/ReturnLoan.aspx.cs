using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Configuration;

namespace Library_Management_System_AD.Admin
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// @class  ReturnLoan
    ///
    /// @brief  A return loan.
    ///
    /// @author Sirjan
    /// @date   21/04/2017
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class ReturnLoan : System.Web.UI.Page
    {
        Loan newLoan = new Loan();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn protected void Page_Load(object sender, EventArgs e)
        ///
        /// @brief  Event handler. Called by Page for load events.
        ///
        /// @author Sirjan
        /// @date   21/04/2017
        ///
        /// @param  sender  Source of the event.
        /// @param  e       Event information.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] != null)
            {
                lblUserName.Text = Session["name"].ToString();
                lblUserName1.Text = Session["name"].ToString();

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    string loanId = Request.QueryString["id"];

                    string connectString =
                        WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
                    string queryString = "SELECT loan_types.type, book_copies.copy_number, members.name, loans.issued_date FROM loans JOIN loan_types ON loan_types.id = loans.loan_type_id JOIN book_copies ON book_copies.id =loans.book_copy_id JOIN members ON members.id =loans.member_id where loans.id =' " + loanId + " ' ";

                    SqlConnection myConnection = new SqlConnection(connectString);
                    myConnection.Open();
                    SqlCommand myCommand = new SqlCommand(queryString, myConnection);
                    SqlDataReader myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        this.loanId.Value = loanId;
                        loanType.Text = (myReader["type"].ToString());
                        bookCopy.Text = (myReader["copy_number"].ToString());
                        member.Text = (myReader["name"].ToString());
                        txtIssuedDate.Text = String.Format("{0:yyyy-MM-dd }", myReader["issued_date"]);
                    }
                    myReader.Close();

                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn protected void BtnReturnLoan(object sender, EventArgs e)
        ///
        /// @brief  Button return loan.
        ///
        /// @author Sirjan
        /// @date   21/04/2017
        ///
        /// @param  sender  Source of the event.
        /// @param  e       Event information.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void BtnReturnLoan(object sender, EventArgs e)
        {
            try
            {
                newLoan.ReturnTheBook(Convert.ToInt32(loanId.Value), Convert.ToDateTime(txtReturnedDate.Text));
                lblMessage.Text = "Book has been returned.";
                lblMessage.ForeColor = Color.Green;
            }
            catch (Exception exception)
            {
                lblMessage.Text = exception.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}