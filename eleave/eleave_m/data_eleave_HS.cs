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
        public DataTable fill_app_rej_hr()
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_fill_app_rej_hr";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int reject_leave(int lid)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_reject_leave_hr";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@leave_id", lid);
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

        public int accept_leave(int lid)
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

        public int checkold(int uid)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_chk_oldpwd_hr";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@uid", uid);
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

        public int updatepwd(int uid, string nwpwd)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_update_pwd_hr";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@uid", uid);
            cmd.Parameters.AddWithValue("@nwpwd", nwpwd);
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
        public string file_hr(int lid)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "sp_fetch_file";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = db.connect();
            cmd.Parameters.AddWithValue("@lid", lid);
            SqlParameter outparam = new SqlParameter();
            outparam.ParameterName = "@file";
            outparam.Direction = ParameterDirection.InputOutput;
            outparam.DbType = DbType.Int32;
            outparam.Value = 0;
            cmd.Parameters.Add(outparam);
            cmd.ExecuteNonQuery();
            string file = cmd.Parameters["@file"].Value.ToString();
            cmd.Dispose();
            return file;
            
            
            
            //SqlDataAdapter da = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            //da.SelectCommand = cmd;
            //da.Fill(dt);
            //db.disconnect();
            //return dt;
        }
    }
}
