﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eleave_c;

namespace eleave_view.user
{
    public partial class update_profile : System.Web.UI.Page
    {
        bus_eleave bus = new bus_eleave();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fill_details_user();
            }
        }

        protected void fill_details_user()
        {
            bus.userid = int.Parse(Session["user_id"].ToString());
            DataTable dt = bus.fill_details_user();
            if (dt.Rows.Count > 0)
            {
                lblname.Text = dt.Rows[0][0].ToString();
                lbluname.Text = dt.Rows[0][1].ToString();
                lblgender.Text = dt.Rows[0][2].ToString();
                lbldoj.Text = dt.Rows[0][3].ToString();
                lbldep.Text = dt.Rows[0][4].ToString();
                lbldesg.Text = dt.Rows[0][5].ToString();
                lblgrade.Text = dt.Rows[0][6].ToString();
                lblregion.Text = dt.Rows[0][7].ToString();
                txtadd1.Text = dt.Rows[0][8].ToString();
                txtadd2.Text = dt.Rows[0][9].ToString();
                txtphone.Text = dt.Rows[0][10].ToString();
            }
        }
        protected void btnuprofile_Click(object sender, EventArgs e)
        {

            bus.userid = int.Parse(Session["user_id"].ToString());
            bus.add1 = txtadd1.Text.Trim();
            bus.add2 = txtadd2.Text.Trim();
            bus.mob = txtphone.Text.Trim();
            int r = bus.update_profile();
            if (r == 1)
            {
                clear();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "success();", true);
            }
            else if (r == 2)
            {
                clear();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "error();", true);
            }
            else
            {
                clear();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "warning();", true);
            }
        }

        public void clear()
        {
            txtadd1.Text = "";
            txtadd2.Text = "";
            txtphone.Text = "";
        }
    }
}