using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using eleave_m;

namespace eleave_c
{
    
    public class bus_eleave_HS
    {
        data_eleave_HS obj=new data_eleave_HS();
        public int userid { get; set; }
        // public struct name { get; set; }

        public DataTable fetch_collegues()
        {
            return obj.fetch_collegues(userid);
        }
    }
}
