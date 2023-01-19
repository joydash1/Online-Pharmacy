using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Online_Phanmacy_Management_System.Admin
{
    public partial class Medicines : System.Web.UI.Page
    {
        private string Constring = ConfigurationManager.ConnectionStrings["pharmacy"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetMedicineList();
                GetCategory();
                MedUpdateBtn.Visible = false;
            }
        }
        public void GetMedicineList()
        {
            SqlConnection conn = new SqlConnection(Constring);
            string query = @"select * from Medicine";
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            MedicineRepeater.DataSource = dt;
            MedicineRepeater.DataBind();
        }
        private void GetCategory()
        {
            SqlConnection conn = new SqlConnection(Constring);
            string query = @"select * from Category";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            CatDropDownlist.DataSource = cmd.ExecuteReader();
            CatDropDownlist.DataTextField = "CategoryName";
            CatDropDownlist.DataValueField = "categoryId";
            CatDropDownlist.DataBind();
        }
        protected void MedInsertBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Constring))

                if (medcode.Value == null)
                {
                    Response.Write("<script>alert('Something Goes Wrong Try Again Later!!')</script>");
                }

                else
                {
                    try
                    {
                        conn.Open();
                        string query = @"insert into Medicine (medCode,medName,medPrice,medStock,medExpDate,categoryId) 
                        values(@medCode,@medName,@medPrice,@medStock,@medExpDate,@categoryId)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@medCode", medcode.Value);
                        cmd.Parameters.AddWithValue("@medName", medname.Value);
                        cmd.Parameters.AddWithValue("@medPrice",medprice.Value);
                        cmd.Parameters.AddWithValue("@medStock", medstock.Value);
                        cmd.Parameters.AddWithValue("@medExpDate", medexpairedate.Value);
                        cmd.Parameters.AddWithValue("@categoryId", CatDropDownlist.SelectedValue);
                        //cmd.Parameters.AddWithValue("@medPrice", Convert.ToInt32(medprice.Value));
                        //cmd.Parameters.AddWithValue("@medStock", Convert.ToInt32(medstock.Value));
                        //cmd.Parameters.AddWithValue("@medExpDate", Convert.ToDateTime(medexpairedate.Value));
                        //cmd.Parameters.AddWithValue("@categoryId", Convert.ToInt32(CatDropDownlist.SelectedValue));
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        GetMedicineList();
                        Clear();
                        Response.Write("<script>alert('Medicine details Inserted SuccessFully!!')</script>");
                    }
                    catch (Exception)
                    {
                        Response.Write("<script>alert('Medicine details Not Inserted ')</script>");
                    }

                    finally
                    {
                        conn.Close();
                    }
                }
        }

        private void Clear()
        {
            medcode.Value = string.Empty;
            medname.Value = string.Empty;
            medstock.Value = string.Empty;
            medprice.Value = string.Empty;
            medexpairedate.Value = string.Empty;
            CatDropDownlist.SelectedValue = string.Empty;
        }

        protected void MedicineRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                MedUpdateBtn.Visible = true;
                MedInsertBtn.Visible = false;
                medlbl.Visible = true;
                medlbl.Text = e.CommandArgument.ToString();

                Label lblmedcode = e.Item.FindControl("lblmedcode") as Label;
                medcode.Value = lblmedcode.Text.ToString();

                Label lblmedname = e.Item.FindControl("lblmedname") as Label;
                medname.Value = lblmedname.Text.ToString();

                Label lblmedeprice = e.Item.FindControl("lblmedeprice") as Label;
                medprice.Value = lblmedeprice.Text.ToString();

                Label lblmedstock = e.Item.FindControl("lblmedstock") as Label;
                medstock.Value = lblmedstock.Text.ToString();

                Label lblmedexp = e.Item.FindControl("lblmedexp") as Label;
                medexpairedate.Value = lblmedexp.Text.ToString();

                Label lblmedcat = e.Item.FindControl("lblmedcat") as Label;
                CatDropDownlist.SelectedValue = lblmedcat.Text.ToString();
            }
            else if (e.CommandName == "delete")
            {
                SqlConnection conn = new SqlConnection(Constring);
                conn.Open();
                string query = @"delete from Medicine where medCode = @medCode";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@medCode", e.CommandArgument);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Row delete SuccessFully!!')</script>");
                conn.Close();
                GetMedicineList();
            }
        }

        protected void MedUpdateBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Constring))

                if (medcode.Value == null || medname.Value == null || medprice.Value == null || medstock.Value == null
                    || medexpairedate.Value == null || CatDropDownlist.SelectedValue == null)
                {
                    Response.Write("<script>alert('Something Goes Wrong Try Again Later')</script>");
                }

                else
                {
                    try
                    {
                        conn.Open();
                        string query = @"update Medicine set  medCode=@medCode,medName=@medName,medPrice=@medPrice,medStock=@medStock,medExpDate=@medExpDate,categoryId=@categoryId where medID=@medID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@medID", Convert.ToInt32(medlbl.Text));
                        cmd.Parameters.AddWithValue("@medCode",medcode.Value);
                        cmd.Parameters.AddWithValue("@medName", medname.Value);
                        cmd.Parameters.AddWithValue("@medPrice", medprice.Value);
                        cmd.Parameters.AddWithValue("@medStock", medstock.Value);
                        cmd.Parameters.AddWithValue("@medExpDate", medexpairedate.Value);
                        cmd.Parameters.AddWithValue("@categoryId", CatDropDownlist.SelectedValue);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        GetMedicineList();
                        Clear();
                        Response.Write("<script>alert('Medicine Update SuccessFully!!')</script>");

                    }
                    catch (Exception)
                    {
                        Response.Write("<script>alert('Medicine Update Goes Wrong Try Again Later')</script>");
                    }

                    finally
                    {
                        conn.Close();
                    }
                }
        }
    }
}
//cmd.Parameters.AddWithValue("@medCode", Convert.ToInt32(medlbl.Text));
//cmd.Parameters.AddWithValue("@medCode", medcode.Value);
//cmd.Parameters.AddWithValue("@medName", medname.Value);
//cmd.Parameters.AddWithValue("@medPrice", Convert.ToInt32(medprice.Value));
//cmd.Parameters.AddWithValue("@medStock", Convert.ToInt32(medstock.Value));
//cmd.Parameters.AddWithValue("@medExpDate", Convert.ToDateTime(medexpairedate.Value));
//cmd.Parameters.AddWithValue("@categoryId", Convert.ToInt32(CatDropDownlist.SelectedValue));