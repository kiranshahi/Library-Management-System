using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD.Admin
{
    public partial class MembershipType : System.Web.UI.Page
    {
        MemberType newMemberType = new MemberType();
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

        protected void BtnAddMembershipType(object sender, EventArgs e)
        {
            try
            {
                newMemberType.AddMemberType(txtType.Text, Convert.ToInt32(txtBooksAllowed.Text), txtPenaltyCharge.Text);
                lblMessage.Text = "Member type added successfully.";
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