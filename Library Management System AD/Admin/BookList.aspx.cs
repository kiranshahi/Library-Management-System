using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD
{
    public partial class BookList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["name"] != null)
            //{
            //    lblUserName.Text = Session["name"].ToString();
            //    lblUserName1.Text = Session["name"].ToString();

            //    this.polulateTable();
            //}
            //else
            //{
            //    Response.Redirect("~/Login.aspx");
            //}
            this.populateTable();
        }

        private void populateTable()
        {
            string searchBook = this.bookName.Text;
            string searchAuthor = this.authorName.Text;
            string searchPublisher = this.publisherName.Text;


            List<Book> books =
                this.includeLoaned.Checked ?
                Book.GetBooks(searchBook, searchAuthor, searchPublisher) :
                Book.GetAvailableBooks(searchBook, searchAuthor, searchPublisher);

            if (books.Count == 0)
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
                this.info.Text = "Total records displayed: " + books.Count.ToString();
            }
            this.BookLister.DataSource = books;
            this.BookLister.DataBind();
        }

    }
}