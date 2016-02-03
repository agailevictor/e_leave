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
    public partial class forward_hr : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        bus_eleave_HS obj = new bus_eleave_HS();
        int f;
        CheckBox cbox;
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
                fillleavesfr();

            }
            else
            {
                Response.Redirect("~/unauthorised.aspx");
            }
        }

        protected void fillleavesfr()
        {
            DataTable dt = bus.fillleavesfr();
            if (dt.Rows.Count > 0)
            {
                grd_forward.DataSource = dt;
                grd_forward.DataBind();
            }
            else
            {
                grd_forward.DataSource = null;
                grd_forward.DataBind();
                btnaccept.Visible = false;
                btnreject.Visible = false;
                Panel1.Visible = false;
            }
        }

        protected void btnaccept_Click(object sender, EventArgs e)
        {
            f = 1;
            foreach (GridViewRow row in grd_forward.Rows)
            {
                cbox = (CheckBox)row.FindControl("chk"); //RowSelector is the id of checkbox in Grid View
                if (cbox.Checked == true)
                {
                    // Fetch request's id
                    int RequestId = Convert.ToInt32(grd_forward.DataKeys[row.RowIndex].Value);

                    // Write your approval logic here
                    bus.lid = RequestId;
                    int r = bus.forward_leave();
                    if (r == 1)
                    {
                        f = 0;
                    }
                    else
                    {
                        f = 2;
                    }

                }

            }
            if (f == 0)
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else if(f == 2)
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
            else
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning();", true);
            }

        }

        protected void lnkforward_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            int id = int.Parse(grd_forward.DataKeys[row.RowIndex].Value.ToString());
            bus.lid = id;
            int r = bus.forward_leave();
            if (r == 1)
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }

        }

        protected void lnkreject_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = lnk.NamingContainer as GridViewRow;
            string rej = ((TextBox)grd_forward.Rows[row.RowIndex].FindControl("TextBox1")).Text.Trim();
            //if (rej != "")
            //{
                int id = int.Parse(grd_forward.DataKeys[row.RowIndex].Value.ToString());
                bus.lid = id;
                bus.reason = rej;
                int r = bus.reject_leave();
                if (r == 1)
                {
                    fillleavesfr();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
                }
                else
                {
                    fillleavesfr();
                    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
                }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning2();", true);
            //}
        }

        protected Boolean Isenable(string ltype)
        {            
            if (ltype == "Medical")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void lnk_dwn_Click(object sender, EventArgs e)
        {

            LinkButton lnkbtn = sender as LinkButton;
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            string filePath = gvrow.Cells[9].Text.ToString();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
            Response.TransmitFile(Server.MapPath(filePath));
            Response.End();
        }

        protected void grd_forward_PreRender(object sender, EventArgs e)
        {
            if (grd_forward.Rows.Count > 0)
            {
                grd_forward.UseAccessibleHeader = true;
                grd_forward.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void btnrejc_Click(object sender, EventArgs e)
        {
            f = 1;
            foreach (GridViewRow row in grd_forward.Rows)
            {
                cbox = (CheckBox)row.FindControl("chk"); //RowSelector is the id of checkbox in Grid View
                if (cbox.Checked == true)
                {
                    if (txtbreason.Text != "")
                    {
                        // Fetch request's id
                        int RequestId = Convert.ToInt32(grd_forward.DataKeys[row.RowIndex].Value);

                        // Write your approval logic here
                        bus.lid = RequestId;
                        bus.reason = txtbreason.Text.Trim();
                        int r = bus.reject_leave();
                        if (r == 1)
                        {
                            f = 0;
                        }
                        else
                        {
                            f = 2;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning2();", true);
                    }

                }

            }
            if (f == 0)
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else if (f == 2)
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
            else
            {
                fillleavesfr();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning();", true);
            }
        }
    }
}