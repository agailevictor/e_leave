using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace eleave_m
{
    public class data_eleave_HS
    {
        SqlCommand cmd = new SqlCommand();
        dbconnect db = new dbconnect();
        public DataTable fetch_collegues(int uid)
        {
            cmd.Parameters.Clear();           
            cmd.CommandText = "sp_fetch_collegues_hr";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@uid", uid);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }
    }
}
