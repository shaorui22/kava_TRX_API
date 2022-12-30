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
    public class da_im_material_master
    {
        //---------------------按Table的方式查询方法--------------------------//
        private static List<im_material_master> DoTableQuery(string sql_str, SqlParameter[] paras)
        {
            var lisRtn = new List<im_material_master>();
            try
            {
                var dtback = DBHelper_SQLServer.ExecuteDataTable(sql_str, paras);
                lisRtn = EntityTableParse<im_material_master>.ToList(dtback);
            }
            catch
            {
            }
            return lisRtn;
        }
        //---------------------查询并赋值到实体类list的方法  IReader方式--------------------------//
        private static List<im_material_master> DoQuery(string sql_str, SqlParameter[] paras)
        {
            var lisRtn = new List<im_material_master>();
            try
            {
                using (IDataReader dr = DBHelper_SQLServer.ExecuteReader(sql_str, paras))
                {
                    while (dr.Read())
                    {
                        var p = new im_material_master();
                        #region 逐个赋值 
                        p.masterid = DBHelper_SQLServer.GetDataValue<string>(dr, "masterid");
                        p.mcode = DBHelper_SQLServer.GetDataValue<string>(dr, "mcode");
                        p.mdesc = DBHelper_SQLServer.GetDataValue<string>(dr, "mdesc");
                        p.mtype_manufacture = DBHelper_SQLServer.GetDataValue<string>(dr, "mtype_manufacture");
                        p.mtype_physical = DBHelper_SQLServer.GetDataValue<string>(dr, "mtype_physical");
                        p.mtype_abc = DBHelper_SQLServer.GetDataValue<string>(dr, "mtype_abc");
                        p.specification = DBHelper_SQLServer.GetDataValue<string>(dr, "specification");
                        p.mcolor = DBHelper_SQLServer.GetDataValue<string>(dr, "mcolor");
                        p.barcode = DBHelper_SQLServer.GetDataValue<string>(dr, "barcode");
                        p.erpcode = DBHelper_SQLServer.GetDataValue<string>(dr, "erpcode");
                        p.barcode10 = DBHelper_SQLServer.GetDataValue<string>(dr, "barcode10");
                        p.barcode11 = DBHelper_SQLServer.GetDataValue<string>(dr, "barcode11");
                        p.barcode12 = DBHelper_SQLServer.GetDataValue<string>(dr, "barcode12");
                        p.replace_code = DBHelper_SQLServer.GetDataValue<string>(dr, "replace_code");
                        p.product_code = DBHelper_SQLServer.GetDataValue<string>(dr, "product_code");
                        p.design_life_cycle = DBHelper_SQLServer.GetDataValue<int>(dr, "design_life_cycle");
                        p.for_customer = DBHelper_SQLServer.GetDataValue<string>(dr, "for_customer");
                        p.safe_stock_num = DBHelper_SQLServer.GetDataValue<int>(dr, "safe_stock_num");
                        p.price_unit = DBHelper_SQLServer.GetDataValue<decimal>(dr, "price_unit");
                        p.flag_lock = DBHelper_SQLServer.GetDataValue<string>(dr, "flag_lock");
                        p.flag_lock_desc = DBHelper_SQLServer.GetDataValue<string>(dr, "flag_lock_desc");
                        p.purchase_cycle = DBHelper_SQLServer.GetDataValue<int>(dr, "purchase_cycle");
                        p.is_key_material = DBHelper_SQLServer.GetDataValue<string>(dr, "is_key_material");
                        p.price_tax_default = DBHelper_SQLServer.GetDataValue<decimal>(dr, "price_tax_default");
                        p.uom_unit_default = DBHelper_SQLServer.GetDataValue<string>(dr, "uom_unit_default");
                        p.package_qty_default = DBHelper_SQLServer.GetDataValue<decimal>(dr, "package_qty_default");
                        p.u_create_name = DBHelper_SQLServer.GetDataValue<string>(dr, "u_create_name");
                        p.u_create_id = DBHelper_SQLServer.GetDataValue<string>(dr, "u_create_id");
                        p.t_create = DBHelper_SQLServer.GetDataValue<DateTime>(dr, "t_create");
                        p.u_update_name = DBHelper_SQLServer.GetDataValue<string>(dr, "u_update_name");
                        p.u_update_id = DBHelper_SQLServer.GetDataValue<string>(dr, "u_update_id");
                        p.t_update = DBHelper_SQLServer.GetDataValue<DateTime>(dr, "t_update");
                        p.flag_delete = DBHelper_SQLServer.GetDataValue<bool>(dr, "flag_delete");
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
            catch  
            {
            }
            return lisRtn;
        }
        //----------------------Insert方法----------------------------------------------//
        public static bool InsertNew(im_material_master newOne)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" Insert into im_material_master (  ");
            sb.Append("masterid, ");
            sb.Append("mcode, ");
            sb.Append("mdesc, ");
            sb.Append("mtype_manufacture, ");
            sb.Append("mtype_physical, ");
            sb.Append("mtype_abc, ");
            sb.Append("specification, ");
            sb.Append("mcolor, ");
            sb.Append("barcode, ");
            sb.Append("erpcode, ");
            sb.Append("barcode10, ");
            sb.Append("barcode11, ");
            sb.Append("barcode12, ");
            sb.Append("replace_code, ");
            sb.Append("product_code, ");
            sb.Append("design_life_cycle, ");
            sb.Append("for_customer, ");
            sb.Append("safe_stock_num, ");
            sb.Append("price_unit, ");
            sb.Append("flag_lock, ");
            sb.Append("flag_lock_desc, ");
            sb.Append("purchase_cycle, ");
            sb.Append("is_key_material, ");
            sb.Append("price_tax_default, ");
            sb.Append("uom_unit_default, ");
            sb.Append("package_qty_default, ");
            sb.Append("u_create_name, ");
            sb.Append("u_create_id, ");
            sb.Append("t_create, ");
            sb.Append("u_update_name, ");
            sb.Append("u_update_id, ");
            sb.Append("t_update, ");
            sb.Append("flag_delete, ");
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
            sb.Append("@masterid,");
            sb.Append("@mcode,");
            sb.Append("@mdesc,");
            sb.Append("@mtype_manufacture,");
            sb.Append("@mtype_physical,");
            sb.Append("@mtype_abc,");
            sb.Append("@specification,");
            sb.Append("@mcolor,");
            sb.Append("@barcode,");
            sb.Append("@erpcode,");
            sb.Append("@barcode10,");
            sb.Append("@barcode11,");
            sb.Append("@barcode12,");
            sb.Append("@replace_code,");
            sb.Append("@product_code,");
            sb.Append("@design_life_cycle,");
            sb.Append("@for_customer,");
            sb.Append("@safe_stock_num,");
            sb.Append("@price_unit,");
            sb.Append("@flag_lock,");
            sb.Append("@flag_lock_desc,");
            sb.Append("@purchase_cycle,");
            sb.Append("@is_key_material,");
            sb.Append("@price_tax_default,");
            sb.Append("@uom_unit_default,");
            sb.Append("@package_qty_default,");
            sb.Append("@u_create_name,");
            sb.Append("@u_create_id,");
            sb.Append("@t_create,");
            sb.Append("@u_update_name,");
            sb.Append("@u_update_id,");
            sb.Append("@t_update,");
            sb.Append("@flag_delete,");
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
            cmd.Parameters.Add(new SqlParameter("@masterid", SqlDbType.NVarChar, 500) { Value = newOne.masterid ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@mcode", SqlDbType.NVarChar, 500) { Value = newOne.mcode ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@mdesc", SqlDbType.NVarChar, 500) { Value = newOne.mdesc ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@mtype_manufacture", SqlDbType.NVarChar, 500) { Value = newOne.mtype_manufacture ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@mtype_physical", SqlDbType.NVarChar, 500) { Value = newOne.mtype_physical ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@mtype_abc", SqlDbType.NVarChar, 500) { Value = newOne.mtype_abc ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@specification", SqlDbType.NVarChar, 500) { Value = newOne.specification ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@mcolor", SqlDbType.NVarChar, 500) { Value = newOne.mcolor ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@barcode", SqlDbType.NVarChar, 500) { Value = newOne.barcode ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@erpcode", SqlDbType.NVarChar, 500) { Value = newOne.erpcode ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@barcode10", SqlDbType.NVarChar, 500) { Value = newOne.barcode10 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@barcode11", SqlDbType.NVarChar, 500) { Value = newOne.barcode11 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@barcode12", SqlDbType.NVarChar, 500) { Value = newOne.barcode12 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@replace_code", SqlDbType.NVarChar, 500) { Value = newOne.replace_code ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@product_code", SqlDbType.NVarChar, 500) { Value = newOne.product_code ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@design_life_cycle", SqlDbType.Int) { Value = newOne.design_life_cycle });
            cmd.Parameters.Add(new SqlParameter("@for_customer", SqlDbType.NVarChar, 500) { Value = newOne.for_customer ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@safe_stock_num", SqlDbType.Int) { Value = newOne.safe_stock_num });
            cmd.Parameters.Add(new SqlParameter("@price_unit", SqlDbType.Decimal) { Value = newOne.price_unit });
            cmd.Parameters.Add(new SqlParameter("@flag_lock", SqlDbType.NVarChar, 500) { Value = newOne.flag_lock ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@flag_lock_desc", SqlDbType.NVarChar, 500) { Value = newOne.flag_lock_desc ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@purchase_cycle", SqlDbType.Int) { Value = newOne.purchase_cycle });
            cmd.Parameters.Add(new SqlParameter("@is_key_material", SqlDbType.NVarChar, 500) { Value = newOne.is_key_material ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@price_tax_default", SqlDbType.Decimal) { Value = newOne.price_tax_default });
            cmd.Parameters.Add(new SqlParameter("@uom_unit_default", SqlDbType.NVarChar, 500) { Value = newOne.uom_unit_default ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@package_qty_default", SqlDbType.Decimal) { Value = newOne.package_qty_default });
            cmd.Parameters.Add(new SqlParameter("@u_create_name", SqlDbType.NVarChar, 500) { Value = newOne.u_create_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_id", SqlDbType.NVarChar, 500) { Value = newOne.u_create_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_create", SqlDbType.DateTime) { Value = newOne.t_create });
            cmd.Parameters.Add(new SqlParameter("@u_update_name", SqlDbType.NVarChar, 500) { Value = newOne.u_update_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_update_id", SqlDbType.NVarChar, 500) { Value = newOne.u_update_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_update", SqlDbType.DateTime) { Value = newOne.t_update });
            cmd.Parameters.Add(new SqlParameter("@flag_delete", SqlDbType.Bit) { Value = newOne.flag_delete });
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
        public static bool UpdateOne(im_material_master newOne)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" update im_material_master set  ");
            sb.Append("  mcode = @mcode ,   ");
            sb.Append("  mdesc = @mdesc ,   ");
            sb.Append("  mtype_manufacture = @mtype_manufacture ,   ");
            sb.Append("  mtype_physical = @mtype_physical ,   ");
            sb.Append("  mtype_abc = @mtype_abc ,   ");
            sb.Append("  specification = @specification ,   ");
            sb.Append("  mcolor = @mcolor ,   ");
            sb.Append("  barcode = @barcode ,   ");
            sb.Append("  erpcode = @erpcode ,   ");
            sb.Append("  barcode10 = @barcode10 ,   ");
            sb.Append("  barcode11 = @barcode11 ,   ");
            sb.Append("  barcode12 = @barcode12 ,   ");
            sb.Append("  replace_code = @replace_code ,   ");
            sb.Append("  product_code = @product_code ,   ");
            sb.Append("  design_life_cycle = @design_life_cycle ,   ");
            sb.Append("  for_customer = @for_customer ,   ");
            sb.Append("  safe_stock_num = @safe_stock_num ,   ");
            sb.Append("  price_unit = @price_unit ,   ");
            sb.Append("  flag_lock = @flag_lock ,   ");
            sb.Append("  flag_lock_desc = @flag_lock_desc ,   ");
            sb.Append("  purchase_cycle = @purchase_cycle ,   ");
            sb.Append("  is_key_material = @is_key_material ,   ");
            sb.Append("  price_tax_default = @price_tax_default ,   ");
            sb.Append("  uom_unit_default = @uom_unit_default ,   ");
            sb.Append("  package_qty_default = @package_qty_default ,   ");
            sb.Append("  u_create_name = @u_create_name ,   ");
            sb.Append("  u_create_id = @u_create_id ,   ");
            sb.Append("  t_create = @t_create ,   ");
            sb.Append("  u_update_name = @u_update_name ,   ");
            sb.Append("  u_update_id = @u_update_id ,   ");
            sb.Append("  t_update = @t_update ,   ");
            sb.Append("  flag_delete = @flag_delete ,   ");
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
            sb.Append(" where masterid = @masterid  ");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sb.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@mcode", SqlDbType.NVarChar, 500) { Value = newOne.mcode ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@mdesc", SqlDbType.NVarChar, 500) { Value = newOne.mdesc ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@mtype_manufacture", SqlDbType.NVarChar, 500) { Value = newOne.mtype_manufacture ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@mtype_physical", SqlDbType.NVarChar, 500) { Value = newOne.mtype_physical ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@mtype_abc", SqlDbType.NVarChar, 500) { Value = newOne.mtype_abc ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@specification", SqlDbType.NVarChar, 500) { Value = newOne.specification ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@mcolor", SqlDbType.NVarChar, 500) { Value = newOne.mcolor ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@barcode", SqlDbType.NVarChar, 500) { Value = newOne.barcode ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@erpcode", SqlDbType.NVarChar, 500) { Value = newOne.erpcode ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@barcode10", SqlDbType.NVarChar, 500) { Value = newOne.barcode10 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@barcode11", SqlDbType.NVarChar, 500) { Value = newOne.barcode11 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@barcode12", SqlDbType.NVarChar, 500) { Value = newOne.barcode12 ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@replace_code", SqlDbType.NVarChar, 500) { Value = newOne.replace_code ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@product_code", SqlDbType.NVarChar, 500) { Value = newOne.product_code ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@design_life_cycle", SqlDbType.Int) { Value = newOne.design_life_cycle });
            cmd.Parameters.Add(new SqlParameter("@for_customer", SqlDbType.NVarChar, 500) { Value = newOne.for_customer ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@safe_stock_num", SqlDbType.Int) { Value = newOne.safe_stock_num });
            cmd.Parameters.Add(new SqlParameter("@price_unit", SqlDbType.Decimal) { Value = newOne.price_unit });
            cmd.Parameters.Add(new SqlParameter("@flag_lock", SqlDbType.NVarChar, 500) { Value = newOne.flag_lock ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@flag_lock_desc", SqlDbType.NVarChar, 500) { Value = newOne.flag_lock_desc ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@purchase_cycle", SqlDbType.Int) { Value = newOne.purchase_cycle });
            cmd.Parameters.Add(new SqlParameter("@is_key_material", SqlDbType.NVarChar, 500) { Value = newOne.is_key_material ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@price_tax_default", SqlDbType.Decimal) { Value = newOne.price_tax_default });
            cmd.Parameters.Add(new SqlParameter("@uom_unit_default", SqlDbType.NVarChar, 500) { Value = newOne.uom_unit_default ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@package_qty_default", SqlDbType.Decimal) { Value = newOne.package_qty_default });
            cmd.Parameters.Add(new SqlParameter("@u_create_name", SqlDbType.NVarChar, 500) { Value = newOne.u_create_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_id", SqlDbType.NVarChar, 500) { Value = newOne.u_create_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_create", SqlDbType.DateTime) { Value = newOne.t_create });
            cmd.Parameters.Add(new SqlParameter("@u_update_name", SqlDbType.NVarChar, 500) { Value = newOne.u_update_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_update_id", SqlDbType.NVarChar, 500) { Value = newOne.u_update_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_update", SqlDbType.DateTime) { Value = newOne.t_update });
            cmd.Parameters.Add(new SqlParameter("@flag_delete", SqlDbType.Bit) { Value = newOne.flag_delete });
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
            cmd.Parameters.Add(new SqlParameter("@masterid", SqlDbType.NVarChar, 500) { Value = newOne.masterid ?? DBNull.Value.ToString() });
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
        public static bool DeleteByPKID(object mcode)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" delete from im_material_master where mcode=@masterid ");
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sb.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@masterid", SqlDbType.NVarChar, 150) { Value = mcode });
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
        /// <summary>
        ///根据条件获取
        /// </summary>
        /// <returns></returns>
        public static List<im_material_master> Get(List<KVP> keyValues)
        {
            StringBuilder sb = new StringBuilder();
            List<SqlParameter> parametrs = new List<SqlParameter>();
            sb.Append("select * from im_material_master where  flag_delete = 0 ");

            foreach (var keyValue in keyValues)
            {
                #region 逐个条件

                if (keyValue.Key.Trim().ToUpper() == "CODE_OR_DESC_LIKE")
                {
                    if (keyValue.Value.ToString() != string.Empty)
                    { 
                        sb.Append("and (mcode  like '%" + keyValue.Value + "%'  or mdesc  like '%" + keyValue.Value + "%'  or c100_1 like '%" + keyValue.Value + "%' ) ");
                    }
                }
             
                #endregion
            }
            var rtn = DoTableQuery(sb.ToString(), parametrs.ToArray());

            return rtn;
        }
    }
}