using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD
{
    public partial class Login : System.Web.UI.Page
    {
        User newUser = new User();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = newUser.CheckUserLogin(txtUsername.Text, txtPassword.Text);
            if (dt.Rows.Count > 0)
            {
                Session.Add("userid", dt.Rows[0]["id"].ToString());
                Session.Add("name", dt.Rows[0]["name"].ToString());
                if (dt.Rows[0]["role"].ToString().ToLower() == "Admin".ToLower())
                {
                    Response.Redirect("~/Admin/Register.aspx");
                }
                else if (dt.Rows[0]["role"].ToString().ToLower() == "User".ToLower())
                {
                    Response.Redirect("~/Admin/Default.aspx");
                }
            }
            else
            {
                lblMessage.Text = "Username or password do not match.";
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}