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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                disdates(2);
            }
        }

        public DataTable disdates(int userid)
        {
            bus_eleave bus = new bus_eleave();
            bus.userid = userid;
            DataTable dt = bus.fetch_holidays1();
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("dates1");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string[] split = dt.Rows[i]["dates"].ToString().Split(',');
                for(int j = 0; j < split.Length ; j++ )
                {
                    DataRow dr = dt1.NewRow(); 
                    dr["dates1"] = split[j]; 
                    dt1.Rows.Add(dr);
                }
            }
            return dt1;
        }
    }
}