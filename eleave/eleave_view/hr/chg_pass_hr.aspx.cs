using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eleave_c;
using System.Data;

namespace eleave_view.hr
{
    public partial class chg_pass_hr : System.Web.UI.Page
    {
        bus_eleave_HS obj = new bus_eleave_HS();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int res;
            int old = checkold();
            if(old==1)
            {
                if (nwpwd_hr_txt.Text == conf_nwpwd_hr_txt.Text)
                {
                    obj.userid = int.Parse(Session["user_id"].ToString());
                    obj.nwpwd = nwpwd_hr_txt.Text;
                    res=obj.updatepwd();
                    if(res==1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success_pwd();", true);                      
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_pwd();", true);                      
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "pwd_match_fail();", true);                      
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);                      
            }
        }

        public int checkold()
        {
            obj.userid = int.Parse(Session["user_id"].ToString());
            int res=obj.checkold();
            return res;   
        }

        public void clear()
        {
            oldpwd_hr_txt.Text = "";
            nwpwd_hr_txt.Text = "";
            conf_nwpwd_hr_txt.Text = "";
        }
    }
}