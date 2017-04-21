using System;
using System.Drawing;

namespace Library_Management_System_AD.Admin
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// @class  Publishers
    ///
    /// @brief  A publishers.
    ///
    /// 
    /// @date   21/04/2017
    ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn protected void BtnAddPublisher(object sender, EventArgs e)
        ///
        /// @brief  Button add publisher.
        ///
        /// 
        /// @date   21/04/2017
        ///
        /// @param  sender  Source of the event.
        /// @param  e       Event information.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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