using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRX_KAVA_API.Models
{
    public class wms_agv_place
    {
        ///<summary>
        ///
        ///</summary>

        public string plid { get; set; }
        ///<summary>
        ///
        ///</summary>

        public string place_code { get; set; }
        ///<summary>
        ///工厂编号
        ///</summary>

        public string plant_code { get; set; }
        ///<summary>
        ///仓库
        ///</summary>

        public string warehouse_code { get; set; }
        ///<summary>
        ///
        ///</summary>

        public string code_wcs { get; set; }
        ///<summary>
        ///
        ///</summary>

        public string code_mes { get; set; }
        ///<summary>
        ///
        ///</summary>

        public string code_erp { get; set; }
        ///<summary>
        ///巷道
        ///</summary>

        public int numb_lane { get; set; }
        ///<summary>
        ///排
        ///</summary>

        public int numb_row { get; set; }
        ///<summary>
        ///列
        ///</summary>

        public int numb_column { get; set; }
        ///<summary>
        ///层
        ///</summary>

        public int numb_layer { get; set; }
        ///<summary>
        ///单元
        ///</summary>

        public int numb_unit { get; set; }
        ///<summary>
        ///
        ///</summary>

        public string place_desc { get; set; }
        ///<summary>
        ///货位类型
        ///</summary>

        public string place_type { get; set; }
        ///<summary>
        ///货位区域
        ///</summary>

        public string place_area { get; set; }
        ///<summary>
        ///
        ///</summary>

        public string is_empty { get; set; }
        ///<summary>
        ///是否锁定Y/N
        ///</summary>

        public string flag_lock { get; set; }
        ///<summary>
        ///是否有任务Y/N
        ///</summary>

        public string flag_has_task { get; set; }
        ///<summary>
        ///绑定物料类型
        ///</summary>

        public string bind_material_type { get; set; }
        ///<summary>
        ///绑定物料编号
        ///</summary>

        public string bind_material_code { get; set; }
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

        public string hight_level { get; set; }
        ///<summary>
        ///
        ///</summary>

        public int pl_length { get; set; }
        ///<summary>
        ///
        ///</summary>

        public int pl_width { get; set; }
        ///<summary>
        ///
        ///</summary>

        public int pl_height { get; set; }
        ///<summary>
        ///
        ///</summary>

        public decimal max_weight { get; set; }
        ///<summary>
        ///
        ///</summary>

        public string pallet_container { get; set; }
        ///<summary>
        ///
        ///</summary>

        public string belong_device { get; set; }
        ///<summary>
        ///
        ///</summary>

        public string rsv_str1 { get; set; }
        ///<summary>
        ///
        ///</summary>

        public string rsv_str2 { get; set; }
        ///<summary>
        ///
        ///</summary>

        public string rsv_str3 { get; set; }
        ///<summary>
        ///
        ///</summary>

        public string rsv_str4 { get; set; }
        ///<summary>
        ///
        ///</summary>

        public string rsv_str5 { get; set; }
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