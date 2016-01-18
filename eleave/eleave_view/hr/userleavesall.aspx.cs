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
    public partial class userleavesall : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fill_leaves_all();
            }
        }

        protected void fill_leaves_all()
        {
            DataTable dt = bus.fill_leaves_all();
            grd_userleaves.DataSource = dt;
            grd_userleaves.DataBind();
        }

        protected void grd_userleaves_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_userleaves.PageIndex = e.NewPageIndex;
            fill_leaves_all();
        }
    }
}