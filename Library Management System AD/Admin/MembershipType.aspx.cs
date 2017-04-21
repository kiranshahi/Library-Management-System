using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD.Admin
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// @class  MembershipType
    ///
    /// @brief  A membership type.
    ///
    /// 
    /// @date   21/04/2017
    ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn protected void BtnAddMembershipType(object sender, EventArgs e)
        ///
        /// @brief  Button add membership type.
        ///
        /// 
        /// @date   21/04/2017
        ///
        /// @param  sender  Source of the event.
        /// @param  e       Event information.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void BtnAddMembershipType(object sender, EventArgs e)
        {
            try
            {
                newMemberType.AddMemberType(txtType.Text, Convert.ToInt32(txtBooksAllowed.Text), Convert.ToInt32(txtPenaltyCharge.Text));
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