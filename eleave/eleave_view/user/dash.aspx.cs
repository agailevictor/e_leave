﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eleave_c;
using System.Web.Services;

namespace eleave_view.user
{
    public partial class dash : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static List<Event> GetEvents()
        {
            List<Event> events = new List<Event>();
            bus_eleave bus = new bus_eleave();
            DataTable dt = bus.fetch_holidays();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Event _Event = new Event();
                _Event.EventID = int.Parse(dt.Rows[i]["event_id"].ToString());
                _Event.EventName = dt.Rows[i]["event_name"].ToString();
                _Event.EventDate = dt.Rows[i]["event_date"].ToString();
                _Event.color = dt.Rows[i]["event_color"].ToString();
                events.Add(_Event);
            }
            return events;
        }
        [WebMethod]
        public static List<Leaves> fetchleave(int userid)
        {
            List<Leaves> leaves = new List<Leaves>();
            bus_eleave bus = new bus_eleave();
            bus.userid = userid;
            DataTable dt = bus.fetch_leaves();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Leaves _Leaves = new Leaves();
                _Leaves.LeaveType = dt.Rows[i]["ltype"].ToString();
                _Leaves.LeaveCount = float.Parse(dt.Rows[i]["num"].ToString());
                _Leaves.LeavePerc = float.Parse(dt.Rows[i]["perc"].ToString());
                _Leaves.LeaveTot = float.Parse(dt.Rows[i]["tot"].ToString());
                leaves.Add(_Leaves);
            }
            return leaves;
        }
    }
}