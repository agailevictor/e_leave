using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eleave_view
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                check_multiple_login();
            }
        }

        public void check_multiple_login()
        {
            if (Session["is_login"] == "t")
            {
                if (Session["role"].ToString() == "User")
                {
                    Response.Redirect("~/user/dash.aspx");
                }
                else if (Session["role"].ToString() == "official")
                {
                    Response.Redirect("~/official/adduser.aspx");
                }
                else
                {
                    Response.Redirect("~/succ.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}