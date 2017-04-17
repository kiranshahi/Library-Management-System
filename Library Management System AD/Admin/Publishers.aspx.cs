using System;
using System.Drawing;

namespace Library_Management_System_AD.Admin
{
    public partial class Publishers : System.Web.UI.Page
    {
        Publisher newPublisher = new Publisher();
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

        protected void BtnAddPublisher(object sender, EventArgs e)
        {
            try
            {
                newPublisher.AddPublisher(txtFUllName.Text, txtAddress.Text);
                lblMessage.Text = "Publisher added successfully.";
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