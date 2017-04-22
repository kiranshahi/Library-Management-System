using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD.Admin
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// @class  ActiveLoans
    ///
    /// @brief  The loans that are not yet returned.
    /// @date   21/04/2017
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class ActiveLoans : System.Web.UI.Page
    {
        List<Loan> loans;

        public ActiveLoans()
            : base()
        {
            loans = new List<Loan>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn protected void Page_Load(object sender, EventArgs e)
        ///
        /// @brief  Event handler. Called by Page for load events.
        ///         Checks login,
        ///         Initializes display data
        ///         
        ///
        /// @date   21/04/2017
        ///
        /// @param  sender  Source of the event.
        /// @param  e       Event information.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null)
            {
                Response.Redirect("~/Login");
            }
            lblUserName.Text = Session["name"].ToString();
            lblUserName1.Text = Session["name"].ToString();
            try
            {
                this.populateTable();
            }
            catch (Exception ex)
            {
                this.info.CssClass = "text-danger";
                if (ex is SqlException || ex is IndexOutOfRangeException)
                {
                    this.info.Text = "Database Error Occurred";
                    return;
                }
                if (ex is Win32Exception)
                {
                    this.info.Text = "Database is not installed or not started.";
                    return;
                }
                throw;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn private void populateTable()
        ///
        /// @brief  Populate table with all the active loans
        ///
        /// @date   21/04/2017
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void populateTable()
        {
            this.loans = Loan.GetActiveLoans();
            if (this.loans.Count == 0)
            {
                this.info.Text = "No Active Loans";
                if (!this.info.CssClass.Contains("text-danger"))
                {
                    this.info.CssClass += " text-danger";
                }
            }
            else
            {
                this.info.Text = this.info.Text.Replace("text-danger", "");
                this.info.Text = "Total records displayed: " + this.loans.Count.ToString();
            }
            this.LoanLister.DataSource = this.loans;
            this.LoanLister.DataBind();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn protected void LoanLister_RowDataBound(object sender, GridViewRowEventArgs e)
        ///
        /// @brief  Event handler. Called by LoanLister for row data bound events.
        ///         Removes fifth column (returned_date) because books haven't been returned yet
        ///
        /// 
        /// @date   21/04/2017
        ///
        /// @param  sender  Source of the event.
        /// @param  e       Grid view row event information.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void LoanLister_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int row = e.Row.RowIndex;
            e.Row.Cells.RemoveAt(5);

            if(row >= 0)
            {
                TableCell newCell = new TableCell();
                newCell.Text = "<a class=\"btn btn-primary\" href=\"/admin/returnloan?id="
                                + this.loans[e.Row.RowIndex].Id
                                + "\">"
                                +"Return </a>";
                int col = e.Row.Cells.Add(newCell);
            }
        }



    }
}