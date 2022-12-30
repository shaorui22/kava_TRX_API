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
    public class da_im_container
    {
        //---------------------按Table的方式查询方法--------------------------//
        private static List<im_container> DoTableQuery(string sql_str, SqlParameter[] paras)
        {
            var lisRtn = new List<im_container>();
            try
            {
                var dtback = DBHelper_SQLServer.ExecuteDataTable(sql_str, paras);
                lisRtn = EntityTableParse<im_container>.ToList(dtback);
            }
            catch
            {
            }
            return lisRtn;
        }
        //---------------------查询并赋值到实体类list的方法  IReader方式--------------------------//
        private static List<im_container> DoQuery(string sql_str, SqlParameter[] paras)
        {
            var lisRtn = new List<im_container>();
            try
            {
                using (IDataReader dr = DBHelper_SQLServer.ExecuteReader(sql_str, paras))
                {
                    while (dr.Read())
                    {
                        var p = new im_container();
                        #region 逐个赋值 
                        p.ctnid = DBHelper_SQLServer.GetDataValue<string>(dr, "ctnid");
                        p.ctncode = DBHelper_SQLServer.GetDataValue<string>(dr, "ctncode");
                        p.ctndesc = DBHelper_SQLServer.GetDataValue<string>(dr, "ctndesc");
                        p.ctn_type = DBHelper_SQLServer.GetDataValue<string>(dr, "ctn_type");
                        p.ctn_length = DBHelper_SQLServer.GetDataValue<int>(dr, "ctn_length");
                        p.ctn_width = DBHelper_SQLServer.GetDataValue<int>(dr, "ctn_width");
                        p.ctn_height = DBHelper_SQLServer.GetDataValue<int>(dr, "ctn_height");
                        p.max_weight = DBHelper_SQLServer.GetDataValue<decimal>(dr, "max_weight");
                        p.selt_weight = DBHelper_SQLServer.GetDataValue<decimal>(dr, "selt_weight");
                        p.bind_factory_line = DBHelper_SQLServer.GetDataValue<string>(dr, "bind_factory_line");
                        p.bind_material_type = DBHelper_SQLServer.GetDataValue<string>(dr, "bind_material_type");
                        p.bind_material_code = DBHelper_SQLServer.GetDataValue<string>(dr, "bind_material_code");
                        p.u_create_name = DBHelper_SQLServer.GetDataValue<string>(dr, "u_create_name");
                        p.u_create_id = DBHelper_SQLServer.GetDataValue<string>(dr, "u_create_id");
                        p.t_create = DBHelper_SQLServer.GetDataValue<DateTime>(dr, "t_create");
                        p.u_update_name = DBHelper_SQLServer.GetDataValue<string>(dr, "u_update_name");
                        p.u_update_id = DBHelper_SQLServer.GetDataValue<string>(dr, "u_update_id");
                        p.t_update = DBHelper_SQLServer.GetDataValue<DateTime>(dr, "t_update");
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
        public static bool InsertNew(im_container newOne)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" Insert into im_container (  ");
            sb.Append("ctnid, ");
            sb.Append("ctncode, ");
            sb.Append("ctndesc, ");
            sb.Append("ctn_type, ");
            sb.Append("ctn_length, ");
            sb.Append("ctn_width, ");
            sb.Append("ctn_height, ");
            sb.Append("max_weight, ");
            sb.Append("selt_weight, ");
            sb.Append("bind_factory_line, ");
            sb.Append("bind_material_type, ");
            sb.Append("bind_material_code, ");
            sb.Append("u_create_name, ");
            sb.Append("u_create_id, ");
            sb.Append("t_create, ");
            sb.Append("u_update_name, ");
            sb.Append("u_update_id, ");
            sb.Append("t_update, ");
            sb.Append("flag_delete )");
            sb.Append(" values ( ");
            sb.Append("@ctnid,");
            sb.Append("@ctncode,");
            sb.Append("@ctndesc,");
            sb.Append("@ctn_type,");
            sb.Append("@ctn_length,");
            sb.Append("@ctn_width,");
            sb.Append("@ctn_height,");
            sb.Append("@max_weight,");
            sb.Append("@selt_weight,");
            sb.Append("@bind_factory_line,");
            sb.Append("@bind_material_type,");
            sb.Append("@bind_material_code,");
            sb.Append("@u_create_name,");
            sb.Append("@u_create_id,");
            sb.Append("@t_create,");
            sb.Append("@u_update_name,");
            sb.Append("@u_update_id,");
            sb.Append("@t_update,");
            sb.Append("@flag_delete )");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sb.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@ctnid", SqlDbType.NVarChar, 500) { Value = newOne.ctnid ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@ctncode", SqlDbType.NVarChar, 500) { Value = newOne.ctncode ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@ctndesc", SqlDbType.NVarChar, 500) { Value = newOne.ctndesc ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@ctn_type", SqlDbType.NVarChar, 500) { Value = newOne.ctn_type ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@ctn_length", SqlDbType.Int) { Value = newOne.ctn_length });
            cmd.Parameters.Add(new SqlParameter("@ctn_width", SqlDbType.Int) { Value = newOne.ctn_width });
            cmd.Parameters.Add(new SqlParameter("@ctn_height", SqlDbType.Int) { Value = newOne.ctn_height });
            cmd.Parameters.Add(new SqlParameter("@max_weight", SqlDbType.Decimal) { Value = newOne.max_weight });
            cmd.Parameters.Add(new SqlParameter("@selt_weight", SqlDbType.Decimal) { Value = newOne.selt_weight });
            cmd.Parameters.Add(new SqlParameter("@bind_factory_line", SqlDbType.NVarChar, 500) { Value = newOne.bind_factory_line ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@bind_material_type", SqlDbType.NVarChar, 500) { Value = newOne.bind_material_type ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@bind_material_code", SqlDbType.NVarChar, 500) { Value = newOne.bind_material_code ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_name", SqlDbType.NVarChar, 500) { Value = newOne.u_create_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_id", SqlDbType.NVarChar, 500) { Value = newOne.u_create_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_create", SqlDbType.DateTime) { Value = newOne.t_create });
            cmd.Parameters.Add(new SqlParameter("@u_update_name", SqlDbType.NVarChar, 500) { Value = newOne.u_update_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_update_id", SqlDbType.NVarChar, 500) { Value = newOne.u_update_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_update", SqlDbType.DateTime) { Value = newOne.t_update });
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
        public static bool UpdateOne(im_container newOne)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" update im_container set  ");
            sb.Append("  ctncode = @ctncode ,   ");
            sb.Append("  ctndesc = @ctndesc ,   ");
            sb.Append("  ctn_type = @ctn_type ,   ");
            sb.Append("  ctn_length = @ctn_length ,   ");
            sb.Append("  ctn_width = @ctn_width ,   ");
            sb.Append("  ctn_height = @ctn_height ,   ");
            sb.Append("  max_weight = @max_weight ,   ");
            sb.Append("  selt_weight = @selt_weight ,   ");
            sb.Append("  bind_factory_line = @bind_factory_line ,   ");
            sb.Append("  bind_material_type = @bind_material_type ,   ");
            sb.Append("  bind_material_code = @bind_material_code ,   ");
            sb.Append("  u_create_name = @u_create_name ,   ");
            sb.Append("  u_create_id = @u_create_id ,   ");
            sb.Append("  t_create = @t_create ,   ");
            sb.Append("  u_update_name = @u_update_name ,   ");
            sb.Append("  u_update_id = @u_update_id ,   ");
            sb.Append("  t_update = @t_update ,   ");
            sb.Append("  flag_delete = @flag_delete   ");
            sb.Append(" where ctnid = @ctnid  ");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sb.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@ctncode", SqlDbType.NVarChar, 500) { Value = newOne.ctncode ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@ctndesc", SqlDbType.NVarChar, 500) { Value = newOne.ctndesc ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@ctn_type", SqlDbType.NVarChar, 500) { Value = newOne.ctn_type ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@ctn_length", SqlDbType.Int) { Value = newOne.ctn_length });
            cmd.Parameters.Add(new SqlParameter("@ctn_width", SqlDbType.Int) { Value = newOne.ctn_width });
            cmd.Parameters.Add(new SqlParameter("@ctn_height", SqlDbType.Int) { Value = newOne.ctn_height });
            cmd.Parameters.Add(new SqlParameter("@max_weight", SqlDbType.Decimal) { Value = newOne.max_weight });
            cmd.Parameters.Add(new SqlParameter("@selt_weight", SqlDbType.Decimal) { Value = newOne.selt_weight });
            cmd.Parameters.Add(new SqlParameter("@bind_factory_line", SqlDbType.NVarChar, 500) { Value = newOne.bind_factory_line ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@bind_material_type", SqlDbType.NVarChar, 500) { Value = newOne.bind_material_type ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@bind_material_code", SqlDbType.NVarChar, 500) { Value = newOne.bind_material_code ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_name", SqlDbType.NVarChar, 500) { Value = newOne.u_create_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_id", SqlDbType.NVarChar, 500) { Value = newOne.u_create_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_create", SqlDbType.DateTime) { Value = newOne.t_create });
            cmd.Parameters.Add(new SqlParameter("@u_update_name", SqlDbType.NVarChar, 500) { Value = newOne.u_update_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_update_id", SqlDbType.NVarChar, 500) { Value = newOne.u_update_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_update", SqlDbType.DateTime) { Value = newOne.t_update });
            cmd.Parameters.Add(new SqlParameter("@flag_delete", SqlDbType.Bit) { Value = newOne.flag_delete });
            cmd.Parameters.Add(new SqlParameter("@ctnid", SqlDbType.NVarChar, 500) { Value = newOne.ctnid ?? DBNull.Value.ToString() });
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
                sb.Append(" delete from im_container where ctnid=@ctnid ");
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sb.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@ctnid", SqlDbType.NVarChar, 150) { Value = PK_ID });
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
        public static im_container GetOneByID(object PK_ID)
        {
            List<SqlParameter> prs = new List<SqlParameter>();
            prs.Add(new SqlParameter("@ctnid", SqlDbType.NVarChar, 150) { Value = PK_ID });
            var lis = DoTableQuery("select * from im_container where ctnid =@ctnid", prs.ToArray());
            if (lis != null && lis.Count > 0)
            {
                return lis[0];
            }
            else
            {
                return null;
            }
        }

        public static List<im_container> GetByCodeDESC(string desc)
        {
            List<SqlParameter> prs = new List<SqlParameter>();
            var lis = DoTableQuery("select * from im_container where (ctncode like '%" + desc + "%') or (ctndesc like '%" + desc + "%')", prs.ToArray());
            return lis;
        }
        /// <summary>
        ///		根据条件获取
        /// </summary>
        /// <returns></returns>
        public static List<im_container> Get(List<KVP> keyValues)
        {
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parametrs = new List<SqlParameter>();
            sb.Append("select * from im_container where  flag_delete = 0 ");
            foreach (var keyValue in keyValues)
            {
                if (keyValue.Key.Trim().ToUpper() == "CTNCODE")
                {

                }
                if (keyValue.Key.Trim().ToUpper() == "CTNDESC")
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
            return DoTableQuery(sb.ToString(), parametrs.ToArray());
        }
        public static List<im_container> GetALL()
        {
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parametrs = new List<SqlParameter>();
            sb.Append("select * from im_container where  flag_delete = 0 ");
            return DoTableQuery(sb.ToString(), parametrs.ToArray());
        }
 
    }
}