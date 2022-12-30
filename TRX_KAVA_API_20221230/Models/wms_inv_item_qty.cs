using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRX_KAVA_API.Models
{
    [Serializable]
    public class wms_inv_item_qty
    {
        public string itemcode { get; set; }
        public string itemdesc { get; set; }
        /// <summary>
        ///  物料类型
        /// </summary> 
        public string mtype { get; set; }
        /// <summary>
        /// 库存 状态
        /// </summary>
        public string inv_status { get; set; } 
        /// <summary>
        /// 批号
        /// </summary>
        public string batchno { get; set; }
        /// <summary>
        /// 批号2
        /// </summary>
        public string batchno2 { get; set; }
        public string uom { get; set; }
        public decimal qty { get; set; }
        public string package_uom { get; set; }
        public int qtyPackage { get; set; }
        public decimal qty2 { get; set; }
        public string uom2 { get; set; }
        public decimal qty3 { get; set; }
        public string uom3 { get; set; }
        public string remarks { get; set; }
    }
}