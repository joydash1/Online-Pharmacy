using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Phanmacy_Management_System.Admin
{
    public partial class Seller : System.Web.UI.Page
    {
        private string constring = ConfigurationManager.ConnectionStrings["pharmacy"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SellerEditBtn.Visible = false;
                GetSellerLIst();
            }
        }

        private void GetSellerLIst()
        {
            SqlConnection conn = new SqlConnection(constring);
            string query = @"select * from Seller";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            SellerRepeater.DataSource = dt;
            SellerRepeater.DataBind();

        }

        protected void SellerInsertBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                if (sellername.Value == null || sellername.Value == null || sellerpass.Value == null ||
                   sellerdob.Value == null || GenderDropDownList.SelectedValue == null || sellerAddress.Value == null)
                {
                    Response.Write("<script>alert('Insert All data Field Please')</script>");
                }

                else
                {
                    try
                    {
                        conn.Open();
                        string query = @"insert into Seller (sellerName,sellerEmail,sellerPas,sellerDOB,sellerGender,sellerAddress) values (@sellerName,@sellerEmail,@sellerPas,@sellerDOB,@sellerGender,@sellerAddress)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@sellerName", sellername.Value);
                        cmd.Parameters.AddWithValue("@sellerEmail", selleremail.Value);
                        cmd.Parameters.AddWithValue("@sellerPas", sellerpass.Value);
                        cmd.Parameters.AddWithValue("@sellerDOB", Convert.ToDateTime(sellerdob.Value));
                        cmd.Parameters.AddWithValue("@sellerGender", GenderDropDownList.SelectedValue);
                        cmd.Parameters.AddWithValue("@sellerAddress", sellerAddress.Value);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        GetSellerLIst();
                        Clear();
                        Response.Write("<script>alert('Seller Information Inserted Successfully')</script>");
                    }
                    catch (Exception)
                    {
                        Response.Write("<script>alert(' Seller Information Not Inserted ! Try Again Later')</script>");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

            }
        }

        private void Clear()
        {
            sellername.Value = string.Empty;
            selleremail.Value = string.Empty;
            sellerpass.Value = string.Empty;
            sellerdob.Value = string.Empty;
            sellerAddress.Value = string.Empty;
        }

        protected void SellerRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {


            if (e.CommandName == "edit")
            {

                SellerInsertBtn.Visible = false;
                SellerEditBtn.Visible = true;
                msgsel.Visible = true;
                msgsel.Text = e.CommandArgument.ToString();
                
                Label sellerIDlbl = e.Item.FindControl("sellerIDlbl") as Label;
                sellername.Value = sellerIDlbl.Text.ToString();

                Label sellernamelbl = e.Item.FindControl("sellernamelbl") as Label;
                sellername.Value = sellernamelbl.Text.ToString();

                Label selleremaillbl = e.Item.FindControl("selleremaillbl") as Label;
                selleremail.Value = selleremaillbl.Text.ToString();

                Label sellerpasslbl = e.Item.FindControl("sellerpasslbl") as Label;
                sellerpass.Value = sellerpasslbl.Text.ToString();

                Label sellerDOBlbl = e.Item.FindControl("sellerDOBlbl") as Label;
                sellerdob.Value = sellerDOBlbl.Text.ToString();

                Label sellergenderlbl = e.Item.FindControl("sellergenderlbl") as Label;
                GenderDropDownList.SelectedValue = sellergenderlbl.Text.ToString();

                Label selleraddresslbl = e.Item.FindControl("selleraddresslbl") as Label;
                sellerAddress.Value = selleraddresslbl.Text.ToString();
            }
            else if (e.CommandName == "delete")
            {
                SqlConnection conn = new SqlConnection(constring);
                conn.Open();
                string query = @"delete from Seller where sellerId = @sellerId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@sellerId", e.CommandArgument);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Row delete SuccessFully!!')</script>");
                conn.Close();
                GetSellerLIst();
            }
        }

        protected void SellerEditBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(constring))
            {
                if (sellername.Value == null || selleremail.Value == null || sellerpass.Value == null || sellerdob.Value == null
                   || GenderDropDownList.SelectedValue == null || sellerAddress.Value == null)
                {
                    Response.Write("<script>alert('Something Goes Wrong Try Again Later')</script>");
                }
                else
                {
                    try
                    {

                        conn.Open();
                        string query = @"update Seller set sellerName=@sellerName,sellerEmail=@sellerEmail,sellerPas=@sellerPas,sellerDOB=@sellerDOB,sellerGender=@sellerGender,sellerAddress=@sellerAddress where sellerId = @sellerId";
                        SqlCommand cmd = new SqlCommand(query, conn);

                        cmd.Parameters.AddWithValue("@sellerId", Convert.ToInt32(msgsel.Text));
                        cmd.Parameters.AddWithValue("@sellerName", sellername.Value);
                        cmd.Parameters.AddWithValue("@sellerEmail", selleremail.Value);
                        cmd.Parameters.AddWithValue("@sellerPas", sellerpass.Value);
                        cmd.Parameters.AddWithValue("@sellerDOB", Convert.ToDateTime(sellerdob.Value));
                        cmd.Parameters.AddWithValue("@sellerGender", GenderDropDownList.SelectedValue);
                        cmd.Parameters.AddWithValue("@sellerAddress", sellerAddress.Value);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        Response.Write("<script>alert('Seller Information Update Successfully')</script>");
                        Clear();
                        GetSellerLIst();
                    }
                    catch (Exception)
                    {
                        Response.Write("<script>alert('Something Went Wrong ! Try Again Later')</script>");
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
        }
    }
}




