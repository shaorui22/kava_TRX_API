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
    public class da_sys_tbl_clmn_set
    {
        //---------------------按Table的方式查询方法--------------------------//
        private static List<sys_tbl_clmn_set> DoTableQuery(string sql_str, SqlParameter[] paras)
        {
            var lisRtn = new List<sys_tbl_clmn_set>();
            try
            {
                var dtback = DBHelper_SQLServer.ExecuteDataTable(sql_str, paras);
                lisRtn = EntityTableParse<sys_tbl_clmn_set>.ToList(dtback);
            }
            catch
            {
            }
            return lisRtn;
        }
        //---------------------查询并赋值到实体类list的方法  IReader方式--------------------------//
        private static List<sys_tbl_clmn_set> DoQuery(string sql_str, SqlParameter[] paras)
        {
            var lisRtn = new List<sys_tbl_clmn_set>();
            try
            {
                using (IDataReader dr = DBHelper_SQLServer.ExecuteReader(sql_str, paras))
                {
                    while (dr.Read())
                    {
                        var p = new sys_tbl_clmn_set();
                        #region 逐个赋值 
                        p.scid = DBHelper_SQLServer.GetDataValue<string>(dr, "scid");
                        p.tb_name = DBHelper_SQLServer.GetDataValue<string>(dr, "tb_name");
                        p.column_field = DBHelper_SQLServer.GetDataValue<string>(dr, "column_field");
                        p.column_desc = DBHelper_SQLServer.GetDataValue<string>(dr, "column_desc");
                        p.column_type = DBHelper_SQLServer.GetDataValue<string>(dr, "column_type");
                        p.display = DBHelper_SQLServer.GetDataValue<bool>(dr, "display");
                        p.allow_null = DBHelper_SQLServer.GetDataValue<bool>(dr, "allow_null");
                        p.default_value = DBHelper_SQLServer.GetDataValue<string>(dr, "default_value");
                        p.display_order = DBHelper_SQLServer.GetDataValue<int>(dr, "display_order");
                        p.u_create_name = DBHelper_SQLServer.GetDataValue<string>(dr, "u_create_name");
                        p.u_create_id = DBHelper_SQLServer.GetDataValue<string>(dr, "u_create_id");
                        p.t_create = DBHelper_SQLServer.GetDataValue<DateTime>(dr, "t_create");
                        p.u_update_name = DBHelper_SQLServer.GetDataValue<string>(dr, "u_update_name");
                        p.u_update_id = DBHelper_SQLServer.GetDataValue<string>(dr, "u_update_id");
                        p.t_update = DBHelper_SQLServer.GetDataValue<DateTime>(dr, "t_update");
                        p.flag_delete = DBHelper_SQLServer.GetDataValue<bool>(dr, "flag_delete");
                        p.dropdownList_vls = DBHelper_SQLServer.GetDataValue<string>(dr, "dropdownList_vls");
                        p.iskeycolumn = DBHelper_SQLServer.GetDataValue<bool>(dr, "iskeycolumn");
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
        public static bool InsertNew(sys_tbl_clmn_set newOne)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" Insert into sys_tbl_clmn_set (  ");
            sb.Append("scid, ");
            sb.Append("tb_name, ");
            sb.Append("column_field, ");
            sb.Append("column_desc, ");
            sb.Append("column_type, ");
            sb.Append("display, ");
            sb.Append("allow_null, ");
            sb.Append("default_value, ");
            sb.Append("display_order, ");
            sb.Append("u_create_name, ");
            sb.Append("u_create_id, ");
            sb.Append("t_create, ");
            sb.Append("u_update_name, ");
            sb.Append("u_update_id, ");
            sb.Append("t_update, ");
            sb.Append("flag_delete, ");
            sb.Append("dropdownList_vls, ");
            sb.Append("iskeycolumn )");
            sb.Append(" values ( ");
            sb.Append("@scid,");
            sb.Append("@tb_name,");
            sb.Append("@column_field,");
            sb.Append("@column_desc,");
            sb.Append("@column_type,");
            sb.Append("@display,");
            sb.Append("@allow_null,");
            sb.Append("@default_value,");
            sb.Append("@display_order,");
            sb.Append("@u_create_name,");
            sb.Append("@u_create_id,");
            sb.Append("@t_create,");
            sb.Append("@u_update_name,");
            sb.Append("@u_update_id,");
            sb.Append("@t_update,");
            sb.Append("@flag_delete,");
            sb.Append("@dropdownList_vls,");
            sb.Append("@iskeycolumn )");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sb.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@scid", SqlDbType.NVarChar, 500) { Value = newOne.scid ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@tb_name", SqlDbType.NVarChar, 500) { Value = newOne.tb_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@column_field", SqlDbType.NVarChar, 500) { Value = newOne.column_field ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@column_desc", SqlDbType.NVarChar, 500) { Value = newOne.column_desc ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@column_type", SqlDbType.NVarChar, 500) { Value = newOne.column_type ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@display", SqlDbType.Bit) { Value = newOne.display });
            cmd.Parameters.Add(new SqlParameter("@allow_null", SqlDbType.Bit) { Value = newOne.allow_null });
            cmd.Parameters.Add(new SqlParameter("@default_value", SqlDbType.NVarChar, 500) { Value = newOne.default_value ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@display_order", SqlDbType.Int) { Value = newOne.display_order });
            cmd.Parameters.Add(new SqlParameter("@u_create_name", SqlDbType.NVarChar, 500) { Value = newOne.u_create_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_id", SqlDbType.NVarChar, 500) { Value = newOne.u_create_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_create", SqlDbType.DateTime) { Value = newOne.t_create });
            cmd.Parameters.Add(new SqlParameter("@u_update_name", SqlDbType.NVarChar, 500) { Value = newOne.u_update_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_update_id", SqlDbType.NVarChar, 500) { Value = newOne.u_update_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_update", SqlDbType.DateTime) { Value = newOne.t_update });
            cmd.Parameters.Add(new SqlParameter("@flag_delete", SqlDbType.Bit) { Value = newOne.flag_delete });
            cmd.Parameters.Add(new SqlParameter("@dropdownList_vls", SqlDbType.NVarChar, 500) { Value = newOne.dropdownList_vls ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@iskeycolumn", SqlDbType.Bit) { Value = newOne.iskeycolumn });

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
        public static bool UpdateOne(sys_tbl_clmn_set newOne)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" update sys_tbl_clmn_set set  ");
            sb.Append("  tb_name = @tb_name ,   ");
            sb.Append("  column_field = @column_field ,   ");
            sb.Append("  column_desc = @column_desc ,   ");
            sb.Append("  column_type = @column_type ,   ");
            sb.Append("  display = @display ,   ");
            sb.Append("  allow_null = @allow_null ,   ");
            sb.Append("  default_value = @default_value ,   ");
            sb.Append("  display_order = @display_order ,   ");
            sb.Append("  u_create_name = @u_create_name ,   ");
            sb.Append("  u_create_id = @u_create_id ,   ");
            sb.Append("  t_create = @t_create ,   ");
            sb.Append("  u_update_name = @u_update_name ,   ");
            sb.Append("  u_update_id = @u_update_id ,   ");
            sb.Append("  t_update = @t_update ,   ");
            sb.Append("  flag_delete = @flag_delete ,   ");
            sb.Append("  dropdownList_vls = @dropdownList_vls ,   ");
            sb.Append("  iskeycolumn = @iskeycolumn   ");
            sb.Append(" where scid = @scid  ");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sb.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@tb_name", SqlDbType.NVarChar, 500) { Value = newOne.tb_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@column_field", SqlDbType.NVarChar, 500) { Value = newOne.column_field ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@column_desc", SqlDbType.NVarChar, 500) { Value = newOne.column_desc ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@column_type", SqlDbType.NVarChar, 500) { Value = newOne.column_type ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@display", SqlDbType.Bit) { Value = newOne.display });
            cmd.Parameters.Add(new SqlParameter("@allow_null", SqlDbType.Bit) { Value = newOne.allow_null });
            cmd.Parameters.Add(new SqlParameter("@default_value", SqlDbType.NVarChar, 500) { Value = newOne.default_value ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@display_order", SqlDbType.Int) { Value = newOne.display_order });
            cmd.Parameters.Add(new SqlParameter("@u_create_name", SqlDbType.NVarChar, 500) { Value = newOne.u_create_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_id", SqlDbType.NVarChar, 500) { Value = newOne.u_create_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_create", SqlDbType.DateTime) { Value = newOne.t_create });
            cmd.Parameters.Add(new SqlParameter("@u_update_name", SqlDbType.NVarChar, 500) { Value = newOne.u_update_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_update_id", SqlDbType.NVarChar, 500) { Value = newOne.u_update_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_update", SqlDbType.DateTime) { Value = newOne.t_update });
            cmd.Parameters.Add(new SqlParameter("@flag_delete", SqlDbType.Bit) { Value = newOne.flag_delete });
            cmd.Parameters.Add(new SqlParameter("@dropdownList_vls", SqlDbType.NVarChar, 500) { Value = newOne.dropdownList_vls ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@iskeycolumn", SqlDbType.Bit) { Value = newOne.iskeycolumn });
            cmd.Parameters.Add(new SqlParameter("@scid", SqlDbType.NVarChar, 500) { Value = newOne.scid ?? DBNull.Value.ToString() });
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
                sb.Append(" delete from sys_tbl_clmn_set where scid=@scid ");
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sb.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@scid", SqlDbType.NVarChar, 150) { Value = PK_ID });
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
        public static sys_tbl_clmn_set GetOneByID(object PK_ID)
        {
            List<SqlParameter> prs = new List<SqlParameter>();
            prs.Add(new SqlParameter("@scid", SqlDbType.NVarChar, 150) { Value = PK_ID });
            var lis = DoTableQuery("select * from sys_tbl_clmn_set where scid =@scid", prs.ToArray());
            if (lis != null && lis.Count > 0)
            {
                return lis[0];
            }
            else
            {
                return null;
            }
        }

        public static List<sys_tbl_clmn_set> GetByTableName(string tablename)
        {
            List<SqlParameter> prs = new List<SqlParameter>();
            prs.Add(new SqlParameter("@tb_name", SqlDbType.NVarChar, 150) { Value = tablename });
            var lis = DoTableQuery("select * from sys_tbl_clmn_set where tb_name =@tb_name", prs.ToArray());
            return lis;
        }

    }
}