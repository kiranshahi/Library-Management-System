using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// @class  BookList
    ///
    /// @brief  List of books.
    ///
    /// @date   21/04/2017
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class BookList : System.Web.UI.Page
    {
        List<Book> books;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn protected void Page_Load(object sender, EventArgs e)
        ///
        /// @brief  Event handler. Called by Page for load events.
        ///
        /// @date   21/04/2017
        ///
        /// @param  sender  Source of the event.
        /// @param  e       Event information.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
            try
            {
                this.PopulateTable();
                this.PopulateFilters();
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
        /// @fn private void populateFilters()
        ///
        /// @brief  Populate filters for displayed books
        ///         - all books  
        ///         - books available currently  
        ///         - books not borrowed in last 31 days (only to registered users)
        ///
        /// @date   21/04/2017
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void PopulateFilters()
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn private void populateTable()
        ///
        /// @brief  Populate table with books data.
        ///
        /// @date   21/04/2017
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void PopulateTable()
        {
            string searchBook = this.bookName.Text;
            string searchAuthor = this.authorName.Text;
            string searchPublisher = this.publisherName.Text;


            switch(this.Filter.SelectedIndex)
            {
                case 0 : default:
                    this.ShowSearch();
                    this.books = Book.GetBooks(searchBook, searchAuthor, searchPublisher);
                    break;
                case 1:
                    this.ShowSearch();
                    this.books = Book.GetAvailableBooks(searchBook, searchAuthor, searchPublisher);
                    break;
                case 2:
                    this.HideSearch();
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn private void HideSearch()
        ///
        /// @brief  Hides the text based search fields.
        ///
        /// @date   21/04/2017
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void HideSearch()
        {
            this.authorName.Visible = false;
            this.bookName.Visible = false;
            this.publisherName.Visible = false;
            this.submit.Visible = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn private void ShowSearch()
        ///
        /// @brief  Shows the text based search fields
        ///
        /// @date   21/04/2017
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ShowSearch()
        {
            this.authorName.Visible = true;
            this.bookName.Visible = true;
            this.publisherName.Visible = true;
            this.submit.Visible = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn public void BookLister_RowDataBound(object sender, GridViewRowEventArgs e)
        ///
        /// @brief  Event handler. Called by BookLister for row data bound events.
        ///         Hides book id
        ///         Add edit option for each book.
        ///
        /// @date   21/04/2017
        ///
        /// @param  sender  Source of the event.
        /// @param  e       Grid view row event information.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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