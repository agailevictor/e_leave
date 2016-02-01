using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eleave_c;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace eleave_view.user
{
    public partial class listleaves : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        ReportDocument rd = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checklogin();
            }
        }

        protected void checklogin()
        {
            if (Session["is_login"].ToString() == "t")
            {
                change_stat();
                fill_grid();

            }
            else
            {
                Response.Redirect("~/unauthorised.aspx");
            }
        }

        protected void change_stat()
        {
            bus.userid = int.Parse(Session["user_id"].ToString());
            bus.change_stat();
        }

        protected void fill_grid()
        {
            bus.userid = int.Parse(Session["user_id"].ToString());
            DataTable dt = bus.fill_grid();
            grd_leaves.DataSource = dt;
            grd_leaves.DataBind();
        }

        protected Boolean Isenable(string Status)
        {
            //string a = Status;
            if (Status == "Approved")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected Boolean Isvisible(string Status)
        {
            //string a = Status;
            if (Status == "HR Level Pending")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            int id = int.Parse(grd_leaves.DataKeys[row.RowIndex].Value.ToString());
            bus.lid = id;
            int r = bus.cancel_leave();
            if (r == 1)
            {
                fill_grid();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else
            {
                fill_grid();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
        }

        protected void lnldownload_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(grd_leaves.DataKeys[row.RowIndex].Value.ToString());
            download_leaves(id);
        }

        private void download_leaves(int id)
        {
            bus.lid = id;
            DataTable dt = bus.fetch_download_leaves();
            if (dt.Rows.Count > 0)
            {
                rd.Load(Server.MapPath(Request.ApplicationPath) + "/user/download_approved.rpt");
                rd.SetDataSource(dt);
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Approved_Leave");
            }
        }

        protected void grd_leaves_PreRender(object sender, EventArgs e)
        {
            if (grd_leaves.Rows.Count > 0)
            {
                grd_leaves.UseAccessibleHeader = true;
                grd_leaves.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}