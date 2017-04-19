using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD.Admin
{
    public partial class Profile : System.Web.UI.Page
    {
        User updateUser = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] != null)
            {
                lblUserName.Text = Session["name"].ToString();
                lblUserName1.Text = Session["name"].ToString();
                int userid = Convert.ToInt32(Session["userid"]);
                if (!IsPostBack)
                {
                    string connectString =
                        WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
                    string QueryString = "select * from users where id = ' " +userid+ " ' ";

                    SqlConnection myConnection = new SqlConnection(connectString);
                    DataTable ds = new DataTable();
                    myConnection.Open();
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(QueryString, myConnection);
                    myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        txtUserName.Text = (myReader["username"].ToString());
                        txtName.Text = (myReader["name"].ToString());
                        txtEmail.Text = (myReader["email"].ToString());
                        txtPhone.Text = (myReader["phone"].ToString());
                    }
                    myReader.Close();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void UpdateProfile(object sender, EventArgs e)
        {
            try
            {
                updateUser.UpdateUserDetails(txtUserName.Text, txtName.Text, txtEmail.Text, txtPhone.Text, txtPassword.Text);
                lblMessage.Text = "Updated successfully.";
            }
            catch (Exception exception)
            {
                lblMessage.Text = exception.Message;
            }
        }
    }
}