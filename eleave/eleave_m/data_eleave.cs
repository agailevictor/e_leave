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
            cmd.Parameters.Clear();
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
            cmd.Parameters.Clear();
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
            cmd.Parameters.Clear();
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
            cmd.Parameters.Clear();
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
            cmd.Parameters.Clear();
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
            cmd.Parameters.Clear();
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
            cmd.Parameters.Clear();
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
            cmd.Parameters.Clear();
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
            cmd.Parameters.Clear();
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
            cmd.Parameters.Clear();
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
            cmd.Parameters.Clear();
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
            cmd.Parameters.Clear();
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
            cmd.Parameters.Clear();
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

        public int insert_oleave(int userid, int ltype, string dates, int period, string reason, double rdays, string jobc, string contact)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_insert_oleaves";
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
            cmd.Parameters.Clear();
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
            cmd.Parameters.Clear();
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
            cmd.Parameters.Clear();
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
            cmd.Parameters.Clear();
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

        public DataTable fillgender()
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_fillgender";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }

        public DataTable filldep()
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_filldepartment";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }

        public int add_user(string name,string user_name,string gender,DateTime doj,int dep,int grade,int desi,int region)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_add_user";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@user_name", user_name);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@doj", doj);
            cmd.Parameters.AddWithValue("@dep", dep);
            cmd.Parameters.AddWithValue("@grade", grade);
            cmd.Parameters.AddWithValue("@desi", desi);
            cmd.Parameters.AddWithValue("@region", region);
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

        public DataTable fetchdesignation(int id)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_fetchdesignation";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }

        public DataTable fetchgrade(int id)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_fetchgrade";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }

        public DataTable fillregion()
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_fillregion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }

        public DataTable fetchdisdates()
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_fetchdisdates";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }

        public DataTable fillusers()
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_fetchall_users";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }

        public int deleteuser(int id)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_deleteuser";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@id", id);
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

        public DataTable fillleavesfr()
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_fillleavesfr";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }

        public DataTable fill_leaves_all()
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_userleaves_all";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }

        public int forward_leave(int lid)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_accept_leave_hr";
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

        public int reject_leave(int lid)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_reject_leave_hr";
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

        public int fetchalerts()
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_fetchalerts";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
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

        public int updatepwd(int uid, string oldp, string newp)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_update_pwd_hr";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@uid", uid);
            cmd.Parameters.AddWithValue("@oldp", oldp);
            cmd.Parameters.AddWithValue("@newp", newp);
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

        public DataTable fill_details_user(int uid)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_fill_details_user";
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

        public int update_profile(int uid,string add1,string add2,int mob)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_updateProfile_hr";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@uid", uid);
            cmd.Parameters.AddWithValue("@add1", add1);
            cmd.Parameters.AddWithValue("@add2", add2);
            cmd.Parameters.AddWithValue("@mob", mob);
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

        public int oldpchk(int uid ,string password)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_oldpchk";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@uid", uid);
            cmd.Parameters.AddWithValue("@password", password);
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

        public DataTable fillleavesapr()
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_fill_leaves_app";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }

        public int approve_leave(int lid)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_approve_leave";
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

        public int reject_leave_md(int lid)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_reject_leave_md";
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

        public DataTable fill_leaves_all_highcharts()
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_userleaves_all_highcharts";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            db.disconnect();
            return dt;
        }
    }
}
