using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD.Admin
{
    public partial class ActiveLoans : System.Web.UI.Page
    {
        List<Loan> loans;

        public ActiveLoans()
            : base()
        {
            loans = new List<Loan>();
        }
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