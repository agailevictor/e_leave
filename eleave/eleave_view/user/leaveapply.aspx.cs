using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using eleave_c;
using System.IO;


namespace eleave_view.user
{
    public partial class leaveapply : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        string filename;
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
                fill_userdetails();
                fill_leavetypes();
                fill_period();
                fill_collegues();
                txtdate.Attributes.Add("readonly", "readonly");

            }
            else
            {
                Response.Redirect("~/unauthorised.aspx");
            }
        }

        [WebMethod]
        public static List<Event> disdates(int userid)
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

        protected void fill_userdetails()
        {
            bus.userid = int.Parse(Session["user_id"].ToString());
            DataTable dt1 = bus.fetch_details();
            if (dt1.Rows.Count > 0)
            {
                lblname.Text = dt1.Rows[0][0].ToString();
                lbldep.Text = dt1.Rows[0][1].ToString();
                lblpos.Text = dt1.Rows[0][2].ToString();
                txtphone.Text = dt1.Rows[0][3].ToString();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning();", true);
            }
        }
        protected void fill_leavetypes()
        {
            bus.userid = int.Parse(Session["user_id"].ToString());
            DataTable dt2 = bus.fetch_leavetypes();
            if (dt2.Rows.Count > 0)
            {
                ddlltype.DataSource = dt2;
                ddlltype.DataBind();
                ddlltype.Items.Insert(0, new ListItem("-----SELECT-----", ""));
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning();", true);
            }
        }
        protected void fill_period()
        {
            DataTable dt3 = bus.fetch_period();
            if (dt3.Rows.Count > 0)
            {
                ddlper.DataSource = dt3;
                ddlper.DataBind();
                ddlper.Items.Insert(0, new ListItem("-----SELECT-----", ""));
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning();", true);
            }
        }
        protected void fill_collegues()
        {
            bus.userid = int.Parse(Session["user_id"].ToString());
            DataTable dt4 = bus.fetch_collegues();
            if (dt4.Rows.Count > 0)
            {
                ddljobc.DataSource = dt4;
                ddljobc.DataBind();
                ddljobc.Items.Insert(0, new ListItem("-----SELECT-----", ""));
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning();", true);
            }
        }

        protected void btnreq_Click(object sender, EventArgs e)
        {
            if (int.Parse(ddlltype.SelectedValue.ToString()) == 2)
            {
                if (fupload.HasFile)
                {
                    if (fupload.PostedFile.ContentLength < 3145728)
                    {
                        String ext = System.IO.Path.GetExtension(fupload.FileName);
                        if (ext == ".pdf")
                        {

                            FileInfo file = new System.IO.FileInfo(fupload.PostedFile.FileName);
                            string fname = file.Name.Remove((file.Name.Length - file.Extension.Length));
                            fname = fname + System.DateTime.Now.ToString("_dd-MM-yy_hh;mm;ss") + file.Extension; // renaming file uploads
                            filename = Path.Combine(HttpContext.Current.Server.MapPath("~/uploads/"), fname);
                            string filename_vir = Path.Combine("~/uploads/", fname);
                            //fupload.SaveAs(filename);
                            bus.userid = int.Parse(Session["user_id"].ToString());
                            bus.ltype = int.Parse(ddlltype.SelectedValue.ToString());
                            bus.dates = txtdate.Text.Trim();
                            bus.period = int.Parse(ddlper.SelectedValue.ToString());
                            bus.reason = txtreason.Text.Trim();
                            bus.rdays = getcount();
                            bus.jobc = ddljobc.SelectedItem.ToString();
                            bus.contact = txtphone.Text.Trim();
                            bus.med_path = filename_vir;
                            // check here the applied leaves exceeds or not (here check only medical)
                            int r = bus.insert_med();
                            if (r == 1)
                            {
                                fupload.SaveAs(filename);
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
                            //ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errorpdf();window.location='" + Request.ApplicationPath + "user/leaves.aspx';", true);
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
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errorofile();", true);
                }
            }
            else if (int.Parse(ddlltype.SelectedValue.ToString()) == 5 || int.Parse(ddlltype.SelectedValue.ToString()) == 6)
            {
                bus.userid = int.Parse(Session["user_id"].ToString());
                bus.ltype = int.Parse(ddlltype.SelectedValue.ToString());
                bus.dates = txtdate.Text.Trim();
                bus.period = int.Parse(ddlper.SelectedValue.ToString());
                bus.reason = txtreason.Text.Trim();
                bus.rdays = getcount();
                bus.jobc = ddljobc.SelectedItem.ToString();
                bus.contact = txtphone.Text.Trim();
                int r1 = bus.insert_oleave(); 
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
                bus.userid = int.Parse(Session["user_id"].ToString());
                bus.ltype = int.Parse(ddlltype.SelectedValue.ToString());
                bus.dates = txtdate.Text.Trim();
                bus.period = int.Parse(ddlper.SelectedValue.ToString());
                bus.reason = txtreason.Text.Trim();
                bus.rdays = getcount();
                bus.jobc = ddljobc.SelectedItem.ToString();
                bus.contact = txtphone.Text.Trim();
                // check here the applied leaves exceeds or not (annual, marriage, maternity)
                //int inter = bus.check_avail();
                //if (inter == 1)
                //{ 
                // too many parameters clear sql parameters
                //    applyleave();
                //}
                //else
                //{
                //    clearfeilds();
                //    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errornotavail();", true);
                //}
                int r1 = bus.insert_leave(); // checking and insertion is done in one procedure
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

        protected double getcount()
        {
            double ct = 0;
            double hf = 0.5;
            string a;
            if (int.Parse(ddlper.SelectedValue.ToString()) == 1 && txtdate.Text.Trim() != "")
            {
                a = txtdate.Text.Trim();
                string[] values = a.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    ct = ct + 1;
                }
            }
            else if (int.Parse(ddlper.SelectedValue.ToString()) == 2 && txtdate.Text.Trim() != "")
            {
                a = txtdate.Text.Trim();
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

        protected void clearfeilds()
        {
            txtreason.Text = "";
            txtphone.Text = "";
            txtdate.Text = "";
            fill_userdetails();
            fill_period();
            fill_leavetypes();
            fill_collegues();
        }

        protected void clearfeilds1()
        {
            txtdate.Text = "";
        }

        protected void clearfeilds2()
        {
            ddlltype.SelectedIndex = 0;
        }

        public void applyleave()
        {
            bus.userid = int.Parse(Session["user_id"].ToString());
            bus.ltype = int.Parse(ddlltype.SelectedValue.ToString());
            bus.dates = txtdate.Text.Trim();
            bus.period = int.Parse(ddlper.SelectedValue.ToString());
            bus.reason = txtreason.Text.Trim();
            bus.rdays = getcount();
            bus.jobc = ddljobc.SelectedItem.ToString();
            bus.contact = txtphone.Text.Trim();
            int r1 = bus.insert_leave();
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


    }
}