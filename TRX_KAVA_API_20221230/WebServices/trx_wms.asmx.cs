using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using TRX_KAVA_API.Models;

namespace TRX_KAVA_API.WebServices
{
    /// <summary>
    /// trx_wms 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class trx_wms : System.Web.Services.WebService
    {
        #region WCS-TASK
        [WebMethod]
        public string WCS_Generate_In_task(string place_from, string place_to, string tasknum, string barcode)
        {
            string rtn = "E未执行WCS-WebService调用";
            try
            {
                LogHelper.Info("PDA调用一次WCS生成入库任务 接口：place_from" + place_from + " >place_to：" + place_to + " >tasknum：" + tasknum + " >barcode：" + barcode);
                using (WebSrvWCS.WCS_forWMSSoapClient client = new WebSrvWCS.WCS_forWMSSoapClient())
                {
                    var r = client.InTask(place_from, place_to, tasknum, barcode);
                    if (r.result)
                    {
                        rtn = "S";
                    }
                    else
                    {
                        rtn = "E 调用WCS入库任务 接口 服务失败，返回错误提示：Code:" + r.error_code + "MSG: " + r.error_message;
                    }
                }
            }
            catch (Exception exc)
            {
                rtn = "E -WCS生成入库任务webService 接口错误：" + exc.Message;
                LogHelper.Error("WCS生成入库任务webService 接口错误：" + exc.Message + "\r\n" + exc.StackTrace);
            }
            return rtn;
        }

        [WebMethod]
        public string WCS_Generate_Out_Task(string place_from, string place_to, string tasknum, string barcode,string res)
        {
            string rtn = "E未执行WCS-WebService调用";
            try
            {
                LogHelper.Info("PDA调用一次WCS生成出库任务 接口：place_from:" + place_from + " >place_to：" + place_to + " >tasknum：" + tasknum + " >barcode：" + barcode);
                using (WebSrvWCS.WCS_forWMSSoapClient client = new WebSrvWCS.WCS_forWMSSoapClient())
                { 
                    var r = client.OutTask(place_from, place_to, tasknum, barcode,res);
                    if (r.result)
                    {
                        rtn = "S";
                    }
                    else
                    {
                        rtn = "E 调用WCS出库 接口 服务失败，返回错误提示：Code:" + r.error_code + "MSG: " + r.error_message;
                    }
                }
            }
            catch (Exception exc)
            {
                rtn = "E -WCS生成出库任务webService 接口错误：" + exc.Message;
                LogHelper.Error("WCS生成出库任务webService 接口错误：" + exc.Message + "\r\n" + exc.StackTrace);
            }
            return rtn;
        }
        [WebMethod]
        public string WCS_Generate_Transfer_Task(string place_from, string place_to, string tasknum, string barcode,string out_number)
        {
            string rtn = "E未执行WCS-WebService调用";
            try
            {
                LogHelper.Info("PDA调用一次WCS生成 移库 任务 接口：place_from" + place_from + " >place_to：" + place_to + " >tasknum：" + tasknum + " >barcode：" + barcode);
                using (WebSrvWCS.WCS_forWMSSoapClient client = new WebSrvWCS.WCS_forWMSSoapClient())
                {
                    var r = client.MoveTask(place_from, place_to, tasknum, barcode,out_number);
                    if (r.result)
                    {
                        rtn = "S";
                    }
                    else
                    {
                        rtn = "E 调用WCS移库 接口 服务失败，返回错误提示：Code:" + r.error_code + "MSG: " + r.error_message;
                    }
                }
            }
            catch (Exception exc)
            {
                rtn = "E -WCS生成移库 任务webService 接口错误：" + exc.Message;
                LogHelper.Error("WCS生成移库 任务webService 接口错误：" + exc.Message + "\r\n" + exc.StackTrace);
            }
            return rtn;
        }
        [WebMethod]
        public string WCS_Generate_Conveyor_Task(string place_from, string place_to, string tasknum, string barcode)
        {
            string rtn = "E未执行WCS-WebService调用";
            try
            {
                LogHelper.Info("PDA调用一次WCS生成 输送机搬运 任务 接口：place_from" + place_from + " >place_to：" + place_to + " >tasknum：" + tasknum + " >barcode：" + barcode);
                using (WebSrvWCS.WCS_forWMSSoapClient client = new WebSrvWCS.WCS_forWMSSoapClient())
                {
                    var r = client.ContainerOutConveyorAskToNewPort(place_from, place_to, tasknum, barcode);
                    if (r.result)
                    {
                        rtn = "S";
                    }
                    else
                    {
                        rtn = "E 调用WCS 输送机搬运 接口 服务失败，返回错误提示：Code:" + r.error_code + "MSG: " + r.error_message;
                    }
                }
            }
            catch (Exception exc)
            {
                rtn = "E -WCS生成 输送机搬运 任务webService 接口错误：" + exc.Message;
                LogHelper.Error("WCS生成 输送机搬运 任务webService 接口错误：" + exc.Message + "\r\n" + exc.StackTrace);
            }
            return rtn;
        }

        [WebMethod]
        public string WCS_OutPickReturn_GenerateInTask(string place_from, string place_to,  string barcode ,bool isPickReturn,string height)
        {
            try
            {
                using (wms4wcs client =new wms4wcs())
                {
                    var ts = client.ContainerInAsk(Guid.NewGuid().ToString(),barcode, place_from, height, 400, isPickReturn,"");
                    if (ts.result)
                    {
                        var wcsrtn = WCS_Generate_In_task(place_from, ts.place_instock, ts.task_num, barcode);
                        if (wcsrtn == "S")
                        {
                            return "S下发WMS-WCS入库新任务成功！";
                        }
                        else
                        {
                            return wcsrtn;
                        }
                    }
                    else
                    {
                        return "E wms生成新任务失败！请联系管理员重试!";
                    }
                }
            }
            catch (Exception exc)
            {
                return "E下发WMS-WCS入库新任务失败！"+exc.Message;
            }
        }



        #endregion

        #region PLACES
        [WebMethod]
        public wms_places PlaceGetOneByID(string ID)
        {
            return DAL.da_wms_places.GetOneByID(ID);
        }

        [WebMethod]
        public wms_places PlaceGetOneByCode(string placecode)
        {
            return DAL.da_wms_places.GetOneByCode(placecode);
        }

        [WebMethod]
        public string PlaceAdd(wms_places pl)
        {
            if (DAL.da_wms_places.InsertNew(pl))
            {
                return "suss";
            }
            else
            {
                return "fail";
            }
        }

        [WebMethod]
        public bool PlaceUpdate(wms_places pl)
        {
            return DAL.da_wms_places.UpdateOne(pl);

        }
        [WebMethod(Description = "获取所有库位")]
        public List<wms_places> PlaceGetAll()
        {
            return DAL.da_wms_places.Get(new List<KVP>());
        }

        //[WebMethod(Description = "根据巷道及出入库获取取放货口")]
        //public string PlaceGetInOutStation(string slide, string InOrOut)
        //{
        //    return DAL.da_wms_places.getInOutStation(slide, InOrOut);
        //}

        [WebMethod]
        public List<wms_places> PlaceGetNotEmptyOrHasTaskPlaces()
        {
            return DAL.da_wms_places.GetNotEmptyOrHasTaskPlaces();
        }

        [WebMethod]
        public bool PlaceUpdateSeq(int seqs, int row, int column, int layer)
        {
            return DAL.da_wms_places.updateSeq(seqs, row, column, layer);
        }

        [WebMethod]
        public string PlaceInOccupyUnDo(string placenum)
        {
            return DAL.da_wms_places.InOccupyPlaceUnDo(placenum);
        }
        #endregion

        #region sysConfig
        [WebMethod]
        public int SysConfig_GetNewRcdID(string configcode)
        {
            return DAL.da_sys_config.GetNewRcdID(configcode);
        }
        [WebMethod]
        public bool SysConfig_InsertNEW(sys_config tt)
        {
            return DAL.da_sys_config.InsertNew(tt);
        }
        [WebMethod]
        public bool SysConfig_Update(sys_config tt)
        {
            return DAL.da_sys_config.UpdateOne(tt);
        }
        [WebMethod]
        public sys_config SysConfig_GetOne(string configcode)
        {
            return DAL.da_sys_config.GetOneByID(configcode);
        }

        [WebMethod]
        public List<sys_config> SysConfig_GetByTypes(string typecode)
        {
            return DAL.da_sys_config.GetByTypes(typecode);
        }

        [WebMethod]
        public bool SysConfig_UpdateRealtimeValueByType(string typecode1, string typecode2, string value1, string value2, string value3)
        {
            return DAL.da_sys_config.SysConfig_UpdateRealtimeValueByType(typecode1, typecode2, value1, value2, value3);
        }
        #endregion

        #region Inventory
        [WebMethod]
        public bool InventoryCVM_InsertOne(wms_inventory tt)
        {
            return DAL.da_wms_inventory.InsertNew(tt);
        }

        [WebMethod(Description = "组盘方法1")]
        public string InventoryCVM_SubBind(string warehouse, string pallet, List<wms_inv_item_qty> item_qtys, string doUSer, string order_from, string order_in, string order_purchase, string order_manufacture)
        {
            return DAL.da_wms_inventory.SubBind1(warehouse, pallet, item_qtys, doUSer, order_from, order_in, order_purchase, order_manufacture);
        }

        [WebMethod(Description = "组盘方法2")]
        public string InventoryCVM_SubBind2(List<wms_inventory> item_qtys)
        {
            return DAL.da_wms_inventory.SubBind2(item_qtys);
        }

        [WebMethod]
        public bool InventoryCVM_UpdateOne(wms_inventory tt)
        {
            return DAL.da_wms_inventory.UpdateOne(tt);
        }

        [WebMethod]
        public List<wms_inventory> InventoryCVM_GetAllBymcode(string Mcode)
        {
            return DAL.da_wms_inventory.list_GetOneByMcode(Mcode);
        }
        [WebMethod]
        public bool InventoryCVM_DeleteOne(string cvmid)
        {
            return DAL.da_wms_inventory.DeleteByPKID(cvmid);
        }

        [WebMethod]
        public wms_inventory InventoryCVM_GetByID(string id)
        {
            return DAL.da_wms_inventory.GetOneByID(id);

        }

        [WebMethod]
        public wms_inventory InventoryCVM_GetByPallet(string pallet)
        {
            return DAL.da_wms_inventory.GetOneByPallet(pallet);
        }
        [WebMethod]
        public List<wms_inventory> InventoryCVM_GetAllByPallet(string pallet)
        {
            return DAL.da_wms_inventory.GetAllByPallet(pallet);
        }
        [WebMethod]
        public wms_inventory InventoryCVM_GetOneByMcode(string Mcode)
        {
            return DAL.da_wms_inventory.GetOneByMcode(Mcode);
        }

        [WebMethod]
        public List<wms_inventory> InventoryCVM_GetByInventoryType(string type)
        {
            return DAL.da_wms_inventory.GetOneByInventoryType(type);
        }

        [WebMethod(Description = "返回托盘号最近一次出库时的组盘信息")]
        public List<wms_inventory> InventoryHIS_GetByInventorycontainer_id(string container_id)
        {
            return DAL.da_wms_inventory.List_GetOneBycontainer_id(container_id);
        }
        #endregion

        #region DeviceTask
        [WebMethod]
        public bool DeviceTask_insert(wms_devices_task tt)
        {
            var lisNot = DAL.da_wms_devices_task.GetNotFinishTasks("");
            if (lisNot != null)
            {
                if (tt.task_type == "SRM_OUT" && lisNot.Select(x => x.place_from).Contains(tt.place_from))
                {
                    LogHelper.Info(tt.place_from + "有重复出入库任务。");
                    return false; //有重复！
                }
            }
            // DAL.da_wms_devices_task.ExcuteMoveFinishedTaskOut();  //移除已完成出库任务。
            return DAL.da_wms_devices_task.InsertNew(tt);
        }
        [WebMethod]
        public bool DeviceTask_Update(wms_devices_task tt)
        {
            return DAL.da_wms_devices_task.UpdateOne(tt);
        }
        [WebMethod]
        public bool DeviceTask_Delete(string taskid)
        {
            return DAL.da_wms_devices_task.DeleteByPKID(taskid);
        }
        [WebMethod]
        public wms_devices_task DeviceTask_GetOneByID(string taskid)
        {
            return DAL.da_wms_devices_task.GetOneByID(taskid);
        }
        [WebMethod]
        public wms_devices_task DeviceTask_GetDoingPallet(string palletcode, string tasktype)
        {
            return DAL.da_wms_devices_task.GetDoingPallet(palletcode, tasktype);
        }
        [WebMethod]
        public wms_devices_task DeviceTask_GetOneByTargetPlace(string toPlaceID)
        {
            return DAL.da_wms_devices_task.GetOneByTargetPlace(toPlaceID);
        }
        [WebMethod]
        public List<wms_devices_task> DeviceTask_GetNotFinishTasks(string typecode)
        {
            return DAL.da_wms_devices_task.GetNotFinishTasks(typecode);
        }
        [WebMethod]
        public List<wms_devices_task> DeviceTask_GetRecordsByConditions(string mcodeOrdesc, string TimeStart, string TimeEnd, string inout_type)
        {
            return DAL.da_wms_devices_task.GetRecordsByConditions(mcodeOrdesc, TimeStart, TimeEnd, inout_type);
        }
        #endregion

        #region IM Master
        [WebMethod(Description = "根据物料属性集合获取相关物料")]
        public List<im_material_master> IM_GetByTypeAndCodeDescLike(List<KVP> keyValues)
        {
            return DAL.da_im_material_master.Get(keyValues);
        }

        [WebMethod(Description = "新增单个物料")]
        public string IM_AddMaterial(im_material_master im)
        {
            if (DAL.da_im_material_master.InsertNew(im))
            {
                return "suss";
            }
            else
            {
                return "fail";
            }
        }


        [WebMethod(Description = "依据物料号删除单个物料")]
        public bool IM_DeleteByID(string mcode)
        {
            return DAL.da_im_material_master.DeleteByPKID(mcode);
        }

        #endregion

    }
}

 
