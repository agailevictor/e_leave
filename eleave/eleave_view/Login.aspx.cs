    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eleave_c;

namespace eleave_view
{
    public partial class Login : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                inval.Visible = false;
            }
        }

        protected void logi_Click(object sender, EventArgs e)
        {
            if (username.Text != "" && password.Text != "")
            {
                bus.user_name = username.Text;
                bus.password = password.Text;
                int res = bus.check_login();
                if (res == 1)
                {
                    inval.Visible = false;
                    set_sessions();

                }
                else
                {
                    username.Text = "";
                    password.Text = "";
                    inval.Visible = true;
                }
            }
            else
            {
            }
        }

        public void set_sessions()
        {
            bus.user_name = username.Text;
            DataTable dt = bus.fetch_userdetails();
            if (dt.Rows.Count > 0)
            {
                Session["user_id"] = dt.Rows[0][0].ToString();
                Session["name"] = dt.Rows[0][1].ToString();
                Session["gender"] = dt.Rows[0][2].ToString();
                Session["doj"] = dt.Rows[0][3].ToString();
                Session["dep"] = dt.Rows[0][4].ToString();
                Session["des"] = dt.Rows[0][5].ToString();
                Session["role"] = dt.Rows[0][6].ToString();
                Session["is_login"] = "t";
                if (Session["role"].ToString() == "User")
                {
                    Response.Redirect("~/user/dash.aspx");
                }
                else if (Session["role"].ToString() == "HR")
                {
                    Response.Redirect("~/hr/hrdash.aspx");
                }
                else if (Session["role"].ToString() == "Management")
                {
                    Response.Redirect("~/md/dash.aspx");
                }
                else
                {
                    Response.Redirect("~/unauthorised.aspx");
                }
            }
            else
            {
            }
        }

    }
}