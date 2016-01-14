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

namespace eleave_view.hr
{
    public partial class status_leave_hr : System.Web.UI.Page
    {
        bus_eleave obj = new bus_eleave();
        ReportDocument rd = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checklogin();
                //fill_grid();
            }           
        }

        public void checklogin()
        {
            if (Session["is_login"].ToString() == "f")
            {
                Response.Redirect("~/MainPage.aspx");

            }
            else
            {
                fill_grid_hr();
            }
        }

        //To bind the grid with datatable
        protected void fill_grid_hr()
        {
            obj.userid = int.Parse(Session["user_id"].ToString());
            DataTable dt = obj.fill_grid();
            status_hr.DataSource = dt;
            status_hr.DataBind();
        }

        protected Boolean Isenable(string Status)
        {
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
            if (Status == "HR Level Pending")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            status_hr.PageIndex = e.NewPageIndex;
            fill_grid_hr();
        }

        //Cancelling user applied leaves
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            int id = int.Parse(status_hr.DataKeys[row.RowIndex].Value.ToString());
            obj.lid = id;
            int r = obj.cancel_leave();
            if (r == 1)
            {
                fill_grid_hr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else
            {
                fill_grid_hr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(status_hr.DataKeys[row.RowIndex].Value.ToString());
            download_leave_hr(id);
        }   
       
        public void download_leave_hr(int id)
        {
            obj.lid = id;
            DataTable dt = obj.fetch_download_leaves();
            if (dt.Rows.Count > 0)
            {
                rd.Load(Server.MapPath(Request.ApplicationPath) + "/hr/download_approved_hr.rpt");
                rd.SetDataSource(dt);
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Approved_Leave");
            }
        }
    }
}