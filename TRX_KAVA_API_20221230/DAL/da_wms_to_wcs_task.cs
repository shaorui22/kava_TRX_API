using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TRX_KAVA_API.Models;

namespace TRX_KAVA_API.DAL
{
    public class Da_wms_to_wcs_task
    {
        public static bool Wms_to_wcs_task_TRANSFER(string place_from,string place_to,string barcode,string do_device)
        {
            LogHelper.Info("调用一次WCS生成移库任务 接口：place_from" + place_from + " >place_to：" + place_to + " >barcode：" + barcode);
            try
            {
                int newtaskID = DAL.da_sys_config.GetNewRcdID("taskIDgeneratorTransfer");
                wms_devices_task nisa = new wms_devices_task();             
                nisa.taskid = newtaskID.ToString();
                nisa.taskcode = newtaskID.ToString();
                nisa.main_material = "";
                nisa.do_device = do_device;
                nisa.do_platform = "SRM";
                nisa.order_from = "";
                nisa.place_from = place_from;
                nisa.place_to = place_to;
                nisa.container_id = barcode;
                nisa.place_from_wcs = "";
                nisa.place_to_wcs = "";
                nisa.task_detail_neck = 0;
                nisa.task_type = "SRM_TO";
                nisa.task_status = "NEW";
                nisa.task_batch = "";
                nisa.t_create = System.DateTime.Now;
                nisa.t_update = System.DateTime.Now;
                nisa.t_diliver = System.DateTime.Parse("2000-01-01 00:00:01");
                nisa.t_finish = System.DateTime.Parse("2000-01-01 00:00:01");
                nisa.u_create_name = "";
                nisa.u_create_id = "";
                nisa.u_update_name = "";
                nisa.u_update_id = "";
                nisa.flag_feedback = "N";
                nisa.flag_delete = false;
                if (DAL.da_wms_devices_task.InsertNew(nisa))
                {
                    //修改货位状态
                    DAL.da_wms_places.InOccupyPlace_out(newtaskID.ToString(), place_from);
                    DAL.da_wms_places.InOccupyPlace(newtaskID.ToString(), place_to);
                    using (WebSrvWCS.WCS_forWMSSoapClient client = new WebSrvWCS.WCS_forWMSSoapClient())
                    {
                        var wcsInvoke = client.MoveTask(place_from,place_to, nisa.taskcode, nisa.container_id,"WMS");
                        if (wcsInvoke.result)
                        {                                 
                            return true;
                        }
                        else
                        {                     
                            return false;
                        }
                    }                    
                }
                else
                {
                    
                    return false;
                }
               
            }
            catch (Exception exc)
            {              
                LogHelper.Error("WCS生成入库任务webService 接口错误：" + exc.Message + "\r\n" + exc.StackTrace);

                return false;
            }
            
        }



    }
}