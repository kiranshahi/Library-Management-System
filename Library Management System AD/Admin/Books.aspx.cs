using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Configuration;

namespace Library_Management_System_AD.Admin
{
    public partial class Books : System.Web.UI.Page
    {
        Book newBook = new Book();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectString = WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
                string QueryString = "select * from publishers";

                SqlConnection myConnection = new SqlConnection(connectString);
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
                newBook.CreateBook(txtTitle.Text, txtOverview.Text, txtIsbn.Text, Convert.ToInt32(publisherList.Value), Convert.ToDateTime(txtPublishedDate.Text), Convert.ToInt32(txtEdition.Text), txtBarCode.Text);
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