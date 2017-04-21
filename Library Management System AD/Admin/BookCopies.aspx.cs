using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Configuration;

namespace Library_Management_System_AD.Admin
{
    public partial class BookCopies : System.Web.UI.Page
    {
        BookCopy newBookCopies = new BookCopy();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn protected void Page_Load(object sender, EventArgs e)
        ///
        /// @brief  Event handler. Called by Page for load events.
        ///
        /// @author Sirjan
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

                if (!IsPostBack)
                {
                    string connectString = WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
                    string QueryString = "select * from books";

                    SqlConnection myConnection = new SqlConnection(connectString);
                    SqlDataAdapter myCommand = new SqlDataAdapter(QueryString, myConnection);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "book");

                    bookOption.DataSource = ds;
                    bookOption.DataTextField = "title";
                    bookOption.DataValueField = "id";
                    bookOption.DataBind();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn protected void BtnAddBookCopies(object sender, EventArgs e)
        ///
        /// @brief  Button add book copies.
        ///
        /// @author Sirjan
        /// @date   21/04/2017
        ///
        /// @param  sender  Source of the event.
        /// @param  e       Event information.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void BtnAddBookCopies(object sender, EventArgs e)
        {
            try
            {
                newBookCopies.CreateBookCopies(Convert.ToInt32(txtCopyNumber.Text), Convert.ToInt32(bookOption.Value), Convert.ToDateTime(txtPurchasedDate.Text), txtLocation.Text);
                lblMessage.Text = "Book Copy has been added.";
                lblMessage.ForeColor = Color.Green;
            }
            catch (Exception exception)
            {
                lblMessage.Text = exception.Message;
                lblMessage.ForeColor = Color.Red;

            }
        }
    }
}