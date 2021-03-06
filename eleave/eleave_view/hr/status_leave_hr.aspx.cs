﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eleave_c;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Web.Mail;

namespace eleave_view.hr
{
    public partial class status_leave_hr : System.Web.UI.Page
    {
        bus_eleave obj = new bus_eleave();
        ReportDocument rd = new ReportDocument();
        bus_eleave_HS bus = new bus_eleave_HS();
        int f;
        CheckBox cbox;
        public string toemail, mailbody, url = "http://uoa.hummingsoft.com.my:8065/e_leave/ target=\"_blank\"", url2 = "http://192.168.1.65/e_leave/ target=\"_blank\"";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checklogin();
            }           
        }

        protected void checklogin()
        {
            if (Session["is_login"] != null)
            {
                if (Session["is_login"].ToString() == "t")
                {
                    change_stat();
                    fill_grid_hr();

                }
                else
                {
                    Response.Redirect("~/unauthorised.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void change_stat()
        {
            obj.userid = int.Parse(Session["user_id"].ToString());
            obj.change_stat();// to change the seen status of notification
        }

        //To bind the grid with datatable
        protected void fill_grid_hr()
        {
            obj.userid = int.Parse(Session["user_id"].ToString());
            DataTable dt = obj.fill_grid();
            if (dt.Rows.Count > 0)
            {
                status_hr.DataSource = dt;
                status_hr.DataBind();
            }
            else
            {
                status_hr.DataSource = null;
                status_hr.DataBind();
            }
        }

        protected Boolean Isenable(string Status)
        {
            if (Status == "Approved")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected Boolean Isvisible(string Status)
        {
            if (Status == "HR Level Pending")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Cancelling user applied leaves
        protected void btncancel_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            int id = int.Parse(status_hr.DataKeys[row.RowIndex].Value.ToString());
            obj.lid = id;
            int r = obj.cancel_leave();
            if (r == 1)
            {
                fetch_hr_email();
                mailbody = "<table  border='1' cellpadding='0' cellspacing='0' style='width: 850px; border-color: black;'><tr><td colspan='9'><br>&nbsp &nbspDear Sir / Madam,<br /><br />&nbsp&nbsp&nbsp&nbsp&nbspLeave application submitted by <b>" + Session["name"].ToString() + "</b> has been cancelled on <b>" + DateTime.Now.ToString("dd/MM/yyyy") + ".</b> The details are as follows.<br /><br /></td></tr><tr style='font-weight: 700;'></tr><tr><td colspan='9'><br/><p></p><p> &nbsp&nbsp&nbspName:   " + Session["name"].ToString() + "</p><p>&nbsp&nbsp&nbspDepartment:   " + Session["dep"].ToString() + "</p><p>&nbsp&nbsp&nbspDesignation:   " + Session["des"].ToString() + " </p><p>&nbsp&nbsp&nbspLeave Type:   " + row.Cells[1].Text.ToString() + " </p><p>&nbsp&nbsp&nbspPeriod:   " + row.Cells[4].Text.ToString() + " </p><p>&nbsp&nbsp&nbsp</p><p>&nbsp&nbsp&nbspclick<a href=" + url2 + "> here </a>to login into the application (UOA)</p><p>&nbsp&nbsp&nbspclick<a href=" + url + "> here </a>to login into the application</p><br/></td></tr><tr></tr><td colspan='9' style='font-weight: bold' align='right'><br /><br />Regards,<br />Team e-leave</td></tr><tr><td align='center'><p style='color:blue;'> This is a system generated response. Please do not respond to this email id.</p></td></tr></table>";
                bool check = SendWebMail(toemail, "Leave Application Notification", mailbody, "", "", "info@hummingsoft.com.my");
                if(check == true)
                {
                    fill_grid_hr();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                }
                else
                {
                    fill_grid_hr();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "errormail();", true);
                }
            }
            else
            {
                fill_grid_hr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(status_hr.DataKeys[row.RowIndex].Value.ToString());
            download_leave_hr(id);
        }   
       
        public void download_leave_hr(int id)
        {
            obj.lid = id;
            DataTable dt = obj.fetch_download_leaves();
            int reg = Int32.Parse(Session["region"].ToString());
            if (dt.Rows.Count > 0)
            {
                if(reg==2)
                {
                    rd.Load(Server.MapPath(Request.ApplicationPath) + "/hr/approved.rpt");
                    rd.SetDataSource(dt);
                    // location of empty pdf file
                    string exportPath = Server.MapPath("~/pdf/Approved_Leave.pdf");

                    // export the report to pdf and write to empty pdf file inside pdf folder
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = exportPath;
                    CrExportOptions = rd.ExportOptions;//Report document  object has to be given here
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    rd.Export();
                    Response.Redirect("~/ViewPdf.aspx?reportFile=" + exportPath);
                }
                else if(reg==1)
                {
                    rd.Load(Server.MapPath(Request.ApplicationPath) + "/hr/approved_malaysia.rpt");
                    rd.SetDataSource(dt);
                    // location of empty pdf file
                    string exportPath = Server.MapPath("~/pdf/Approved_Leave.pdf");

                    // export the report to pdf and write to empty pdf file inside pdf folder
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = exportPath;
                    CrExportOptions = rd.ExportOptions;//Report document  object has to be given here
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    rd.Export();
                    Response.Redirect("~/ViewPdf.aspx?reportFile=" + exportPath);
                }
            }
        }

        protected void status_hr_PreRender(object sender, EventArgs e)
        {
            if (status_hr.Rows.Count > 0)
            {
                status_hr.UseAccessibleHeader = true;
                status_hr.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void lnkedit_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(status_hr.DataKeys[row.RowIndex].Value.ToString());
            Session["eleave_id"] = id;
            Response.Redirect("~/hr/edit_leave.aspx");
        }

        public void fetch_hr_email()
        {
            toemail = "";            
            DataTable dtemail = bus.fetch_mail_details_cancel();
            if (dtemail.Rows.Count > 0)
            {
                for (int i = 0; i < dtemail.Rows.Count; i++)
                {
                    toemail = toemail + dtemail.Rows[i]["email"].ToString();
                    toemail += (i < dtemail.Rows.Count - 1) ? ";" : string.Empty;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning();", true);
            }
        }
        private bool SendWebMail(string strTo, string subj, string cont, string cc, string bcc, string strfrom)
        {
            bool flg = false;
            MailMessage msg = new MailMessage();
            msg.Body = cont;
            msg.From = strfrom;
            msg.To = strTo;
            msg.Subject = subj;
            msg.Cc = cc;
            msg.Bcc = bcc;
            msg.BodyFormat = MailFormat.Html;
            try
            {
                //SmtpMail.SmtpServer = "175.143.44.165";
                SmtpMail.SmtpServer = "192.168.1.4"; // change the ip address to this when hosting in server
                SmtpMail.Send(msg);
                flg = true;
            }
            catch (Exception)
            {
                flg = false;
            }
            return flg;
        }
    }
}