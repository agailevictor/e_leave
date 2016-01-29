using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eleave_c;
using System.Data;
using System.IO;
using System.Web.Services;
using System.Text.RegularExpressions;

namespace eleave_view.hr
{
    public partial class applyleave_hr : System.Web.UI.Page
    {
        bus_eleave obj = new bus_eleave();
        bus_eleave_HS obj1 = new bus_eleave_HS();
        string filename;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fill_lbl_hr();
                fill_ltype_hr();
                fill_period_hr();
                fill_collegues_hr();
                txtdate_hr.Attributes.Add("readonly", "readonly");
            }            
        }

        //To get dates. Called by Json
        [WebMethod]
        public static List<Event> disdates_hr(int userid)
        {
            List<Event> dates = new List<Event>();
            bus_eleave bus = new bus_eleave();
            //DataTable dt = bus.fetch_holidays1();
            DataTable dt2 = fetchdates(userid);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                Event _holiday = new Event();
                _holiday.EventDate = dt2.Rows[i]["dates1"].ToString();
                dates.Add(_holiday);
            }
            return dates;
        }

        public static DataTable fetchdates(int userid)
        {
            bus_eleave bus = new bus_eleave();
            bus.userid = userid;
            DataTable dt = bus.fetch_holidays1();
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("dates1");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string[] split = dt.Rows[i]["dates"].ToString().Split(',');
                for (int j = 0; j < split.Length; j++)
                {
                    DataRow dr = dt1.NewRow();
                    dr["dates1"] = split[j];
                    dt1.Rows.Add(dr);
                }
            }
            return dt1;
        }
        protected void btnreq_hr_Click(object sender, EventArgs e)
        {
            if (int.Parse(ddlltype_hr.SelectedValue.ToString()) == 2)
            {
                if (fupload_hr.HasFile)
                {
                    if (fupload_hr.PostedFile.ContentLength < 3145728)
                    {
                        String ext = System.IO.Path.GetExtension(fupload_hr.FileName);
                        if (ext == ".pdf")
                        {
                            FileInfo file = new System.IO.FileInfo(fupload_hr.PostedFile.FileName);
                            string fname = file.Name.Remove((file.Name.Length - file.Extension.Length));
                            fname = fname + System.DateTime.Now.ToString("_dd-MM-yy_hh;mm;ss") + file.Extension; // renaming file uploads
                            filename = Path.Combine(HttpContext.Current.Server.MapPath("~/uploads/"), fname);
                            string filename_vir = Path.Combine("~/uploads/", fname);                            
                            obj.userid = int.Parse(Session["user_id"].ToString());                            
                            obj.ltype = int.Parse(ddlltype_hr.SelectedValue.ToString());
                            obj.dates = txtdate_hr.Text.Trim();
                            obj.period = int.Parse(ddlper_hr.SelectedValue.ToString());
                            obj.reason = txtreason_hr.Text.Trim();
                            obj.rdays = getcount();
                            obj.jobc = ddljobc_hr.SelectedItem.ToString();
                            obj.contact = txtphone_hr.Text.Trim();
                            obj.med_path = filename_vir;
                            int r = obj.insert_med();
                            if (r == 1)
                            {
                                fupload_hr.SaveAs(filename);
                                clearfeilds();
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                            }
                            else if (r == 2)
                            {
                                clearfeilds();
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
                            }
                            else
                            {
                                clearfeilds1();
                                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errornotavail();", true);
                            }
                        }
                        else
                        {
                            clearfeilds2();
                            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errorpdf();", true);
                        }
                    }
                    else
                    {
                        clearfeilds2();
                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errorpdfsize();", true);
                    }
                }
                else
                {
                    clearfeilds2();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
                }
            }
            else if (int.Parse(ddlltype_hr.SelectedValue.ToString()) == 5 || int.Parse(ddlltype_hr.SelectedValue.ToString()) == 6)
            {
                obj.userid = int.Parse(Session["user_id"].ToString());
                obj.ltype = int.Parse(ddlltype_hr.SelectedValue.ToString());
                obj.dates = txtdate_hr.Text.Trim();
                obj.period = int.Parse(ddlper_hr.SelectedValue.ToString());
                obj.reason = txtreason_hr.Text.Trim();
                obj.rdays = getcount();
                obj.jobc = ddljobc_hr.SelectedItem.ToString();
                obj.contact = txtphone_hr.Text.Trim();
                int r1 = obj.insert_oleave();
                if (r1 == 1)
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
            else
            {
                obj.userid = int.Parse(Session["user_id"].ToString());
                obj.ltype = int.Parse(ddlltype_hr.SelectedValue.ToString());
                obj.dates = txtdate_hr.Text.Trim();
                obj.period = int.Parse(ddlper_hr.SelectedValue.ToString());
                obj.reason = txtreason_hr.Text.Trim();
                obj.rdays = getcount();
                obj.jobc = ddljobc_hr.SelectedItem.ToString();
                obj.contact = txtphone_hr.Text.Trim();
                
                int r1 = obj.insert_leave(); // checking and insertion is done in one procedure
                if (r1 == 1)
                {
                    clearfeilds();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                }
                else if (r1 == 3)
                {
                    clearfeilds1();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errornotavail();", true);
                }
                else
                {
                    clearfeilds();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
                }
            }
        }

        //To clear the feilds
        protected void clearfeilds()
        {
            txtreason_hr.Text = "";
            txtphone_hr.Text = "";
            txtdate_hr.Text = "";
            fill_lbl_hr();
            fill_ltype_hr();
            fill_period_hr();
            fill_collegues_hr();
        }

        protected void clearfeilds1()
        {
            txtdate_hr.Text = "";
        }

        protected void clearfeilds2()
        {
            ddlltype_hr.SelectedIndex = 0;
        }

        //To get the no: of days selected
        protected double getcount()
        {
            double ct = 0;
            double hf = 0.5;
            string a;
            if (int.Parse(ddlper_hr.SelectedValue.ToString()) == 1 && txtdate_hr.Text.Trim() != "")
            {
                a = txtdate_hr.Text.Trim();
                string[] values = a.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    ct = ct + 1;
                }
            }
            else if (int.Parse(ddlper_hr.SelectedValue.ToString()) == 2 && txtdate_hr.Text.Trim() != "")
            {
                a = txtdate_hr.Text.Trim();
                string[] values = a.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    ct = ct + hf;
                }
            }
            else
            {
                ct = 0; 
            }
            return ct;
        }

        //To bind label with Name, Department and Position
        protected void fill_lbl_hr()
        {
            obj.userid = int.Parse(Session["user_id"].ToString());
            DataTable dt1 = obj.fetch_details();
            if (dt1.Rows.Count > 0)
            {
                lblname_hr.Text = dt1.Rows[0][0].ToString();
                lbldep_hr.Text = dt1.Rows[0][1].ToString();
                lblpos_hr.Text = dt1.Rows[0][2].ToString();
                txtphone_hr.Text = dt1.Rows[0][3].ToString();
            }
            else
            {

            }
        }

        //To fill Leave Type DropDownList
        protected void fill_ltype_hr()
        {
            obj.userid = int.Parse(Session["user_id"].ToString());
            DataTable dt1 = obj.fetch_leavetypes();
            if (dt1.Rows.Count > 0)
            {
                ddlltype_hr.DataSource = dt1;
                ddlltype_hr.DataBind();
                ddlltype_hr.Items.Insert(0, new ListItem("-----SELECT-----", ""));
            }
            else
            {

            }
        }

        //To fill Period DropDownList
        protected void fill_period_hr()
        {
            DataTable dt1 = obj.fetch_period();
            if (dt1.Rows.Count > 0)
            {
                ddlper_hr.DataSource = dt1;
                ddlper_hr.DataBind();
                ddlper_hr.Items.Insert(0, new ListItem("-----SELECT-----", ""));
            }
            else
            {

            }
        }

        //To fill Covered By DropDownList
        protected void fill_collegues_hr()
        {
            obj1.userid = int.Parse(Session["user_id"].ToString());
            DataTable dt1 = obj1.fetch_collegues();
            if (dt1.Rows.Count > 0)
            {
                ddljobc_hr.DataSource = dt1;
                ddljobc_hr.DataBind();
                ddljobc_hr.Items.Insert(0, new ListItem("-----SELECT-----", ""));
            }
            else
            {

            }
        }

        [WebMethod]

        public static int countchk(int userid, int type, string dates)
        {
            return 1;
        }
    }    
}