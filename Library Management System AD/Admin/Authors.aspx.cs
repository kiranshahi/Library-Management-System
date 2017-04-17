using System;
using System.Drawing;

namespace Library_Management_System_AD.Admin
{
    public partial class Authors : System.Web.UI.Page
    {
        Author newAuthor = new Author();
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

        protected void BtnAddAuthor(object sender, EventArgs e)
        {
            if (!newAuthor.CheckAuthor(txtFUllName.Text))
            {
                try
                {
                    newAuthor.CreateAuthor(txtFUllName.Text, txtAddress.Text);
                    lblMessage.Text = "Author added successfully.";
                    lblMessage.ForeColor = Color.Green;
                }
                catch (Exception exception)
                {
                    lblMessage.Text = "Some error has been occured. Error details: " + exception.Message;
                    lblMessage.ForeColor = Color.Red;
                }
            }
            else
            {
                lblMessage.Text = "Author already exist!";
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}