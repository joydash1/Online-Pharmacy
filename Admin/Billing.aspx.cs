using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Phanmacy_Management_System.Admin
{
    public partial class Billing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] == null)
                {
                    Response.Redirect("~/Admin/Login.aspx");
                }
            }
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/Admin/Login.aspx");
        }
    }
}