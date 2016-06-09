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
    public partial class download_all_hr : System.Web.UI.Page
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
            if (Session["is_login"] != null)
            {
                if (Session["is_login"].ToString() == "t")
                {
                    fill_grid();

                }
                else
                {
                    Response.Redirect("~/unauthorised.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
        protected void grd_leave_dwnld_PreRender(object sender, EventArgs e)
        {
            if (grd_leave_dwnld.Rows.Count > 0)
            {
                grd_leave_dwnld.UseAccessibleHeader = true;
                grd_leave_dwnld.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void fill_grid()
        {
            DataTable dt = bus.fill_leves_appr_all();
            grd_leave_dwnld.DataSource = dt;
            grd_leave_dwnld.DataBind();
        }

        protected void lnkdwnld_all_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(grd_leave_dwnld.DataKeys[row.RowIndex].Value.ToString());
            int region_id = int.Parse(row.Cells[1].Text.ToString());
            download_leaves(id, region_id);
        }

        private void download_leaves(int id, int rid)
        {
            bus.lid = id;
            DataTable dt = bus.fetch_download_leaves();
            int reg = rid;
            if (dt.Rows.Count > 0)
            {
                if (reg == 2)
                {
                    rd.Load(Server.MapPath(Request.ApplicationPath) + "/user/approved.rpt");
                    rd.SetDataSource(dt);
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Approved_Leave");
                }
                else if (reg == 1)
                {
                    rd.Load(Server.MapPath(Request.ApplicationPath) + "/user/approved_malaysia.rpt");
                    rd.SetDataSource(dt);
                    rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Approved_Leave");
                }
            }
        }

    }
}