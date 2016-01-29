using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eleave_c;
using System.Data;
using System.Web.Services;

namespace eleave_view.user
{
    public partial class chg_pass : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static int oldpchk(int userid, string oldp)
        {
            bus_eleave bus = new bus_eleave();
            bus.userid = userid;
            bus.password = oldp;
            int r = bus.oldpchk();
            return r;
        }
        public void clear()
        {
            txt_oldpwd.Text = "";
            txt_nwpwd.Text = "";
            txt_conf_nwpwd.Text = "";
        }

        protected void btncp_Click(object sender, EventArgs e)
        {
            if (txt_oldpwd.Text != "" && txt_nwpwd.Text != "" && txt_conf_nwpwd.Text != "")
            {
                bus.userid = int.Parse(Session["user_id"].ToString());
                bus.oldp = txt_oldpwd.Text;
                bus.newp = txt_conf_nwpwd.Text;
                int r = bus.updatepwd();
                if (r == 1)
                {
                    clear();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_pwd();", true);
                }
                else if (r == 2)
                {
                    clear();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_pwd();", true);
                }
                else
                {
                    clear();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_old();", true);
                }
            }
        }
    }
}