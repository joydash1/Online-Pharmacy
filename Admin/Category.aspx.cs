using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Phanmacy_Management_System.Admin
{
    public partial class Category : System.Web.UI.Page
    {
        private string Constring = ConfigurationManager.ConnectionStrings["pharmacy"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GeTallCategory();
                CatUpdatebtn.Visible = false;
            }
        }

        public void GeTallCategory()
        {
            SqlConnection conn = new SqlConnection(Constring);
            string query = @"select * from Category";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CategoryRepeater.DataSource = dt;
            CategoryRepeater.DataBind();
        }
        protected void Categorybtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Constring))

                if (categoryname.Value == null)
                {
                    catmsg.Visible = true;
                    catmsg.Text = "Something Goes Wrong";
                    catmsg.ForeColor = System.Drawing.Color.Red;
                }

                else
                {
                    try
                    {
                        conn.Open();
                        string query = @"insert into Category values (@CategoryName)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@CategoryName", categoryname.Value);
                        cmd.ExecuteNonQuery();
                        catmsg.Visible = true;
                        catmsg.Text = "Category Inserted Successfully";
                        catmsg.ForeColor = System.Drawing.Color.Green;
                        conn.Close();
                        GeTallCategory();
                        clear();
                    }
                    catch (Exception)
                    {
                        catmsg.Visible = true;
                        catmsg.Text = "Something Goes Wrong";
                        catmsg.ForeColor = System.Drawing.Color.Red;
                    }

                    finally
                    {
                        conn.Close();
                    }
                }

        }
        private void clear()
        {
            categoryname.Value = string.Empty;

        }

        protected void CategoryRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                Categorybtn.Visible = false;
                CatUpdatebtn.Visible = true;
                catmsg.Visible = true;
                catmsg.Text = e.CommandArgument.ToString();

                Label lblcatname = e.Item.FindControl("lblcatname") as Label;
                categoryname.Value = lblcatname.Text.ToString();

            }

            else if (e.CommandName == "delete")
            {
                SqlConnection conn = new SqlConnection(Constring);
                conn.Open();
                string query = @"delete from Category where categoryId = @categoryId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@categoryId", Convert.ToInt32(e.CommandArgument));
                cmd.ExecuteNonQuery();
                conn.Close();
                GeTallCategory();
            }
        }

        protected void CategoryRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void CatUpdatebtn_Click(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(Constring))
            {
                try
                {
                    conn.Open();
                    string query = @"update category set CategoryName = @CategoryName where categoryId = @categoryId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@categoryId", Convert.ToInt32(catmsg.Text));
                    cmd.Parameters.AddWithValue("@CategoryName", categoryname.Value.Trim());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("<script>alert('Data Update SuccessFully!!')</script>");
                    clear();
                    GeTallCategory();

                }
                catch (Exception)
                {

                    Response.Write("<script>alert('Data Update Failed!!') </script>");
                }
                finally
                { conn.Close(); }

            }
        }
    }
}





