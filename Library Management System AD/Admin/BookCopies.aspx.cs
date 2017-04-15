using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD.Admin
{
    public partial class BookCopies : System.Web.UI.Page
    {
        BookCopy newBookCopies = new BookCopy();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ConnectString = "Data Source=DESKTOP-CK5EETK;Initial Catalog=LMSdb;Integrated Security=True";
                string QueryString = "select * from books";

                SqlConnection myConnection = new SqlConnection(ConnectString);
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