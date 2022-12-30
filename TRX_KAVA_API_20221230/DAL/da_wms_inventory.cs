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
    public class da_wms_inventory
    {
        //---------------------按Table的方式查询方法--------------------------//
        private static List<wms_inventory> DoTableQuery(string sql_str, SqlParameter[] paras)
        {
            var lisRtn = new List<wms_inventory>();
            try
            {
                var dtback = DBHelper_SQLServer.ExecuteDataTable(sql_str, paras);
                lisRtn = EntityTableParse<wms_inventory>.ToList(dtback);
            }
            catch
            {
            }
            return lisRtn;
        }
        //---------------------查询并赋值到实体类list的方法  IReader方式--------------------------//
        private static List<wms_inventory> DoQuery(string sql_str, SqlParameter[] paras)
        {
            var lisRtn = new List<wms_inventory>();
            try
            {
                using (IDataReader dr = DBHelper_SQLServer.ExecuteReader(sql_str, paras))
                {
                    while (dr.Read())
                    {
                        var p = new wms_inventory();
                        #region 逐个赋值 
                        p.invid = DBHelper_SQLServer.GetDataValue<string>(dr, "invid");
                        p.warehouse = DBHelper_SQLServer.GetDataValue<string>(dr, "warehouse");
                        p.place_code = DBHelper_SQLServer.GetDataValue<string>(dr, "place_code");
                        p.container_id = DBHelper_SQLServer.GetDataValue<string>(dr, "container_id");
                        p.inv_type = DBHelper_SQLServer.GetDataValue<string>(dr, "inv_type");
                        p.order_from = DBHelper_SQLServer.GetDataValue<string>(dr, "order_from");
                        p.order_in = DBHelper_SQLServer.GetDataValue<string>(dr, "order_in");
                        p.order_purchase = DBHelper_SQLServer.GetDataValue<string>(dr, "order_purchase");
                        p.order_out = DBHelper_SQLServer.GetDataValue<string>(dr, "order_out");
                        p.order_manufacture = DBHelper_SQLServer.GetDataValue<string>(dr, "order_manufacture");
                        p.order_customer = DBHelper_SQLServer.GetDataValue<string>(dr, "order_customer");
                        p.belong_customer = DBHelper_SQLServer.GetDataValue<string>(dr, "belong_customer");
                        p.mcode = DBHelper_SQLServer.GetDataValue<string>(dr, "mcode");
                        p.mdesc = DBHelper_SQLServer.GetDataValue<string>(dr, "mdesc");
                        p.mtype = DBHelper_SQLServer.GetDataValue<string>(dr, "mtype");
                        p.inv_status = DBHelper_SQLServer.GetDataValue<string>(dr, "inv_status");
                        p.batchno = DBHelper_SQLServer.GetDataValue<string>(dr, "batchno");
                        p.batchno_rsv1 = DBHelper_SQLServer.GetDataValue<string>(dr, "batchno_rsv1");
                        p.batchno_rsv2 = DBHelper_SQLServer.GetDataValue<string>(dr, "batchno_rsv2");
                        p.batchno_rsv3 = DBHelper_SQLServer.GetDataValue<string>(dr, "batchno_rsv3");
                        p.uom = DBHelper_SQLServer.GetDataValue<string>(dr, "uom");
                        p.qty = DBHelper_SQLServer.GetDataValue<decimal>(dr, "qty");
                        p.qty_occupy = DBHelper_SQLServer.GetDataValue<decimal>(dr, "qty_occupy");
                        p.qty_package = DBHelper_SQLServer.GetDataValue<decimal>(dr, "qty_package");
                        p.qty_occupy_package = DBHelper_SQLServer.GetDataValue<decimal>(dr, "qty_occupy_package");
                        p.uom_package = DBHelper_SQLServer.GetDataValue<string>(dr, "uom_package");
                        p.t_create = DBHelper_SQLServer.GetDataValue<DateTime>(dr, "t_create");
                        p.t_update = DBHelper_SQLServer.GetDataValue<DateTime>(dr, "t_update");
                        p.t_in = DBHelper_SQLServer.GetDataValue<DateTime>(dr, "t_in");
                        p.t_out = DBHelper_SQLServer.GetDataValue<DateTime>(dr, "t_out");
                        p.t_out_permit = DBHelper_SQLServer.GetDataValue<DateTime>(dr, "t_out_permit");
                        p.occupy_symbol = DBHelper_SQLServer.GetDataValue<string>(dr, "occupy_symbol");
                        p.occupy_content = DBHelper_SQLServer.GetDataValue<string>(dr, "occupy_content");
                        p.u_create_name = DBHelper_SQLServer.GetDataValue<string>(dr, "u_create_name");
                        p.u_create_id = DBHelper_SQLServer.GetDataValue<string>(dr, "u_create_id");
                        p.u_update_name = DBHelper_SQLServer.GetDataValue<string>(dr, "u_update_name");
                        p.u_update_id = DBHelper_SQLServer.GetDataValue<string>(dr, "u_update_id");
                        p.flag_delete = DBHelper_SQLServer.GetDataValue<bool>(dr, "flag_delete");
                        p.flag_effect = DBHelper_SQLServer.GetDataValue<bool>(dr, "flag_effect");
                        p.flag_synchro = DBHelper_SQLServer.GetDataValue<bool>(dr, "flag_synchro");
                        p.flag_audit = DBHelper_SQLServer.GetDataValue<bool>(dr, "flag_audit");
                        p.c100_1 = DBHelper_SQLServer.GetDataValue<string>(dr, "c100_1");
                        p.c100_2 = DBHelper_SQLServer.GetDataValue<string>(dr, "c100_2");
                        p.c100_3 = DBHelper_SQLServer.GetDataValue<string>(dr, "c100_3");
                        p.c100_4 = DBHelper_SQLServer.GetDataValue<string>(dr, "c100_4");
                        p.c100_5 = DBHelper_SQLServer.GetDataValue<string>(dr, "c100_5");
                        p.c200_1 = DBHelper_SQLServer.GetDataValue<string>(dr, "c200_1");
                        p.c200_2 = DBHelper_SQLServer.GetDataValue<string>(dr, "c200_2");
                        p.c200_3 = DBHelper_SQLServer.GetDataValue<string>(dr, "c200_3");
                        p.c200_4 = DBHelper_SQLServer.GetDataValue<string>(dr, "c200_4");
                        p.c200_5 = DBHelper_SQLServer.GetDataValue<string>(dr, "c200_5");
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
            catch (Exception exc)
            {
            }
            return lisRtn;
        }
        //----------------------Insert方法----------------------------------------------//
        public static bool InsertNew(wms_inventory newOne)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" Insert into wms_inventory (  ");
            sb.Append("invid, ");
            sb.Append("warehouse, ");
            sb.Append("place_code, ");
            sb.Append("container_id, ");
            sb.Append("inv_type, ");
            sb.Append("order_from, ");
            sb.Append("order_in, ");
            sb.Append("order_purchase, ");
            sb.Append("order_out, ");
            sb.Append("order_manufacture, ");
            sb.Append("order_customer, ");
            sb.Append("belong_customer, ");
            sb.Append("mcode, ");
            sb.Append("mdesc, ");
            sb.Append("mtype, ");
            sb.Append("inv_status, ");
            sb.Append("batchno, ");
            sb.Append("batchno_rsv1, ");
            sb.Append("batchno_rsv2, ");
            sb.Append("batchno_rsv3, ");
            sb.Append("uom, ");
            sb.Append("qty, ");
            sb.Append("qty_occupy, ");
            sb.Append("qty_package, ");
            sb.Append("qty_occupy_package, ");
            sb.Append("uom_package, ");
            sb.Append("t_create, ");
            sb.Append("t_update, ");
            sb.Append("t_in, ");
            sb.Append("t_out, ");
            sb.Append("t_out_permit, ");
            sb.Append("occupy_symbol, ");
            sb.Append("occupy_content, ");
            sb.Append("u_create_name, ");
            sb.Append("u_create_id, ");
            sb.Append("u_update_name, ");
            sb.Append("u_update_id, ");
            sb.Append("flag_delete, ");
            sb.Append("flag_effect, ");
            sb.Append("flag_synchro, ");
            sb.Append("flag_audit, ");
            sb.Append("c100_1, ");
            sb.Append("c100_2, ");
            sb.Append("c100_3, ");
            sb.Append("c100_4, ");
            sb.Append("c100_5, ");
            sb.Append("c200_1, ");
            sb.Append("c200_2, ");
            sb.Append("c200_3, ");
            sb.Append("c200_4, ");
            sb.Append("c200_5, ");
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
            sb.Append("@invid,");
            sb.Append("@warehouse,");
            sb.Append("@place_code,");
            sb.Append("@container_id,");
            sb.Append("@inv_type,");
            sb.Append("@order_from,");
            sb.Append("@order_in,");
            sb.Append("@order_purchase,");
            sb.Append("@order_out,");
            sb.Append("@order_manufacture,");
            sb.Append("@order_customer,");
            sb.Append("@belong_customer,");
            sb.Append("@mcode,");
            sb.Append("@mdesc,");
            sb.Append("@mtype,");
            sb.Append("@inv_status,");
            sb.Append("@batchno,");
            sb.Append("@batchno_rsv1,");
            sb.Append("@batchno_rsv2,");
            sb.Append("@batchno_rsv3,");
            sb.Append("@uom,");
            sb.Append("@qty,");
            sb.Append("@qty_occupy,");
            sb.Append("@qty_package,");
            sb.Append("@qty_occupy_package,");
            sb.Append("@uom_package,");
            sb.Append("@t_create,");
            sb.Append("@t_update,");
            sb.Append("@t_in,");
            sb.Append("@t_out,");
            sb.Append("@t_out_permit,");
            sb.Append("@occupy_symbol,");
            sb.Append("@occupy_content,");
            sb.Append("@u_create_name,");
            sb.Append("@u_create_id,");
            sb.Append("@u_update_name,");
            sb.Append("@u_update_id,");
            sb.Append("@flag_delete,");
            sb.Append("@flag_effect,");
            sb.Append("@flag_synchro,");
            sb.Append("@flag_audit,");
            sb.Append("@c100_1,");
            sb.Append("@c100_2,");
            sb.Append("@c100_3,");
            sb.Append("@c100_4,");
            sb.Append("@c100_5,");
            sb.Append("@c200_1,");
            sb.Append("@c200_2,");
            sb.Append("@c200_3,");
            sb.Append("@c200_4,");
            sb.Append("@c200_5,");
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
            cmd.Parameters.Add(new SqlParameter("@invid", SqlDbType.NVarChar, 500) { Value = newOne.invid ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@warehouse", SqlDbType.NVarChar, 500) { Value = newOne.warehouse ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@place_code", SqlDbType.NVarChar, 500) { Value = newOne.place_code ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@container_id", SqlDbType.NVarChar, 500) { Value = newOne.container_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@inv_type", SqlDbType.NVarChar, 500) { Value = newOne.inv_type ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@order_from", SqlDbType.NVarChar, 500) { Value = newOne.order_from ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@order_in", SqlDbType.NVarChar, 500) { Value = newOne.order_in ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@order_purchase", SqlDbType.NVarChar, 500) { Value = newOne.order_purchase ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@order_out", SqlDbType.NVarChar, 500) { Value = newOne.order_out ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@order_manufacture", SqlDbType.NVarChar, 500) { Value = newOne.order_manufacture ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@order_customer", SqlDbType.NVarChar, 500) { Value = newOne.order_customer ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@belong_customer", SqlDbType.NVarChar, 500) { Value = newOne.belong_customer ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@mcode", SqlDbType.NVarChar, 500) { Value = newOne.mcode ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@mdesc", SqlDbType.NVarChar, 500) { Value = newOne.mdesc ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@mtype", SqlDbType.NVarChar, 500) { Value = newOne.mtype ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@inv_status", SqlDbType.NVarChar, 500) { Value = newOne.inv_status ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@batchno", SqlDbType.NVarChar, 500) { Value = newOne.batchno ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@batchno_rsv1", SqlDbType.NVarChar, 500) { Value = newOne.batchno_rsv1 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@batchno_rsv2", SqlDbType.NVarChar, 500) { Value = newOne.batchno_rsv2 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@batchno_rsv3", SqlDbType.NVarChar, 500) { Value = newOne.batchno_rsv3 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@uom", SqlDbType.NVarChar, 500) { Value = newOne.uom ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@qty", SqlDbType.Decimal) { Value = newOne.qty });
            cmd.Parameters.Add(new SqlParameter("@qty_occupy", SqlDbType.Decimal) { Value = newOne.qty_occupy });
            cmd.Parameters.Add(new SqlParameter("@qty_package", SqlDbType.Decimal) { Value = newOne.qty_package });
            cmd.Parameters.Add(new SqlParameter("@qty_occupy_package", SqlDbType.Decimal) { Value = newOne.qty_occupy_package });
            cmd.Parameters.Add(new SqlParameter("@uom_package", SqlDbType.NVarChar, 500) { Value = newOne.uom_package ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_create", SqlDbType.DateTime) { Value = newOne.t_create });
            cmd.Parameters.Add(new SqlParameter("@t_update", SqlDbType.DateTime) { Value = newOne.t_update });
            cmd.Parameters.Add(new SqlParameter("@t_in", SqlDbType.DateTime) { Value = newOne.t_in });
            cmd.Parameters.Add(new SqlParameter("@t_out", SqlDbType.DateTime) { Value = newOne.t_out });
            cmd.Parameters.Add(new SqlParameter("@t_out_permit", SqlDbType.DateTime) { Value = newOne.t_out_permit });
            cmd.Parameters.Add(new SqlParameter("@occupy_symbol", SqlDbType.NVarChar, 500) { Value = newOne.occupy_symbol ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@occupy_content", SqlDbType.NVarChar, 500) { Value = newOne.occupy_content ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_name", SqlDbType.NVarChar, 500) { Value = newOne.u_create_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_id", SqlDbType.NVarChar, 500) { Value = newOne.u_create_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_update_name", SqlDbType.NVarChar, 500) { Value = newOne.u_update_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_update_id", SqlDbType.NVarChar, 500) { Value = newOne.u_update_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@flag_delete", SqlDbType.Bit) { Value = newOne.flag_delete });
            cmd.Parameters.Add(new SqlParameter("@flag_effect", SqlDbType.Bit) { Value = newOne.flag_effect });
            cmd.Parameters.Add(new SqlParameter("@flag_synchro", SqlDbType.Bit) { Value = newOne.flag_synchro });
            cmd.Parameters.Add(new SqlParameter("@flag_audit", SqlDbType.Bit) { Value = newOne.flag_audit });
            cmd.Parameters.Add(new SqlParameter("@c100_1", SqlDbType.NVarChar, 500) { Value = newOne.c100_1 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@c100_2", SqlDbType.NVarChar, 500) { Value = newOne.c100_2 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@c100_3", SqlDbType.NVarChar, 500) { Value = newOne.c100_3 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@c100_4", SqlDbType.NVarChar, 500) { Value = newOne.c100_4 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@c100_5", SqlDbType.NVarChar, 500) { Value = newOne.c100_5 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@c200_1", SqlDbType.NVarChar, 500) { Value = newOne.c200_1 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@c200_2", SqlDbType.NVarChar, 500) { Value = newOne.c200_2 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@c200_3", SqlDbType.NVarChar, 500) { Value = newOne.c200_3 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@c200_4", SqlDbType.NVarChar, 500) { Value = newOne.c200_4 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@c200_5", SqlDbType.NVarChar, 500) { Value = newOne.c200_5 ?? DBNull.Value.ToString() });
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
        public static bool UpdateOne(wms_inventory newOne)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" update wms_inventory set  ");
            sb.Append("  warehouse = @warehouse ,   ");
            sb.Append("  place_code = @place_code ,   ");
            sb.Append("  container_id = @container_id ,   ");
            sb.Append("  inv_type = @inv_type ,   ");
            sb.Append("  order_from = @order_from ,   ");
            sb.Append("  order_in = @order_in ,   ");
            sb.Append("  order_purchase = @order_purchase ,   ");
            sb.Append("  order_out = @order_out ,   ");
            sb.Append("  order_manufacture = @order_manufacture ,   ");
            sb.Append("  order_customer = @order_customer ,   ");
            sb.Append("  belong_customer = @belong_customer ,   ");
            sb.Append("  mcode = @mcode ,   ");
            sb.Append("  mdesc = @mdesc ,   ");
            sb.Append("  mtype = @mtype ,   ");
            sb.Append("  inv_status = @inv_status ,   ");
            sb.Append("  batchno = @batchno ,   ");
            sb.Append("  batchno_rsv1 = @batchno_rsv1 ,   ");
            sb.Append("  batchno_rsv2 = @batchno_rsv2 ,   ");
            sb.Append("  batchno_rsv3 = @batchno_rsv3 ,   ");
            sb.Append("  uom = @uom ,   ");
            sb.Append("  qty = @qty ,   ");
            sb.Append("  qty_occupy = @qty_occupy ,   ");
            sb.Append("  qty_package = @qty_package ,   ");
            sb.Append("  qty_occupy_package = @qty_occupy_package ,   ");
            sb.Append("  uom_package = @uom_package ,   ");
            sb.Append("  t_create = @t_create ,   ");
            sb.Append("  t_update = @t_update ,   ");
            sb.Append("  t_in = @t_in ,   ");
            sb.Append("  t_out = @t_out ,   ");
            sb.Append("  t_out_permit = @t_out_permit ,   ");
            sb.Append("  occupy_symbol = @occupy_symbol ,   ");
            sb.Append("  occupy_content = @occupy_content ,   ");
            sb.Append("  u_create_name = @u_create_name ,   ");
            sb.Append("  u_create_id = @u_create_id ,   ");
            sb.Append("  u_update_name = @u_update_name ,   ");
            sb.Append("  u_update_id = @u_update_id ,   ");
            sb.Append("  flag_delete = @flag_delete ,   ");
            sb.Append("  flag_effect = @flag_effect ,   ");
            sb.Append("  flag_synchro = @flag_synchro ,   ");
            sb.Append("  flag_audit = @flag_audit ,   ");
            sb.Append("  c100_1 = @c100_1 ,   ");
            sb.Append("  c100_2 = @c100_2 ,   ");
            sb.Append("  c100_3 = @c100_3 ,   ");
            sb.Append("  c100_4 = @c100_4 ,   ");
            sb.Append("  c100_5 = @c100_5 ,   ");
            sb.Append("  c200_1 = @c200_1 ,   ");
            sb.Append("  c200_2 = @c200_2 ,   ");
            sb.Append("  c200_3 = @c200_3 ,   ");
            sb.Append("  c200_4 = @c200_4 ,   ");
            sb.Append("  c200_5 = @c200_5 ,   ");
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
            sb.Append(" where invid = @invid  ");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sb.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@warehouse", SqlDbType.NVarChar, 500) { Value = newOne.warehouse ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@place_code", SqlDbType.NVarChar, 500) { Value = newOne.place_code ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@container_id", SqlDbType.NVarChar, 500) { Value = newOne.container_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@inv_type", SqlDbType.NVarChar, 500) { Value = newOne.inv_type ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@order_from", SqlDbType.NVarChar, 500) { Value = newOne.order_from ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@order_in", SqlDbType.NVarChar, 500) { Value = newOne.order_in ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@order_purchase", SqlDbType.NVarChar, 500) { Value = newOne.order_purchase ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@order_out", SqlDbType.NVarChar, 500) { Value = newOne.order_out ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@order_manufacture", SqlDbType.NVarChar, 500) { Value = newOne.order_manufacture ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@order_customer", SqlDbType.NVarChar, 500) { Value = newOne.order_customer ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@belong_customer", SqlDbType.NVarChar, 500) { Value = newOne.belong_customer ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@mcode", SqlDbType.NVarChar, 500) { Value = newOne.mcode ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@mdesc", SqlDbType.NVarChar, 500) { Value = newOne.mdesc ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@mtype", SqlDbType.NVarChar, 500) { Value = newOne.mtype ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@inv_status", SqlDbType.NVarChar, 500) { Value = newOne.inv_status ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@batchno", SqlDbType.NVarChar, 500) { Value = newOne.batchno ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@batchno_rsv1", SqlDbType.NVarChar, 500) { Value = newOne.batchno_rsv1 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@batchno_rsv2", SqlDbType.NVarChar, 500) { Value = newOne.batchno_rsv2 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@batchno_rsv3", SqlDbType.NVarChar, 500) { Value = newOne.batchno_rsv3 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@uom", SqlDbType.NVarChar, 500) { Value = newOne.uom ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@qty", SqlDbType.Decimal) { Value = newOne.qty });
            cmd.Parameters.Add(new SqlParameter("@qty_occupy", SqlDbType.Decimal) { Value = newOne.qty_occupy });
            cmd.Parameters.Add(new SqlParameter("@qty_package", SqlDbType.Decimal) { Value = newOne.qty_package });
            cmd.Parameters.Add(new SqlParameter("@qty_occupy_package", SqlDbType.Decimal) { Value = newOne.qty_occupy_package });
            cmd.Parameters.Add(new SqlParameter("@uom_package", SqlDbType.NVarChar, 500) { Value = newOne.uom_package ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_create", SqlDbType.DateTime) { Value = newOne.t_create });
            cmd.Parameters.Add(new SqlParameter("@t_update", SqlDbType.DateTime) { Value = newOne.t_update });
            cmd.Parameters.Add(new SqlParameter("@t_in", SqlDbType.DateTime) { Value = newOne.t_in });
            cmd.Parameters.Add(new SqlParameter("@t_out", SqlDbType.DateTime) { Value = newOne.t_out });
            cmd.Parameters.Add(new SqlParameter("@t_out_permit", SqlDbType.DateTime) { Value = newOne.t_out_permit });
            cmd.Parameters.Add(new SqlParameter("@occupy_symbol", SqlDbType.NVarChar, 500) { Value = newOne.occupy_symbol ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@occupy_content", SqlDbType.NVarChar, 500) { Value = newOne.occupy_content ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_name", SqlDbType.NVarChar, 500) { Value = newOne.u_create_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_id", SqlDbType.NVarChar, 500) { Value = newOne.u_create_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_update_name", SqlDbType.NVarChar, 500) { Value = newOne.u_update_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_update_id", SqlDbType.NVarChar, 500) { Value = newOne.u_update_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@flag_delete", SqlDbType.Bit) { Value = newOne.flag_delete });
            cmd.Parameters.Add(new SqlParameter("@flag_effect", SqlDbType.Bit) { Value = newOne.flag_effect });
            cmd.Parameters.Add(new SqlParameter("@flag_synchro", SqlDbType.Bit) { Value = newOne.flag_synchro });
            cmd.Parameters.Add(new SqlParameter("@flag_audit", SqlDbType.Bit) { Value = newOne.flag_audit });
            cmd.Parameters.Add(new SqlParameter("@c100_1", SqlDbType.NVarChar, 500) { Value = newOne.c100_1 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@c100_2", SqlDbType.NVarChar, 500) { Value = newOne.c100_2 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@c100_3", SqlDbType.NVarChar, 500) { Value = newOne.c100_3 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@c100_4", SqlDbType.NVarChar, 500) { Value = newOne.c100_4 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@c100_5", SqlDbType.NVarChar, 500) { Value = newOne.c100_5 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@c200_1", SqlDbType.NVarChar, 500) { Value = newOne.c200_1 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@c200_2", SqlDbType.NVarChar, 500) { Value = newOne.c200_2 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@c200_3", SqlDbType.NVarChar, 500) { Value = newOne.c200_3 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@c200_4", SqlDbType.NVarChar, 500) { Value = newOne.c200_4 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@c200_5", SqlDbType.NVarChar, 500) { Value = newOne.c200_5 ?? DBNull.Value.ToString() });
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
            cmd.Parameters.Add(new SqlParameter("@invid", SqlDbType.NVarChar, 500) { Value = newOne.invid ?? DBNull.Value.ToString() });
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
                sb.Append(" delete from wms_inventory where invid=@invid ");
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sb.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@invid", SqlDbType.NVarChar, 150) { Value = PK_ID });
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
            catch (Exception exc)
            {
                return false;
            }
        }
        //----------------------GetOneByID方法--------------------------------------//
        public static wms_inventory GetOneByID(object PK_ID)
        {
            List<SqlParameter> prs = new List<SqlParameter>();
            prs.Add(new SqlParameter("@invid", SqlDbType.NVarChar, 150) { Value = PK_ID });
            var lis = DoTableQuery("select * from wms_inventory where invid =@invid", prs.ToArray());
            if (lis != null && lis.Count > 0)
            {
                return lis[0];
            }
            else
            {
                return null;
            }
        }

        internal static wms_inventory GetOneByPallet(string pallet)
        {
            var lis = DoTableQuery("select * from wms_inventory where container_id ='" + pallet + "' and inv_type != 'InFinished' ", null);
            if (lis != null && lis.Count > 0)
            {
                return lis[0];
            }
            else
            {
                return null;
            }
        }

        internal static List<wms_inventory> GetAllByPallet(string Palletcode)
        {
            var lis = DoTableQuery("select * from wms_inventory where container_id ='" + Palletcode + "'", null);
            if (lis != null && lis.Count > 0)
            {
                return lis;
            }
            else
            {
                return new List<wms_inventory>();
            }
        }
        internal static wms_inventory GetOneByMcode(string Mcode)
        {
            var lis = DoTableQuery("select * from wms_inventory where mcode ='" + Mcode + "'", null);
            if (lis != null && lis.Count > 0)
            {
                return lis[0];
            }
            else
            {
                return null;
            }
        }
        internal static List<wms_inventory> GetOneByInventoryType(string invType)
        {
            var lis = DoTableQuery("select * from wms_inventory where inv_type ='" + invType + "' and qty>0  and flag_effect=1", null);
            return lis;
        }

        /// <summary>
        /// 物料信息组盘
        /// </summary>      
        internal static string SubBind2(List<wms_inventory> item_qty)
        {
            string rtn = "E";
            try
            {              
                bool allSuss = true;                            
                for (int i = 0; i < item_qty.Count; i++)
                {
                    var suss = InsertNew(item_qty[i]);
                    allSuss = allSuss && suss;
                }

                if (allSuss)
                {
                    rtn = "S" + System.DateTime.Now.ToString("HH:mm:ss") + "绑定成功。";
                    LogHelper.Info("手持绑定成功" + item_qty[0].container_id + "共" + item_qty.Count + "个物料。");
                }
                else
                {
                    rtn = "E" + System.DateTime.Now.ToString("HH:mm:ss") + "绑定失败请联系管理员。";
                    LogHelper.Info("手持绑定失败" + item_qty[0].container_id + "共" + item_qty.Count + "个物料。");
                }
                return rtn;
            }
            catch (Exception exc)
            {
                LogHelper.Error("PDA提交绑定托盘遇到问题：" + exc.Message + "\r\n" + exc.StackTrace);
                return "E" + exc.Message;
            }
        }
        internal static string SubBind1(string warehouse, string pallet, List<wms_inv_item_qty> item_qtys, string doUSer, string order_from, string order_in, string order_purchase, string order_manufacture)
        {
            string rtn = "E";
            try
            {
                List<wms_inventory> lisInsert = new List<wms_inventory>();
                bool allSuss = true;
                // var palletInv = DAL.da_wms_inventory.GetAllByPallet(pallet);
                for (int i = 0; i < item_qtys.Count; i++)
                {
                    var oneMqty = item_qtys[i];

                    #region MyRegion
                    wms_inventory nisa = new wms_inventory
                    {
                        invid = Guid.NewGuid().ToString(),
                        warehouse = warehouse == "" ? "W1" : warehouse,
                        place_code = "",
                        container_id = pallet,
                        inv_type = "InTemp",
                        order_from = order_from,
                        order_in = order_in,
                        order_purchase = order_purchase,
                        order_out = "",
                        order_manufacture = order_manufacture,
                        order_customer = "",
                        belong_customer = "",
                        mcode = oneMqty.itemcode,
                        mdesc = oneMqty.itemdesc,
                        mtype = oneMqty.mtype,
                        inv_status = oneMqty.inv_status,
                        batchno = oneMqty.batchno,
                        batchno_rsv1 = oneMqty.batchno2,
                        batchno_rsv2 = "",
                        batchno_rsv3 = "",
                        uom = oneMqty.uom,
                        qty = oneMqty.qty,
                        qty_occupy = 0,
                        qty_package = oneMqty.qtyPackage,
                        qty_occupy_package = 0,
                        uom_package = oneMqty.package_uom,
                        t_create = System.DateTime.Now,
                        t_update = System.DateTime.Now,
                        t_in = System.DateTime.Parse("2000-01-01 00:00:01"),
                        t_out = System.DateTime.Parse("2000-01-01 00:00:01"),
                        t_out_permit = System.DateTime.Parse("2000-01-01 00:00:01"),
                        occupy_symbol = "",
                        occupy_content = "",
                        u_create_name = "",
                        u_create_id = doUSer,
                        u_update_name = "",
                        u_update_id = "",
                        flag_delete = false,
                        flag_effect = true,
                        flag_synchro = false,
                        flag_audit = false,
                        c100_1 = "",
                        c100_2 = "",
                        c100_3 = "",
                        c100_4 = "",
                        c100_5 = "",
                        c200_1 = "",
                        c200_2 = "",
                        c200_3 = "",
                        c200_4 = "",
                        c200_5 = "",
                        i1 = 0,
                        i2 = 0,
                        i3 = 0,
                        i4 = 0,
                        i5 = 0,
                        n1 = 0,
                        n2 = 0,
                        n3 = 0,
                        n4 = 0,
                        n5 = 0
                    };

                    #endregion

                    lisInsert.Add(nisa);
                    
                }
                for (int i = 0; i < lisInsert.Count; i++)
                {
                    var suss = InsertNew(lisInsert[i]);
                    allSuss = allSuss && suss;
                }

                if (allSuss)
                {
                    rtn = "S" + System.DateTime.Now.ToString("HH:mm:ss") + "绑定成功。";
                    LogHelper.Info("手持绑定成功" + pallet + "共" + item_qtys.Count + "个物料。");
                }
                else
                {
                    rtn = "E" + System.DateTime.Now.ToString("HH:mm:ss") + "绑定失败请联系管理员。";
                    LogHelper.Info("手持绑定失败" + pallet + "共" + item_qtys.Count + "个物料。");
                }
                return rtn;
            }
            catch (Exception exc)
            {
                LogHelper.Error("PDA提交绑定托盘遇到问题：" + exc.Message + "\r\n" + exc.StackTrace);
                return "E" + exc.Message;
            }
        }

        internal static List<wms_inventory> list_GetOneByMcode(string Mcode)
        {
            var lis = DoTableQuery("select * from wms_inventory where mcode ='" + Mcode + "' and inv_type = 'InFinished'", null);
            if (lis != null && lis.Count > 0)
            {
                return lis;
            }
            else
            {
                return null;
            }
        }



        internal static List<wms_inventory> List_GetOneBycontainer_id(string container_id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT TOP 1 * ");
            sb.Append("FROM [kavaTRX].[dbo].[wms_inventory_histroy]  ");
            sb.Append("WHERE container_id = '"+container_id+"' ");
            sb.Append("ORDER BY t_out_permit DESC  ");

            var lis = DoTableQuery(sb.ToString(), null);
            if (lis != null && lis.Count > 0)
            {
                return lis;
            }
            else
            {
                return null;
            }
        }

    }
}