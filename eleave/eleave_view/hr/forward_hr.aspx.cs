using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eleave_c;

namespace eleave_view.hr
{
    public partial class forward_hr : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        int f;
        CheckBox cbox;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillleavesfr();
            }
        }

        protected void fillleavesfr()
        {
            DataTable dt = bus.fillleavesfr();
            if (dt.Rows.Count > 0)
            {
                grd_forward.DataSource = dt;
                grd_forward.DataBind();
            }
            else
            {
                grd_forward.DataSource = null;
                grd_forward.DataBind();
                btnaccept.Visible = false;
                btnreject.Visible = false;
            }
        }

        protected void btnaccept_Click(object sender, EventArgs e)
        {
            f = 1;
            foreach (GridViewRow row in grd_forward.Rows)
            {
                cbox = (CheckBox)row.FindControl("chk"); //RowSelector is the id of checkbox in Grid View
                if (cbox.Checked == true)
                {
                    // Fetch request's id
                    int RequestId = Convert.ToInt32(grd_forward.DataKeys[row.RowIndex].Value);

                    // Write your approval logic here
                    bus.lid = RequestId;
                    int r = bus.forward_leave();
                    if (r == 1)
                    {
                        f = 0;
                    }
                    else
                    {
                        f = 2;
                    }

                }

            }
            if (f == 0)
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else if(f == 2)
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
            else
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning();", true);
            }

        }

        protected void btnreject_Click(object sender, EventArgs e)
        {

            f = 1;
            foreach (GridViewRow row in grd_forward.Rows)
            {
                cbox = (CheckBox)row.FindControl("chk"); //RowSelector is the id of checkbox in Grid View
                if (cbox.Checked == true)
                {
                    // Fetch request's id
                    int RequestId = Convert.ToInt32(grd_forward.DataKeys[row.RowIndex].Value);

                    // Write your approval logic here
                    bus.lid = RequestId;
                    int r = bus.reject_leave();
                    if (r == 1)
                    {
                        f = 0;
                    }
                    else
                    {
                        f = 2;
                    }

                }

            }
            if (f == 0)
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else if (f == 2)
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
            else
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning();", true);
            }
        }

        protected void lnkforward_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(grd_forward.DataKeys[row.RowIndex].Value.ToString());
            bus.lid = id;
            int r = bus.forward_leave();
            if (r == 1)
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }

        }

        protected void lnkreject_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(grd_forward.DataKeys[row.RowIndex].Value.ToString());
            bus.lid = id;
            int r = bus.reject_leave();
            if (r == 1)
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
        }


    }
}