using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD.Admin
{
    public partial class LoanTypes : System.Web.UI.Page
    {
        LoanType newLoanType = new LoanType();

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
        }

        protected void BtnAddLoanType(object sender, EventArgs e)
        {
            newLoanType.AddLoanType(txtType.Text, Convert.ToInt32(txtMaxDuration.Text));
            lblMessage.Text = "Loan type added successfully.";
            lblMessage.ForeColor = Color.Green;
            
        }
    }
}