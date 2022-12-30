using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRX_KAVA_API.Models
{
    [Serializable]
    
    public class sys_config
    {
        ///<summary>
        ///
        ///</summary>
        
        public string config_code { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string config_desc { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string config_type { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string config_type2 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string realtime_value1 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string realtime_value2 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string realtime_value3 { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public DateTime t_create { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public DateTime t_update { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string flag_void { get; set; }
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
        ///
        ///</summary>
        
        public bool flag_delete { get; set; }
    }
}