using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using eleave_c;

namespace eleave_view.user
{
    public partial class applyleave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Event> disdates()
        {
            List<Event> dates = new List<Event>();
            bus_eleave bus = new bus_eleave();
            DataTable dt = bus.fetch_holidays1();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Event _holiday = new Event();
                _holiday.EventDate = dt.Rows[i]["dates"].ToString();
                dates.Add(_holiday);
            }
            return dates;
        }
    }
}