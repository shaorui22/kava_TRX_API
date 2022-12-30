using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRX_KAVA_API.Models
{
    public class WCS_Ask_Result
    {
        /// <summary>
        /// 执行结果
        /// </summary>
        public bool result { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string error_code { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        public string error_message { get; set; }

        /// <summary>
        /// wcs发过来的请求顺序号
        /// </summary>
        public string ask_num { get; set; }

        /// <summary>
        /// 入库货位
        /// </summary>
        public string place_instock { get; set; }
        
        /// <summary>
        /// 目标道口
        /// </summary>
        public string sorting_port { get; set; }

        /// <summary>
        /// 是否缠膜
        /// </summary>
        public bool pallet_wrapping { get; set; }

        /// <summary>
        /// 任务号
        /// </summary>
        public string task_num { get; set; }

        /// <summary>
        /// 备用字段1
        /// </summary>
        public string reserve_field1 { get; set; }

        /// <summary>
        /// 备用字段2
        /// </summary>
        public string reserve_field2 { get; set; }
        /// <summary>
        /// 备用字段3
        /// </summary>
        public string reserve_field3 { get; set; }
        /// <summary>
        /// 备用字段4
        /// </summary>
        public string reserve_field4 { get; set; }
        /// <summary>
        /// 备用字段5
        /// </summary>
        public string reserve_field5 { get; set; }
    }
}