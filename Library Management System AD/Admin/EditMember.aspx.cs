using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Configuration;

namespace Library_Management_System_AD.Admin
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// @class  EditMember
    ///
    /// @brief  An edit member.
    ///
    /// 
    /// @date   21/04/2017
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class EditMember : System.Web.UI.Page
    {
        Member newMember = new Member();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn protected void Page_Load(object sender, EventArgs e)
        ///
        /// @brief  Event handler. Called by Page for load events.
        ///
        /// 
        /// @date   21/04/2017
        ///
        /// @param  sender  Source of the event.
        /// @param  e       Event information.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.HandlePageLoad();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn private void HandlePageLoad()
        ///
        /// @brief  Handles the page load.
        ///
        /// 
        /// @date   21/04/2017
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void HandlePageLoad()
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
                        string queryString = "select * from members where id = ' " + memberId + " ' ";

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
                        }
                        myReader.Close();

                        string memberTypeQueryString = "select * from membership_types";
                        SqlDataAdapter memberTypeCommand = new SqlDataAdapter(memberTypeQueryString, myConnection);
                        DataSet ds = new DataSet();
                        memberTypeCommand.Fill(ds, "membershipTypes");

                        membershipType.DataSource = ds;
                        membershipType.DataTextField = "type";
                        membershipType.DataValueField = "id";
                        membershipType.DataBind();
                    }
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// @fn protected void UpdateMemberDetails(object sender, EventArgs e)
        ///
        /// @brief  Updates the member details.
        ///
        /// 
        /// @date   21/04/2017
        ///
        /// @param  sender  Source of the event.
        /// @param  e       Event information.
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void UpdateMemberDetails(object sender, EventArgs e)
        {
            try
            {
                int a = newMember.UpdateMemberDetails(Convert.ToInt32(memberId.Value), txtName.Text, txtEmail.Text, txtPhone.Text, Convert.ToInt32(membershipType.Value), txtAddress.Text);
                lblMessage.Text = "Member updated successfully.";
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