using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eleave_c;
using System.Web.Services;

namespace eleave_view.hr
{
    public partial class edituser : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        DataTable dt;
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
                fillgender();
                filldep();
                fillregion();
                txtdoje.Attributes.Add("readonly", "readonly");
                txtcategory.Attributes.Add("readonly", "readonly");
                fill_details();

            }
            else
            {
                Response.Redirect("~/unauthorised.aspx");
            }
        }

        [WebMethod]
        public static List<Event> disdates()
        {
            List<Event> dates = new List<Event>();
            bus_eleave bus = new bus_eleave();
            DataTable dt = bus.fetchdisdates();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Event _holiday = new Event();
                _holiday.EventDate = dt.Rows[i]["dates"].ToString();
                dates.Add(_holiday);
            }
            return dates;
        }

        public void fill_details()
        {
            bus.id = int.Parse(Session["edit_id"].ToString());
            dt = bus.fill_details_user_edit();
            if(dt.Rows.Count > 0)
            {               
                txtname.Text = dt.Rows[0][1].ToString();
                txtuname.Text = dt.Rows[0][2].ToString();
                txtdoje.Text = dt.Rows[0][4].ToString();
                ddlgender.Items.FindByText(dt.Rows[0][3].ToString()).Selected = true;
                ddldep.Items.FindByValue(dt.Rows[0][5].ToString()).Selected = true;
                filldesignation(int.Parse(dt.Rows[0][5].ToString()));
                fillgrade(int.Parse(dt.Rows[0][6].ToString()));
                ddlregion.Items.FindByValue(dt.Rows[0][8].ToString()).Selected = true;
            }
            else
            {

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

        public void filldesignation(int dp)
        {
            bus.id = dp;
            DataTable dt1 = bus.fetchdesignation();
            ddldesi.DataSource = dt1;
            ddldesi.DataBind();
            ddldesi.Items.Insert(0, new ListItem("-----SELECT-----", ""));
            ddldesi.Items.FindByValue(dt.Rows[0][6].ToString()).Selected = true;
        }

        public void fillgrade(int gr)
        {
            bus.id = gr;
            DataTable dt2 = bus.fetchgrade();
            ddlgrade.DataSource = dt2;
            ddlgrade.DataBind();
            txtcategory.Text = dt2.Rows[0][2].ToString();
        }

        protected void fillregion()
        {
            DataTable reg = bus.fillregion();
            ddlregion.DataSource = reg;
            ddlregion.DataBind();
            ddlregion.Items.Insert(0, new ListItem("-----SELECT-----", ""));
        }

        protected void btnupuser_Click(object sender, EventArgs e)
        {
            bus.id = int.Parse(Session["edit_id"].ToString());
            bus.name = txtname.Text.Trim();
            bus.user_name = txtuname.Text.Trim();
            bus.gender = ddlgender.SelectedItem.ToString().Trim();
            bus.doj = DateTime.Parse(txtdoje.Text.Trim());
            bus.dep = int.Parse(ddldep.SelectedValue.ToString());
            //string d = ddldesi.SelectedValue.ToString();
            bus.desi = int.Parse(Request.Form[ddldesi.UniqueID]);
            //string g =  Request.Form[ddlgrade.UniqueID];
            bus.grade = int.Parse(Request.Form[ddlgrade.UniqueID]);
            bus.region = int.Parse(ddlregion.SelectedValue.ToString());
            int r = bus.update_user();
            if (r == 1)
            {
                clearfeilds();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else if (r == 2)
            {
                clearfeilds();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error_dupli();", true);
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
            txtdoje.Text = "";
            ddlgender.SelectedIndex = 0;
            ddldep.SelectedIndex = 0;
            ddlgrade.SelectedIndex = 0;
            ddldesi.SelectedIndex = 0;
            ddlregion.SelectedIndex = 0;
            Session["edit_id"] = "";
        }
    }
}