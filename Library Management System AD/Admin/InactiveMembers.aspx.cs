using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD.Admin
{
    public partial class InactiveMembers : System.Web.UI.Page
    {
        List<InactiveMember> members;
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

            List<InactiveMember> members = Member.GetInactiveMembers();

            if (members.Count == 0)
            {
                this.info.Text = "No Inactive Members";
                if (!this.info.CssClass.Contains("text-danger"))
                {
                    this.info.CssClass += " text-danger";
                }
            }
            else
            {
                this.info.Text = this.info.Text.Replace("text-danger", "");
                this.info.Text = "Total records displayed: " + members.Count.ToString();
            }
            this.members = members;
            this.MemberLister.DataSource = members;
            this.MemberLister.DataBind();
        }


        public void MemberLister_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int row = e.Row.RowIndex;

            if (row >= 0)
            {
                TableCell newCell = new TableCell();
                newCell.Text = "<a class=\"btn btn-primary\" href=\"/admin/EditMember?id="
                                + this.members[e.Row.RowIndex].Id
                                + "\">"
                                + "Edit </a>";
                int col = e.Row.Cells.Add(newCell);
            }
        }
    }
}