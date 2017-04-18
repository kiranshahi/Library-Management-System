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
        Author newAuthor = new Author();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] != null)
            {
                lblUserName.Text = Session["name"].ToString();
                lblUserName1.Text = Session["name"].ToString();
                if (!IsPostBack)
                {
                    string connectString =
                        WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
                    string QueryString = "select * from publishers";

                    SqlConnection myConnection = new SqlConnection(connectString);
                    SqlDataAdapter myCommand = new SqlDataAdapter(QueryString, myConnection);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "publishers");

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
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void BtnAddBooks(object sender, EventArgs e)
        {
            

            try
            {
                newBook.CreateBook(txtTitle.Text, txtOverview.Text, txtIsbn.Text, Convert.ToInt32(publisherList.Value), txtPublishedDate.Text, Convert.ToInt32(txtEdition.Text));
                lblMessage.Text = "Book added successfully.";
                lblMessage.ForeColor = Color.Green;
            }
            catch (Exception exception)
            {
                lblMessage.Text = "Error occurred while saving data. Error details : " + exception.Message;

                lblMessage.ForeColor = Color.Red;
            }
        }

        protected void BtnAddAuthor(object sender, EventArgs e)
        {
            if ((txtFUllName.Text != ""))
            {
                if (!newAuthor.CheckAuthor(txtFUllName.Text))
                {
                    try
                    {
                        newAuthor.CreateAuthor(txtFUllName.Text, txtAddress.Text);
                        Response.Redirect("~/Admin/Books.aspx");
                        lblMessage.Text = "Author added successfully.";
                        lblMessage.ForeColor = Color.Green;
                    }
                    catch (Exception exception)
                    {
                        lblMessage.Text = "Some error has been occured. Error details: " + exception.Message;
                        lblMessage.ForeColor = Color.Red;
                    }
                }
                else
                {
                    lblMessage.Text = "Author already exist!";
                    lblMessage.ForeColor = Color.Red;
                }
            }
            
        }
    }
}