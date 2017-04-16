using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD.Admin
{
    public partial class LoanTypes : System.Web.UI.Page
    {
        LoanType newLoanType = new LoanType();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAddLoanType(object sender, EventArgs e)
        {
            newLoanType.AddLoanType(txtType.Text, Convert.ToInt32(txtMaxDuration.Text));
        }
    }
}