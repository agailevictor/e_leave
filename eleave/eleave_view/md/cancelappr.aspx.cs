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
    public partial class cancelappr : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        string idate, a, a1, output, period;
        DateTime dt1, dt2;
        int chk;
        double ct;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fillcancapprl();
            }
        }

        protected void fillcancapprl()
        {
            DataTable dt = bus.fillcancapprl();
            grdcancelappr.DataSource = dt;
            grdcancelappr.DataBind();
        }

        protected void lnkapprove_Click(object sender, EventArgs e)
        {
            chk = 0;
            ct = 0;
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(grdcancelappr.DataKeys[row.RowIndex].Value.ToString());
            a = row.Cells[5].Text.ToString().Trim();
            period = row.Cells[6].Text.ToString().Trim();
            idate = row.Cells[8].Text.ToString().Trim();
            string[] values = a.Split(',');
            DataTable nc = new DataTable();
            nc.Columns.Add("Date", typeof(string));
            for (int i = 0; i < values.Length; i++)
            {
                a1 = values[i].ToString();
                dt1 = DateTime.Parse(a1);
                dt2 = DateTime.Parse(idate);
                if (dt1 < dt2)
                {
                    //can't cancel that leave
                    // get the count of the leaves, update the days requested to these days
                    nc.Rows.Add(a1);
                    ct = ct + 1;
                    chk = 1;
                }
                else
                {
                    // can cancel that leave dont do anything
                }

            }

            if(chk == 0)
            {
                // cancel all leaves
                bus.lid = id;
                int r = bus.cancel_all_approved();
                if(r==1)
                {
                    fillcancapprl();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                }
                else
                {
                    fillcancapprl();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
                }
            }
            else
            {
                // cancel the leaves that are not in datatable and update the dates requested with the dates in datatable and the count

                for (int i = 0; i < nc.Rows.Count; i++)
                {
                    output = output + nc.Rows[i]["Date"].ToString();
                    output += (i < nc.Rows.Count -1) ? "," : string.Empty;
                }

                bus.lid = id;
                bus.dates = output;
                if(period == "Full Day")
                {
                bus.rdays = ct;
                }
                else{
                    bus.rdays = ct/2;
                }
                int r = bus.cancel_av_approved();
                if (r == 1)
                {
                    fillcancapprl();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                }
                else
                {
                    fillcancapprl();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
                }             
            }
        }

        protected void lnkreject_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(grdcancelappr.DataKeys[row.RowIndex].Value.ToString());
            bus.lid = id;
            int r = bus.reject_can_appr();
            if (r == 1)
            {
                fillcancapprl();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else
            {
                fillcancapprl();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
        }

        protected void grdcancelappr_PreRender(object sender, EventArgs e)
        {
            if (grdcancelappr.Rows.Count > 0)
            {
                grdcancelappr.UseAccessibleHeader = true;
                grdcancelappr.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}