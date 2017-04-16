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
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void BtnAddBookCopies(object sender, EventArgs e)
        {
            try
            {
                newBookCopies.CreateBookCopies(Convert.ToInt32(bookOption.Value), Convert.ToDateTime(txtPurchasedDate.Text), txtLocation.Text);
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