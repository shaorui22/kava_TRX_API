using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using TRX_KAVA_API.Models;

namespace TRX_KAVA_API.DAL
{
    public class da_wms_devices_task
    {
        //---------------------按Table的方式查询方法--------------------------//
        private static List<wms_devices_task> DoTableQuery(string sql_str, SqlParameter[] paras)
        {
            var lisRtn = new List<wms_devices_task>();
            try
            {
                var dtback = DBHelper_SQLServer.ExecuteDataTable(sql_str, paras);
                lisRtn = EntityTableParse<wms_devices_task>.ToList(dtback);
            }
            catch
            {
            }
            return lisRtn;
        }
        //---------------------查询并赋值到实体类list的方法  IReader方式--------------------------//
        private static List<wms_devices_task> DoQuery(string sql_str, SqlParameter[] paras)
        {
            var lisRtn = new List<wms_devices_task>();
            try
            {
                using (IDataReader dr = DBHelper_SQLServer.ExecuteReader(sql_str, paras))
                {
                    while (dr.Read())
                    {
                        var p = new wms_devices_task();
                        #region 逐个赋值 
                        p.taskid = DBHelper_SQLServer.GetDataValue<string>(dr, "taskid");
                        p.taskcode = DBHelper_SQLServer.GetDataValue<string>(dr, "taskcode");
                        p.main_material = DBHelper_SQLServer.GetDataValue<string>(dr, "main_material");
                        p.do_device = DBHelper_SQLServer.GetDataValue<string>(dr, "do_device");
                        p.do_platform = DBHelper_SQLServer.GetDataValue<string>(dr, "do_platform");
                        p.order_from = DBHelper_SQLServer.GetDataValue<string>(dr, "order_from");
                        p.place_from = DBHelper_SQLServer.GetDataValue<string>(dr, "place_from");
                        p.place_to = DBHelper_SQLServer.GetDataValue<string>(dr, "place_to");
                        p.container_id = DBHelper_SQLServer.GetDataValue<string>(dr, "container_id");
                        p.place_from_wcs = DBHelper_SQLServer.GetDataValue<string>(dr, "place_from_wcs");
                        p.place_to_wcs = DBHelper_SQLServer.GetDataValue<string>(dr, "place_to_wcs");
                        p.task_detail_neck = DBHelper_SQLServer.GetDataValue<int>(dr, "task_detail_neck");
                        p.task_type = DBHelper_SQLServer.GetDataValue<string>(dr, "task_type");
                        p.task_status = DBHelper_SQLServer.GetDataValue<string>(dr, "task_status");
                        p.task_batch = DBHelper_SQLServer.GetDataValue<string>(dr, "task_batch");
                        p.t_create = DBHelper_SQLServer.GetDataValue<DateTime>(dr, "t_create");
                        p.t_update = DBHelper_SQLServer.GetDataValue<DateTime>(dr, "t_update");
                        p.t_diliver = DBHelper_SQLServer.GetDataValue<DateTime>(dr, "t_diliver");
                        p.t_finish = DBHelper_SQLServer.GetDataValue<DateTime>(dr, "t_finish");
                        p.u_create_name = DBHelper_SQLServer.GetDataValue<string>(dr, "u_create_name");
                        p.u_create_id = DBHelper_SQLServer.GetDataValue<string>(dr, "u_create_id");
                        p.u_update_name = DBHelper_SQLServer.GetDataValue<string>(dr, "u_update_name");
                        p.u_update_id = DBHelper_SQLServer.GetDataValue<string>(dr, "u_update_id");
                        p.flag_feedback = DBHelper_SQLServer.GetDataValue<string>(dr, "flag_feedback");
                        p.flag_delete = DBHelper_SQLServer.GetDataValue<bool>(dr, "flag_delete");
                        #endregion
                        lisRtn.Add(p);
                    }
                }
            }
            catch  
            {
            }
            return lisRtn;
        }
        //----------------------Insert方法----------------------------------------------//
        public static bool InsertNew(wms_devices_task newOne)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" Insert into wms_devices_task (  ");
            sb.Append("taskid, ");
            sb.Append("taskcode, ");
            sb.Append("main_material, ");
            sb.Append("do_device, ");
            sb.Append("do_platform, ");
            sb.Append("order_from, ");
            sb.Append("place_from, ");
            sb.Append("place_to, ");
            sb.Append("container_id, ");
            sb.Append("place_from_wcs, ");
            sb.Append("place_to_wcs, ");
            sb.Append("task_detail_neck, ");
            sb.Append("task_type, ");
            sb.Append("task_status, ");
            sb.Append("task_batch, ");
            sb.Append("t_create, ");
            sb.Append("t_update, ");
            sb.Append("t_diliver, ");
            sb.Append("t_finish, ");
            sb.Append("u_create_name, ");
            sb.Append("u_create_id, ");
            sb.Append("u_update_name, ");
            sb.Append("u_update_id, ");
            sb.Append("flag_feedback, ");
            sb.Append("flag_delete )");
            sb.Append(" values ( ");
            sb.Append("@taskid,");
            sb.Append("@taskcode,");
            sb.Append("@main_material,");
            sb.Append("@do_device,");
            sb.Append("@do_platform,");
            sb.Append("@order_from,");
            sb.Append("@place_from,");
            sb.Append("@place_to,");
            sb.Append("@container_id,");
            sb.Append("@place_from_wcs,");
            sb.Append("@place_to_wcs,");
            sb.Append("@task_detail_neck,");
            sb.Append("@task_type,");
            sb.Append("@task_status,");
            sb.Append("@task_batch,");
            sb.Append("@t_create,");
            sb.Append("@t_update,");
            sb.Append("@t_diliver,");
            sb.Append("@t_finish,");
            sb.Append("@u_create_name,");
            sb.Append("@u_create_id,");
            sb.Append("@u_update_name,");
            sb.Append("@u_update_id,");
            sb.Append("@flag_feedback,");
            sb.Append("@flag_delete )");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sb.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@taskid", SqlDbType.NVarChar, 500) { Value = newOne.taskid ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@taskcode", SqlDbType.NVarChar, 500) { Value = newOne.taskcode ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@main_material", SqlDbType.NVarChar, 500) { Value = newOne.main_material ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@do_device", SqlDbType.NVarChar, 500) { Value = newOne.do_device ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@do_platform", SqlDbType.NVarChar, 500) { Value = newOne.do_platform ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@order_from", SqlDbType.NVarChar, 500) { Value = newOne.order_from ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@place_from", SqlDbType.NVarChar, 500) { Value = newOne.place_from ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@place_to", SqlDbType.NVarChar, 500) { Value = newOne.place_to ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@container_id", SqlDbType.NVarChar, 500) { Value = newOne.container_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@place_from_wcs", SqlDbType.NVarChar, 500) { Value = newOne.place_from_wcs ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@place_to_wcs", SqlDbType.NVarChar, 500) { Value = newOne.place_to_wcs ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@task_detail_neck", SqlDbType.Int) { Value = newOne.task_detail_neck });
            cmd.Parameters.Add(new SqlParameter("@task_type", SqlDbType.NVarChar, 500) { Value = newOne.task_type ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@task_status", SqlDbType.NVarChar, 500) { Value = newOne.task_status ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@task_batch", SqlDbType.NVarChar, 500) { Value = newOne.task_batch ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_create", SqlDbType.DateTime) { Value = newOne.t_create });
            cmd.Parameters.Add(new SqlParameter("@t_update", SqlDbType.DateTime) { Value = newOne.t_update });
            cmd.Parameters.Add(new SqlParameter("@t_diliver", SqlDbType.DateTime) { Value = newOne.t_diliver });
            cmd.Parameters.Add(new SqlParameter("@t_finish", SqlDbType.DateTime) { Value = newOne.t_finish });
            cmd.Parameters.Add(new SqlParameter("@u_create_name", SqlDbType.NVarChar, 500) { Value = newOne.u_create_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_id", SqlDbType.NVarChar, 500) { Value = newOne.u_create_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_update_name", SqlDbType.NVarChar, 500) { Value = newOne.u_update_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_update_id", SqlDbType.NVarChar, 500) { Value = newOne.u_update_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@flag_feedback", SqlDbType.NVarChar, 500) { Value = newOne.flag_feedback ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@flag_delete", SqlDbType.Bit) { Value = newOne.flag_delete });

            int val = DBHelper_SQLServer.ExecuteNonQuery(cmd);
            if (val > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static void ExcuteMoveFinishedTaskOut()
        {
             
        }

        //----------------------UpdateOne方法---------------------------------------//
        public static bool UpdateOne(wms_devices_task newOne)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" update wms_devices_task set  ");
            sb.Append("  taskcode = @taskcode ,   ");
            sb.Append("  main_material = @main_material ,   ");
            sb.Append("  do_device = @do_device ,   ");
            sb.Append("  do_platform = @do_platform ,   ");
            sb.Append("  order_from = @order_from ,   ");
            sb.Append("  place_from = @place_from ,   ");
            sb.Append("  place_to = @place_to ,   ");
            sb.Append("  container_id = @container_id ,   ");
            sb.Append("  place_from_wcs = @place_from_wcs ,   ");
            sb.Append("  place_to_wcs = @place_to_wcs ,   ");
            sb.Append("  task_detail_neck = @task_detail_neck ,   ");
            sb.Append("  task_type = @task_type ,   ");
            sb.Append("  task_status = @task_status ,   ");
            sb.Append("  task_batch = @task_batch ,   ");
            sb.Append("  t_create = @t_create ,   ");
            sb.Append("  t_update = @t_update ,   ");
            sb.Append("  t_diliver = @t_diliver ,   ");
            sb.Append("  t_finish = @t_finish ,   ");
            sb.Append("  u_create_name = @u_create_name ,   ");
            sb.Append("  u_create_id = @u_create_id ,   ");
            sb.Append("  u_update_name = @u_update_name ,   ");
            sb.Append("  u_update_id = @u_update_id ,   ");
            sb.Append("  flag_feedback = @flag_feedback ,   ");
            sb.Append("  flag_delete = @flag_delete   ");
            sb.Append(" where taskid = @taskid  ");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sb.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@taskcode", SqlDbType.NVarChar, 500) { Value = newOne.taskcode ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@main_material", SqlDbType.NVarChar, 500) { Value = newOne.main_material ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@do_device", SqlDbType.NVarChar, 500) { Value = newOne.do_device ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@do_platform", SqlDbType.NVarChar, 500) { Value = newOne.do_platform ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@order_from", SqlDbType.NVarChar, 500) { Value = newOne.order_from ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@place_from", SqlDbType.NVarChar, 500) { Value = newOne.place_from ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@place_to", SqlDbType.NVarChar, 500) { Value = newOne.place_to ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@container_id", SqlDbType.NVarChar, 500) { Value = newOne.container_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@place_from_wcs", SqlDbType.NVarChar, 500) { Value = newOne.place_from_wcs ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@place_to_wcs", SqlDbType.NVarChar, 500) { Value = newOne.place_to_wcs ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@task_detail_neck", SqlDbType.Int) { Value = newOne.task_detail_neck });
            cmd.Parameters.Add(new SqlParameter("@task_type", SqlDbType.NVarChar, 500) { Value = newOne.task_type ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@task_status", SqlDbType.NVarChar, 500) { Value = newOne.task_status ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@task_batch", SqlDbType.NVarChar, 500) { Value = newOne.task_batch ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@t_create", SqlDbType.DateTime) { Value = newOne.t_create });
            cmd.Parameters.Add(new SqlParameter("@t_update", SqlDbType.DateTime) { Value = newOne.t_update });
            cmd.Parameters.Add(new SqlParameter("@t_diliver", SqlDbType.DateTime) { Value = newOne.t_diliver });
            cmd.Parameters.Add(new SqlParameter("@t_finish", SqlDbType.DateTime) { Value = newOne.t_finish });
            cmd.Parameters.Add(new SqlParameter("@u_create_name", SqlDbType.NVarChar, 500) { Value = newOne.u_create_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_create_id", SqlDbType.NVarChar, 500) { Value = newOne.u_create_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_update_name", SqlDbType.NVarChar, 500) { Value = newOne.u_update_name ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@u_update_id", SqlDbType.NVarChar, 500) { Value = newOne.u_update_id ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@flag_feedback", SqlDbType.NVarChar, 500) { Value = newOne.flag_feedback ?? DBNull.Value.ToString() });
            cmd.Parameters.Add(new SqlParameter("@flag_delete", SqlDbType.Bit) { Value = newOne.flag_delete });
            cmd.Parameters.Add(new SqlParameter("@taskid", SqlDbType.NVarChar, 500) { Value = newOne.taskid ?? DBNull.Value.ToString() });
            int val = DBHelper_SQLServer.ExecuteNonQuery(cmd);
            if (val > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //----------------------Delete方法---------------------------------------------//
        public static bool DeleteByPKID(object PK_ID)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" delete from wms_devices_task where taskid=@taskid ");
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sb.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@taskid", SqlDbType.NVarChar, 150) { Value = PK_ID });
                int val = DBHelper_SQLServer.ExecuteNonQuery(cmd);
                if (val > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch  
            {
                return false;
            }
        }
        //----------------------GetOneByID方法--------------------------------------//
        public static wms_devices_task GetOneByID(object PK_ID)
        {
            List<SqlParameter> prs = new List<SqlParameter>();
            prs.Add(new SqlParameter("@taskid", SqlDbType.NVarChar, 150) { Value = PK_ID });
            var lis = DoTableQuery("select * from wms_devices_task where taskid =@taskid", prs.ToArray());
            if (lis != null && lis.Count > 0)
            {
                return lis[0];
            }
            else
            {
                return null;
            }
        }
        internal static wms_devices_task GetOneByTaskCode(string taskcode)
        {
            List<SqlParameter> prs = new List<SqlParameter>();
            prs.Add(new SqlParameter("@taskcode", SqlDbType.NVarChar, 150) { Value = taskcode });
            var lis = DoTableQuery("select * from wms_devices_task where taskcode =@taskcode", prs.ToArray());
            if (lis != null && lis.Count > 0)
            {
                return lis[0];
            }
            else
            {
                return null;
            }
        }

        internal static wms_devices_task GetDoingPallet(string palletcode, string tasktype)
        {
            List<SqlParameter> prs = new List<SqlParameter>
            {
                new SqlParameter("@container_id", SqlDbType.NVarChar, 150) { Value = palletcode },
                new SqlParameter("@task_type", SqlDbType.NVarChar, 150) { Value = tasktype }
            };
            var lis = DoTableQuery("select * from wms_devices_task where container_id =@container_id and task_type=@task_type and task_status in ('DOING','NEW' ) and flag_delete=0", prs.ToArray());
            if (lis != null && lis.Count > 0)
            {
                return lis[0];
            }
            else
            {
                return null;
            }
        }

      

        internal static wms_devices_task GetOneByTargetPlace(string toPlaceID)
        {
            List<SqlParameter> prs = new List<SqlParameter>();
            prs.Add(new SqlParameter("@place_to", SqlDbType.NVarChar, 150) { Value = toPlaceID });
            var lis = DoTableQuery("select * from wms_devices_task where place_to =@place_to and flag_delete=0", prs.ToArray());
            if (lis != null && lis.Count > 0)
            {
                return lis[0];
            }
            else
            {
                return null;
            }
        }

        internal static List<wms_devices_task> GetNotFinishTasks(string typecode)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from wms_devices_task where task_status <>'FINISHED'  and flag_delete=0");
            if (typecode != "")
            {
                sb.Append(" and task_type ='" + typecode + "'");
            }
            List<SqlParameter> prs = new List<SqlParameter>();
            var lis = DoTableQuery(sb.ToString(), prs.ToArray());
            return lis;
        }


        internal static wms_devices_task GetOneByTargetPlace_from(string fromPlaceID)
        {
            List<SqlParameter> prs = new List<SqlParameter>();
            prs.Add(new SqlParameter("@place_from", SqlDbType.NVarChar, 150) { Value = fromPlaceID });
            var lis = DoTableQuery("select * from wms_devices_task where place_from =@place_from and task_status = 'NEW'", prs.ToArray());
            if (lis != null && lis.Count > 0)
            {
                //if (lis[0].taskcode.StartsWith("2"))
                //{
                return lis[0];
                //} 
                //else
                //{
                //    return null;
                //}
            }
            else
            {
                return null;
            }
        }




        internal static List<wms_devices_task> GetRecordsByConditions(string mcodeOrdesc, string TimeStart, string TimeEnd, string inout_type)
        {
            StringBuilder sb = new StringBuilder();
            var dtStart = DateTime.Parse(TimeStart);
            var dtEnd = DateTime.Parse(TimeEnd);
            sb.Append("select * from v_wms_devices_task where  CONVERT(varchar(100), t_diliver, 120)>='" + dtStart.ToString("yyyy-MM-dd HH:mm:ss") + "' and CONVERT(varchar(100), t_diliver, 120)<='" + dtEnd.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            if (inout_type != "")
            {
                sb.Append(" and task_type ='" + inout_type + "'");
            }
            if (mcodeOrdesc != "")
            {
                sb.Append("  and ( main_material like '%" + mcodeOrdesc + "%' or task_batch like '%" + mcodeOrdesc + "%')");
            }

            List<SqlParameter> prs = new List<SqlParameter>();
            var lis = DoTableQuery(sb.ToString(), prs.ToArray());
            return lis;
        }

        internal static string SRMOutFinishedUpdate(string tasknum)
        {
            string rtn = "E";
            try
            {
                List<SqlParameter> parass = new List<SqlParameter>();
                parass.Add(new SqlParameter("@taskcode", tasknum));
              
                SqlParameter pa = new SqlParameter();
                pa.Direction = ParameterDirection.InputOutput;
                pa.ParameterName = "@return_value";
                pa.Size = 5000;
                pa.SqlValue = "";
                parass.Add(pa);
                var prrslt = parass.ToArray();
                var rslt = DAL.DBHelper_SQLServer.ExecuteProcedure("p_srm_out_finish_update", ref prrslt);
                
                rtn = pa.Value.ToString();
                var str = "执行存储过程 p_srm_out_finish_update,任务号：" + tasknum + ",结果" + rtn;
                LogHelper.Info(str);

                return rtn;
            }
            catch(Exception exc)
            {
                rtn = "E执行出库完成存储过程遇到错误："+exc.Message+"\r\n"+exc.StackTrace; 
                LogHelper.Error(rtn);
                return rtn;
            }
        }
        internal static string SRMTransferFinishedUpdate(string task_num)
        {
            string rtn = "E";
            try
            {
                List<SqlParameter> parass = new List<SqlParameter>();
                parass.Add(new SqlParameter("@taskcode", task_num));

                SqlParameter pa = new SqlParameter();
                pa.Direction = ParameterDirection.InputOutput;
                pa.ParameterName = "@return_value";
                pa.Size = 5000;
                pa.SqlValue = "";
                parass.Add(pa);
                var prrslt = parass.ToArray();
                var rslt = DAL.DBHelper_SQLServer.ExecuteProcedure("p_srm_transfer_finish_update", ref prrslt);

              
                rtn = pa.Value.ToString();
                var str = "执行存储过程 p_srm_transfer_finish_update,任务号：" + task_num + ",结果" + rtn;
                LogHelper.Info(str);
                return rtn;
            }
            catch (Exception exc)
            {
                rtn = "E执行移库完成存储过程遇到错误：" + exc.Message + "\r\n" + exc.StackTrace;
                LogHelper.Error(rtn);
                return rtn;
            }
        }
    }
}