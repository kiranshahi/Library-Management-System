using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// @class  MemberLoans
    ///
    /// @brief  Loans by a member.
    ///
    /// @date   21/04/2017
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class MemberLoans : System.Web.UI.Page
    {
        List<Loan> loans;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null)
            {
                Response.Redirect("~/Login");
            }
            lblUserName.Text = Session["name"].ToString();
            lblUserName1.Text = Session["name"].ToString();
            this.populateTable();


        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn private void populateTable()
        ///
        /// @brief  Populate table with loans of a member.
        ///
        /// @date   21/04/2017
        ///
        /// @exception  FormatException Thrown when the format of the member id is incorrect.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void populateTable()
        {
            int memberId;
            try 
            {
                memberId = Convert.ToInt16(Request.QueryString["member"]);
                if(memberId == 0) throw new FormatException();
                this.MemberId.InnerText = "for member id: " + memberId.ToString();
            }
            catch (FormatException)
            {
                this.info.Text = "Invalid Member ID provided";
                if (!this.info.CssClass.Contains("text-danger"))
                {
                    this.info.CssClass += " text-danger";
                }
                return;
            }

            List<Loan> loans = Loan.GetMemberLoans(memberId);

            if (loans.Count == 0)
            {
                this.info.Text = "No Loans by member in last 31 days";
                if (!this.info.CssClass.Contains("text-danger"))
                {
                    this.info.CssClass += " text-danger";
                }
            }
            else
            {
                this.info.Text = this.info.Text.Replace("text-danger", "");
                this.info.Text = "Total records displayed: " + loans.Count.ToString();
            }
            this.loans = loans;
            this.LoanLister.DataSource = loans;
            this.LoanLister.DataBind();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn protected void LoanLister_RowDataBound(object sender, GridViewRowEventArgs e)
        ///
        /// @brief  Event handler. Called by LoanLister for row data bound events.
        ///         - Add option for returning the loaned book.
        ///
        /// @date   21/04/2017
        ///
        /// @param  sender  Source of the event.
        /// @param  e       Grid view row event information.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void LoanLister_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int row = e.Row.RowIndex;

            if (row >= 0)
            {
                if (!String.IsNullOrWhiteSpace(this.loans[e.Row.RowIndex].ReturnedDate)) return;

                TableCell newCell = new TableCell();
                newCell.Text = "<a class=\"btn btn-primary\" href=\"/admin/returnloan?id="
                                + this.loans[e.Row.RowIndex].Id
                                + "\">"
                                + "Return </a>";
                int col = e.Row.Cells.Add(newCell);
            }
        }

    }
}