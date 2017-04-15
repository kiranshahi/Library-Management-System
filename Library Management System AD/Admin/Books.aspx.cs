using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Library_Management_System_AD.Admin
{
    public partial class Books : System.Web.UI.Page
    {
        Book newBook = new Book();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ConnectString = "Data Source=DESKTOP-CK5EETK;Initial Catalog=LMSdb;Integrated Security=True";
                string QueryString = "select * from publishers";

                SqlConnection myConnection = new SqlConnection(ConnectString);
                SqlDataAdapter myCommand = new SqlDataAdapter(QueryString, myConnection);
                DataSet ds = new DataSet();
                myCommand.Fill(ds, "publishers");

                publisherList.DataSource = ds;
                publisherList.DataTextField = "name";
                publisherList.DataValueField = "id";
                publisherList.DataBind();
            }
        }

        protected void BtnAddBooks(object sender, EventArgs e)
        {
            try
            {
                newBook.CreateBook(txtTitle.Text, txtOverview.Text, txtIsbn.Text, Convert.ToInt32(publisherList.Value), Convert.ToDateTime(txtPublishedDate.Text), Convert.ToInt32(txtEdition.Text));
                lblMessage.Text = "Book added successfully.";
                lblMessage.ForeColor = Color.Green;
            }
            catch (Exception exception)
            {
                lblMessage.Text = "Error occurred while saving data. Error details : " + exception.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}