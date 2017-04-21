using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Configuration;

namespace Library_Management_System_AD.Admin
{
    public partial class ReturnLoan : System.Web.UI.Page
    {
        Loan newLoan = new Loan();
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
                    string queryString = "SELECT loan_types.type, loan_types.max_duration, book_copies.copy_number, members.name, loans.issued_date, loans.returned_date, membership_types.penalty_charge FROM loans JOIN loan_types ON loan_types.id = loans.loan_type_id JOIN book_copies ON book_copies.id =loans.book_copy_id JOIN members ON members.id =loans.member_id JOIN membership_types on members.membership_type_id = membership_types.id where loans.id =' " + loanId + " ' ";

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
                        DateTime issueDate = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd }", myReader["issued_date"]));
                        Int32 maxDuration = Convert.ToInt32(myReader["max_duration"].ToString());
                        DateTime dueDate = issueDate.AddDays(maxDuration);
                        txtDueDate.Text = String.Format("{0:yyyy-MM-dd }", dueDate);
                        Int32 fineAmount = 0;
                        Int32 fineRate = Convert.ToInt32(myReader["penalty_charge"].ToString());
                        DateTime today = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                        if (!String.IsNullOrWhiteSpace(myReader["returned_date"].ToString()))
                        {
                            DateTime returnedDate = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd }", myReader["returned_date"]));
                            txtReturnedDate.Text = String.Format("{0:yyyy-MM-dd }", myReader["returned_date"]);
                            txtReturnedDate.Attributes.Add("readonly", "readonly");
                            if (dueDate < returnedDate)
                            {
                                TimeSpan exceedTimeSpan = returnedDate - dueDate;
                                Int32 exceedDays = Convert.ToInt32(exceedTimeSpan.TotalDays);
                                fineAmount = exceedDays * fineRate;
                                txtFineAmount.Text = "Rs. "+fineAmount.ToString();
                            }
                        } else if (today > dueDate)
                        {
                            TimeSpan exceedTimeSpan = today - dueDate;
                            Int32 exceedDays = Convert.ToInt32(exceedTimeSpan.TotalDays);
                            fineAmount = exceedDays * fineRate;
                            txtFineAmount.Text = "Rs. " + fineAmount.ToString();
                        }
                    }
                    myReader.Close();

                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

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