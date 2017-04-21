using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD.Admin
{
    public partial class EditBook : System.Web.UI.Page
    {
        Book updateBook = new Book();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectString =
                    WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
                SqlConnection myConnection = new SqlConnection(connectString);

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    string bookId = Request.QueryString["id"];
                    
                    string QueryString = "select * from books where id = ' " + bookId + " ' ";
                    myConnection.Open();
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(QueryString, myConnection);
                    myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        this.bookId.Value = (myReader["id"].ToString());
                        txtTitle.Text = (myReader["title"].ToString());
                        txtOverview.Text = (myReader["overview"].ToString());
                        txtIsbn.Text = (myReader["isbn"].ToString());
                        txtPublishedDate.Text = String.Format("{0:yyyy-MM-dd }", myReader["published_date"]);
                        txtEdition.Text = (myReader["edition"].ToString());
                    }
                    myReader.Close();
                }

                
                string PublisherString = "select * from publishers";
                SqlDataAdapter getPublishersCommand = new SqlDataAdapter(PublisherString, myConnection);
                DataSet ds = new DataSet();
                getPublishersCommand.Fill(ds, "publishers");

                publisherList.DataSource = ds;
                publisherList.DataTextField = "name";
                publisherList.DataValueField = "id";
                publisherList.DataBind();

                string AuthorString = "select * from authors";
                SqlDataAdapter getAuthorCommand = new SqlDataAdapter(AuthorString, myConnection);
                DataSet authorDs = new DataSet();
                getAuthorCommand.Fill(authorDs, "authors");

                authorList.DataSource = authorDs;
                authorList.DataTextField = "name";
                authorList.DataValueField = "id";
                authorList.DataBind();
            }
        }

        protected void updateBookDetails(object sender, EventArgs e)
        {
            try
            {
                updateBook.UpdateBook(Convert.ToInt32(bookId.Value), txtTitle.Text, txtOverview.Text, txtIsbn.Text,
    Convert.ToInt32(publisherList.Value), txtPublishedDate.Text, Convert.ToInt32(txtEdition));
                lblMessage.Text = "Book updated successfully.";
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