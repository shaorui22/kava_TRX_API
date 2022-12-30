using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRX_KAVA_API.Models
{
    [Serializable]
    
    public class im_container
    {
        ///<summary>
        ///
        ///</summary>
        
        public string ctnid { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string ctncode { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string ctndesc { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string ctn_type { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public int ctn_length { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public int ctn_width { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public int ctn_height { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public decimal max_weight { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public decimal selt_weight { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string bind_factory_line { get; set; }
        ///<summary>
        ///
        ///</summary>
        
        public string bind_material_type { get; set; }
        ///<summary>
        ///
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
    }
}