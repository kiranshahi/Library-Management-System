using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD.Admin
{
    public partial class UserList : System.Web.UI.Page
    {
        List<User> users;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null || Session["role"].ToString().ToLower() != "admin")
            {
                Response.Redirect("~/Login");
            }
            lblUserName.Text = Session["name"].ToString();
            lblUserName1.Text = Session["name"].ToString();
            this.populateTable();


        }

        private void populateTable()
        {
            List<User> users = Library_Management_System_AD.User.GetUsers();

            if (users.Count == 0)
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
                this.info.Text = "Total records displayed: " + users.Count.ToString();
            }
            this.users = users;
            this.UserLister.DataSource = users;
            this.UserLister.DataBind();
        }

        protected void UserLister_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int row = e.Row.RowIndex;

            if (row >= 0)
            {
                TableCell newCell = new TableCell();
                newCell.Text = "<a class=\"btn btn-primary\" href=\"/admin/EditUser?id="
                                + this.users[e.Row.RowIndex].Id
                                + "\">"
                                + "Edit </a>";
               
                int col = e.Row.Cells.Add(newCell);
            }
        }
    }
}