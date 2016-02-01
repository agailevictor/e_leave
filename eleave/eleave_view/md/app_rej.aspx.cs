using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eleave_c;

namespace eleave_view.md
{
    public partial class app_rej : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        int f;
        CheckBox cbox;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                checklogin();
            }
        }

        protected void checklogin()
        {
            if (Session["is_login"].ToString() == "t")
            {
                fillleavesapr();

            }
            else
            {
                Response.Redirect("~/unauthorised.aspx");
            }
        }

        protected void fillleavesapr()
        {
            DataTable dt = bus.fillleavesapr();
            if (dt.Rows.Count > 0)
            {
                grd_app_rej.DataSource = dt;
                grd_app_rej.DataBind();
            }
            else
            {
                grd_app_rej.DataSource = null;
                grd_app_rej.DataBind();
                btnaccept.Visible = false;
                btnreject.Visible = false;
            }
        }

        protected Boolean Isenable(string ltype)
        {
            if (ltype == "Medical")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void lnk_dwn_Click(object sender, EventArgs e)
        {
            LinkButton lnkbtn = sender as LinkButton;
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            string filePath = gvrow.Cells[9].Text.ToString();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
            Response.TransmitFile(Server.MapPath(filePath));
            Response.End();
        }

        protected void grd_app_rej_PreRender(object sender, EventArgs e)
        {
            if (grd_app_rej.Rows.Count > 0)
            {
                grd_app_rej.UseAccessibleHeader = true;
                grd_app_rej.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void lnkforward_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(grd_app_rej.DataKeys[row.RowIndex].Value.ToString());
            bus.lid = id;
            int r = bus.approve_leave();
            if (r == 1)
            {
                fillleavesapr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else
            {
                fillleavesapr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
        }

        protected void lnkreject_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(grd_app_rej.DataKeys[row.RowIndex].Value.ToString());
            bus.lid = id;
            int r = bus.reject_leave_md();
            if (r == 1)
            {
                fillleavesapr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else
            {
                fillleavesapr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
        }

        protected void btnaccept_Click(object sender, EventArgs e)
        {
            f = 1;
            foreach (GridViewRow row in grd_app_rej.Rows)
            {
                cbox = (CheckBox)row.FindControl("chk"); //RowSelector is the id of checkbox in Grid View
                if (cbox.Checked == true)
                {
                    // Fetch request's id
                    int RequestId = Convert.ToInt32(grd_app_rej.DataKeys[row.RowIndex].Value);

                    // Write your approval logic here
                    bus.lid = RequestId;
                    int r = bus.approve_leave();
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
                fillleavesapr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else if (f == 2)
            {
                fillleavesapr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
            else
            {
                fillleavesapr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning();", true);
            }
        }

        protected void btnreject_Click(object sender, EventArgs e)
        {
            f = 1;
            foreach (GridViewRow row in grd_app_rej.Rows)
            {
                cbox = (CheckBox)row.FindControl("chk"); //RowSelector is the id of checkbox in Grid View
                if (cbox.Checked == true)
                {
                    // Fetch request's id
                    int RequestId = Convert.ToInt32(grd_app_rej.DataKeys[row.RowIndex].Value);

                    // Write your approval logic here
                    bus.lid = RequestId;
                    int r = bus.reject_leave_md();
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
                fillleavesapr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else if (f == 2)
            {
                fillleavesapr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
            else
            {
                fillleavesapr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning();", true);
            }
        }
    }
}