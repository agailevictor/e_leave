using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using eleave_c;
using System.Web.Services;

namespace eleave_view.md
{
    public partial class dash : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();
        bus_eleave bus = new bus_eleave();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<leaveall> highcharts()
        {
            List<leaveall> ls = new List<leaveall>();
            bus_eleave bus = new bus_eleave();
            DataTable dt = bus.fill_leaves_all_highcharts();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                leaveall _ls = new leaveall();
                _ls.Name = dt.Rows[i]["name"].ToString();
                _ls.aleave = float.Parse(dt.Rows[i]["aleave"].ToString());
                _ls.sleave = float.Parse(dt.Rows[i]["sleave"].ToString());
                _ls.mleave = float.Parse(dt.Rows[i]["mleave"].ToString());
                _ls.m2leave = float.Parse(dt.Rows[i]["m2leave"].ToString());
                ls.Add(_ls);
            }
            return ls;
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
        public static int updatealerts()
        {
            bus_eleave bus = new bus_eleave();
            int r = bus.fetchalerts_md();
            return r;
        }
    }
}