using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eleave_c;
using System.Data;
using System.Web.Services;

namespace eleave_view.hr
{
    public partial class chg_pass_hr : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if(oldpwd_hr_txt.Text !="" && nwpwd_hr_txt.Text !="" && conf_nwpwd_hr_txt.Text !="")
            {
                bus.userid = int.Parse(Session["user_id"].ToString());
                bus.oldp = oldpwd_hr_txt.Text;
                bus.newp = conf_nwpwd_hr_txt.Text;
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

        public void clear()
        {
            oldpwd_hr_txt.Text = "";
            nwpwd_hr_txt.Text = "";
            conf_nwpwd_hr_txt.Text = "";
        }
        [WebMethod]
        public static int oldpchk(int userid,string oldp)
        {
            bus_eleave bus = new bus_eleave();
            bus.userid = userid;
            bus.password = oldp;
            int r = bus.oldpchk();
            return r;
        }
    }
}