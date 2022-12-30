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
    public class da_wms_places
    {
        //---------------------按Table的方式查询方法--------------------------//
        private static List<wms_places> DoTableQuery(string sql_str, SqlParameter[] paras)
        {
            var lisRtn = new List<wms_places>();
            try
            {
                var dtback = DBHelper_SQLServer.ExecuteDataTable(sql_str, paras);
                lisRtn = EntityTableParse<wms_places>.ToList(dtback);
            }
            catch
            {
            }
            return lisRtn;
        }
        //---------------------查询并赋值到实体类list的方法  IReader方式--------------------------//
        private static List<wms_places> DoQuery(string sql_str, SqlParameter[] paras)
        {
            var lisRtn = new List<wms_places>();
            try
            {
                using (IDataReader dr = DBHelper_SQLServer.ExecuteReader(sql_str, paras))
                {
                    while (dr.Read())
                    {
                        var p = new wms_places();
                        #region 逐个赋值 
                        p.plid = DBHelper_SQLServer.GetDataValue<string>(dr, "plid");
                        p.place_code = DBHelper_SQLServer.GetDataValue<string>(dr, "place_code");
                        p.plant_code = DBHelper_SQLServer.GetDataValue<string>(dr, "plant_code");
                        p.warehouse_code = DBHelper_SQLServer.GetDataValue<string>(dr, "warehouse_code");
                        p.code_wcs = DBHelper_SQLServer.GetDataValue<string>(dr, "code_wcs");
                        p.code_mes = DBHelper_SQLServer.GetDataValue<string>(dr, "code_mes");
                        p.code_erp = DBHelper_SQLServer.GetDataValue<string>(dr, "code_erp");
                        p.numb_lane = DBHelper_SQLServer.GetDataValue<int>(dr, "numb_lane");
                        p.numb_row = DBHelper_SQLServer.GetDataValue<int>(dr, "numb_row");
                        p.numb_column = DBHelper_SQLServer.GetDataValue<int>(dr, "numb_column");
                        p.numb_layer = DBHelper_SQLServer.GetDataValue<int>(dr, "numb_layer");
                        p.numb_unit = DBHelper_SQLServer.GetDataValue<int>(dr, "numb_unit");
                        p.place_desc = DBHelper_SQLServer.GetDataValue<string>(dr, "place_desc");
                        p.place_type = DBHelper_SQLServer.GetDataValue<string>(dr, "place_type");
                        p.place_area = DBHelper_SQLServer.GetDataValue<string>(dr, "place_area");
                        p.is_empty = DBHelper_SQLServer.GetDataValue<string>(dr, "is_empty");
                        p.flag_lock = DBHelper_SQLServer.GetDataValue<string>(dr, "flag_lock");
                        p.flag_has_task = DBHelper_SQLServer.GetDataValue<string>(dr, "flag_has_task");
                        p.bind_material_type = DBHelper_SQLServer.GetDataValue<string>(dr, "bind_material_type");
                        p.bind_material_code = DBHelper_SQLServer.GetDataValue<string>(dr, "bind_material_code");
                        p.u_create_name = DBHelper_SQLServer.GetDataValue<string>(dr, "u_create_name");
                        p.u_create_id = DBHelper_SQLServer.GetDataValue<string>(dr, "u_create_id");
                        p.t_create = DBHelper_SQLServer.GetDataValue<DateTime>(dr, "t_create");
                        p.u_update_name = DBHelper_SQLServer.GetDataValue<string>(dr, "u_update_name");
                        p.u_update_id = DBHelper_SQLServer.GetDataValue<string>(dr, "u_update_id");
                        p.t_update = DBHelper_SQLServer.GetDataValue<DateTime>(dr, "t_update");
                        p.flag_delete = DBHelper_SQLServer.GetDataValue<bool>(dr, "flag_delete");
                        p.hight_level = DBHelper_SQLServer.GetDataValue<string>(dr, "hight_level");
                        p.pl_length = DBHelper_SQLServer.GetDataValue<int>(dr, "pl_length");
                        p.pl_width = DBHelper_SQLServer.GetDataValue<int>(dr, "pl_width");
                        p.pl_height = DBHelper_SQLServer.GetDataValue<int>(dr, "pl_height");
                        p.max_weight = DBHelper_SQLServer.GetDataValue<decimal>(dr, "max_weight");
                        p.pallet_container = DBHelper_SQLServer.GetDataValue<string>(dr, "pallet_container");
                        p.belong_device = DBHelper_SQLServer.GetDataValue<string>(dr, "belong_device");
                        p.rsv_str1 = DBHelper_SQLServer.GetDataValue<string>(dr, "rsv_str1");
                        p.rsv_str2 = DBHelper_SQLServer.GetDataValue<string>(dr, "rsv_str2");
                        p.rsv_str3 = DBHelper_SQLServer.GetDataValue<string>(dr, "rsv_str3");
                        p.rsv_str4 = DBHelper_SQLServer.GetDataValue<string>(dr, "rsv_str4");
                        p.rsv_str5 = DBHelper_SQLServer.GetDataValue<string>(dr, "rsv_str5");
                        p.i1 = DBHelper_SQLServer.GetDataValue<int>(dr, "i1");
                        p.i2 = DBHelper_SQLServer.GetDataValue<int>(dr, "i2");
                        p.i3 = DBHelper_SQLServer.GetDataValue<int>(dr, "i3");
                        p.i4 = DBHelper_SQLServer.GetDataValue<int>(dr, "i4");
                        p.i5 = DBHelper_SQLServer.GetDataValue<int>(dr, "i5");
                        p.n1 = DBHelper_SQLServer.GetDataValue<decimal>(dr, "n1");
                        p.n2 = DBHelper_SQLServer.GetDataValue<decimal>(dr, "n2");
                        p.n3 = DBHelper_SQLServer.GetDataValue<decimal>(dr, "n3");
                        p.n4 = DBHelper_SQLServer.GetDataValue<decimal>(dr, "n4");
                        p.n5 = DBHelper_SQLServer.GetDataValue<decimal>(dr, "n5");
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

        internal static object GetDockEmptyPlaceByPallet(string container_id)
        {
            throw new NotImplementedException();
        }

        //----------------------Insert方法----------------------------------------------//
        public static bool InsertNew(wms_places newOne)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" Insert into wms_places (  ");
            sb.Append("plid, ");
            sb.Append("place_code, ");
            sb.Append("plant_code, ");
            sb.Append("warehouse_code, ");
            sb.Append("code_wcs, ");
            sb.Append("code_mes, ");
            sb.Append("code_erp, ");
            sb.Append("numb_lane, ");
            sb.Append("numb_row, ");
            sb.Append("numb_column, ");
            sb.Append("numb_layer, ");
            sb.Append("numb_unit, ");
            sb.Append("place_desc, ");
            sb.Append("place_type, ");
            sb.Append("place_area, ");
            sb.Append("is_empty, ");
            sb.Append("flag_lock, ");
            sb.Append("flag_has_task, ");
            sb.Append("bind_material_type, ");
            sb.Append("bind_material_code, ");
            sb.Append("u_create_name, ");
            sb.Append("u_create_id, ");
            sb.Append("t_create, ");
            sb.Append("u_update_name, ");
            sb.Append("u_update_id, ");
            sb.Append("t_update, ");
            sb.Append("flag_delete, ");
            sb.Append("hight_level, ");
            sb.Append("pl_length, ");
            sb.Append("pl_width, ");
            sb.Append("pl_height, ");
            sb.Append("max_weight, ");
            sb.Append("pallet_container, ");
            sb.Append("belong_device, ");
            sb.Append("rsv_str1, ");
            sb.Append("rsv_str2, ");
            sb.Append("rsv_str3, ");
            sb.Append("rsv_str4, ");
            sb.Append("rsv_str5, ");
            sb.Append("i1, ");
            sb.Append("i2, ");
            sb.Append("i3, ");
            sb.Append("i4, ");
            sb.Append("i5, ");
            sb.Append("n1, ");
            sb.Append("n2, ");
            sb.Append("n3, ");
            sb.Append("n4, ");
            sb.Append("n5 )");
            sb.Append(" values ( ");
            sb.Append("@plid,");
            sb.Append("@place_code,");
            sb.Append("@plant_code,");
            sb.Append("@warehouse_code,");
            sb.Append("@code_wcs,");
            sb.Append("@code_mes,");
            sb.Append("@code_erp,");
            sb.Append("@numb_lane,");
            sb.Append("@numb_row,");
            sb.Append("@numb_column,");
            sb.Append("@numb_layer,");
            sb.Append("@numb_unit,");
            sb.Append("@place_desc,");
            sb.Append("@place_type,");
            sb.Append("@place_area,");
            sb.Append("@is_empty,");
            sb.Append("@flag_lock,");
            sb.Append("@flag_has_task,");
            sb.Append("@bind_material_type,");
            sb.Append("@bind_material_code,");
            sb.Append("@u_create_name,");
            sb.Append("@u_create_id,");
            sb.Append("@t_create,");
            sb.Append("@u_update_name,");
            sb.Append("@u_update_id,");
            sb.Append("@t_update,");
            sb.Append("@flag_delete,");
            sb.Append("@hight_level,");
            sb.Append("@pl_length,");
            sb.Append("@pl_width,");
            sb.Append("@pl_height,");
            sb.Append("@max_weight,");
            sb.Append("@pallet_container,");
            sb.Append("@belong_device,");
            sb.Append("@rsv_str1,");
            sb.Append("@rsv_str2,");
            sb.Append("@rsv_str3,");
            sb.Append("@rsv_str4,");
            sb.Append("@rsv_str5,");
            sb.Append("@i1,");
            sb.Append("@i2,");
            sb.Append("@i3,");
            sb.Append("@i4,");
            sb.Append("@i5,");
            sb.Append("@n1,");
            sb.Append("@n2,");
            sb.Append("@n3,");
            sb.Append("@n4,");
            sb.Append("@n5 )");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sb.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@plid", SqlDbType.NVarChar, 500) { Value = newOne.plid ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@place_code", SqlDbType.NVarChar, 500) { Value = newOne.place_code ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@plant_code", SqlDbType.NVarChar, 500) { Value = newOne.plant_code ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@warehouse_code", SqlDbType.NVarChar, 500) { Value = newOne.warehouse_code ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@code_wcs", SqlDbType.NVarChar, 500) { Value = newOne.code_wcs ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@code_mes", SqlDbType.NVarChar, 500) { Value = newOne.code_mes ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@code_erp", SqlDbType.NVarChar, 500) { Value = newOne.code_erp ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@numb_lane", SqlDbType.Int) { Value = newOne.numb_lane });
            cmd.Parameters.Add(new SqlParameter("@numb_row", SqlDbType.Int) { Value = newOne.numb_row });
            cmd.Parameters.Add(new SqlParameter("@numb_column", SqlDbType.Int) { Value = newOne.numb_column });
            cmd.Parameters.Add(new SqlParameter("@numb_layer", SqlDbType.Int) { Value = newOne.numb_layer });
            cmd.Parameters.Add(new SqlParameter("@numb_unit", SqlDbType.Int) { Value = newOne.numb_unit });
            cmd.Parameters.Add(new SqlParameter("@place_desc", SqlDbType.NVarChar, 500) { Value = newOne.place_desc ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@place_type", SqlDbType.NVarChar, 500) { Value = newOne.place_type ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@place_area", SqlDbType.NVarChar, 500) { Value = newOne.place_area ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@is_empty", SqlDbType.NVarChar, 500) { Value = newOne.is_empty ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@flag_lock", SqlDbType.NVarChar, 500) { Value = newOne.flag_lock ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@flag_has_task", SqlDbType.NVarChar, 500) { Value = newOne.flag_has_task ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@bind_material_type", SqlDbType.NVarChar, 500) { Value = newOne.bind_material_type ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@bind_material_code", SqlDbType.NVarChar, 500) { Value = newOne.bind_material_code ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_name", SqlDbType.NVarChar, 500) { Value = newOne.u_create_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_id", SqlDbType.NVarChar, 500) { Value = newOne.u_create_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_create", SqlDbType.DateTime) { Value = newOne.t_create });
            cmd.Parameters.Add(new SqlParameter("@u_update_name", SqlDbType.NVarChar, 500) { Value = newOne.u_update_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_update_id", SqlDbType.NVarChar, 500) { Value = newOne.u_update_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_update", SqlDbType.DateTime) { Value = newOne.t_update });
            cmd.Parameters.Add(new SqlParameter("@flag_delete", SqlDbType.Bit) { Value = newOne.flag_delete });
            cmd.Parameters.Add(new SqlParameter("@hight_level", SqlDbType.NVarChar, 500) { Value = newOne.hight_level ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@pl_length", SqlDbType.Int) { Value = newOne.pl_length });
            cmd.Parameters.Add(new SqlParameter("@pl_width", SqlDbType.Int) { Value = newOne.pl_width });
            cmd.Parameters.Add(new SqlParameter("@pl_height", SqlDbType.Int) { Value = newOne.pl_height });
            cmd.Parameters.Add(new SqlParameter("@max_weight", SqlDbType.Decimal) { Value = newOne.max_weight });
            cmd.Parameters.Add(new SqlParameter("@pallet_container", SqlDbType.NVarChar, 500) { Value = newOne.pallet_container ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@belong_device", SqlDbType.NVarChar, 500) { Value = newOne.belong_device ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@rsv_str1", SqlDbType.NVarChar, 500) { Value = newOne.rsv_str1 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@rsv_str2", SqlDbType.NVarChar, 500) { Value = newOne.rsv_str2 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@rsv_str3", SqlDbType.NVarChar, 500) { Value = newOne.rsv_str3 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@rsv_str4", SqlDbType.NVarChar, 500) { Value = newOne.rsv_str4 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@rsv_str5", SqlDbType.NVarChar, 500) { Value = newOne.rsv_str5 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@i1", SqlDbType.Int) { Value = newOne.i1 });
            cmd.Parameters.Add(new SqlParameter("@i2", SqlDbType.Int) { Value = newOne.i2 });
            cmd.Parameters.Add(new SqlParameter("@i3", SqlDbType.Int) { Value = newOne.i3 });
            cmd.Parameters.Add(new SqlParameter("@i4", SqlDbType.Int) { Value = newOne.i4 });
            cmd.Parameters.Add(new SqlParameter("@i5", SqlDbType.Int) { Value = newOne.i5 });
            cmd.Parameters.Add(new SqlParameter("@n1", SqlDbType.Decimal) { Value = newOne.n1 });
            cmd.Parameters.Add(new SqlParameter("@n2", SqlDbType.Decimal) { Value = newOne.n2 });
            cmd.Parameters.Add(new SqlParameter("@n3", SqlDbType.Decimal) { Value = newOne.n3 });
            cmd.Parameters.Add(new SqlParameter("@n4", SqlDbType.Decimal) { Value = newOne.n4 });
            cmd.Parameters.Add(new SqlParameter("@n5", SqlDbType.Decimal) { Value = newOne.n5 });

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
        public static bool UpdateOne(wms_places newOne)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" update wms_places set  ");
            sb.Append("  place_code = @place_code ,   ");
            sb.Append("  plant_code = @plant_code ,   ");
            sb.Append("  warehouse_code = @warehouse_code ,   ");
            sb.Append("  code_wcs = @code_wcs ,   ");
            sb.Append("  code_mes = @code_mes ,   ");
            sb.Append("  code_erp = @code_erp ,   ");
            sb.Append("  numb_lane = @numb_lane ,   ");
            sb.Append("  numb_row = @numb_row ,   ");
            sb.Append("  numb_column = @numb_column ,   ");
            sb.Append("  numb_layer = @numb_layer ,   ");
            sb.Append("  numb_unit = @numb_unit ,   ");
            sb.Append("  place_desc = @place_desc ,   ");
            sb.Append("  place_type = @place_type ,   ");
            sb.Append("  place_area = @place_area ,   ");
            sb.Append("  is_empty = @is_empty ,   ");
            sb.Append("  flag_lock = @flag_lock ,   ");
            sb.Append("  flag_has_task = @flag_has_task ,   ");
            sb.Append("  bind_material_type = @bind_material_type ,   ");
            sb.Append("  bind_material_code = @bind_material_code ,   ");
            sb.Append("  u_create_name = @u_create_name ,   ");
            sb.Append("  u_create_id = @u_create_id ,   ");
            sb.Append("  t_create = @t_create ,   ");
            sb.Append("  u_update_name = @u_update_name ,   ");
            sb.Append("  u_update_id = @u_update_id ,   ");
            sb.Append("  t_update = @t_update ,   ");
            sb.Append("  flag_delete = @flag_delete ,   ");
            sb.Append("  hight_level = @hight_level ,   ");
            sb.Append("  pl_length = @pl_length ,   ");
            sb.Append("  pl_width = @pl_width ,   ");
            sb.Append("  pl_height = @pl_height ,   ");
            sb.Append("  max_weight = @max_weight ,   ");
            sb.Append("  pallet_container = @pallet_container ,   ");
            sb.Append("  belong_device = @belong_device ,   ");
            sb.Append("  rsv_str1 = @rsv_str1 ,   ");
            sb.Append("  rsv_str2 = @rsv_str2 ,   ");
            sb.Append("  rsv_str3 = @rsv_str3 ,   ");
            sb.Append("  rsv_str4 = @rsv_str4 ,   ");
            sb.Append("  rsv_str5 = @rsv_str5 ,   ");
            sb.Append("  i1 = @i1 ,   ");
            sb.Append("  i2 = @i2 ,   ");
            sb.Append("  i3 = @i3 ,   ");
            sb.Append("  i4 = @i4 ,   ");
            sb.Append("  i5 = @i5 ,   ");
            sb.Append("  n1 = @n1 ,   ");
            sb.Append("  n2 = @n2 ,   ");
            sb.Append("  n3 = @n3 ,   ");
            sb.Append("  n4 = @n4 ,   ");
            sb.Append("  n5 = @n5   ");
            sb.Append(" where plid = @plid  ");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sb.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@place_code", SqlDbType.NVarChar, 500) { Value = newOne.place_code ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@plant_code", SqlDbType.NVarChar, 500) { Value = newOne.plant_code ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@warehouse_code", SqlDbType.NVarChar, 500) { Value = newOne.warehouse_code ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@code_wcs", SqlDbType.NVarChar, 500) { Value = newOne.code_wcs ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@code_mes", SqlDbType.NVarChar, 500) { Value = newOne.code_mes ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@code_erp", SqlDbType.NVarChar, 500) { Value = newOne.code_erp ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@numb_lane", SqlDbType.Int) { Value = newOne.numb_lane });
            cmd.Parameters.Add(new SqlParameter("@numb_row", SqlDbType.Int) { Value = newOne.numb_row });
            cmd.Parameters.Add(new SqlParameter("@numb_column", SqlDbType.Int) { Value = newOne.numb_column });
            cmd.Parameters.Add(new SqlParameter("@numb_layer", SqlDbType.Int) { Value = newOne.numb_layer });
            cmd.Parameters.Add(new SqlParameter("@numb_unit", SqlDbType.Int) { Value = newOne.numb_unit });
            cmd.Parameters.Add(new SqlParameter("@place_desc", SqlDbType.NVarChar, 500) { Value = newOne.place_desc ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@place_type", SqlDbType.NVarChar, 500) { Value = newOne.place_type ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@place_area", SqlDbType.NVarChar, 500) { Value = newOne.place_area ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@is_empty", SqlDbType.NVarChar, 500) { Value = newOne.is_empty ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@flag_lock", SqlDbType.NVarChar, 500) { Value = newOne.flag_lock ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@flag_has_task", SqlDbType.NVarChar, 500) { Value = newOne.flag_has_task ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@bind_material_type", SqlDbType.NVarChar, 500) { Value = newOne.bind_material_type ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@bind_material_code", SqlDbType.NVarChar, 500) { Value = newOne.bind_material_code ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_name", SqlDbType.NVarChar, 500) { Value = newOne.u_create_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_id", SqlDbType.NVarChar, 500) { Value = newOne.u_create_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_create", SqlDbType.DateTime) { Value = newOne.t_create });
            cmd.Parameters.Add(new SqlParameter("@u_update_name", SqlDbType.NVarChar, 500) { Value = newOne.u_update_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_update_id", SqlDbType.NVarChar, 500) { Value = newOne.u_update_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_update", SqlDbType.DateTime) { Value = newOne.t_update });
            cmd.Parameters.Add(new SqlParameter("@flag_delete", SqlDbType.Bit) { Value = newOne.flag_delete });
            cmd.Parameters.Add(new SqlParameter("@hight_level", SqlDbType.NVarChar, 500) { Value = newOne.hight_level ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@pl_length", SqlDbType.Int) { Value = newOne.pl_length });
            cmd.Parameters.Add(new SqlParameter("@pl_width", SqlDbType.Int) { Value = newOne.pl_width });
            cmd.Parameters.Add(new SqlParameter("@pl_height", SqlDbType.Int) { Value = newOne.pl_height });
            cmd.Parameters.Add(new SqlParameter("@max_weight", SqlDbType.Decimal) { Value = newOne.max_weight });
            cmd.Parameters.Add(new SqlParameter("@pallet_container", SqlDbType.NVarChar, 500) { Value = newOne.pallet_container ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@belong_device", SqlDbType.NVarChar, 500) { Value = newOne.belong_device ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@rsv_str1", SqlDbType.NVarChar, 500) { Value = newOne.rsv_str1 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@rsv_str2", SqlDbType.NVarChar, 500) { Value = newOne.rsv_str2 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@rsv_str3", SqlDbType.NVarChar, 500) { Value = newOne.rsv_str3 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@rsv_str4", SqlDbType.NVarChar, 500) { Value = newOne.rsv_str4 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@rsv_str5", SqlDbType.NVarChar, 500) { Value = newOne.rsv_str5 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@i1", SqlDbType.Int) { Value = newOne.i1 });
            cmd.Parameters.Add(new SqlParameter("@i2", SqlDbType.Int) { Value = newOne.i2 });
            cmd.Parameters.Add(new SqlParameter("@i3", SqlDbType.Int) { Value = newOne.i3 });
            cmd.Parameters.Add(new SqlParameter("@i4", SqlDbType.Int) { Value = newOne.i4 });
            cmd.Parameters.Add(new SqlParameter("@i5", SqlDbType.Int) { Value = newOne.i5 });
            cmd.Parameters.Add(new SqlParameter("@n1", SqlDbType.Decimal) { Value = newOne.n1 });
            cmd.Parameters.Add(new SqlParameter("@n2", SqlDbType.Decimal) { Value = newOne.n2 });
            cmd.Parameters.Add(new SqlParameter("@n3", SqlDbType.Decimal) { Value = newOne.n3 });
            cmd.Parameters.Add(new SqlParameter("@n4", SqlDbType.Decimal) { Value = newOne.n4 });
            cmd.Parameters.Add(new SqlParameter("@n5", SqlDbType.Decimal) { Value = newOne.n5 });
            cmd.Parameters.Add(new SqlParameter("@plid", SqlDbType.NVarChar, 500) { Value = newOne.plid ?? DBNull.Value.ToString() });
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
                sb.Append(" delete from wms_places where plid=@plid ");
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sb.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@plid", SqlDbType.NVarChar, 150) { Value = PK_ID });
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
        public static wms_places GetOneByID(object PK_ID)
        {
            List<SqlParameter> prs = new List<SqlParameter>();
            prs.Add(new SqlParameter("@plid", SqlDbType.NVarChar, 150) { Value = PK_ID });
            var lis = DoTableQuery("select * from wms_places where plid =@plid", prs.ToArray());
            if (lis != null && lis.Count > 0)
            {
                return lis[0];
            }
            else
            {
                return null;
            }
        }

        internal static wms_places GetOneByCode(string placecode)
        {
            List<SqlParameter> prs = new List<SqlParameter>();
            prs.Add(new SqlParameter("@place_code", SqlDbType.NVarChar, 150) { Value = placecode });
            var lis = DoTableQuery("select * from wms_places where place_code =@place_code", prs.ToArray());
            if (lis != null && lis.Count > 0)
            {
                return lis[0];
            }
            else
            {
                return null;
            }
        }
        internal static wms_places GetOneByPallet(string pallet)
        {
            List<SqlParameter> prs = new List<SqlParameter>
            {
                new SqlParameter("@pallet_container", SqlDbType.NVarChar, 150) { Value = pallet }
            };
            var lis = DoTableQuery("select * from wms_places where pallet_container =@pallet_container", prs.ToArray());
            if (lis != null && lis.Count > 0)
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
        internal static List<wms_places> Get(List<KVP> keyValues)
        {
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parametrs = new List<SqlParameter>();
            sb.Append("select * from wms_places where  flag_delete = 0 ");
            foreach (var keyValue in keyValues)
            {
                if (keyValue.Key.Trim().ToUpper() == "PLACE_CODE")
                {
                    sb.Append(" and  place_code =@place_code ");
                    SqlParameter pa = new SqlParameter();
                    var p = new SqlParameter("@place_code", SqlDbType.NVarChar, 150) { Value = keyValue.Value };
                    parametrs.Add(p);
                }
                else if (keyValue.Key.Trim().ToUpper() == "HIGHT_LEVEL")
                {
                }
                else if (keyValue.Key.Trim().ToUpper() == "IS_EMPTY")
                {
                    sb.Append(" and  is_empty =@is_empty ");
                    SqlParameter pa = new SqlParameter();
                    var p = new SqlParameter("@is_empty", SqlDbType.NVarChar, 150) { Value = keyValue.Value };
                    parametrs.Add(p);
                }
                else if (keyValue.Key.Trim().ToUpper() == "FLAG_LOCK")
                {
                    sb.Append(" and  flag_lock =@flag_lock ");
                    SqlParameter pa = new SqlParameter();
                    var p = new SqlParameter("@flag_lock", SqlDbType.NVarChar, 150) { Value = keyValue.Value };
                    parametrs.Add(p);
                }
                else if (keyValue.Key.Trim().ToUpper() == "FLAG_HAS_TASK")
                {
                    sb.Append(" and  flag_has_task =@flag_has_task ");
                    SqlParameter pa = new SqlParameter();
                    var p = new SqlParameter("@flag_has_task", SqlDbType.NVarChar, 150) { Value = keyValue.Value };
                    parametrs.Add(p);
                }
                else if (keyValue.Key.Trim().ToUpper() == "STARTTIME")
                {
                    //var start = Convert.ToDateTime(keyValue.Value).Date;

                }
                else if (keyValue.Key.Trim().ToUpper() == "ENDTIME")
                {
                    //var end = Convert.ToDateTime(keyValue.Value).AddDays(1).Date;

                }
            }
            var rtn = DoTableQuery(sb.ToString(), parametrs.ToArray());

            return rtn;
        }

        internal static List<wms_places> GetNotEmptyOrHasTaskPlaces()
        {
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parametrs = new List<SqlParameter>();
            sb.Append("select * from wms_places where  flag_delete = 0 and flag_has_task ='Y' or is_empty ='N'");
            var rtn = DoTableQuery(sb.ToString(), parametrs.ToArray());

            return rtn;
        }

        internal static bool updateSeq(int seqs, int row, int column, int layer)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" update  wms_places set numb_unit= " + seqs + " where numb_row= " + row + " and numb_column =" + column + " and numb_layer= " + layer);
                SqlCommand cmd = new SqlCommand();
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


        internal static wms_places PlaceGetOneEmptyByPallet(string name, string container_id)
        {
            List<SqlParameter> parass = new List<SqlParameter>();

            parass.Add(new SqlParameter("@pallet", container_id));
            SqlParameter pa = new SqlParameter();
            pa.Direction = ParameterDirection.InputOutput;
            pa.ParameterName = "@return_value";
            pa.Size = 5000;
            pa.SqlValue = "";
            parass.Add(pa);
            var prrslt = parass.ToArray();
            var rslt = DAL.DBHelper_SQLServer.ExecuteProcedure(name, ref prrslt);
            var returnVL = pa.Value.ToString();
            var str = "执行存储过程" + name + ", 返回行值" + rslt + "结果:" + returnVL;
            LogHelper.Info(str);

            if (returnVL != "")
            {
                var find = GetOneByCode(returnVL);
                return find;
            }
            else
            {
                return null;
            }
        }
        //internal static wms_places PlaceGetOneEmptyByPallet(int pal,int weight,int lane)
        //{
        //    List<SqlParameter> parass = new List<SqlParameter>
        //    {
        //        new SqlParameter("@pallet", pal),
        //        new SqlParameter("@Weight", weight),
        //        new SqlParameter("@lane", lane)
        //    };
        //    SqlParameter pa = new SqlParameter
        //    {
        //        Direction = ParameterDirection.InputOutput,
        //        ParameterName = "@return_value",
        //        Size = 5000,
        //        SqlValue = ""
        //    };
        //    parass.Add(pa); 
        //    var prrslt = parass.ToArray();
        //    var rslt = DBHelper_SQLServer.ExecuteProcedure("select_place_in_wms_places", ref prrslt);
        //    var returnVL = pa.Value.ToString();
        //    var str = "执行存储过程select_place_in_wms_places , 返回行值" + rslt + "结果:" + returnVL;
        //    LogHelper.Info(str);

        //    if (returnVL != "")
        //    {
        //        var find = GetOneByCode(returnVL);
        //        if (find == null)
        //        {
        //            find.rsv_str1 = returnVL;
        //        }
        //        return find;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        internal static wms_places PlaceGetOneEmptyByPallet1(string container_id)
        {
            List<SqlParameter> parass = new List<SqlParameter>();

            parass.Add(new SqlParameter("@pallet", container_id));
            SqlParameter pa = new SqlParameter();
            pa.Direction = ParameterDirection.InputOutput;
            pa.ParameterName = "@return_value";
            pa.Size = 5000;
            pa.SqlValue = "";
            parass.Add(pa);
            var prrslt = parass.ToArray();
            var rslt = DAL.DBHelper_SQLServer.ExecuteProcedure("p_get_in_empty_place_by_pallet_waiceG", ref prrslt);
            var returnVL = pa.Value.ToString();
            var str = "执行存储过程 p_get_in_empty_place_by_pallet_waiceG, 返回行值" + rslt + "结果:" + returnVL;
            LogHelper.Info(str);

            if (returnVL != "")
            {
                var find = GetOneByCode(returnVL);
                return find;
            }
            else
            {
                return null;
            }
        }

        internal static wms_places PlaceGetOneEmptyByPallet2(string container_id)
        {
            List<SqlParameter> parass = new List<SqlParameter>();

            parass.Add(new SqlParameter("@pallet", container_id));
            SqlParameter pa = new SqlParameter();
            pa.Direction = ParameterDirection.InputOutput;
            pa.ParameterName = "@return_value";
            pa.Size = 5000;
            pa.SqlValue = "";
            parass.Add(pa);
            var prrslt = parass.ToArray();
            var rslt = DAL.DBHelper_SQLServer.ExecuteProcedure("p_get_in_empty_place_by_pallet_diepan", ref prrslt);
            var returnVL = pa.Value.ToString();
            var str = "执行存储过程 p_get_in_empty_place_by_pallet_diepan, 返回行值" + rslt + "结果:" + returnVL;
            LogHelper.Info(str);

            if (returnVL != "")
            {
                var find = GetOneByCode(returnVL);
                return find;
            }
            else
            {
                return null;
            }
        }

        internal static string InOccupyPlace(string task,string placenum)
        {
            try
            {
                string rtn = "E初始化未提交数据库";
                List<SqlParameter> parass = new List<SqlParameter>();
                parass.Add(new SqlParameter("@taskcode", task));
                parass.Add(new SqlParameter("@place_code", placenum));
                SqlParameter pa = new SqlParameter();
                pa.Direction = ParameterDirection.InputOutput;
                pa.ParameterName = "@return_value";
                pa.Size = 5000;
                pa.SqlValue = "";
                parass.Add(pa);
                var prrslt = parass.ToArray();
                var rslt = DAL.DBHelper_SQLServer.ExecuteProcedure("p_srm_in_task_occupy_place", ref prrslt);
                var outResult = prrslt.ToList().Find(p => p.ParameterName == "@return_value");
                rtn = (outResult == null || outResult.Value == null) ? "E执行失败原因未知" : outResult.Value.ToString();
                var str = "执行存储过程 p_srm_in_task_occupy_place,任务号："+task+"货位："+placenum+",结果"+rtn  ;
                LogHelper.Info(str);
                return rtn;
            }
            catch (Exception ec)
            {
                var str = "E执行存储过程 p_srm_in_task_occupy_place" + ec.Message + "\r\n" + ec.StackTrace;
                LogHelper.Error(str);
                return str;
            }
        }

        internal static string InOccupyPlace_out(string task, string placenum)
        {
            try
            {
                string rtn = "E初始化未提交数据库";
                List<SqlParameter> parass = new List<SqlParameter>();
                parass.Add(new SqlParameter("@taskcode", task));
                parass.Add(new SqlParameter("@place_code", placenum));
                SqlParameter pa = new SqlParameter();
                pa.Direction = ParameterDirection.InputOutput;
                pa.ParameterName = "@return_value";
                pa.Size = 5000;
                pa.SqlValue = "";
                parass.Add(pa);
                var prrslt = parass.ToArray();
                var rslt = DAL.DBHelper_SQLServer.ExecuteProcedure("p_srm_in_task_occupy_place_forout", ref prrslt);
                var outResult = prrslt.ToList().Find(p => p.ParameterName == "@return_value");
                rtn = (outResult == null || outResult.Value == null) ? "E执行失败原因未知" : outResult.Value.ToString();
                var str = "执行存储过程 p_srm_in_task_occupy_place_forout,任务号：" + task + "货位：" + placenum + ",结果" + rtn;
                LogHelper.Info(str);
                return rtn;
            }
            catch (Exception ec)
            {
                var str = "E执行存储过程 p_srm_in_task_occupy_place" + ec.Message + "\r\n" + ec.StackTrace;
                LogHelper.Error(str);
                return str;
            }
        }



        internal static string InOccupyPlaceUnDo(  string placenum)
        {
            try
            {
                string rtn = "E初始化未提交数据库";
                List<SqlParameter> parass = new List<SqlParameter>();
                
                parass.Add(new SqlParameter("@place_code", placenum));
                SqlParameter pa = new SqlParameter();
                pa.Direction = ParameterDirection.InputOutput;
                pa.ParameterName = "@return_value";
                pa.Size = 5000;
                pa.SqlValue = "";
                parass.Add(pa);
                var prrslt = parass.ToArray();
                var rslt = DAL.DBHelper_SQLServer.ExecuteProcedure("p_srm_in_task_occupy_place_undo", ref prrslt);
                var outResult = prrslt.ToList().Find(p => p.ParameterName == "@return_value");
                rtn = (outResult == null || outResult.Value == null) ? "E执行失败原因未知" : outResult.Value.ToString();
                var str = "执行存储过程 p_srm_in_task_occupy_place_undo, 货位：" + placenum + ",结果" + rtn;
                LogHelper.Info(str);
                return rtn;
            }
            catch (Exception ec)
            {
                var str = "E执行存储过程 p_srm_in_task_occupy_place_undo" + ec.Message + "\r\n" + ec.StackTrace;
                LogHelper.Error(str);
                return str;
            }
        }
         
        internal static string InFinishUpdate(string task, string placenum,string palletnum)
        {
            try
            {
                string rtn = "E初始化未提交数据库";
                List<SqlParameter> parass = new List<SqlParameter>();
                parass.Add(new SqlParameter("@taskcode", task));
                parass.Add(new SqlParameter("@place_code", placenum));
                parass.Add(new SqlParameter("@palletnum", palletnum));
                SqlParameter pa = new SqlParameter();
                pa.Direction = ParameterDirection.InputOutput;
                pa.ParameterName = "@return_value";
                pa.Size = 5000;
                pa.SqlValue = "";
                parass.Add(pa);
                var prrslt = parass.ToArray();
                var rslt = DAL.DBHelper_SQLServer.ExecuteProcedure("p_srm_in_task_finish_update", ref prrslt);
                var outResult = prrslt.ToList().Find(p => p.ParameterName == "@return_value");
                rtn = (outResult == null || outResult.Value == null) ? "E执行失败原因未知" : outResult.Value.ToString();
                var str = "执行存储过程 p_srm_in_task_finish_update,任务号：" + task + "货位：" + placenum +"托盘号："+palletnum+ ",结果" + rtn;
                LogHelper.Info(str);
                return rtn;
            }
            catch (Exception ec)
            {
                var str = "E执行存储过程 [p_srm_in_task_finish_update]遇到错误：" + ec.Message + "\r\n" + ec.StackTrace;
                LogHelper.Error(str);
                return str;
            }
        }

        internal static wms_places SelectSeq(int numb_lane, string rsv_str3,string rsv_str4)
        {
            try
            {
                List<SqlParameter> prs = new List<SqlParameter>();
                prs.Add(new SqlParameter("@numb_lane", SqlDbType.NVarChar, 150) { Value = numb_lane });
                prs.Add(new SqlParameter("@rsv_str3", SqlDbType.NVarChar, 150) { Value = rsv_str3 });
                prs.Add(new SqlParameter("@rsv_str4", SqlDbType.NVarChar, 150) { Value = rsv_str4 });
                StringBuilder sb = new StringBuilder();
                sb.Append(" select top 1 * from wms_places where ");
                sb.Append(" numb_lane = @numb_lane and rsv_str3 = @rsv_str3 and rsv_str4 = @rsv_str4  ");
                sb.Append(" and is_empty ='Y' and flag_has_task ='N' and place_desc = '2' and flag_delete = 0");
                var rtn = DoTableQuery(sb.ToString(), prs.ToArray());
                if (rtn != null && rtn.Count > 0)
                {
                    return rtn[0];
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}