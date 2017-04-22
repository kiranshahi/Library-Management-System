using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD.Admin
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// @class  InactiveMembers
    ///
    /// @brief  An inactive member. 
    ///             -who has not borrowed in last 31 days
    ///
    /// @date   21/04/2017
    ////////////////////////////////////////////////////////////////////////////////////////////////////

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
        /// @brief  Populate table with inactive user details.
        ///
        /// @date   21/04/2017
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn public void MemberLister_RowDataBound(object sender, GridViewRowEventArgs e)
        ///
        /// @brief  Event handler. Called by MemberLister for row data bound events.
        ///         -Adds edit option for members
        ///
        /// 
        /// @date   21/04/2017
        ///
        /// @param  sender  Source of the event.
        /// @param  e       Grid view row event information.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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