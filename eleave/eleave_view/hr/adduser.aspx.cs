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
    public partial class adduser : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillgender();
                filldep();
                txtdoj.Attributes.Add("readonly", "readonly");
            }
        }

        protected void fillgender()
        {
            DataTable dtg = bus.fillgender();
            ddlgender.DataSource = dtg;
            ddlgender.DataBind();
            ddlgender.Items.Insert(0, new ListItem("-----SELECT-----", ""));
        }

        protected void filldep()
        {
            DataTable dtdep = bus.filldep();
            ddldep.DataSource = dtdep;
            ddldep.DataBind();
            ddldep.Items.Insert(0, new ListItem("-----SELECT-----", ""));
        }

        protected void btnreq_hr_Click(object sender, EventArgs e)
        {
            bus.name = txtname.Text.Trim();
            bus.user_name = txtuname.Text.Trim();
            bus.gender = ddlgender.Text.ToString().Trim();
            bus.doj = DateTime.Parse(txtdoj.Text.Trim());
            bus.dep = int.Parse(ddldep.SelectedValue.ToString());
            bus.grade = int.Parse(ddlgrade.SelectedValue.ToString());
            bus.desi = int.Parse(ddldesi.SelectedValue.ToString());
            bus.region = int.Parse(ddlregion.SelectedValue.ToString());
            int r = bus.add_user();
            if (r == 1)
            {
                clearfeilds();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else
            {
                clearfeilds();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
        }

        protected void clearfeilds()
        {
            txtname.Text = "";
            txtuname.Text = "";
            txtdoj.Text = "";
            ddlgender.SelectedIndex = 0;
            ddldep.SelectedIndex = 0;
            ddlgrade.SelectedIndex = 0;
            ddldesi.SelectedIndex = 0;
            ddlregion.SelectedIndex = 0;
        }
    }
}