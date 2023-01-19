using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Phanmacy_Management_System.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        private string Constring = ConfigurationManager.ConnectionStrings["pharmacy"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AdminBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Constring))
            {
                try
                {
                    string query = @"select sellerName,sellerPas from Seller where sellerName ='" + adminname.Value + "'  and sellerPas='" + adminpass.Value + "'";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if(sdr.Read())
                    {
                        Session["id"] = adminname.Value;
                        Response.Redirect("~/Admin/Billing.aspx");
                    }
                    else
                    {
                        msgadmin.Visible = true;
                        msgadmin.Text = "Information Not Match";
                        msgadmin.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception)
                {

                    msgadmin.Visible = true;
                    msgadmin.Text = "Invalid Seller";
                    msgadmin.ForeColor = System.Drawing.Color.Red;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}

// if(cmd.Parameters.Count == 0)
//{
//    msgadmin.Visible = true;
//    msgadmin.Text = "Invalid Seller";
//    msgadmin.ForeColor = System.Drawing.Color.Red;
//}