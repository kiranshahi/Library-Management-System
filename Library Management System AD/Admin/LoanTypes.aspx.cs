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
    /// @class  LoanTypes
    ///
    /// @brief  A loan types.
    ///
    /// 
    /// @date   21/04/2017
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class LoanTypes : System.Web.UI.Page
    {
        LoanType newLoanType = new LoanType();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn protected void Page_Load(object sender, EventArgs e)
        ///
        /// @brief  Event handler. Called by Page for load events.
        ///
        /// 
        /// @date   21/04/2017
        ///
        /// @param  sender  Source of the event.
        /// @param  e       Event information.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
        /// @fn protected void BtnAddLoanType(object sender, EventArgs e)
        ///
        /// @brief  Button add loan type.
        ///
        /// 
        /// @date   21/04/2017
        ///
        /// @param  sender  Source of the event.
        /// @param  e       Event information.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void BtnAddLoanType(object sender, EventArgs e)
        {
            newLoanType.AddLoanType(txtType.Text, Convert.ToInt32(txtMaxDuration.Text));
            lblMessage.Text = "Loan type added successfully.";
            lblMessage.ForeColor = Color.Green;
            
        }
    }
}