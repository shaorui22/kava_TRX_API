using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRX_KAVA_API.Models
{
    [Serializable]
   
    public class im_material_master
    {
        ///<summary>
        ///
        ///</summary>
        
        public string masterid { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string mcode { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string mdesc { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string mtype_manufacture { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string mtype_physical { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string mtype_abc { get; set; }
        ///<summary>
        ///规格型号
        ///</summary>
        
        public string specification { get; set; }
        ///<summary>
        ///物料颜色
        ///</summary>
        
        public string mcolor { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string barcode { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string erpcode { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string barcode10 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string barcode11 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string barcode12 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string replace_code { get; set; }
        ///<summary>
        ///产品代码
        ///</summary>
        
        public string product_code { get; set; }
        ///<summary>
        ///设计寿命（天数）
        ///</summary>
        
        public int design_life_cycle { get; set; }
        ///<summary>
        ///物料所属客户
        ///</summary>
        
        public string for_customer { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public int safe_stock_num { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public decimal price_unit { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string flag_lock { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string flag_lock_desc { get; set; }
        ///<summary>
        ///采购周期，天数
        ///</summary>
        
        public int purchase_cycle { get; set; }
        ///<summary>
        ///是否是关键物料
        ///</summary>
        
        public string is_key_material { get; set; }
        ///<summary>
        ///默认含税价格
        ///</summary>
        
        public decimal price_tax_default { get; set; }
        ///<summary>
        ///默认单位
        ///</summary>
        
        public string uom_unit_default { get; set; }
        ///<summary>
        ///包装数量，多少个/kg  1箱、盒、袋等。
        ///</summary>
        
        public decimal package_qty_default { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string u_create_name { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string u_create_id { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public DateTime t_create { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string u_update_name { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string u_update_id { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public DateTime t_update { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public bool flag_delete { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string c100_1 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string c100_2 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string c100_3 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string c100_4 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string c100_5 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string c200_1 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string c200_2 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string c200_3 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string c200_4 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string c200_5 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public int i1 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public int i2 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public int i3 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public int i4 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public int i5 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public decimal n1 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public decimal n2 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public decimal n3 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public decimal n4 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public decimal n5 { get; set; }
    }
}