using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using TRX_KAVA_API.Models;

namespace TRX_KAVA_API.WebServices
{
    /// <summary>
    /// WMS_4_WCS 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]          
    public class wms4wcs : WebService
    {

        [WebMethod(Description = "返回服务器时间字符串，格式yyyy-MM-dd HH:mm:ss.fff")]
        public string GetServerTimeString()
        {
            var t = System.DateTime.Now; 
            var r=  t.ToString("yyyy-MM-dd HH:mm:ss.fff");
            LogHelper.Info("获取服务器时间接口被调用一次。");
            return r;
        }


        [WebMethod(Description = "WCS反馈WMS包装线一垛完成接口")]
        public string ContainerWCS2(string PallentBarcode, string workcenter, string totlenum, string Salesorder, string ordermcode, string Guestorder)
        {

            var r = "二楼码垛完成！调度WMS反馈接口成功！";
            //var getinTask = DAL.da_wms_agv_task.GetOnedoingByTaskCode(container_id.Trim());

            string SQL = "SELECT NEXT VALUE  FOR [dbo].[IDforNumber] as 'ID'";
            List<NEWID> list = new List<NEWID>();
            list = SqlHelp.ExecuteDataTable<NEWID>(SQL, CommandType.Text, null);

            var Batchnumbe = PallentBarcode + DateTime.Now.ToString("yyyyMMdd") + list[0].ID.ToString("000");
            LogHelper.Info("获取WCS码垛完成接口被调用一次。" + "托盘号：" + PallentBarcode + "工作中心：" + workcenter + "总数量：" + totlenum + "成品编号：" + ordermcode + "订单号：" + Salesorder + "客方货号：" + Guestorder + "入库批次号：" + Batchnumbe);
            return r;
        }


        /// <summary>
        /// 入库申请，返回货位、任务号等信息
        /// </summary>
        /// <param name="ask_num">请求号</param>
        /// <param name="container_id">容器号(托盘/箱号)</param>
        /// <param name="in_port_num">申请时的道口编号</param>
        /// <param name="height_level">高度值</param>
        /// <param name="weight">重量KG</param>
        /// <param name="is_pick_return">是否拣货后入库</param>
        /// <param name="rsv_type">备用类型</param>
        /// <returns></returns>
        [WebMethod(Description = "托盘放上入库口后WCS申请调用接口。经过外形检测后，WCS根据托盘物料属性,获取相关入库库位、目标道口")] 
        public WCS_Ask_Result ContainerInAsk(string ask_num, string container_id, string in_port_num, string height_level, decimal weight, bool is_pick_return, string rsv_type)
        {
            WCS_Ask_Result rtn = new WCS_Ask_Result();
           try
            {
                LogHelper.Info("WCS调用一次入库货位申请："+ask_num+" >"+ container_id + " >" + in_port_num + " >" + height_level + " >" + weight + " >" + is_pick_return + " >" + rsv_type);

                rtn.ask_num = ask_num;             
                rtn.error_code = "0000";
                rtn.result = true;
                rtn.error_message = "入库申请执行处理成功";
                rtn.place_instock = "";
                rtn.task_num = "";
                rtn.sorting_port = in_port_num;

                if (container_id.Trim() == "")
                {
                    rtn.error_code = "0003";
                    rtn.result = false;
                    rtn.error_message = "托盘号为空";
                }
                else
                {
                    var find_inStock = DAL.da_wms_places.GetOneByPallet(container_id.Trim());
                    if (find_inStock != null)
                    {
                        rtn.error_code = "0002";
                        rtn.result = false;
                        rtn.error_message = "托盘号重复，库内已有该托盘";
                    } 
                    else
                    {
                        if (container_id.Trim()== "200228" || container_id.Trim() == "200229")
                        {
                            var plGet = DAL.da_wms_places.PlaceGetOneEmptyByPallet2(container_id); //以托盘号获取空货位号。
                            if (plGet.place_code != null)
                            {
                                rtn.place_instock = plGet.place_code;
                                int newtaskID = DAL.da_sys_config.GetNewRcdID("taskIDgeneratorIn");
                                rtn.task_num = newtaskID.ToString();
                                #region NEWtaskEntity
                                wms_devices_task nisa = new wms_devices_task
                                {
                                    taskid = newtaskID.ToString(),
                                    taskcode = newtaskID.ToString(),
                                    main_material = "",
                                    do_device = "SRM" + plGet.belong_device,
                                    do_platform = "SRM",
                                    order_from = "",
                                    place_from = in_port_num,
                                    place_to = plGet.place_code, //入库货位
                                    container_id = container_id,
                                    place_from_wcs = "",
                                    place_to_wcs = "",
                                    task_detail_neck = 0,
                                    task_type = "SRM_IN",
                                    task_status = "NEW",
                                    task_batch = "",
                                    t_create = DateTime.Now,
                                    t_update = DateTime.Now,
                                    t_diliver = DateTime.Parse("2000-01-01 00:00:01"),
                                    t_finish = DateTime.Parse("2000-01-01 00:00:01"),
                                    u_create_name = "WCS",
                                    u_create_id = "",
                                    u_update_name = "",
                                    u_update_id = "",
                                    flag_feedback = "N",
                                    flag_delete = false
                                };
                                #endregion

                                if (DAL.da_wms_devices_task.InsertNew(nisa))
                                {
                                    DAL.da_wms_places.InOccupyPlace(newtaskID.ToString(), plGet.place_code);
                                }
                                else
                                {
                                    rtn.error_code = "0009";
                                    rtn.result = false;
                                    rtn.error_message = "WMS生成任务失败，请联系管理员重试。";
                                    rtn.task_num = "";
                                    rtn.place_instock = "";
                                }
                            }
                            else
                            {
                                rtn.error_code = "0006";
                                rtn.result = false;
                                rtn.error_message = plGet.rsv_str1;
                            }
                        }
                        else
                        {
                            var lis = DAL.da_wms_inventory.GetOneByPallet(container_id.Trim());
                            if (lis == null)
                            {
                                rtn.error_code = "0002";
                                rtn.result = false;
                                rtn.error_message = "托盘号没有组盘";
                            }
                            else
                            {
                                var getinTask = DAL.da_wms_devices_task.GetDoingPallet(container_id.Trim(), "SRM_IN");
                                if (getinTask != null) //任务表里有该托盘的未完成任务，直接返回该任务。
                                {
                                    rtn.place_instock = getinTask.place_to;
                                    rtn.task_num = getinTask.taskcode;
                                    rtn.error_message = "入库申请执行处理成功,直接返回已有任务。";
                                    rtn.reserve_field1 = "任务表里有该托盘的未完成任务，直接返回该任务。";
                                    LogHelper.Error(rtn.error_message + rtn.reserve_field1);
                                }
                                else
                                {
                                    if (weight > 500 && weight < 800)
                                    {
                                        var plGet1 = DAL.da_wms_places.PlaceGetOneEmptyByPallet("p_get_in_empty_place_by_pallet_500", container_id); //以托盘号获取空货位号。
                                        if (plGet1 != null)
                                        {
                                            rtn.place_instock = plGet1.place_code;
                                            int newtaskID = DAL.da_sys_config.GetNewRcdID("taskIDgeneratorIn");
                                            rtn.task_num = newtaskID.ToString();
                                            #region NEWtaskEntity
                                            wms_devices_task nisa = new wms_devices_task();

                                            nisa.taskid = newtaskID.ToString();
                                            nisa.taskcode = newtaskID.ToString();
                                            nisa.main_material = "";
                                            nisa.do_device = "SRM" + plGet1.belong_device;
                                            nisa.do_platform = "SRM";
                                            nisa.order_from = "";
                                            nisa.place_from = in_port_num;
                                            nisa.place_to = plGet1.place_code; //入库货位
                                            nisa.container_id = container_id;
                                            nisa.place_from_wcs = "";
                                            nisa.place_to_wcs = "";
                                            nisa.task_detail_neck = 0;
                                            nisa.task_type = "SRM_IN";
                                            nisa.task_status = "NEW";
                                            nisa.task_batch = "";
                                            nisa.t_create = System.DateTime.Now;
                                            nisa.t_update = System.DateTime.Now;
                                            nisa.t_diliver = System.DateTime.Parse("2000-01-01 00:00:01");
                                            nisa.t_finish = System.DateTime.Parse("2000-01-01 00:00:01");
                                            nisa.u_create_name = "WCS";
                                            nisa.u_create_id = "";
                                            nisa.u_update_name = "";
                                            nisa.u_update_id = "";
                                            nisa.flag_feedback = "N";
                                            nisa.flag_delete = false;
                                            #endregion

                                            if (DAL.da_wms_devices_task.InsertNew(nisa))
                                            {
                                                DAL.da_wms_places.InOccupyPlace(newtaskID.ToString(), plGet1.place_code);
                                            }
                                            else
                                            {
                                                rtn.error_code = "0009";
                                                rtn.result = false;
                                                rtn.error_message = "WMS生成任务失败，请联系管理员重试。";
                                                rtn.task_num = "";
                                                rtn.place_instock = "";
                                            }
                                        }
                                        else
                                        {
                                            rtn.error_code = "0006";
                                            rtn.result = false;
                                            rtn.error_message = "库位已满";
                                        }
                                    }
                                    else if (weight > 800 && weight < 1000)
                                    {
                                        var plGet1 = DAL.da_wms_places.PlaceGetOneEmptyByPallet("p_get_in_empty_place_by_pallet_1000", container_id); //以托盘号获取空货位号。
                                        if (plGet1 != null)
                                        {
                                            rtn.place_instock = plGet1.place_code;
                                            int newtaskID = DAL.da_sys_config.GetNewRcdID("taskIDgeneratorIn");
                                            rtn.task_num = newtaskID.ToString();
                                            #region NEWtaskEntity
                                            wms_devices_task nisa = new wms_devices_task();

                                            nisa.taskid = newtaskID.ToString();
                                            nisa.taskcode = newtaskID.ToString();
                                            nisa.main_material = "";
                                            nisa.do_device = "SRM" + plGet1.belong_device;
                                            nisa.do_platform = "SRM";
                                            nisa.order_from = "";
                                            nisa.place_from = in_port_num;
                                            nisa.place_to = plGet1.place_code; //入库货位
                                            nisa.container_id = container_id;
                                            nisa.place_from_wcs = "";
                                            nisa.place_to_wcs = "";
                                            nisa.task_detail_neck = 0;
                                            nisa.task_type = "SRM_IN";
                                            nisa.task_status = "NEW";
                                            nisa.task_batch = "";
                                            nisa.t_create = System.DateTime.Now;
                                            nisa.t_update = System.DateTime.Now;
                                            nisa.t_diliver = System.DateTime.Parse("2000-01-01 00:00:01");
                                            nisa.t_finish = System.DateTime.Parse("2000-01-01 00:00:01");
                                            nisa.u_create_name = "WCS";
                                            nisa.u_create_id = "";
                                            nisa.u_update_name = "";
                                            nisa.u_update_id = "";
                                            nisa.flag_feedback = "N";
                                            nisa.flag_delete = false;
                                            #endregion

                                            if (DAL.da_wms_devices_task.InsertNew(nisa))
                                            {
                                                DAL.da_wms_places.InOccupyPlace(newtaskID.ToString(), plGet1.place_code);
                                            }
                                            else
                                            {
                                                rtn.error_code = "0009";
                                                rtn.result = false;
                                                rtn.error_message = "WMS生成任务失败，请联系管理员重试。";
                                                rtn.task_num = "";
                                                rtn.place_instock = "";
                                            }
                                        }
                                        else
                                        {
                                            rtn.error_code = "0006";
                                            rtn.result = false;
                                            rtn.error_message = "库位已满";
                                        }
                                    }
                                    else if (weight > 1000)
                                    {
                                        rtn.error_code = "0006";
                                        rtn.result = false;
                                        rtn.error_message = "超重！！！！";
                                    }
                                    else
                                    {
                                        if (height_level == "1")
                                        {
                                            //申请外侧低货位
                                            var plGet = DAL.da_wms_places.PlaceGetOneEmptyByPallet("p_get_in_empty_place_by_pallet", container_id); //以托盘号获取空货位号。
                                            if (plGet != null)
                                            {
                                                rtn.place_instock = plGet.place_code;
                                                int newtaskID = DAL.da_sys_config.GetNewRcdID("taskIDgeneratorIn");
                                                rtn.task_num = newtaskID.ToString();
                                                #region NEWtaskEntity
                                                wms_devices_task nisa = new wms_devices_task();

                                                nisa.taskid = newtaskID.ToString();
                                                nisa.taskcode = newtaskID.ToString();
                                                nisa.main_material = "";
                                                nisa.do_device = "SRM" + plGet.belong_device;
                                                nisa.do_platform = "SRM";
                                                nisa.order_from = "";
                                                nisa.place_from = in_port_num;
                                                nisa.place_to = plGet.place_code; //入库货位
                                                nisa.container_id = container_id;
                                                nisa.place_from_wcs = "";
                                                nisa.place_to_wcs = "";
                                                nisa.task_detail_neck = 0;
                                                nisa.task_type = "SRM_IN";
                                                nisa.task_status = "NEW";
                                                nisa.task_batch = "";
                                                nisa.t_create = System.DateTime.Now;
                                                nisa.t_update = System.DateTime.Now;
                                                nisa.t_diliver = System.DateTime.Parse("2000-01-01 00:00:01");
                                                nisa.t_finish = System.DateTime.Parse("2000-01-01 00:00:01");
                                                nisa.u_create_name = "WCS";
                                                nisa.u_create_id = "";
                                                nisa.u_update_name = "";
                                                nisa.u_update_id = "";
                                                nisa.flag_feedback = "N";
                                                nisa.flag_delete = false;
                                                #endregion

                                                if (DAL.da_wms_devices_task.InsertNew(nisa))
                                                {
                                                    DAL.da_wms_places.InOccupyPlace(newtaskID.ToString(), plGet.place_code);
                                                }
                                                else
                                                {
                                                    rtn.error_code = "0009";
                                                    rtn.result = false;
                                                    rtn.error_message = "WMS生成任务失败，请联系管理员重试。";
                                                    rtn.task_num = "";
                                                    rtn.place_instock = "";
                                                }
                                            }
                                            else
                                            {
                                                //申请内侧低货位
                                                plGet = DAL.da_wms_places.PlaceGetOneEmptyByPallet("p_get_in_empty_place_by_pallet_neice", container_id); //以托盘号获取空货位号。
                                                if (plGet != null)
                                                {
                                                    rtn.place_instock = plGet.place_code;
                                                    int newtaskID = DAL.da_sys_config.GetNewRcdID("taskIDgeneratorIn");
                                                    rtn.task_num = newtaskID.ToString();
                                                    #region NEWtaskEntity
                                                    wms_devices_task nisa = new wms_devices_task();

                                                    nisa.taskid = newtaskID.ToString();
                                                    nisa.taskcode = newtaskID.ToString();
                                                    nisa.main_material = "";
                                                    nisa.do_device = "SRM" + plGet.belong_device;
                                                    nisa.do_platform = "SRM";
                                                    nisa.order_from = "";
                                                    nisa.place_from = in_port_num;
                                                    nisa.place_to = plGet.place_code; //入库货位
                                                    nisa.container_id = container_id;
                                                    nisa.place_from_wcs = "";
                                                    nisa.place_to_wcs = "";
                                                    nisa.task_detail_neck = 0;
                                                    nisa.task_type = "SRM_IN";
                                                    nisa.task_status = "NEW";
                                                    nisa.task_batch = "";
                                                    nisa.t_create = System.DateTime.Now;
                                                    nisa.t_update = System.DateTime.Now;
                                                    nisa.t_diliver = System.DateTime.Parse("2000-01-01 00:00:01");
                                                    nisa.t_finish = System.DateTime.Parse("2000-01-01 00:00:01");
                                                    nisa.u_create_name = "WCS";
                                                    nisa.u_create_id = "";
                                                    nisa.u_update_name = "";
                                                    nisa.u_update_id = "";
                                                    nisa.flag_feedback = "N";
                                                    nisa.flag_delete = false;
                                                    #endregion

                                                    if (DAL.da_wms_devices_task.InsertNew(nisa))
                                                    {
                                                        DAL.da_wms_places.InOccupyPlace(newtaskID.ToString(), plGet.place_code);
                                                    }
                                                    else
                                                    {
                                                        rtn.error_code = "0009";
                                                        rtn.result = false;
                                                        rtn.error_message = "WMS生成任务失败，请联系管理员重试。";
                                                        rtn.task_num = "";
                                                        rtn.place_instock = "";
                                                    }
                                                }
                                                else
                                                {
                                                    //申请外侧高货位
                                                    plGet = DAL.da_wms_places.PlaceGetOneEmptyByPallet("p_get_in_empty_place_by_pallet_waiceG", container_id); //以托盘号获取空货位号。
                                                    if (plGet != null)
                                                    {
                                                        rtn.place_instock = plGet.place_code;
                                                        int newtaskID = DAL.da_sys_config.GetNewRcdID("taskIDgeneratorIn");
                                                        rtn.task_num = newtaskID.ToString();
                                                        #region NEWtaskEntity
                                                        wms_devices_task nisa = new wms_devices_task();

                                                        nisa.taskid = newtaskID.ToString();
                                                        nisa.taskcode = newtaskID.ToString();
                                                        nisa.main_material = "";
                                                        nisa.do_device = "SRM" + plGet.belong_device;
                                                        nisa.do_platform = "SRM";
                                                        nisa.order_from = "";
                                                        nisa.place_from = in_port_num;
                                                        nisa.place_to = plGet.place_code; //入库货位
                                                        nisa.container_id = container_id;
                                                        nisa.place_from_wcs = "";
                                                        nisa.place_to_wcs = "";
                                                        nisa.task_detail_neck = 0;
                                                        nisa.task_type = "SRM_IN";
                                                        nisa.task_status = "NEW";
                                                        nisa.task_batch = "";
                                                        nisa.t_create = System.DateTime.Now;
                                                        nisa.t_update = System.DateTime.Now;
                                                        nisa.t_diliver = System.DateTime.Parse("2000-01-01 00:00:01");
                                                        nisa.t_finish = System.DateTime.Parse("2000-01-01 00:00:01");
                                                        nisa.u_create_name = "WCS";
                                                        nisa.u_create_id = "";
                                                        nisa.u_update_name = "";
                                                        nisa.u_update_id = "";
                                                        nisa.flag_feedback = "N";
                                                        nisa.flag_delete = false;
                                                        #endregion

                                                        if (DAL.da_wms_devices_task.InsertNew(nisa))
                                                        {
                                                            DAL.da_wms_places.InOccupyPlace(newtaskID.ToString(), plGet.place_code);
                                                        }
                                                        else
                                                        {
                                                            rtn.error_code = "0009";
                                                            rtn.result = false;
                                                            rtn.error_message = "WMS生成任务失败，请联系管理员重试。";
                                                            rtn.task_num = "";
                                                            rtn.place_instock = "";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //申请内侧高货位
                                                        plGet = DAL.da_wms_places.PlaceGetOneEmptyByPallet("p_get_in_empty_place_by_pallet_neiceG", container_id); //以托盘号获取空货位号。
                                                        if (plGet != null)
                                                        {
                                                            rtn.place_instock = plGet.place_code;
                                                            int newtaskID = DAL.da_sys_config.GetNewRcdID("taskIDgeneratorIn");
                                                            rtn.task_num = newtaskID.ToString();
                                                            #region NEWtaskEntity
                                                            wms_devices_task nisa = new wms_devices_task();

                                                            nisa.taskid = newtaskID.ToString();
                                                            nisa.taskcode = newtaskID.ToString();
                                                            nisa.main_material = "";
                                                            nisa.do_device = "SRM" + plGet.belong_device;
                                                            nisa.do_platform = "SRM";
                                                            nisa.order_from = "";
                                                            nisa.place_from = in_port_num;
                                                            nisa.place_to = plGet.place_code; //入库货位
                                                            nisa.container_id = container_id;
                                                            nisa.place_from_wcs = "";
                                                            nisa.place_to_wcs = "";
                                                            nisa.task_detail_neck = 0;
                                                            nisa.task_type = "SRM_IN";
                                                            nisa.task_status = "NEW";
                                                            nisa.task_batch = "";
                                                            nisa.t_create = System.DateTime.Now;
                                                            nisa.t_update = System.DateTime.Now;
                                                            nisa.t_diliver = System.DateTime.Parse("2000-01-01 00:00:01");
                                                            nisa.t_finish = System.DateTime.Parse("2000-01-01 00:00:01");
                                                            nisa.u_create_name = "WCS";
                                                            nisa.u_create_id = "";
                                                            nisa.u_update_name = "";
                                                            nisa.u_update_id = "";
                                                            nisa.flag_feedback = "N";
                                                            nisa.flag_delete = false;
                                                            #endregion

                                                            if (DAL.da_wms_devices_task.InsertNew(nisa))
                                                            {
                                                                DAL.da_wms_places.InOccupyPlace(newtaskID.ToString(), plGet.place_code);
                                                            }
                                                            else
                                                            {
                                                                rtn.error_code = "0009";
                                                                rtn.result = false;
                                                                rtn.error_message = "WMS生成任务失败，请联系管理员重试。";
                                                                rtn.task_num = "";
                                                                rtn.place_instock = "";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            rtn.error_code = "0006";
                                                            rtn.result = false;
                                                            rtn.error_message = "库位已满";
                                                        }
                                                    }

                                                }

                                            }
                                        }//正常入库
                                        else if (height_level == "4")
                                        {
                                            var plGet = DAL.da_wms_places.PlaceGetOneEmptyByPallet1(container_id); //以托盘号获取空货位号。
                                            if (plGet != null)
                                            {
                                                rtn.place_instock = plGet.place_code;
                                                int newtaskID = DAL.da_sys_config.GetNewRcdID("taskIDgeneratorIn");
                                                rtn.task_num = newtaskID.ToString();
                                                #region NEWtaskEntity
                                                wms_devices_task nisa = new wms_devices_task();

                                                nisa.taskid = newtaskID.ToString();
                                                nisa.taskcode = newtaskID.ToString();
                                                nisa.main_material = "";
                                                nisa.do_device = "SRM" + plGet.belong_device;
                                                nisa.do_platform = "SRM";
                                                nisa.order_from = "";
                                                nisa.place_from = in_port_num;
                                                nisa.place_to = plGet.place_code; //入库货位
                                                nisa.container_id = container_id;
                                                nisa.place_from_wcs = "";
                                                nisa.place_to_wcs = "";
                                                nisa.task_detail_neck = 0;
                                                nisa.task_type = "SRM_IN";
                                                nisa.task_status = "NEW";
                                                nisa.task_batch = "";
                                                nisa.t_create = System.DateTime.Now;
                                                nisa.t_update = System.DateTime.Now;
                                                nisa.t_diliver = System.DateTime.Parse("2000-01-01 00:00:01");
                                                nisa.t_finish = System.DateTime.Parse("2000-01-01 00:00:01");
                                                nisa.u_create_name = "WCS";
                                                nisa.u_create_id = "";
                                                nisa.u_update_name = "";
                                                nisa.u_update_id = "";
                                                nisa.flag_feedback = "N";
                                                nisa.flag_delete = false;
                                                #endregion

                                                if (DAL.da_wms_devices_task.InsertNew(nisa))
                                                {
                                                    DAL.da_wms_places.InOccupyPlace(newtaskID.ToString(), plGet.place_code);
                                                }
                                                else
                                                {
                                                    rtn.error_code = "0009";
                                                    rtn.result = false;
                                                    rtn.error_message = "WMS生成任务失败，请联系管理员重试。";
                                                    rtn.task_num = "";
                                                    rtn.place_instock = "";
                                                }
                                            }
                                            else
                                            {
                                                //申请内侧高货位
                                                plGet = DAL.da_wms_places.PlaceGetOneEmptyByPallet("p_get_in_empty_place_by_pallet_neiceG", container_id); //以托盘号获取空货位号。
                                                if (plGet != null)
                                                {
                                                    rtn.place_instock = plGet.place_code;
                                                    int newtaskID = DAL.da_sys_config.GetNewRcdID("taskIDgeneratorIn");
                                                    rtn.task_num = newtaskID.ToString();
                                                    #region NEWtaskEntity
                                                    wms_devices_task nisa = new wms_devices_task();

                                                    nisa.taskid = newtaskID.ToString();
                                                    nisa.taskcode = newtaskID.ToString();
                                                    nisa.main_material = "";
                                                    nisa.do_device = "SRM" + plGet.belong_device;
                                                    nisa.do_platform = "SRM";
                                                    nisa.order_from = "";
                                                    nisa.place_from = in_port_num;
                                                    nisa.place_to = plGet.place_code; //入库货位
                                                    nisa.container_id = container_id;
                                                    nisa.place_from_wcs = "";
                                                    nisa.place_to_wcs = "";
                                                    nisa.task_detail_neck = 0;
                                                    nisa.task_type = "SRM_IN";
                                                    nisa.task_status = "NEW";
                                                    nisa.task_batch = "";
                                                    nisa.t_create = System.DateTime.Now;
                                                    nisa.t_update = System.DateTime.Now;
                                                    nisa.t_diliver = System.DateTime.Parse("2000-01-01 00:00:01");
                                                    nisa.t_finish = System.DateTime.Parse("2000-01-01 00:00:01");
                                                    nisa.u_create_name = "WCS";
                                                    nisa.u_create_id = "";
                                                    nisa.u_update_name = "";
                                                    nisa.u_update_id = "";
                                                    nisa.flag_feedback = "N";
                                                    nisa.flag_delete = false;
                                                    #endregion

                                                    if (DAL.da_wms_devices_task.InsertNew(nisa))
                                                    {
                                                        DAL.da_wms_places.InOccupyPlace(newtaskID.ToString(), plGet.place_code);
                                                    }
                                                    else
                                                    {
                                                        rtn.error_code = "0009";
                                                        rtn.result = false;
                                                        rtn.error_message = "WMS生成任务失败，请联系管理员重试。";
                                                        rtn.task_num = "";
                                                        rtn.place_instock = "";
                                                    }
                                                }
                                                else
                                                {
                                                    rtn.error_code = "0006";
                                                    rtn.result = false;
                                                    rtn.error_message = "库位已满";
                                                }
                                            }
                                        }//超高货位申请
                                        else if (height_level == "7")
                                        {
                                            var plGet = DAL.da_wms_places.PlaceGetOneEmptyByPallet2(container_id); //以托盘号获取空货位号。
                                            if (plGet != null)
                                            {
                                                rtn.place_instock = plGet.place_code;
                                                int newtaskID = DAL.da_sys_config.GetNewRcdID("taskIDgeneratorIn");
                                                rtn.task_num = newtaskID.ToString();
                                                #region NEWtaskEntity
                                                wms_devices_task nisa = new wms_devices_task();

                                                nisa.taskid = newtaskID.ToString();
                                                nisa.taskcode = newtaskID.ToString();
                                                nisa.main_material = "";
                                                nisa.do_device = "SRM" + plGet.belong_device;
                                                nisa.do_platform = "SRM";
                                                nisa.order_from = "";
                                                nisa.place_from = in_port_num;
                                                nisa.place_to = plGet.place_code; //入库货位
                                                nisa.container_id = container_id;
                                                nisa.place_from_wcs = "";
                                                nisa.place_to_wcs = "";
                                                nisa.task_detail_neck = 0;
                                                nisa.task_type = "SRM_IN";
                                                nisa.task_status = "NEW";
                                                nisa.task_batch = "";
                                                nisa.t_create = System.DateTime.Now;
                                                nisa.t_update = System.DateTime.Now;
                                                nisa.t_diliver = System.DateTime.Parse("2000-01-01 00:00:01");
                                                nisa.t_finish = System.DateTime.Parse("2000-01-01 00:00:01");
                                                nisa.u_create_name = "WCS";
                                                nisa.u_create_id = "";
                                                nisa.u_update_name = "";
                                                nisa.u_update_id = "";
                                                nisa.flag_feedback = "N";
                                                nisa.flag_delete = false;
                                                #endregion

                                                if (DAL.da_wms_devices_task.InsertNew(nisa))
                                                {
                                                    DAL.da_wms_places.InOccupyPlace(newtaskID.ToString(), plGet.place_code);
                                                }
                                                else
                                                {
                                                    rtn.error_code = "0009";
                                                    rtn.result = false;
                                                    rtn.error_message = "WMS生成任务失败，请联系管理员重试。";
                                                    rtn.task_num = "";
                                                    rtn.place_instock = "";
                                                }
                                            }
                                            else
                                            {
                                                rtn.error_code = "0006";
                                                rtn.result = false;
                                                rtn.error_message = "库位已满";
                                            }
                                        }//单独去4号机，叠盘机申请
                                    }
                                }
                            }
                        }
                       
                      
                    } 
                }
                rtn.pallet_wrapping = false;  //默认不缠膜 
                rtn.reserve_field1 = "";
                rtn.reserve_field2 = "";
                rtn.reserve_field3 = "";
                rtn.reserve_field4 = "";
                rtn.reserve_field5 = "";
                 

            }
            catch (Exception exc)
            {
                LogHelper.Error("WCS入库申请库位接口遇到错误："+exc.Message+"\r\n"+exc.StackTrace);
            }


            return rtn;
        }
         
        /// <summary>
        /// WCS向堆垛机发送任务成功通知WMS
        /// </summary>
        /// <param name="ask_num">请求号</param>
        /// <param name="task_num">任务号</param>
        /// <param name="container_id">容器号（托盘/箱号）</param>
        /// <param name="srm_num">堆垛机编号</param>
        /// <param name="laneway">巷道号</param>
        /// <param name="task_type">出入库任务类型，IN入库，OUT出库,TRANSFER移库</param>
        /// <param name="place_from">起始位置</param>
        /// <param name="place_to">目标位置</param>
        /// <param name="place_from2">起始位置2</param>
        /// <param name="place_to2">目标位置2</param>
        /// <returns></returns>
        [WebMethod(Description = "WCS向堆垛机发送任务成功通知WMS")]
        public WCS_Ask_Result SRM_TaskDeliverNotice(string ask_num, string task_num, string container_id, string srm_num, string laneway, string task_type, string place_from, string place_to, string place_from2, string place_to2)
        {
            LogHelper.Info("WCS调用一次发送堆垛机任务下达通知接口：" + ask_num + " >container_id：" + container_id + " >task_num：" + task_num + " >srm_num：" + srm_num + " >laneway：" + laneway + " >task_type：" + task_type + " >place_from：" + place_from + " >place_to：" + place_to + " >place_from2：" + place_from2 + " >place_to2 ：" + place_to2);

            WCS_Ask_Result rtn = new WCS_Ask_Result();
            rtn.ask_num = ask_num;
            rtn.result = true;
            rtn.error_code = "0000";
            rtn.error_message = "堆垛机任务下发通知，接收成功";
            rtn.pallet_wrapping = false;
            rtn.place_instock = "";
            rtn.sorting_port = "";
            rtn.task_num = task_num;
            rtn.reserve_field1 = "";
            rtn.reserve_field2 = "";
            rtn.reserve_field3 = "";
            rtn.reserve_field4 = "";
            rtn.reserve_field5 = "";
            try
            {
                var deviceTask = DAL.da_wms_devices_task.GetOneByTaskCode(task_num);
                if (deviceTask != null)
                {
                    if (deviceTask.container_id == container_id.Trim())
                    {
                        switch (deviceTask.task_type.ToString())
                        {
                            case "SRM_IN":
                                var find_in = DAL.da_wms_places.GetOneByCode(deviceTask.place_to);
                                if (find_in != null)
                                {
                                    //入库的目的位是空的可以放货
                                    if (find_in.is_empty  == "Y")
                                    {
                                        //近叉直接执行                                   
                                        if (find_in.rsv_str3 == "first")
                                        {              
                                            deviceTask.task_status = "DOING";
                                            rtn.place_instock = deviceTask.place_from.ToString();
                                            rtn.sorting_port = deviceTask.place_to.ToString();                        
                                            var updateSuss_out = DAL.da_wms_devices_task.UpdateOne(deviceTask);
                                            if (updateSuss_out == false)
                                            {
                                                LogHelper.Info("入库任务堆垛机反馈接口 更新堆垛机任务下达状态失败！任务号：" + deviceTask.taskcode);
                                            }
                                        }
                                        else
                                        {
                                            //远叉位置（判断近叉位置）
                                            var deviceTask_place = DAL.da_wms_places.GetOneByCode(find_in.code_mes.ToString());
                                            if (deviceTask_place != null)
                                            {
                                                //近叉位置为空，远叉任务执行
                                                if (deviceTask_place.is_empty == "Y")
                                                {
                                                    deviceTask.task_status = "DOING";
                                                    rtn.place_instock = deviceTask.place_from.ToString();
                                                    rtn.sorting_port = deviceTask.place_to.ToString();
                                                    var updateSuss_out = DAL.da_wms_devices_task.UpdateOne(deviceTask);
                                                    if (updateSuss_out == false)
                                                    {
                                                        LogHelper.Info("入库任务堆垛机反馈接口 更新堆垛机任务下达状态失败！任务号：" + deviceTask.taskcode);
                                                    }
                                                }
                                                else
                                                {
                                                    //近叉位置有货，需要移库任务
                                                    var find_place = DAL.da_wms_places.SelectSeq(deviceTask_place.numb_lane, "second", deviceTask_place.rsv_str4);
                                                    if (find_place != null)
                                                    {
                                                        if (DAL.Da_wms_to_wcs_task.Wms_to_wcs_task_TRANSFER(deviceTask_place.place_code, find_place.place_code.ToString(), deviceTask_place.pallet_container, deviceTask_place.numb_lane.ToString()))
                                                        {
                                                            rtn.result = false;
                                                            rtn.error_code = "545";
                                                            rtn.error_message = "需要优先执行移库任务";
                                                        }
                                                        else
                                                        {
                                                            rtn.result = false;
                                                            rtn.error_code = "565";
                                                            rtn.error_message = "调用WCS移库任务接口失败！";
                                                        }

                                                    }
                                                    else
                                                    {
                                                        find_place = DAL.da_wms_places.SelectSeq(deviceTask_place.numb_lane, "first", deviceTask_place.rsv_str4);
                                                        if (find_place != null)
                                                        {
                                                            if (DAL.Da_wms_to_wcs_task.Wms_to_wcs_task_TRANSFER(deviceTask_place.place_code, find_place.place_code.ToString(), deviceTask_place.pallet_container, deviceTask_place.numb_lane.ToString()))
                                                            {
                                                                rtn.result = false;
                                                                rtn.error_code = "545";
                                                                rtn.error_message = "需要优先执行移库任务";
                                                            }
                                                            else
                                                            {
                                                                rtn.result = false;
                                                                rtn.error_code = "565";
                                                                rtn.error_message = "调用WCS移库任务接口失败！";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (deviceTask_place.rsv_str4 == "danshu")
                                                            {
                                                                //没有符合要求的货位
                                                                rtn.result = false;
                                                                rtn.error_code = "575";
                                                                rtn.error_message = "移库任务没有高层目的位";

                                                            }
                                                            else
                                                            {
                                                                find_place = DAL.da_wms_places.SelectSeq(deviceTask_place.numb_lane, "second", "danshu");
                                                                if (find_place != null)
                                                                {
                                                                    if (DAL.Da_wms_to_wcs_task.Wms_to_wcs_task_TRANSFER(deviceTask_place.place_code, find_place.place_code.ToString(), deviceTask_place.pallet_container, deviceTask_place.numb_lane.ToString()))
                                                                    {
                                                                        rtn.result = false;
                                                                        rtn.error_code = "545";
                                                                        rtn.error_message = "需要优先执行移库任务";
                                                                    }
                                                                    else
                                                                    {
                                                                        rtn.result = false;
                                                                        rtn.error_code = "565";
                                                                        rtn.error_message = "调用WCS移库任务接口失败！";
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    find_place = DAL.da_wms_places.SelectSeq(deviceTask_place.numb_lane, "first", "danshu");
                                                                    if (find_place != null)
                                                                    {
                                                                        if (DAL.Da_wms_to_wcs_task.Wms_to_wcs_task_TRANSFER(deviceTask_place.place_code, find_place.place_code.ToString(), deviceTask_place.pallet_container, deviceTask_place.numb_lane.ToString()))
                                                                        {
                                                                            rtn.result = false;
                                                                            rtn.error_code = "545";
                                                                            rtn.error_message = "需要优先执行移库任务";
                                                                        }
                                                                        else
                                                                        {
                                                                            rtn.result = false;
                                                                            rtn.error_code = "565";
                                                                            rtn.error_message = "调用WCS移库任务接口失败！";
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        //没有符合要求的货位
                                                                        rtn.result = false;
                                                                        rtn.error_code = "575";
                                                                        rtn.error_message = deviceTask_place.numb_lane + "号堆垛机移库任务没有目的位";
                                                                    }

                                                                }


                                                            }


                                                        }

                                                    }

                                                }

                                            }
                                            else
                                            {
                                                rtn.result = false;
                                                rtn.error_code = "0012";
                                                rtn.error_message = "没有找到该条码的入库位置相关联的货位！";


                                            }

                                        }
                                    }
                                    else
                                    {
                                        //入库的目的位有货，重新分配货位
                                        rtn.result = true;
                                        var find_place = DAL.da_wms_places.SelectSeq(find_in.numb_lane, "second", find_in.rsv_str4);
                                        if (find_place != null)
                                        {
                                            deviceTask.task_status = "DOING";
                                            rtn.place_instock = deviceTask.place_from.ToString();
                                            rtn.sorting_port = find_place.place_code.ToString();
                                            deviceTask.place_to = find_place.place_code.ToString();
                                            DAL.da_wms_places.InOccupyPlace(deviceTask.taskcode.ToString(), find_place.place_code.ToString());
                                            var updateSuss_out = DAL.da_wms_devices_task.UpdateOne(deviceTask);
                                            if (updateSuss_out == false)
                                            {
                                                LogHelper.Info("入库任务堆垛机反馈接口 更新堆垛机任务下达状态失败！任务号：" + deviceTask.taskcode);
                                            }
                                        }
                                        else
                                        {
                                            find_place = DAL.da_wms_places.SelectSeq(find_in.numb_lane, "first", find_in.rsv_str4);
                                            if (find_place != null)
                                            {
                                                deviceTask.task_status = "DOING";
                                                rtn.place_instock = deviceTask.place_from.ToString();
                                                rtn.sorting_port = find_place.place_code.ToString();
                                                deviceTask.place_to = find_place.place_code.ToString();
                                                DAL.da_wms_places.InOccupyPlace(deviceTask.taskcode.ToString(), find_place.place_code.ToString());
                                                var updateSuss_out = DAL.da_wms_devices_task.UpdateOne(deviceTask);
                                                if (updateSuss_out == false)
                                                {
                                                    LogHelper.Info("入库任务堆垛机反馈接口 更新堆垛机任务下达状态失败！任务号：" + deviceTask.taskcode);
                                                }
                                            }
                                            else
                                            {
                                                if (find_in.rsv_str4 == "danshu")
                                                {
                                                    rtn.result = false;
                                                    rtn.error_code = "006";
                                                    rtn.error_message = find_in.numb_lane +"号堆垛机没有能够重新分配的高层货位";
                                                }
                                                else
                                                {
                                                    find_place = DAL.da_wms_places.SelectSeq(find_in.numb_lane, "second", "danshu");
                                                    if (find_place != null)
                                                    {
                                                        deviceTask.task_status = "DOING";
                                                        rtn.place_instock = deviceTask.place_from.ToString();
                                                        rtn.sorting_port = find_place.place_code.ToString();
                                                        deviceTask.place_to = find_place.place_code.ToString();
                                                        DAL.da_wms_places.InOccupyPlace(deviceTask.taskcode.ToString(), find_place.place_code.ToString());
                                                        var updateSuss_out = DAL.da_wms_devices_task.UpdateOne(deviceTask);
                                                        if (updateSuss_out == false)
                                                        {
                                                            LogHelper.Info("入库任务堆垛机反馈接口 更新堆垛机任务下达状态失败！任务号：" + deviceTask.taskcode);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        find_place = DAL.da_wms_places.SelectSeq(find_in.numb_lane, "first", "danshu");
                                                        if (find_place != null)
                                                        {
                                                            deviceTask.task_status = "DOING";
                                                            rtn.place_instock = deviceTask.place_from.ToString();
                                                            rtn.sorting_port = find_place.place_code.ToString();
                                                            deviceTask.place_to = find_place.place_code.ToString();
                                                            DAL.da_wms_places.InOccupyPlace(deviceTask.taskcode.ToString(), find_place.place_code.ToString());
                                                            var updateSuss_out = DAL.da_wms_devices_task.UpdateOne(deviceTask);
                                                            if (updateSuss_out == false)
                                                            {
                                                                LogHelper.Info("入库任务堆垛机反馈接口 更新堆垛机任务下达状态失败！任务号：" + deviceTask.taskcode);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            rtn.result = false;
                                                            rtn.error_code = "006";
                                                            rtn.error_message = find_in.numb_lane + "号堆垛机没有能够重新分配的货位";
                                                        }
                                                    }


                                                }



                                            }
                                        }





                                        //deviceTask.task_status = "DOING";
                                        //rtn.place_instock = find_in.place_code.ToString();
                                        //rtn.sorting_port = deviceTask.place_to.ToString();
                                        //deviceTask.place_from = find_in.place_code.ToString();
                                        //var updateSuss_out = DAL.da_wms_devices_task.UpdateOne(deviceTask);
                                        //if (updateSuss_out == false)
                                        //{
                                        //    LogHelper.Info("出库完成堆垛机反馈接口 更新堆垛机任务下达状态失败！任务号：" + task_num);
                                        //}
                                    }

                                }
                                else
                                {
                                    rtn.result = false;
                                    rtn.error_code = "0012";
                                    rtn.error_message = "没有找到该条码的入库位置！";
                                }

                                break;

                            case "SRM_OUT":
                                var find_inStock = DAL.da_wms_places.GetOneByPallet(container_id.Trim());
                                if (find_inStock != null)
                                {
                                    if (find_inStock.rsv_str3 == "second")
                                    {
                                        var find = DAL.da_wms_places.GetOneByCode(find_inStock.code_mes.ToString());
                                        if (find.is_empty == "Y")
                                        {
                                            //关联库位是空
                                            deviceTask.task_status = "DOING";
                                            rtn.place_instock = find_inStock.place_code.ToString();
                                            rtn.sorting_port = deviceTask.place_to.ToString();
                                            deviceTask.place_from = find_inStock.place_code.ToString();
                                            var updateSuss_out = DAL.da_wms_devices_task.UpdateOne(deviceTask);
                                            if (updateSuss_out == false)
                                            {
                                                LogHelper.Info("出库任务堆垛机反馈接口 更新堆垛机任务下达状态失败！任务号：" + task_num);
                                            }
                                        }
                                        else
                                        {
                                            //确认关联库位有没有任务
                                            var deviceTask_place = DAL.da_wms_devices_task.GetOneByTargetPlace_from(find_inStock.code_mes.ToString());
                                            if (deviceTask_place != null)
                                            {
                                                //有任务，优先执行
                                                rtn.result = false;
                                                rtn.error_code = "545";
                                                rtn.error_message = "优先执行内侧任务！";
                                                rtn.place_instock = deviceTask_place.place_from.ToString();
                                                rtn.task_num = deviceTask_place.taskcode.ToString();
                                                rtn.sorting_port = deviceTask_place.place_to.ToString();
                                                if (rtn.task_num.StartsWith("2"))
                                                {
                                                    rtn.error_code = "545320";
                                                    deviceTask = DAL.da_wms_devices_task.GetOneByTaskCode(rtn.task_num);
                                                    deviceTask.task_status = "DOING";
                                                    deviceTask.place_from = rtn.place_instock.ToString();
                                                    var updateSuss_out = DAL.da_wms_devices_task.UpdateOne(deviceTask);
                                                    if (updateSuss_out == false)
                                                    {
                                                        LogHelper.Info("出库完成堆垛机反馈接口 更新堆垛机任务下达状态失败！任务号：" + rtn.task_num);
                                                    }

                                                }
                                            }
                                            else
                                            {
                                                //调用移库接口
                                                var find_place = DAL.da_wms_places.SelectSeq(find.numb_lane, "second", find.rsv_str4);
                                                if (find_place != null)
                                                {
                                                    if (DAL.Da_wms_to_wcs_task.Wms_to_wcs_task_TRANSFER(find.place_code, find_place.place_code.ToString(), find.pallet_container, find.numb_lane.ToString()))
                                                    {
                                                        rtn.result = false;
                                                        rtn.error_code = "545";
                                                        rtn.error_message = "需要优先执行移库任务";
                                                    }
                                                    else
                                                    {
                                                        rtn.result = false;
                                                        rtn.error_code = "565";
                                                        rtn.error_message = "调用WCS移库任务接口失败！";
                                                    }
                                                }
                                                else
                                                {
                                                    find_place = DAL.da_wms_places.SelectSeq(find.numb_lane, "first", find.rsv_str4);
                                                    if (find_place != null)
                                                    {
                                                        if (DAL.Da_wms_to_wcs_task.Wms_to_wcs_task_TRANSFER(find.place_code, find_place.place_code.ToString(), find.pallet_container, find.numb_lane.ToString()))
                                                        {
                                                            rtn.result = false;
                                                            rtn.error_code = "545";
                                                            rtn.error_message = "需要优先执行移库任务";
                                                        }
                                                        else
                                                        {
                                                            rtn.result = false;
                                                            rtn.error_code = "565";
                                                            rtn.error_message = "调用WCS移库任务接口失败！";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (find.rsv_str4 == "danshu")
                                                        {
                                                            //没有符合要求的货位
                                                            rtn.result = false;
                                                            rtn.error_code = "575";
                                                            rtn.error_message = "移库任务没有目的位";

                                                        }
                                                        else
                                                        {
                                                            find_place = DAL.da_wms_places.SelectSeq(find.numb_lane, "second", "danshu");
                                                            if (find_place != null)
                                                            {
                                                                if (DAL.Da_wms_to_wcs_task.Wms_to_wcs_task_TRANSFER(find.place_code, find_place.place_code.ToString(), find.pallet_container, find.numb_lane.ToString()))
                                                                {
                                                                    rtn.result = false;
                                                                    rtn.error_code = "545";
                                                                    rtn.error_message = "需要优先执行移库任务";
                                                                }
                                                                else
                                                                {
                                                                    rtn.result = false;
                                                                    rtn.error_code = "565";
                                                                    rtn.error_message = "调用WCS移库任务接口失败！";
                                                                }
                                                            }
                                                            else
                                                            {
                                                                find_place = DAL.da_wms_places.SelectSeq(find.numb_lane, "first", "danshu");
                                                                if (find_place != null)
                                                                {
                                                                    if (DAL.Da_wms_to_wcs_task.Wms_to_wcs_task_TRANSFER(find.place_code, find_place.place_code.ToString(), find.pallet_container, find.numb_lane.ToString()))
                                                                    {
                                                                        rtn.result = false;
                                                                        rtn.error_code = "545";
                                                                        rtn.error_message = "需要优先执行移库任务";
                                                                    }
                                                                    else
                                                                    {
                                                                        rtn.result = false;
                                                                        rtn.error_code = "565";
                                                                        rtn.error_message = "调用WCS移库任务接口失败！";
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    //没有符合要求的货位
                                                                    rtn.result = false;
                                                                    rtn.error_code = "575";
                                                                    rtn.error_message = "移库任务没有目的位";
                                                                }

                                                            }


                                                        }


                                                    }

                                                }
                                            }

                                        }
                                    }
                                    else
                                    {
                                        deviceTask.task_status = "DOING";
                                        rtn.place_instock = find_inStock.place_code.ToString();
                                        rtn.sorting_port = deviceTask.place_to.ToString();
                                        deviceTask.place_from = find_inStock.place_code.ToString();
                                        var updateSuss_out = DAL.da_wms_devices_task.UpdateOne(deviceTask);
                                        if (updateSuss_out == false)
                                        {
                                            LogHelper.Info("出库完成堆垛机反馈接口 更新堆垛机任务下达状态失败！任务号：" + task_num);
                                        }
                                    }

                                }
                                else
                                {
                                    rtn.result = false;
                                    rtn.error_code = "0012";
                                    rtn.error_message = "没有找到该条码的库存位置！";
                                }
                              
                                break;

                            case "SRM_TO":
                                deviceTask.task_status = "DOING";
                                var updateSus_TO = DAL.da_wms_devices_task.UpdateOne(deviceTask);
                                if (updateSus_TO == false)
                                {
                                    LogHelper.Info("移库任务堆垛机反馈接口 更新堆垛机任务下达状态失败！任务号：" + task_num);
                                }
                                break;

                            default:
                                break;
                        }
                    }
                    else
                    {
                        rtn.result = false;
                        rtn.error_code = "0011";
                        rtn.error_message = "托盘号不符合记录！";
                    }

                    //deviceTask.task_status = "DOING";
                    //var updateSuss =  DAL.da_wms_devices_task.UpdateOne(deviceTask);
                    //if (updateSuss == false)
                    //{
                    //    LogHelper.Info("入库完成堆垛机反馈接口 更新堆垛机任务下达状态失败！任务号："+ task_num);
                    //}
                }
                else
                {
                    rtn.result = false;
                    rtn.error_code = "0010";
                    rtn.error_message = "无此任务号！无法更新任务状态";
                }
            }
            catch (Exception exc)
            {
                rtn.result = false;
                rtn.error_code = "0009";
                rtn.error_message = "未知错误："+ exc.Message;
                LogHelper.Error("入库完成堆垛机反馈接口错误：" + exc.Message + "\r\n" + exc.StackTrace);
            }
            return rtn;

        }

        /// <summary>
        /// 堆垛机入库完成，WCS通知WMS
        /// </summary>
        /// <param name="ask_num">请求号</param>
        /// <param name="container_id">容器号（托盘/料箱）</param>
        /// <param name="task_num">入库完成的堆垛机任务号</param>
        /// <param name="srm_num">堆垛机编号</param>
        /// <param name="laneway">巷道号</param>
        /// <returns></returns>
        [WebMethod(Description = "堆垛机入库完成，WCS通知WMS")]
        public WCS_Ask_Result SRMContainerInFinished(string ask_num, string container_id, string task_num,string srm_num, string laneway)
        {
            LogHelper.Info("WCS调用一次 堆垛机入库完成 接口：" + ask_num + " >container_id：" + container_id + " >task_num：" + task_num + " >srm_num：" + srm_num + " >laneway：" + laneway  );
             
            WCS_Ask_Result rtn = new WCS_Ask_Result();
            rtn.ask_num = ask_num;
            rtn.result = true;
            rtn.error_code = "0000";
            rtn.error_message = "接收“入库库完成通知”成功";
            rtn.pallet_wrapping = false;
            rtn.place_instock = "";
            rtn.sorting_port = "";
            rtn.task_num = task_num;
            rtn.reserve_field1 = "";
            rtn.reserve_field2 = "";
            rtn.reserve_field3 = "";
            rtn.reserve_field4 = "";
            rtn.reserve_field5 = "";

            try
            {
              
                var taskGet = DAL.da_wms_devices_task.GetOneByTaskCode(task_num); //根据任务号获取 （目标地址）
                if (taskGet != null) 
                {
                    if (taskGet.task_type != "SRM_IN")
                    {
                        rtn.result = false;
                        rtn.error_code = "0010";
                        rtn.error_message = "此任务号不是入库任务号！无法完成";
                    }
                    else
                    {
                        var ss = DAL.da_wms_places.InFinishUpdate(task_num, taskGet.place_to, container_id);
                        if (ss != "S")
                        {
                            rtn.result = false;
                            rtn.error_code = "0009";
                            rtn.error_message = "执行存储过程遇到 未知错误未成功。";
                        } 
                    } 
                }
                else
                {
                    rtn.result = false;
                    rtn.error_code = "0010";
                    rtn.error_message = "无此任务号！无法完成";
                }
            }
            catch (Exception exc)
            {
                LogHelper.Error("入库完成堆垛机反馈接口错误："+ exc.Message+"\r\n"+exc.StackTrace);
            }
            return rtn;
        }

        /// <summary>
        /// 堆垛机出库完成，WCS通知WMS
        /// </summary>
        /// <param name="ask_num">请求号</param>
        /// <param name="container_id">容器号（托盘/料箱）</param>
        /// <param name="task_num">出库完成的堆垛机任务号</param>
        /// <param name="srm_num">堆垛机编号</param>
        /// <param name="laneway">巷道号</param>
        /// <returns></returns>
        [WebMethod(Description = "堆垛机出库完成，WCS通知WMS")]
        public WCS_Ask_Result SRM_OutTaskFinish(string ask_num, string container_id , string task_num, string srm_num,string laneway)
        {
            LogHelper.Info("WCS调用一次 出库完成通知 接口：ask_num:" + ask_num + " >container_id：" + container_id + " >task_num：" + task_num + " >srm_num：" + srm_num+ " >laneway:"+ laneway);

            WCS_Ask_Result rtn = new WCS_Ask_Result();
            rtn.ask_num = ask_num;
            rtn.result = true;
            rtn.error_code = "0000";
            rtn.error_message = "接收“出库完成通知”成功";
            rtn.pallet_wrapping = false;
            rtn.place_instock = "";
            rtn.sorting_port = "";
            rtn.task_num = task_num;
            rtn.reserve_field1 = "";
            rtn.reserve_field2 = "";
            rtn.reserve_field3 = "";
            rtn.reserve_field4 = "";
            rtn.reserve_field5 = "";
            try
            {
                var taskGet = DAL.da_wms_devices_task.GetOneByTaskCode(task_num); //根据任务号获取 （目标地址）
                if (taskGet != null)
                {
                    if (taskGet.task_type != "SRM_OUT")
                    {
                        rtn.result = false;
                        rtn.error_code = "0010";
                        rtn.error_message = "此任务号不是出库任务号！无法完成";
                    }
                    else
                    {
                        if (DAL.da_wms_devices_task.SRMOutFinishedUpdate(task_num) == "S")
                        {
                            rtn.result = true;
                            rtn.error_code = "0000";
                            rtn.error_message = "接收“出库完成通知”成功";
                        }
                        else
                        {
                            rtn.result = false;
                            rtn.error_code = "1009";
                            rtn.error_message = "处理“出库完成通知”存储过程 失败。请联系管理员重试。";
                        }
                    }
                }
                else
                {
                    rtn.result = false;
                    rtn.error_code = "0010";
                    rtn.error_message = "无此任务号！无法完成";
                }
            }
            catch (Exception exc)
            {
                rtn.result = false;
                rtn.error_code = "0009";
                rtn.error_message = "未知错误：" + exc.Message;
                LogHelper.Error("出库完成通知 接口错误：" + exc.Message + "\r\n" + exc.StackTrace);
            }
            return rtn;
        }

        /// <summary>
        /// 堆垛机移库完成，WCS通知WMS
        /// </summary>
        /// <param name="ask_num">请求号</param>
        /// <param name="container_id">容器号（托盘/料箱）</param>
        /// <param name="task_num">移库完成的堆垛机任务号</param>
        /// <param name="srm_num">堆垛机编号</param>
        /// <param name="laneway">巷道号</param>
        /// <returns></returns>
        [WebMethod(Description = "堆垛机移库完成，WCS通知WMS")]
        public WCS_Ask_Result SRM_TransferTaskFinish(string ask_num, string container_id, string task_num, string srm_num, string laneway)
        {
            LogHelper.Info("WCS调用一次 移库完成通知 接口：ask_num:" + ask_num + " >container_id：" + container_id + " >task_num：" + task_num + " >srm_num：" + srm_num + " >laneway:" + laneway);

            WCS_Ask_Result rtn = new WCS_Ask_Result();
            rtn.ask_num = ask_num;
            rtn.result = true;
            rtn.error_code = "0000";
            rtn.error_message = "接收“移库完成通知”成功";
            rtn.pallet_wrapping = false;
            rtn.place_instock = "";
            rtn.sorting_port = "";
            rtn.task_num = task_num;
            rtn.reserve_field1 = "";
            rtn.reserve_field2 = "";
            rtn.reserve_field3 = "";
            rtn.reserve_field4 = "";
            rtn.reserve_field5 = "";
            try
            {
                var taskGet = DAL.da_wms_devices_task.GetOneByTaskCode(task_num); //根据任务号获取 （目标地址）
                if (taskGet != null)
                {
                    if (taskGet.task_type != "SRM_TO")
                    {
                        rtn.result = false;
                        rtn.error_code = "0010";
                        rtn.error_message = "此任务号不是移库任务号！无法完成";
                    }
                    else
                    {
                        if (DAL.da_wms_devices_task.SRMTransferFinishedUpdate(task_num) == "S")
                        {
                            rtn.result = true;
                            rtn.error_code = "0000";
                            rtn.error_message = "接收“移库完成通知”成功";
                        }
                        else
                        {
                            rtn.result = false;
                            rtn.error_code = "1009";
                            rtn.error_message = "处理“移库完成通知”存储过程 失败。请联系管理员重试。";
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                rtn.result = false;
                rtn.error_code = "0009";
                rtn.error_message = "未知错误：" + exc.Message;
                LogHelper.Error("移库完成通知 接口错误：" + exc.Message + "\r\n" + exc.StackTrace);
            }
            return rtn;
        }
         
        /// <summary>
        /// WCS 请求 补空托盘垛 接口
        /// </summary>
        /// <param name="floorPort">暂时固定为B07</param>
        /// <returns></returns>
        [WebMethod(Description = "拆盘机请求补盘")]
        public WCS_Ask_Result WCSAskPalletReplisment(string floorPort)
        {
            LogHelper.Info("WCS调用一次 请求补空托盘垛 接口：floorPort:" + floorPort  );
            DataTable dt = new DataTable();
            DataTable ddt = new DataTable();
            WCS_Ask_Result rtn = new WCS_Ask_Result();
            rtn.ask_num = "";
            rtn.result = true;
            rtn.error_code = "0000";
            rtn.error_message = "接收“请求补空托盘垛”成功";
            rtn.pallet_wrapping = false;
            rtn.place_instock = "";
            rtn.sorting_port = "";
            rtn.task_num = 
            rtn.reserve_field1 = "";
            rtn.reserve_field2 = "";
            rtn.reserve_field3 = "";
            rtn.reserve_field4 = "";
            rtn.reserve_field5 = "";
            try
            {
                DAL.da_sys_config da = new DAL.da_sys_config();
                var ncd= DAL.da_sys_config.GetNewRcdID("taskIDgeneratorOut").ToString();
              
                wms_devices_task nisa = new wms_devices_task();

                dt = da.GetBy_99999();
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        nisa.container_id = dt.Rows[i]["container_id"].ToString();
                        var getinTask = DAL.da_wms_devices_task.GetDoingPallet(nisa.container_id, "SRM_OUT");
                        if (getinTask == null)
                        {
                            nisa.place_from = dt.Rows[i]["place_code"].ToString();
                            break;
                        }
                    }

                    string[] list = nisa.place_from.Split('-');
                    string pai = list[0].ToString();
                    switch (pai)
                    {
                        case "13":
                        case "14":
                            nisa.place_to = floorPort;
                            break;

                        default:
                            nisa.place_to = "B01";
                            rtn.error_code = "1009";
                            rtn.result = false;
                            rtn.error_message = "出库任务已下发，但不是4号堆垛机";
                            break;
                    }

                    nisa.taskid = ncd;
                    nisa.taskcode = ncd;
                    nisa.main_material = "";
                    nisa.do_device = "";
                    nisa.do_platform = "SRM";
                    nisa.order_from = "";
                    //nisa.place_from = "";
                    //nisa.place_to = "B07";   //	出库	1F4号堆垛机拆盘机出库口
                    //nisa.container_id = "";
                    nisa.place_from_wcs = "";
                    nisa.place_to_wcs = "";
                    nisa.task_detail_neck = 0;
                    nisa.task_type = "SRM_OUT";
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
                        using (trx_wms client = new trx_wms())  //调用另一个WebService
                        {
                            var tellWCS = client.WCS_Generate_Out_Task(nisa.place_from, nisa.place_to, nisa.taskcode, nisa.container_id, "No_wait");
                            if (tellWCS.Substring(0, 1) != "S")
                            {
                                DAL.da_wms_devices_task.DeleteByPKID(ncd);
                                rtn.result = false;
                                rtn.error_code = "1009";
                                rtn.error_message = "处理 请求补空托盘垛 失败，下发WCS堆垛机出库错误。请联系管理员重试。";
                            }
                        }
                    }
                    else
                    {
                        rtn.result = false;
                        rtn.error_code = "1009";
                        rtn.error_message = "处理 请求补空托盘垛 失败，生成出库任务失败。请联系管理员重试。";
                    }
                }
                else
                { 
                    rtn.error_code = "1009";
                    rtn.result = false;
                    rtn.error_message = "没有找到符合要求的空托盘垛";
                }


            }
            catch (Exception exc)
            {
                rtn.result = false;
                rtn.error_code = "0009";
                rtn.error_message = "未知错误：" + exc.Message;
                LogHelper.Error("请求补空托盘垛 接口错误：" + exc.Message + "\r\n" + exc.StackTrace);
            }
            return rtn;
        }
       


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ask_num">请求号</param>
        /// <param name="container_id">托盘/箱号</param>
        /// <param name="port_num">道口编号</param>
        /// <param name="rsv_type">备用类型</param>
        /// <returns></returns>
        [WebMethod(Description = "堆垛机出库完成后放到出库口输送线，WMS告知WCS目标道口去向，此时生成新任务号")]
        public WCS_Ask_Result ContainerOutConveyorAskToNewPort(string ask_num, string container_id, string port_num, string rsv_type)
        {
            LogHelper.Info("WCS调用一次 托盘目标道口去向 接口：ask_num:" + ask_num + " >container_id：" + container_id + " >rsv_type：" + rsv_type  );

            WCS_Ask_Result rtn = new WCS_Ask_Result();
            rtn.ask_num = ask_num;
            rtn.result = true;
            rtn.error_code = "0000";
            rtn.error_message = "接收“出库完成通知”成功";
            rtn.pallet_wrapping = false;
            rtn.place_instock = "";
            rtn.sorting_port = "";
            Random rd = new Random();
            rtn.task_num = rd.Next(100000, 999999).ToString();
            rtn.reserve_field1 = "";
            rtn.reserve_field2 = "";
            rtn.reserve_field3 = "";
            rtn.reserve_field4 = "";
            rtn.reserve_field5 = "";
            try
            {

            }
            catch (Exception exc)
            {
                rtn.result = false;
                rtn.error_code = "0009";
                rtn.error_message = "未知错误：" + exc.Message;
                LogHelper.Error(" 托盘目标道口去向 接口错误：" + exc.Message + "\r\n" + exc.StackTrace);
            }

            return rtn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ask_num"></param>
        /// <param name="container_id">托盘/箱号</param>
        /// <param name="task_no">WMS给定原来的任务号</param>
        /// <param name="rsv_type"></param>
        /// <returns></returns>
        [WebMethod(Description = "输送线到达目标道口，任务完成反馈调用。WMS本身也可以通过PDA扫描确认。")]
        public WCS_Ask_Result ConveyorTransferFinishReport(string ask_num, string container_id, string task_no, string rsv_type)
        {
            LogHelper.Info("WCS调用一次 输送线到达目标道口，任务完成反馈 接口：ask_num:" + ask_num + " >container_id：" + container_id + " >rsv_type：" + rsv_type);

            WCS_Ask_Result rtn = new WCS_Ask_Result();
            rtn.ask_num = ask_num;
            rtn.result = true;
            rtn.error_code = "0000";
            rtn.error_message = "成功。输送线到达目标道口，任务完成反馈调用成功。";
            rtn.pallet_wrapping = false;
            rtn.place_instock = "";
            rtn.sorting_port = "";
            Random rd = new Random();
            rtn.task_num = rd.Next(100000, 999999).ToString();
            rtn.reserve_field1 = "";
            rtn.reserve_field2 = "";
            rtn.reserve_field3 = "";
            rtn.reserve_field4 = "";
            rtn.reserve_field5 = "";
            try
            {

            }
            catch (Exception exc)
            {
                rtn.result = false;
                rtn.error_code = "0009";
                rtn.error_message = "未知错误：" + exc.Message;
                LogHelper.Error("  输送线到达目标道口，任务完成反馈 接口错误：" + exc.Message + "\r\n" + exc.StackTrace);
            }

            return rtn;
        }


    }
}
