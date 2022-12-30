using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRX_KAVA_API.Models
{
    [Serializable]
    
    public class sys_tbl_clmn_set
    {
        ///<summary>
        ///
        ///</summary>
        
        public string scid { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string tb_name { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string column_field { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string column_desc { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string column_type { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public bool display { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public bool allow_null { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string default_value { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public int display_order { get; set; }
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
        
        public string dropdownList_vls { get; set; }
        ///<summary>
        ///是否是主键
        ///</summary> 
        public bool iskeycolumn { get; set; }
    }
}