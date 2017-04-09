using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        User newUser = new User();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            string strpassword = System.Web.Security.Membership.GeneratePassword(12, 6);
            if (newUser.UsernameCheck(txtEmail.Text, txtEmail.Text))
            {
                int i = newUser.resetPassword(txtEmail.Text, strpassword);
                if (i > 0)
                {

                    using (MailMessage mm = new MailMessage("librarymgmtsys@gmail.com", txtEmail.Text))
                    {
                        mm.Subject = "Library Management System Credential";
                        mm.Body = "Hi, somebody requested to change your password.\n";
                        mm.Body += "Here is your new password. Password: " + strpassword + "\n";
                        mm.Body += "Your account password has been changed. \n";
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
                    lblMessage.Text = "New password has been sent to email.";
                    lblMessage.ForeColor = Color.Green;
                }
                else
                {
                    lblMessage.Text = "Username or email not found.";
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }
    }
}