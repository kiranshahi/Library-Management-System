using System;
using System.Drawing;
using System.Net;
using System.Net.Mail;

namespace Library_Management_System_AD.Admin
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// @class  Register
    ///
    /// @brief  A register.
    ///
    /// @author Sirjan
    /// @date   21/04/2017
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class Register : System.Web.UI.Page
    {
        User newUser = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] != null && Session["role"].ToString().ToLower() == "Admin".ToLower())
            {
                lblUserName.Text = Session["name"].ToString();
                lblUserName1.Text = Session["name"].ToString();
            }
            else
            {
                Response.Redirect("~/Admin/Default.aspx");
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn protected void BtnAddUser(object sender, EventArgs e)
        ///
        /// @brief  Button add user.
        ///
        /// @author Sirjan
        /// @date   21/04/2017
        ///
        /// @param  sender  Source of the event.
        /// @param  e       Event information.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void BtnAddUser(object sender, EventArgs e)
        {
            string strpassword = System.Web.Security.Membership.GeneratePassword(12, 6);
            if (!newUser.UsernameCheck(txtUsername.Text, txtEmailID.Text))
            {

                int i = newUser.CreateUser(txtFUllName.Text, txtUsername.Text, txtEmailID.Text, txtMobileNo.Text,
                    strpassword, "User", Convert.ToDateTime(txtRegisteredDate.Text));
                if (i > 0)
                {
                    try
                    {
                        using (MailMessage mm = new MailMessage("librarymgmtsys@gmail.com", txtEmailID.Text))
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
                            NetworkCredential networkCred = new NetworkCredential("librarymgmtsys@gmail.com", "testing!@12");
                            smtp.UseDefaultCredentials = true;
                            smtp.Credentials = networkCred;
                            smtp.Port = 587;
                            smtp.Send(mm);
                            lblMessage.Text = "User Created Successfully. Login Credential is sent to an user\'s email. ";
                            lblMessage.ForeColor = Color.Green;

                        }
                    }
                    catch (SmtpException exception)
                    {
                        lblMessage.Text = "User created but could not send email. Please provide credentials manually."+exception.Message;
                        lblMessage.ForeColor = Color.Red;
                    }

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