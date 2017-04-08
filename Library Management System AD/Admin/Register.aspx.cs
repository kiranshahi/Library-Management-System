using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD.Admin
{
    public partial class Register : System.Web.UI.Page
    {
        User newUser = new User();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSingup_Click(object sender, EventArgs e)
        {
            string strpassword = System.Web.Security.Membership.GeneratePassword(12, 6);
            if (!newUser.UsernameCheck(txtUsername.Text, txtEmailID.Text))
            {

                int i = newUser.CreateUser(txtFUllName.Text, txtUsername.Text, txtEmailID.Text, txtMobileNo.Text,
                    strpassword, "User", Convert.ToDateTime(txtJoinedDate.Text));
                if (i > 0)
                {
                    lblMessage.Text = "User Registered SUccessfully";
                    lblMessage.ForeColor = Color.Green;

                    using (MailMessage mm = new MailMessage("kiran.shahi.c3@gmail.com", txtEmailID.Text))
                    {
                        mm.Subject = "Library Management System Credential";

                        mm.Body = "Hi " + txtFUllName.Text + ",\n";
                        mm.Body += "Username:" + txtUsername.Text + "\n" + "Password:" + strpassword + "\n";
                        mm.Body += "Your account on Library Management System has been created. \n";
                        mm.Body += "Please update your password immediately.";

                        mm.IsBodyHtml = false;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential("librarymgmtsys@gmail.com", "testing!@12");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);

                    }
                    lblMessage.Text = "User Created Successfully. Login Credential is sent to an user\'s email. ";
                    lblMessage.ForeColor = Color.Green;

                }
            }
            else
            {
                lblMessage.Text = "Username or email already exist! ";
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}