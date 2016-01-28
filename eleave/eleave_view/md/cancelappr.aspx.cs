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
    }
}