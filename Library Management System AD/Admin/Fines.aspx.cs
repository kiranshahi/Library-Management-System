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
    public partial class Fines : System.Web.UI.Page
    {
        Fine newFine = new Fine();
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
                    string QueryString = "select * from loans";

                    SqlConnection myConnection = new SqlConnection(connectString);
                    SqlDataAdapter myCommand = new SqlDataAdapter(QueryString, myConnection);
                    DataSet ds = new DataSet();
                    myCommand.Fill(ds, "loans");

                    loanList.DataSource = ds;
                    loanList.DataTextField = "id";
                    loanList.DataValueField = "id";
                    loanList.DataBind();
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void BtnAddFines(object sender, EventArgs e)
        {
            try
            {
                newFine.ChargeFine(Convert.ToInt32(txtRate.Text), Convert.ToInt32(loanList.Value));
                lblMessage.Text = "Fine charged successfully.";
                lblMessage.ForeColor = Color.Green;
            }
            catch (Exception exception)
            {
                lblMessage.Text = "Some error occurred while charging fine. Error details: " + exception.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}