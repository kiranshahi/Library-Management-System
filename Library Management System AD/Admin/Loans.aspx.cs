using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System_AD.Admin
{
    public partial class Loans : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ConnectString = "Data Source=DESKTOP-CK5EETK;Initial Catalog=LMSdb;Integrated Security=True";
                string QueryString = "select * from loan_types";

                SqlConnection myConnection = new SqlConnection(ConnectString);
                SqlDataAdapter myCommand = new SqlDataAdapter(QueryString, myConnection);
                DataSet ds = new DataSet();
                myCommand.Fill(ds, "loan_types");

                loanType.DataSource = ds;
                loanType.DataTextField = "type";
                loanType.DataValueField = "id";
                loanType.DataBind();
            }
        }

        protected void BtnAddLoan(object sender, EventArgs e)
        {

        }
    }
}