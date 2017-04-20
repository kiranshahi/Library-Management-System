using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Configuration;

namespace Library_Management_System_AD.Admin
{
    public partial class EditMember : System.Web.UI.Page
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
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        string memberId = Request.QueryString["id"];

                        string connectString =
                            WebConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
                        string queryString = "SELECT * from members where id =' " + memberId + " ' ";

                        SqlConnection myConnection = new SqlConnection(connectString);
                        myConnection.Open();
                        SqlDataReader myReader = null;
                        SqlCommand myCommand = new SqlCommand(queryString, myConnection);
                        myReader = myCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            this.memberId.Value = memberId;
                            txtName.Text = (myReader["name"].ToString());
                            txtEmail.Text = (myReader["email"].ToString());
                            txtPhone.Text = (myReader["phone"].ToString());
                            txtAddress.Text = (myReader["address"].ToString());
//                        membershipType.Value = 
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

        protected void BtnUpdateDetails(object sender, EventArgs e)
        {
            try
            {
                newMember.UpdateMemberDetails(Convert.ToInt32(memberId.Value), txtName.Text, txtEmail.Text, txtPhone.Text, txtAddress.Text);
                //Response.Redirect("~/Admin/MemberList.aspx");
                //                lblMessage.Text = "Member updated successfully.";
                //                lblMessage.ForeColor = Color.Green;
                lblMessage.Text += memberId.Value + " <br />";
                lblMessage.Text += txtName.Text + " <br />";
                lblMessage.Text += txtEmail.Text + " <br />";
                lblMessage.Text += txtPhone.Text + " <br />";
                lblMessage.Text += membershipType.Value + " <br />";
                lblMessage.Text += txtAddress.Text;
            }
            catch (Exception exception)
            {
                lblMessage.Text = exception.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}