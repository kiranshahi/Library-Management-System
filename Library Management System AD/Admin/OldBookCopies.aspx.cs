using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD.Admin
{
    public partial class OldBookCopies : System.Web.UI.Page
    {

        List<BookCopy> books;
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


            List<BookCopy> books = BookCopy.GetOldCopies();

            if (books.Count == 0)
            {
                this.info.Text = "No Books Older than 365 days";
                if (!this.info.CssClass.Contains("text-danger"))
                {
                    this.info.CssClass += " text-danger";
                }
            }
            else
            {
                this.info.Text = this.info.Text.Replace("text-danger", "");
                this.info.Text = "Total records displayed: " + books.Count.ToString();
            }
            this.books = books;
            this.deleteBtn.Visible = this.books.Count > 0 ? true : false;
            this.BookLister.DataSource = this.books;
            this.BookLister.DataBind();
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            int deletedRowsCount = BookCopy.DeleteOldCopies();
            this.books = BookCopy.GetOldCopies();
            this.BookLister.DataSource = this.books;
            this.BookLister.DataBind();
            this.info.Text = deletedRowsCount + " Book Copies deleted";
            
        }
        
    }
}