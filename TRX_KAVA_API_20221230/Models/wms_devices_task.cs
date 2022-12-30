using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRX_KAVA_API.Models
{
    [Serializable]
     
    public class wms_devices_task
    {
        ///<summary>
        ///任务记录ID，字符串
        ///</summary>
        
        public string taskid { get; set; }
        ///<summary>
        ///任务代码，具有唯一值，一般以数字来表示
        ///</summary>
        
        public string taskcode { get; set; }
        ///<summary>
        ///主要物料代码，可选填
        ///</summary>
        
        public string main_material { get; set; }
        ///<summary>
        ///执行命令的设备ID，堆垛机编号
        ///</summary>
        
        public string do_device { get; set; }
        ///<summary>
        ///执行的设备平台，默认"SRM"堆垛机，"CVNR"输送机
        ///</summary>
        
        public string do_platform { get; set; }
        ///<summary>
        ///任务来源于哪个订单（分解的）
        ///</summary>
        
        public string order_from { get; set; }
        ///<summary>
        ///任务起始货位号（WMS用）
        ///</summary>
        
        public string place_from { get; set; }
        ///<summary>
        ///任务目标货位号（WMS用）
        ///</summary>
        
        public string place_to { get; set; }
        ///<summary>
        ///容器号（托盘料箱）
        ///</summary>
        
        public string container_id { get; set; }
        ///<summary>
        ///任务起始货位号（WCS用）
        ///</summary>
        
        public string place_from_wcs { get; set; }
        ///<summary>
        ///任务目标货位号（WCS用）
        ///</summary>
        
        public string place_to_wcs { get; set; }
        ///<summary>
        ///改任务属于大单据的明细行号，可空选填
        ///</summary>
        
        public int task_detail_neck { get; set; }
        ///<summary>
        ///任务类型，默认"SRM_OUT" 堆垛机出库，WCS只处理出库类型的任务。
        ///</summary>
        
        public string task_type { get; set; }
        ///<summary>
        ///任务状态(NEW/RELEASED/DOING/FINISHED/ERR_CLOSED/ABORTED)
        ///</summary>
        
        public string task_status { get; set; }
        ///<summary>
        ///任务批次号
        ///</summary>
        
        public string task_batch { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public DateTime t_create { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public DateTime t_update { get; set; }
        ///<summary>
        ///任务送达时间
        ///</summary>
        
        public DateTime t_diliver { get; set; }
        ///<summary>
        ///任务完成时间
        ///</summary>
        
        public DateTime t_finish { get; set; }
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
        
        public string u_update_name { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string u_update_id { get; set; }
        ///<summary>
        ///反馈标识，Y/N
        ///</summary>
        
        public string flag_feedback { get; set; }
        ///<summary>
        ///删除标识
        ///</summary>
        
        public bool flag_delete { get; set; }
    }
}