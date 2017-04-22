using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] != null)
            {
                lblUserName.Text = Session["name"].ToString();
                lblUserName1.Text = Session["name"].ToString();
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
            try
            {
                this.AddValues();
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

        private void AddValues()
        {
            this.memberCount.InnerText = Member.GetMembers("").Count.ToString();
            this.activeLoanCount.InnerText = Loan.GetActiveLoans().Count.ToString();
            this.loanCount.InnerText = Loan.GetLoansCount().ToString();
            this.bookCount.InnerText = BookCopy.GetCopiesCount().ToString();
        }
    }
}