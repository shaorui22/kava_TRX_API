using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRX_KAVA_API.Models
{
    [Serializable]
     
    public class wms_inventory
    {
        ///<summary>
        ///唯一编号（Guid.NewGuid()）
        ///</summary>       
        public string invid { get; set; }

        ///<summary>
        ///仓库编号
        ///</summary>      
        public string warehouse { get; set; }

        ///<summary>
        ///库位编号
        ///</summary>       
        public string place_code { get; set; }

        ///<summary>
        ///托盘号
        ///</summary>        
        public string container_id { get; set; }

        ///<summary>
        ///托盘状态（组盘（InTemp）入库完成（InFinished））
        ///</summary>        
        public string inv_type { get; set; }

        ///<summary>
        ///暂空
        ///</summary>       
        public string order_from { get; set; }

        ///<summary>
        ///PC端，PDA端
        ///</summary>        
        public string order_in { get; set; }

        ///<summary>
        ///采购单号
        ///</summary>      
        public string order_purchase { get; set; }

        ///<summary>
        ///采购单明细号
        ///</summary> 
        public string order_out { get; set; }

        ///<summary>
        ///生产单号
        ///</summary>       
        public string order_manufacture { get; set; }

        ///<summary>
        ///生产单明细序号
        ///</summary>       
        public string order_customer { get; set; }

        ///<summary>
        ///订单序号
        ///</summary>        
        public string belong_customer { get; set; }

        ///<summary>
        ///物料编码
        ///</summary>
        public string mcode { get; set; }

        ///<summary>
        ///物料名称
        ///</summary>       
        public string mdesc { get; set; }

        ///<summary>
        ///物料类型
        ///</summary>        
        public string mtype { get; set; }

        ///<summary>
        ///暂空
        ///</summary>       
        public string inv_status { get; set; }

        ///<summary>
        ///批次号
        ///</summary>        
        public string batchno { get; set; }

        ///<summary>
        ///订单明细序号
        ///</summary>      
        public string batchno_rsv1 { get; set; }

        ///<summary>
        ///暂空
        ///</summary>        
        public string batchno_rsv2 { get; set; }

        ///<summary>
        ///暂空
        ///</summary>       
        public string batchno_rsv3 { get; set; }

        ///<summary>
        ///暂空
        ///</summary>       
        public string uom { get; set; }

        ///<summary>
        ///组盘数量
        ///</summary>      
        public decimal qty { get; set; }

        ///<summary>
        ///暂空（decimal格式）
        ///</summary>        
        public decimal qty_occupy { get; set; }

        ///<summary>
        ///暂空（decimal格式）
        ///</summary>        
        public decimal qty_package { get; set; }

        ///<summary>
        ///暂空（decimal格式）
        ///</summary>       
        public decimal qty_occupy_package { get; set; }

        ///<summary>
        ///暂空
        ///</summary>     
        public string uom_package { get; set; }

        ///<summary>
        ///组盘时间
        ///</summary>       
        public DateTime t_create { get; set; }

        ///<summary>
        ///入库完成时间
        ///</summary>       
        public DateTime t_update { get; set; }

        ///<summary>
        ///出库任务下发时间
        ///</summary>        
        public DateTime t_in { get; set; }

        ///<summary>
        ///出库任务完成时间
        ///</summary>        
        public DateTime t_out { get; set; }

        ///<summary>
        ///暂空（time时间格式）
        ///</summary>        
        public DateTime t_out_permit { get; set; }

        ///<summary>
        ///暂空
        ///</summary>        
        public string occupy_symbol { get; set; }

        ///<summary>
        ///暂空
        ///</summary>
        public string occupy_content { get; set; }

        ///<summary>
        ///操作人员姓名
        ///</summary>
        public string u_create_name { get; set; }

        ///<summary>
        ///操作人员ID
        ///</summary>       
        public string u_create_id { get; set; }

        ///<summary>
        ///拣货人员姓名
        ///</summary>        
        public string u_update_name { get; set; }

        ///<summary>
        ///拣货人员ID
        ///</summary>       
        public string u_update_id { get; set; }

        ///<summary>
        ///是否删除（bool类型）
        ///</summary>        
        public bool flag_delete { get; set; }

        ///<summary>
        ///是否有效
        ///</summary>        
        public bool flag_effect { get; set; }

        ///<summary>
        ///是否同步
        ///</summary>       
        public bool flag_synchro { get; set; }

        ///<summary>
        ///是否审核
        ///</summary>        
        public bool flag_audit { get; set; }

        ///<summary>
        ///客方货号
        ///</summary>        
        public string c100_1 { get; set; }

        ///<summary>
        ///工序
        ///</summary>
        public string c100_2 { get; set; }

        ///<summary>
        ///塑料托盘号
        ///</summary>
        public string c100_3 { get; set; }

        ///<summary>
        ///暂空
        ///</summary>
        public string c100_4 { get; set; }

        ///<summary>
        ///暂空
        ///</summary>
        public string c100_5 { get; set; }

        ///<summary>
        ///暂空
        ///</summary>
        public string c200_1 { get; set; }

        ///<summary>
        ///暂空
        ///</summary>
        public string c200_2 { get; set; }

        ///<summary>
        ///暂空
        ///</summary>
        public string c200_3 { get; set; }

        ///<summary>
        ///暂空
        ///</summary>
        public string c200_4 { get; set; }

        ///<summary>
        ///暂空
        ///</summary>
        public string c200_5 { get; set; }

        ///<summary>
        ///暂空
        ///</summary>
        public int i1 { get; set; }

        ///<summary>
        ///暂空
        ///</summary>
        public int i2 { get; set; }

        ///<summary>
        ///暂空
        ///</summary>
        public int i3 { get; set; }

        ///<summary>
        ///暂空
        ///</summary>
        public int i4 { get; set; }

        ///<summary>
        ///暂空
        ///</summary>
        public int i5 { get; set; }

        ///<summary>
        ///暂空
        ///</summary>
        public decimal n1 { get; set; }

        ///<summary>
        ///暂空
        ///</summary>
        public decimal n2 { get; set; }

        ///<summary>
        ///暂空
        ///</summary>
        public decimal n3 { get; set; }

        ///<summary>
        ///暂空
        ///</summary>
        public decimal n4 { get; set; }

        ///<summary>
        ///暂空
        ///</summary>
        public decimal n5 { get; set; }
    }
}