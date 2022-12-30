using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using TRX_KAVA_API.Models;

namespace TRX_KAVA_API.DAL
{
    public class da_sys_config
    {
        //---------------------按Table的方式查询方法--------------------------//
        private static List<sys_config> DoTableQuery(string sql_str, SqlParameter[] paras)
        {
            var lisRtn = new List<sys_config>();
            try
            {
                var dtback = DBHelper_SQLServer.ExecuteDataTable(sql_str, paras);
                lisRtn = EntityTableParse<sys_config>.ToList(dtback);
            }
            catch
            {
            }
            return lisRtn;
        }
        //---------------------查询并赋值到实体类list的方法  IReader方式--------------------------//
        private static List<sys_config> DoQuery(string sql_str, SqlParameter[] paras)
        {
            var lisRtn = new List<sys_config>();
            try
            {
                using (IDataReader dr = DBHelper_SQLServer.ExecuteReader(sql_str, paras))
                {
                    while (dr.Read())
                    {
                        var p = new sys_config();
                        #region 逐个赋值
                        p.config_code = DBHelper_SQLServer.GetDataValue<string>(dr, "config_code");
                        p.config_desc = DBHelper_SQLServer.GetDataValue<string>(dr, "config_desc");
                        p.config_type = DBHelper_SQLServer.GetDataValue<string>(dr, "config_type");
                        p.config_type2 = DBHelper_SQLServer.GetDataValue<string>(dr, "config_type2");
                        p.realtime_value1 = DBHelper_SQLServer.GetDataValue<string>(dr, "realtime_value1");
                        p.realtime_value2 = DBHelper_SQLServer.GetDataValue<string>(dr, "realtime_value2");
                        p.realtime_value3 = DBHelper_SQLServer.GetDataValue<string>(dr, "realtime_value3");
                        p.t_create = DBHelper_SQLServer.GetDataValue<DateTime>(dr, "t_create");
                        p.t_update = DBHelper_SQLServer.GetDataValue<DateTime>(dr, "t_update");
                        p.flag_void = DBHelper_SQLServer.GetDataValue<string>(dr, "flag_void");
                        p.rsv_str1 = DBHelper_SQLServer.GetDataValue<string>(dr, "rsv_str1");
                        p.rsv_str2 = DBHelper_SQLServer.GetDataValue<string>(dr, "rsv_str2");
                        p.u_create_name = DBHelper_SQLServer.GetDataValue<string>(dr, "u_create_name");
                        p.u_create_id = DBHelper_SQLServer.GetDataValue<string>(dr, "u_create_id");
                        p.u_update_name = DBHelper_SQLServer.GetDataValue<string>(dr, "u_update_name");
                        p.u_update_id = DBHelper_SQLServer.GetDataValue<string>(dr, "u_update_id");
                        p.flag_delete = DBHelper_SQLServer.GetDataValue<bool>(dr, "flag_delete");
                        #endregion
                        lisRtn.Add(p);
                    }
                }
            }
            catch  
            {
            }
            return lisRtn;
        }
        //----------------------Insert方法----------------------------------------------//
        public static bool InsertNew(sys_config newOne)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" Insert into sys_config (  ");
            sb.Append("config_code, ");
            sb.Append("config_desc, ");
            sb.Append("config_type, ");
            sb.Append("config_type2, ");
            sb.Append("realtime_value1, ");
            sb.Append("realtime_value2, ");
            sb.Append("realtime_value3, ");
            sb.Append("t_create, ");
            sb.Append("t_update, ");
            sb.Append("flag_void, ");
            sb.Append("rsv_str1, ");
            sb.Append("rsv_str2, ");
            sb.Append("u_create_name, ");
            sb.Append("u_create_id, ");
            sb.Append("u_update_name, ");
            sb.Append("u_update_id, ");
            sb.Append("flag_delete )");
            sb.Append(" values ( ");
            sb.Append("@config_code,");
            sb.Append("@config_desc,");
            sb.Append("@config_type,");
            sb.Append("@config_type2,");
            sb.Append("@realtime_value1,");
            sb.Append("@realtime_value2,");
            sb.Append("@realtime_value3,");
            sb.Append("@t_create,");
            sb.Append("@t_update,");
            sb.Append("@flag_void,");
            sb.Append("@rsv_str1,");
            sb.Append("@rsv_str2,");
            sb.Append("@u_create_name,");
            sb.Append("@u_create_id,");
            sb.Append("@u_update_name,");
            sb.Append("@u_update_id,");
            sb.Append("@flag_delete )");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sb.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@config_code", SqlDbType.NVarChar, 500) { Value = newOne.config_code ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@config_desc", SqlDbType.NVarChar, 500) { Value = newOne.config_desc ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@config_type", SqlDbType.NVarChar, 500) { Value = newOne.config_type ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@config_type2", SqlDbType.NVarChar, 500) { Value = newOne.config_type2 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@realtime_value1", SqlDbType.NVarChar, 500) { Value = newOne.realtime_value1 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@realtime_value2", SqlDbType.NVarChar, 500) { Value = newOne.realtime_value2 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@realtime_value3", SqlDbType.NVarChar, 500) { Value = newOne.realtime_value3 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_create", SqlDbType.DateTime) { Value = newOne.t_create });
            cmd.Parameters.Add(new SqlParameter("@t_update", SqlDbType.DateTime) { Value = newOne.t_update });
            cmd.Parameters.Add(new SqlParameter("@flag_void", SqlDbType.NVarChar, 500) { Value = newOne.flag_void ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@rsv_str1", SqlDbType.NVarChar, 500) { Value = newOne.rsv_str1 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@rsv_str2", SqlDbType.NVarChar, 500) { Value = newOne.rsv_str2 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_name", SqlDbType.NVarChar, 500) { Value = newOne.u_create_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_id", SqlDbType.NVarChar, 500) { Value = newOne.u_create_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_update_name", SqlDbType.NVarChar, 500) { Value = newOne.u_update_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_update_id", SqlDbType.NVarChar, 500) { Value = newOne.u_update_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@flag_delete", SqlDbType.Bit) { Value = newOne.flag_delete });

            int val = DBHelper_SQLServer.ExecuteNonQuery(cmd);
            if (val > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

        //----------------------UpdateOne方法---------------------------------------//
        public static bool UpdateOne(sys_config newOne)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" update sys_config set  ");
            sb.Append("  config_desc = @config_desc ,   ");
            sb.Append("  config_type = @config_type ,   ");
            sb.Append("  config_type2 = @config_type2 ,   ");
            sb.Append("  realtime_value1 = @realtime_value1 ,   ");
            sb.Append("  realtime_value2 = @realtime_value2 ,   ");
            sb.Append("  realtime_value3 = @realtime_value3 ,   ");
            sb.Append("  t_create = @t_create ,   ");
            sb.Append("  t_update = @t_update ,   ");
            sb.Append("  flag_void = @flag_void ,   ");
            sb.Append("  rsv_str1 = @rsv_str1 ,   ");
            sb.Append("  rsv_str2 = @rsv_str2 ,   ");
            sb.Append("  u_create_name = @u_create_name ,   ");
            sb.Append("  u_create_id = @u_create_id ,   ");
            sb.Append("  u_update_name = @u_update_name ,   ");
            sb.Append("  u_update_id = @u_update_id ,   ");
            sb.Append("  flag_delete = @flag_delete   ");
            sb.Append(" where config_code = @config_code  ");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sb.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@config_desc", SqlDbType.NVarChar, 500) { Value = newOne.config_desc ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@config_type", SqlDbType.NVarChar, 500) { Value = newOne.config_type ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@config_type2", SqlDbType.NVarChar, 500) { Value = newOne.config_type2 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@realtime_value1", SqlDbType.NVarChar, 500) { Value = newOne.realtime_value1 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@realtime_value2", SqlDbType.NVarChar, 500) { Value = newOne.realtime_value2 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@realtime_value3", SqlDbType.NVarChar, 500) { Value = newOne.realtime_value3 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_create", SqlDbType.DateTime) { Value = newOne.t_create });
            cmd.Parameters.Add(new SqlParameter("@t_update", SqlDbType.DateTime) { Value = System.DateTime.Now });
            cmd.Parameters.Add(new SqlParameter("@flag_void", SqlDbType.NVarChar, 500) { Value = newOne.flag_void ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@rsv_str1", SqlDbType.NVarChar, 500) { Value = newOne.rsv_str1 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@rsv_str2", SqlDbType.NVarChar, 500) { Value = newOne.rsv_str2 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_name", SqlDbType.NVarChar, 500) { Value = newOne.u_create_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_id", SqlDbType.NVarChar, 500) { Value = newOne.u_create_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_update_name", SqlDbType.NVarChar, 500) { Value = newOne.u_update_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_update_id", SqlDbType.NVarChar, 500) { Value = newOne.u_update_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@flag_delete", SqlDbType.Bit) { Value = newOne.flag_delete });
            cmd.Parameters.Add(new SqlParameter("@config_code", SqlDbType.NVarChar, 500) { Value = newOne.config_code ?? DBNull.Value.ToString() });
            int val = DBHelper_SQLServer.ExecuteNonQuery(cmd);
            if (val > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //----------------------Delete方法---------------------------------------------//
        public static bool DeleteByPKID(object PK_ID)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" delete from sys_config where config_code=@config_code ");
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sb.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@config_code", SqlDbType.NVarChar, 150) { Value = PK_ID });
                int val = DBHelper_SQLServer.ExecuteNonQuery(cmd);
                if (val > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {
                return false;
            }
        }
        //----------------------GetOneByID方法--------------------------------------//
        public static sys_config GetOneByID(object PK_ID)
        {
            List<SqlParameter> prs = new List<SqlParameter>();
            prs.Add(new SqlParameter("@config_code", SqlDbType.NVarChar, 150) { Value = PK_ID });
            var lis = DoTableQuery("select * from sys_config where config_code =@config_code", prs.ToArray());
            if (lis.Count > 0)
            {
                return lis[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        ///		根据条件获取
        /// </summary>
        /// <returns></returns>
        public static List<sys_config> Get(List<KVP> keyValues)
        {
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parametrs = new List<SqlParameter>();
            sb.Append("select * from trx_sys_config where  flag_delete = 0 ");
            foreach (var keyValue in keyValues)
            {
                if (keyValue.Key.Trim().ToUpper() == "CONFIG_CODE")
                {

                }
                if (keyValue.Key.Trim().ToUpper() == "CONFIG_DESC")
                {

                }
                if (keyValue.Key.Trim().ToUpper() == "CONFIG_TYPE")
                {

                }
                if (keyValue.Key.Trim().ToUpper() == "CONFIG_TYPE2")
                {

                }
                if (keyValue.Key.Trim().ToUpper() == "STARTTIME")
                {
                    var start = Convert.ToDateTime(keyValue.Value).Date;

                }
                if (keyValue.Key.Trim().ToUpper() == "ENDTIME")
                {
                    var end = Convert.ToDateTime(keyValue.Value).AddDays(1).Date;

                }
            }
            var rtn = DoTableQuery(sb.ToString(), parametrs.ToArray());

            return rtn;
        }

        /// <summary>
        ///     根据条件分页查询
        /// </summary>
        /// <param name="keyValues"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="total"></param>
        /// <param name="isASC"></param>
        /// <returns></returns>
        public static List<sys_config> Get(List<KVP> keyValues, int PageSize, int PageIndex, out int total, bool isASC = true)
        {
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parametrs = new List<SqlParameter>();
            sb.Append("select * from trx_sys_config where  flag_delete = 0 ");
            foreach (var keyValue in keyValues)
            {
                if (keyValue.Key.Trim().ToUpper() == "CONFIG_CODE")
                {

                }
                if (keyValue.Key.Trim().ToUpper() == "CONFIG_DESC")
                {

                }
                if (keyValue.Key.Trim().ToUpper() == "CONFIG_TYPE")
                {

                }
                if (keyValue.Key.Trim().ToUpper() == "CONFIG_TYPE2")
                {

                }
                if (keyValue.Key.Trim().ToUpper() == "STARTTIME")
                {
                    var start = Convert.ToDateTime(keyValue.Value).Date;

                }
                if (keyValue.Key.Trim().ToUpper() == "ENDTIME")
                {
                    var end = Convert.ToDateTime(keyValue.Value).AddDays(1).Date;

                }
            }
            var rtn = DoTableQuery(sb.ToString(), parametrs.ToArray());
            total = rtn.Count;
            return rtn;
        }

        internal static int GetNewagvRcdID(string configcode)
        {
            int rtn = -1;
            List<SqlParameter> parass = new List<SqlParameter>();
            parass.Add(new SqlParameter("@config_code", configcode));

            SqlParameter pa = new SqlParameter();
            pa.Direction = ParameterDirection.Output;
            pa.ParameterName = "@new_value";
            pa.SqlDbType = SqlDbType.Int;
            parass.Add(pa);
            var prrslt = parass.ToArray();
            var rslt = DAL.DBHelper_SQLServer.ExecuteProcedure("p_getconfig_agv_newid", ref prrslt);
            var outResult = prrslt.ToList().Find(p => p.ParameterName == "@new_value");
            rtn = (outResult == null || outResult.Value == null) ? 0 : int.Parse(outResult.Value.ToString());
            return rtn;
        }

        internal static int GetNewRcdID(string configcode)
        {
            int rtn = -1;
            List<SqlParameter> parass = new List<SqlParameter>();
            parass.Add(new SqlParameter("@config_code", configcode));

            SqlParameter pa = new SqlParameter();
            pa.Direction = ParameterDirection.Output;
            pa.ParameterName = "@new_value";
            pa.SqlDbType = SqlDbType.Int;
            parass.Add(pa);
            var prrslt = parass.ToArray();
            var rslt = DAL.DBHelper_SQLServer.ExecuteProcedure("p_getconfig_newid", ref prrslt);
            var outResult = prrslt.ToList().Find(p => p.ParameterName == "@new_value");
            rtn = (outResult == null || outResult.Value == null) ? 0 : int.Parse(outResult.Value.ToString());
            return rtn;
        }

        public static List<sys_config> GetByTypes(string typecode)
        {
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parametrs = new List<SqlParameter>();
            sb.Append("select * from sys_config where  flag_delete = 0 ");
            sb.Append(" and CONFIG_TYPE=@CONFIG_TYPE ");
            parametrs.Add(new SqlParameter("@CONFIG_TYPE", typecode));

            var rtn = DoTableQuery(sb.ToString(), parametrs.ToArray());

            return rtn;

        }

       
        public DataTable GetBy_99999()
        {
           
            DBHelper_SQLServer sqlServer = new DBHelper_SQLServer();
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("select place_code,container_id  ");
                sb.Append("from [kavaTRX].[dbo].[wms_inventory]  ");
                sb.Append("where inv_type = 'InFinished' and mcode = '99999' and place_code like'13%'  ");
                sb.Append("or  ");
                sb.Append("inv_type = 'InFinished' and mcode = '99999' and place_code like'14%'   ");

                //string SQL = "select * from wms_inventory where inv_type = 'InFinished' and mcode = '99999'";               
                dt = sqlServer.Query(sb.ToString());
                if (dt.Rows.Count > 0)
                {
                    
                }
                else
                {
                    dt = null;
                }

            }
            catch (Exception)
            {
                dt = null;
            }       
            return dt;

        }


        public DataTable GetBy_9999()
        {

            DBHelper_SQLServer sqlServer = new DBHelper_SQLServer();
            DataTable dt = new DataTable();
            try
            {
                string SQL = "select * from wms_inventory where inv_type = 'DOING' and mcode = '99999'";

                dt = sqlServer.Query(SQL);
                if (dt.Rows.Count > 0)
                {

                }
                else
                {
                    dt = null;
                }

            }
            catch (Exception)
            {
                dt = null;
            }
            return dt;

        }




        internal static bool SysConfig_UpdateRealtimeValueByType(string typecode1, string typecode2, string value1, string value2, string value3)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                SqlCommand cmd = new SqlCommand();


                sb.Append(" update sys_config set t_update=getdate()  ");
                if (value1 != "")
                {
                    sb.Append(" , realtime_value1=@realtime_value1");
                    cmd.Parameters.Add(new SqlParameter("@realtime_value1", SqlDbType.NVarChar, 500) { Value = value1 });
                }
                if (value2 != "")
                {
                    sb.Append(" , realtime_value2 =@realtime_value2");
                    cmd.Parameters.Add(new SqlParameter("@realtime_value2", SqlDbType.NVarChar, 500) { Value = value2 });
                }
                if (value3 != "")
                {
                    sb.Append(" , realtime_value3 =@realtime_value3");
                    cmd.Parameters.Add(new SqlParameter("@realtime_value3", SqlDbType.NVarChar, 500) { Value = value3 });
                }
                sb.Append(" where CONFIG_TYPE=@CONFIG_TYPE  ");
                cmd.Parameters.Add(new SqlParameter("@CONFIG_TYPE", SqlDbType.NVarChar, 500) { Value = typecode1 });

                if (typecode2 != "")
                {
                    sb.Append(" and CONFIG_TYPE2=@CONFIG_TYPE2  ");
                    cmd.Parameters.Add(new SqlParameter("@CONFIG_TYPE2", SqlDbType.NVarChar, 500) { Value = typecode2 });
                }

                cmd.CommandText = sb.ToString();
                cmd.CommandType = CommandType.Text;

                int val = DBHelper_SQLServer.ExecuteNonQuery(cmd);
                if (val > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch  
            {
                return false;
            }
        }
    }
}