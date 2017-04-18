using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD.Admin
{
    public partial class Loans : System.Web.UI.Page
    {
        Loan newLoan = new Loan();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] != null)
            {
                lblUserName.Text = Session["name"].ToString();
                lblUserName1.Text = Session["name"].ToString();
                if (!IsPostBack)
                {
                    string connectString =
                        WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
                    string LoanTypeQueryString = "select * from loan_types";

                    SqlConnection myConnection = new SqlConnection(connectString);
                    SqlDataAdapter loanTypeQueryCommand = new SqlDataAdapter(LoanTypeQueryString, myConnection);
                    DataSet loanTypeDs = new DataSet();
                    loanTypeQueryCommand.Fill(loanTypeDs, "loan_types");

                    loanType.DataSource = loanTypeDs;
                    loanType.DataTextField = "type";
                    loanType.DataValueField = "id";
                    loanType.DataBind();

                    /**
                     * bookCopy Query
                     */

                    string BookCopyQueryString = "select * from book_copies";
                    SqlDataAdapter bookCopyQueryCommand = new SqlDataAdapter(BookCopyQueryString, myConnection);
                    DataSet bookCopyDs = new DataSet();
                    bookCopyQueryCommand.Fill(bookCopyDs, "bookCopy");
                    bookCopy.DataSource = bookCopyDs;
                    bookCopy.DataTextField = "id";
                    bookCopy.DataValueField = "id";
                    bookCopy.DataBind();

                    string MemberQueryString = "select * from members";
                    SqlDataAdapter memberQueryCommand = new SqlDataAdapter(MemberQueryString, myConnection);
                    DataSet memberDs = new DataSet();
                    memberQueryCommand.Fill(memberDs, "member");
                    member.DataSource = memberDs;
                    member.DataTextField = "name";
                    member.DataValueField = "id";
                    member.DataBind();
                    
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void BtnAddLoan(object sender, EventArgs e)
        {
            try
            {
                newLoan.AddToLoan(Convert.ToInt32(loanType.Value), Convert.ToInt32(bookCopy.Value), Convert.ToInt32(member.Value), Convert.ToInt32(Session["userid"]), Convert.ToDateTime(txtIssuedDate.Text), txtReturnedDate.Text);
                lblMessage.Text = "Book has been added to loan successfully.";
                lblMessage.ForeColor = Color.Green;
            }
            catch (Exception exception)
            {
                lblMessage.Text = "Some error has occured. Error details :" + exception.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}