using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eleave_c;
using System.Globalization;

namespace eleave_view.user
{
    public partial class cancel : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        string a, a1;
        DateTime dt1, dt2;
        int chk;
        Boolean ret;
        CultureInfo provider = CultureInfo.InvariantCulture;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fill_user_approved_leaves();
            }
        }

        public void fill_user_approved_leaves()
        {
            bus.userid = int.Parse(Session["user_id"].ToString());
            DataTable dt = bus.fill_user_approved_leaves();
            grd_cancel.DataSource = dt;
            grd_cancel.DataBind();
        }

        protected void lnkcancel_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(grd_cancel.DataKeys[row.RowIndex].Value.ToString());
            //string adates = row.Cells[3].Text.Trim();
            bus.lid = id;
            int r = bus.initiate_cancel();
            if (r == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else
            {
                fill_user_approved_leaves();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
        }

        protected Boolean Isvisible(string dates)
        {
            a = dates.Trim();
            ret = false;
            string[] values = a.Split(',');
            for (int i = 0; i < values.Length; i++)
            {
                a1 = values[i].ToString();
                DateTime dt1 = DateTime.Parse(a1);
                DateTime dt2 = DateTime.Now;
                if (dt1 > dt2)
                {
                    ret = true;
                }

            }

            return ret;
        }

        protected void grd_cancel_PreRender(object sender, EventArgs e)
        {
            if(grd_cancel.Rows.Count > 0)
            {
            grd_cancel.UseAccessibleHeader = true;
            grd_cancel.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}