using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Configuration;

namespace Library_Management_System_AD.Admin
{
    public partial class Members : System.Web.UI.Page
    {
        Member newMember = new Member();
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
                    string QueryString = "select * from membership_types";

                    SqlConnection myConnection = new SqlConnection(connectString);
                    SqlDataAdapter myCommand = new SqlDataAdapter(QueryString, myConnection);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "membershipTypes");

                    membershipType.DataSource = ds;
                    membershipType.DataTextField = "type";
                    membershipType.DataValueField = "id";
                    membershipType.DataBind();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void BtnAddMember(object sender, EventArgs e)
        {
            try
            {
                newMember.AddMember(txtFUllName.Text, txtEmail.Text, txtPhone.Text, Convert.ToInt32(membershipType.Value),
                Convert.ToDateTime(txtJoinedDate.Text));
                lblMessage.Text = "Member added successfully.";
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