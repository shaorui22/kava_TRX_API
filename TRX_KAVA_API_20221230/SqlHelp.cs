using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace TRX_KAVA_API
{
    public class SqlHelp
    {
        public static List<T> ExecuteDataTable<T>(string commandText, CommandType commandType, params SqlParameter[] values) where T : new()
        {
            Type type = typeof(T);
            List<T> list = new List<T>();
            try
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter odAdapter = new SqlDataAdapter(commandText, Convert.ToString(ConfigurationManager.AppSettings["local"])))
                {
                    if (values != null) odAdapter.SelectCommand.Parameters.AddRange(values);
                    odAdapter.SelectCommand.CommandType = commandType;
                    odAdapter.Fill(dt);
                }

                //将DataTable 转化为 List集合
                PropertyInfo[] pArray = type.GetProperties();
                foreach (DataRow row in dt.Rows)
                {
                    T entity = new T();
                    foreach (PropertyInfo p in pArray)
                    {
                        if (row[p.Name] is DBNull) continue;
                        var strvalue = row[p.Name];
                        if (strvalue != null)
                        {
                            Type valType = strvalue.GetType();
                            if (valType == typeof(float))
                            {
                                p.SetValue(entity, Convert.ToSingle(strvalue), null);
                            }
                            else if (valType == typeof(double))
                            {
                                p.SetValue(entity, Convert.ToDouble(strvalue), null);
                            }
                            else if (valType == typeof(decimal))
                            {
                                p.SetValue(entity, Convert.ToDecimal(strvalue), null);
                            }
                            else if (valType == typeof(int))
                            {
                                p.SetValue(entity, Convert.ToInt32(strvalue), null);
                            }
                            else if (valType == typeof(DateTime))
                            {
                                p.SetValue(entity, Convert.ToDateTime(strvalue), null);
                            }
                            else if (valType == typeof(string))
                            {
                                p.SetValue(entity, Convert.ToString(strvalue), null);
                            }
                            else if (valType == typeof(Boolean))
                            {
                                p.SetValue(entity, Convert.ToBoolean(strvalue), null);
                            }
                            else if (valType == typeof(Int64))
                            {
                                p.SetValue(entity, Convert.ToInt32(strvalue), null);
                            }
                        }

                    }
                    list.Add(entity);
                }

            }
            catch
            {
                throw;
            }
            return list;
        }
    }
}