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
        List<Book> books;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] != null)
            {
                lblUserName.Text = Session["name"].ToString();
                lblUserName1.Text = Session["name"].ToString();

            }
            else
            {
                lblUserName.Text = "Guest";
                lblUserName1.Text = "Guest";
            }
            this.populateTable();
            this.populateFilters();
        }

        private void populateFilters()
        {
            int selectedIndex;
            if(IsPostBack)
            {
                selectedIndex = this.Filter.SelectedIndex;
            } else {
                selectedIndex = -1;
            }
            this.Filter.Items.Clear();
            
            this.Filter.Items.Add("All books");
            this.Filter.Items.Add("Available books");
            if (Session["name"] != null)
            {
                this.Filter.Items.Add("Inactive Books");
            }
            this.Filter.SelectedIndex = IsPostBack && selectedIndex > this.Filter.Items.Count-1 ?
                this.Filter.Items.Count-1: selectedIndex;
            
        }

        private void populateTable()
        {
            string searchBook = this.bookName.Text;
            string searchAuthor = this.authorName.Text;
            string searchPublisher = this.publisherName.Text;


            switch(this.Filter.SelectedIndex)
            {
                case 0 : default:
                    this.ShowFilters();
                    this.books = Book.GetBooks(searchBook, searchAuthor, searchPublisher);
                    break;
                case 1:
                    this.ShowFilters();
                    this.books = Book.GetAvailableBooks(searchBook, searchAuthor, searchPublisher);
                    break;
                case 2:
                    this.HideFilters();
                    this.books = Book.GetInactiveBook();
                    break;
            }

            if (this.books.Count == 0)
            {
                this.BookLister.Visible = false;
                this.info.Text = "No Record Available";
                if (!this.info.CssClass.Contains("text-danger"))
                {
                    this.info.CssClass += " text-danger";
                }
            }
            else
            {
                this.BookLister.Visible = true;
                this.info.Text = this.info.Text.Replace("text-danger", "");
                this.info.Text = "Total records displayed: " + books.Count.ToString();
            }
            this.BookLister.DataSource = this.books;
            this.BookLister.DataBind();
        }

        private void HideFilters()
        {
            this.authorName.Visible = false;
            this.bookName.Visible = false;
            this.publisherName.Visible = false;
            this.submit.Visible = false;
        }

        private void ShowFilters()
        {
            this.authorName.Visible = true;
            this.bookName.Visible = true;
            this.publisherName.Visible = true;
            this.submit.Visible = true;
        }

        public void BookLister_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int row = e.Row.RowIndex;
            e.Row.Cells.RemoveAt(0);  //don't show the book id to the user

            if (Session["name"] == null) return; //don't show edit option to guest

            if (row >= 0)
            {
                TableCell newCell = new TableCell();
                newCell.Text = "<a class=\"btn btn-primary\" href=\"/admin/EditBook?id="
                                + this.books[e.Row.RowIndex].Id
                                + "\">"
                                + "Edit </a>";
                int col = e.Row.Cells.Add(newCell);
            }
        }
    }
}