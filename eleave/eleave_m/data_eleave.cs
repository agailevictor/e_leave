using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient
;

namespace eleave_m
{
    public class data_eleave
    {
        SqlCommand cmd = new SqlCommand();
        dbconnect db = new dbconnect();

        public int check_login(string username, string pswd)
        {
            cmd.CommandText = "sp_checklogin";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@pswd", pswd);
            SqlParameter outparam = new SqlParameter();
            outparam.ParameterName = "@flag";
            outparam.Direction = ParameterDirection.InputOutput;
            outparam.DbType = DbType.Int32;
            outparam.Value = 0;
            cmd.Parameters.Add(outparam);
            cmd.ExecuteNonQuery();
            int res = int.Parse(cmd.Parameters["@flag"].Value.ToString());
            cmd.Dispose();
            return res;
        }

        public DataTable fetch_userdetails(string username)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_fetch_user_details";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@username", username);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }
        public DataTable fetch_holidays()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_fetch_holidays";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }

        public DataTable fetch_holidays1(int userid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_fetch_holidays1";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@userid", userid);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }

        public DataTable fetch_leaves(int userid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_fetch_leaves";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@userid", userid);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }

        public DataTable fill_grid(int userid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_fill_leaves_user";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@userid", userid);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }

        public DataTable fetch_download_leaves(int lid )
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_download_approved_leaves";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@lid", lid);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }

        public DataTable fetch_details(int userid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_fetch_details";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@userid", userid);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }

        public DataTable fetch_leavetypes(int userid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_fetch_leavetypes";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@userid", userid);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }

        public DataTable fetch_period()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_fetch_period";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }

        public DataTable fetch_collegues(int userid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_fetch_collegues";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@userid", userid);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }

        public int insert_med(int userid,int ltype,string dates,int period,string reason,double rdays,string jobc,string contact,string med_path)
        {
            cmd.CommandText = "sp_insert_med";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@ltype", ltype);
            cmd.Parameters.AddWithValue("@dates", dates);
            cmd.Parameters.AddWithValue("@period", period);
            cmd.Parameters.AddWithValue("@reason", reason);
            cmd.Parameters.AddWithValue("@rdays", rdays);
            cmd.Parameters.AddWithValue("@jobc", jobc);
            cmd.Parameters.AddWithValue("@contact", contact);
            cmd.Parameters.AddWithValue("@med_path", med_path);
            SqlParameter outparam = new SqlParameter();
            outparam.ParameterName = "@flag";
            outparam.Direction = ParameterDirection.InputOutput;
            outparam.DbType = DbType.Int32;
            outparam.Value = 0;
            cmd.Parameters.Add(outparam);
            cmd.ExecuteNonQuery();
            int res = int.Parse(cmd.Parameters["@flag"].Value.ToString());
            cmd.Dispose();
            return res;
        }

        public int insert_leave(int userid, int ltype, string dates, int period, string reason, double rdays, string jobc, string contact)
        {
            //cmd.CommandText = "sp_insert_leave";
            cmd.CommandText = "sp_check_avail_chk";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@ltype", ltype);
            cmd.Parameters.AddWithValue("@dates", dates);
            cmd.Parameters.AddWithValue("@period", period);
            cmd.Parameters.AddWithValue("@reason", reason);
            cmd.Parameters.AddWithValue("@rdays", rdays);
            cmd.Parameters.AddWithValue("@jobc", jobc);
            cmd.Parameters.AddWithValue("@contact", contact);
            SqlParameter outparam = new SqlParameter();
            outparam.ParameterName = "@flag";
            outparam.Direction = ParameterDirection.InputOutput;
            outparam.DbType = DbType.Int32;
            outparam.Value = 0;
            cmd.Parameters.Add(outparam);
            cmd.ExecuteNonQuery();
            int res = int.Parse(cmd.Parameters["@flag"].Value.ToString());
            cmd.Dispose();
            return res;
        }

        public int cancel_leave(int lid)
        {
            cmd.CommandText = "sp_cancel_leave";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@lid", lid);
            SqlParameter outparam = new SqlParameter();
            outparam.ParameterName = "@flag";
            outparam.Direction = ParameterDirection.InputOutput;
            outparam.DbType = DbType.Int32;
            outparam.Value = 0;
            cmd.Parameters.Add(outparam);
            cmd.ExecuteNonQuery();
            int res = int.Parse(cmd.Parameters["@flag"].Value.ToString());
            cmd.Dispose();
            return res;
        }

        public DataTable fill_user_approved_leaves(int userid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "sp_fetch_approved_leaves";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@userid", userid);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }

        public int check_avail(int userid, int ltype, double rdays)
        {
            cmd.CommandText = "sp_check_avail";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@ltype", ltype);
            cmd.Parameters.AddWithValue("@rdays", rdays);
            SqlParameter outparam = new SqlParameter();
            outparam.ParameterName = "@flag";
            outparam.Direction = ParameterDirection.InputOutput;
            outparam.DbType = DbType.Int32;
            outparam.Value = 0;
            cmd.Parameters.Add(outparam);
            cmd.ExecuteNonQuery();
            int res = int.Parse(cmd.Parameters["@flag"].Value.ToString());
            cmd.Dispose();
            return res;
        }

        public int initiate_cancel(int lid)
        {
            cmd.CommandText = "sp_initiate_cancel";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@lid", lid);
            SqlParameter outparam = new SqlParameter();
            outparam.ParameterName = "@flag";
            outparam.Direction = ParameterDirection.InputOutput;
            outparam.DbType = DbType.Int32;
            outparam.Value = 0;
            cmd.Parameters.Add(outparam);
            cmd.ExecuteNonQuery();
            int res = int.Parse(cmd.Parameters["@flag"].Value.ToString());
            cmd.Dispose();
            return res;
        }

        public int upload_holidays(string event_name,DateTime event_date,string event_color)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_upload_holidays_bulk";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@event_name", event_name);
            cmd.Parameters.AddWithValue("@event_date", event_date);
            cmd.Parameters.AddWithValue("@event_color", event_color);
            SqlParameter outparam = new SqlParameter();
            outparam.ParameterName = "@flag";
            outparam.Direction = ParameterDirection.InputOutput;
            outparam.DbType = DbType.Int32;
            outparam.Value = 0;
            cmd.Parameters.Add(outparam);
            cmd.ExecuteNonQuery();
            int res = int.Parse(cmd.Parameters["@flag"].Value.ToString());
            cmd.Dispose();
            return res;
        }
    }
}
