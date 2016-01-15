using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using eleave_m;

namespace eleave_c
{
    public class bus_eleave
    {
        data_eleave data = new data_eleave();

        public string user_name { get; set; }
        public string password { get; set; }
        public int userid { get; set; }
        public int lid { get; set; }
        public int ltype { get; set; }
        public double rdays { get; set; }
        public string dates { get; set; }
        public int period { get; set; }
        public string med_path { get; set; }
        public string reason { get; set; }
        public string jobc { get; set; }
        public string contact { get; set; }
        public string event_name { get; set; }
        public DateTime event_date { get; set; }
        public string event_color { get; set; }

        public string name { get; set; }
        public string gender { get; set; }

        public DateTime doj { get; set; }
        public int dep { get; set; }
        public int grade { get; set; }
        public int desi { get; set; }
        public int region { get; set; }

        public int check_login()
        {
            return data.check_login(user_name, password);
        }

        public DataTable fetch_userdetails()
        {
            return data.fetch_userdetails(user_name);
        }
        public DataTable fetch_holidays()
        {
            return data.fetch_holidays();

        }
        public DataTable fetch_holidays1()
        {
            return data.fetch_holidays1(userid);

        }
        public DataTable fetch_leaves()
        {
            return data.fetch_leaves(userid);
        }

        public DataTable fill_grid()
        {
            return data.fill_grid(userid);
        }

        public DataTable fetch_download_leaves()
        {
            return data.fetch_download_leaves(lid);
        }

        public DataTable fetch_details()
        {
            return data.fetch_details(userid);
        }

        public DataTable fetch_leavetypes()
        {
            return data.fetch_leavetypes(userid);
        }

        public DataTable fetch_period()
        {
            return data.fetch_period();
        }

        public DataTable fetch_collegues()
        {
            return data.fetch_collegues(userid);
        }

        public int insert_med()
        {
            return data.insert_med(userid, ltype, dates, period, reason, rdays, jobc, contact, med_path);
        }

        public int insert_leave()
        {
            return data.insert_leave(userid, ltype, dates, period, reason, rdays, jobc, contact);
        }

        public int cancel_leave()
        {
            return data.cancel_leave(lid);
        }

        public DataTable fill_user_approved_leaves()
        {
            return data.fill_user_approved_leaves(userid);
        }

        public int check_avail()
        {
            return data.check_avail(userid,ltype,rdays);
        }

        public int initiate_cancel()
        {
            return data.initiate_cancel(lid);
        }

        public int upload_holidays()
        {
            return data.upload_holidays(event_name,event_date,event_color);
        }

        public DataTable fillgender()
        {
            return data.fillgender();
        }
        public DataTable filldep()
        {
            return data.filldep();
        }
        public int add_user()
        {
            return data.add_user(name,user_name,gender,doj,dep,grade,desi,region);
        }
        public DataTable fetchdesignation()
        {
            return data.fetchdesignation(lid);
        }
        public DataTable fetchgrade()
        {
            return data.fetchgrade(lid);
        }
        public DataTable fillregion()
        {
            return data.fillregion();
        }

        public DataTable fetchdisdates()
        {
            return data.fetchdisdates();
        }
    }
}
