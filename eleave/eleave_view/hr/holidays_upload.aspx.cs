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
    public partial class holidays_upload : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        datamapper datamapper = new datamapper();
        int CHK_NULL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checklogin();
            }
        }

        protected void checklogin()
        {
            if (Session["is_login"].ToString() == "f")
            {
                Response.Redirect("~/unauthorised.aspx");
            }
        }

        protected void btnreq_hr_Click(object sender, EventArgs e)
        {
            CHK_NULL = 0;
            DataTable a = datamapper.GetDataTable(txtholidays_hr.Text, true);
            if (a.Rows.Count > 0)
            {
                for (int i = 0; i < a.Rows.Count; i++)
                {
                    if (a.Rows[i][0].ToString().Trim() == "")
                    {
                        CHK_NULL = 1;
                        break;
                    }
                    else
                    {
                        bus.event_name = a.Rows[i][0].ToString();
                    }
                    if (a.Rows[i][1].ToString().Trim() == "")
                    {
                        CHK_NULL = 1;
                        break;
                    }
                    else
                    {
                        bus.event_date = DateTime.Parse(a.Rows[i][1].ToString());

                    }
                    if (a.Rows[i][2].ToString().Trim() == "")
                    {
                        CHK_NULL = 1;
                        break;
                    }
                    else
                    {
                        bus.event_color = a.Rows[i][2].ToString();

                    }


                }
                if (CHK_NULL == 0)
                {
                    int count = 0;
                    int countd = 0;
                    int counts = 0;

                    for (int i = 0; i < a.Rows.Count; i++)
                    {

                        bus.event_name = a.Rows[i][0].ToString();
                        bus.event_date = DateTime.Parse(a.Rows[i][1].ToString());
                        bus.event_color = a.Rows[i][2].ToString();
                        int r  = bus.upload_holidays();
                        if (r == 1)
                        {
                            countd++;
                            //lblsuccesfulmsg.Text = +countd + " Record(s) inserted Succesfully ";
                        }
                        else if (r == 2)
                        {
                            counts++;
                            count = counts - countd;
                            //lblduplicatemsg.Text = "There are " + count + " Duplicated Value(s)";
                        }
                        else
                        {

                        }
                    }
                    txtholidays_hr.Text = "";
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
                }
            }
        }
    }
}