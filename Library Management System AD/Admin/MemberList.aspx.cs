using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD.Admin
{
    public partial class MemberList : System.Web.UI.Page
    {
        List<Member> members;
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

            string member = this.member.Text;


            List<Member> members = Member.GetMembers(member);

            if (members.Count == 0)
            {
                this.info.Text = "No Record Available";
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

        protected void MemberLister_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int row = e.Row.RowIndex;

            if (row >= 0)
            {
                TableCell newCell = new TableCell();
                newCell.Text = "<a class=\"btn btn-primary\" href=\"/admin/EditMember?id="
                                + this.members[e.Row.RowIndex].Id
                                + "\">"
                                + "Edit </a>"; 
                newCell.Text += "<a class=\"btn btn-primary\" href=\"/admin/memberloans?member="
                                 + this.members[e.Row.RowIndex].Id
                                 + "\">"
                                 + "Loans </a>";
                int col = e.Row.Cells.Add(newCell);
            }
        }

    }
}