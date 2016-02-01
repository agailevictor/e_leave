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
    public partial class adduser : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
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
                fillgender();
                filldep();
                fillregion();
                txtdoj.Attributes.Add("readonly", "readonly");
                txtcategory.Attributes.Add("readonly", "readonly");

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

        protected void fillregion()
        {
            DataTable reg = bus.fillregion();
            ddlregion.DataSource = reg;
            ddlregion.DataBind();
            ddlregion.Items.Insert(0, new ListItem("-----SELECT-----", ""));
        }

        protected void btnreq_hr_Click(object sender, EventArgs e)
        {
            bus.name = txtname.Text.Trim();
            bus.user_name = txtuname.Text.Trim();
            bus.gender = ddlgender.SelectedItem.ToString().Trim();
            bus.doj = DateTime.Parse(txtdoj.Text.Trim());
            bus.dep = int.Parse(ddldep.SelectedValue.ToString());
            //string d = ddldesi.SelectedValue.ToString();
            bus.desi = int.Parse(Request.Form[ddldesi.UniqueID]);
            //string g =  Request.Form[ddlgrade.UniqueID];
            bus.grade = int.Parse(Request.Form[ddlgrade.UniqueID]);
            bus.region = int.Parse(ddlregion.SelectedValue.ToString());
            int r = bus.add_user();
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
            txtdoj.Text = "";
            ddlgender.SelectedIndex = 0;
            ddldep.SelectedIndex = 0;
            ddlgrade.SelectedIndex = 0;
            ddldesi.SelectedIndex = 0;
            ddlregion.SelectedIndex = 0;
        }

        //protected void ddldep_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    bus.lid = int.Parse(ddldep.SelectedValue.ToString());
        //    DataTable des = bus.fetchdesignation();
        //    ddldesi.DataSource = des;
        //    ddldesi.DataBind();
        //    ddldesi.Items.Insert(0, new ListItem("-----SELECT-----", ""));
        //}

        //protected void ddldesi_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    bus.lid = int.Parse(ddldesi.SelectedValue.ToString());
        //    DataTable gd = bus.fetchgrade();
        //    ddlgrade.DataSource = gd;
        //    ddlgrade.DataBind();
        //    txtcategory.Text = gd.Rows[0][2].ToString();
        //}
        [WebMethod]
        public static List<Desi> filldesi(int dep)
        {
            List<Desi> des = new List<Desi>();
            bus_eleave bus = new bus_eleave();
            bus.id = dep;
            DataTable dt = bus.fetchdesignation();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Desi _Desi = new Desi();
                _Desi.dsg_id = int.Parse(dt.Rows[i]["dsg_id"].ToString());
                _Desi.designation = dt.Rows[i]["designation"].ToString();
                des.Add(_Desi);
            }
            return des;
        }

        [WebMethod]
        public static List<grade> fillgrade(int grade)
        {
            List<grade> grd = new List<grade>();
            bus_eleave bus = new bus_eleave();
            bus.id = grade;
            DataTable dt = bus.fetchgrade();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grade _grade = new grade();
                _grade.grade_id = int.Parse(dt.Rows[i]["grade_id"].ToString());
                _grade.grade_desc = dt.Rows[i]["grade_desc"].ToString();
                _grade.category = dt.Rows[i]["category"].ToString();
                grd.Add(_grade);
            }
            return grd;
        }
    }
}