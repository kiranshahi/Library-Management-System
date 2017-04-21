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
    public partial class EditUser : System.Web.UI.Page
    {
        User updateUser = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["name"] != null && Session["role"].ToString().ToLower() == "Admin".ToLower())
                {
                    lblUserName.Text = Session["name"].ToString();
                    lblUserName1.Text = Session["name"].ToString();
                    if (!IsPostBack)
                    {
                        if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                        {
                            string userid = Request.QueryString["id"];
                        
                            string connectString =
                            WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
                            string QueryString = "select * from users where id = ' " + userid + " ' ";
                            SqlConnection myConnection = new SqlConnection(connectString);
                            DataTable ds = new DataTable();
                            myConnection.Open();
                            SqlDataReader myReader = null;
                            SqlCommand myCommand = new SqlCommand(QueryString, myConnection);
                            myReader = myCommand.ExecuteReader();

                            while (myReader.Read())
                            {
                                userId.Value = (myReader["id"].ToString());
                                txtUserName.Text = (myReader["username"].ToString());
                                txtName.Text = (myReader["name"].ToString());
                                txtEmail.Text = (myReader["email"].ToString());
                                txtPhone.Text = (myReader["phone"].ToString());
                            }
                            myReader.Close();
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void UpdateUser(object sender, EventArgs e)
        {
            try
            {
                updateUser.UpdateUserDetails(Convert.ToInt32(userId.Value), txtName.Text, txtEmail.Text, txtPhone.Text,
                txtPassword.Text);
            }
            catch (Exception exception)
            {
                lblMessage.Text = exception.Message;
            }
        }
    }
}