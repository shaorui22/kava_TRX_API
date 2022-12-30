using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace TRX_KAVA_API.Models
{
    /// <summary>
    /// JSON/ENTITY/LIST/DATAROW/DATATABLE之间的相互转化
    /// </summary>
    /// <typeparam name="T">实体类</typeparam>
    public abstract class EntityTableParse<T> where T : new()
    {
        /// <summary>
        /// 根据实体类添加空白表格
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private static DataTable CreateData(T t)
        {
            if (t == null)
            {
                return null;
            }
            DataTable dataTable = new DataTable(typeof(T).Name);
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                if (propertyInfo.PropertyType.ToString().IndexOf("System.Collections.Generic.List") < 0)
                    dataTable.Columns.Add(new DataColumn(propertyInfo.Name, propertyInfo.PropertyType));
            }
            return dataTable;
        }
        /// <summary>
        /// 将实体类转化成DataRow,忽略其中包含的List类
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static DataRow ToDataRow(T t)
        {
            if (t == null)
            {
                return null;
            }
            DataRow dataRow = CreateData(t).NewRow();
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                if (propertyInfo.PropertyType.ToString().IndexOf("System.Collections.Generic.List") < 0)
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(t, null);
            }
            return dataRow;
        }
        /// <summary>
        /// 将实体类转化成DataTable，忽略其中包含的List类
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(T t)
        {
            if (t == null)
            {
                return null;
            }
            List<T> myList = new List<T>();
            myList.Add(t);
            return ToDataTable(myList);
        }
        /// <summary>
        /// 将List转化成DataTable，加入实体中包含另一个实体或者另一个实体类
        /// </summary>
        /// <param name="ListT"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(List<T> ListT)
        {
            if (ListT == null)
            {
                return null;
            }
            DataTable dt = CreateData(ListT[0]);
            foreach (T t in ListT)
            {
                DataRow dataRow = dt.NewRow();
                foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                {
                    if (propertyInfo.PropertyType.ToString().IndexOf("System.Collections.Generic.List") < 0)
                        dataRow[propertyInfo.Name] = propertyInfo.GetValue(t, null);
                }
                dt.Rows.Add(dataRow);
            }
            return dt;
        }
        /// <summary>
        /// 将JSON转化成DataTable
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(string Json)
        {
            if (Json == string.Empty)
            {
                return null;
            }
            DataTable dt = new DataTable();
            List<T> listT = ToList(Json);
            if (listT == null)
            {
                T t = ToEntity(Json);
                dt = ToDataTable(t);
            }
            else
            {
                dt = ToDataTable(listT);
            }
            return dt;
        }
        /// <summary>
        /// 将DataRow转化成实体类
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static T ToEntity(DataRow dr)
        {
            if (dr == null)
            {
                return default(T);
            }

            T t = new T();
            string tempname = string.Empty;
            PropertyInfo[] propertys = t.GetType().GetProperties();
            foreach (PropertyInfo property in propertys)
            {
                tempname = property.Name;
                if (!property.CanWrite) continue;
                object value = dr[tempname];
                if (value != DBNull.Value)
                {
                    property.SetValue(t, value, null);
                }
            }
            return t;
        }
        /// <summary>
        /// 将JSON转化成实体类
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static T ToEntity(string Json)
        {
            if (Json == string.Empty)
            {
                return default(T);
            }
            List<T> ListT = ToList(Json);
            {
                if (ListT != null)
                {
                    return ListT[0];
                }
                else
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        using (StreamWriter sw = new StreamWriter(stream, Encoding.UTF8))
                        {
                            sw.Write(Json);
                            sw.Flush();
                            stream.Seek(0, SeekOrigin.Begin);
                            XmlSerializer serializer = new XmlSerializer(typeof(T));
                            try
                            {
                                return ((T)serializer.Deserialize(stream));
                            }
                            catch { return default(T); }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 将DataTable转化成List
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ToList(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            List<T> myList = new List<T>();
            Type type = typeof(T);
            string tempname = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo property in propertys)
                {
                    tempname = property.Name;
                    if (dt.Columns.Contains(tempname))
                    {
                        if (!property.CanWrite) continue;
                        object value = dr[tempname];
                        if (value != DBNull.Value)
                        {
                            if (property.GetGetMethod().ReturnParameter.ParameterType.Name == "Int32")
                            {
                                value = Convert.ToInt32(value);
                            }
                            property.SetValue(t, value, null);
                        }
                    }
                }

                myList.Add(t);
            }
            return myList;
        }
        /// <summary>
        /// 将JSON转化成List
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        public static List<T> ToList(string Json)
        {
            if (Json == string.Empty)
            {
                return null;
            }
            using (MemoryStream stream = new MemoryStream())
            {
                using (StreamWriter sw = new StreamWriter(stream, Encoding.UTF8))
                {
                    sw.Write(Json);
                    sw.Flush();
                    stream.Seek(0, SeekOrigin.Begin);
                    XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                    try
                    {
                        return ((List<T>)serializer.Deserialize(stream));
                    }
                    catch { return null; }
                }
            }
        }
        /// <summary>
        /// 将实体类转化成JSON
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ToJson(T t)
        {
            if (t == null) return null;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            MemoryStream stream = new MemoryStream();
            XmlTextWriter xtw = new XmlTextWriter(stream, Encoding.UTF8);
            xtw.Formatting = Formatting.Indented;
            try
            {
                serializer.Serialize(stream, t);
            }
            catch { return null; }
            stream.Position = 0;
            string returnStr = string.Empty;
            using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    returnStr += line;
                }
            }
            return returnStr;

        }
        /// <summary>
        /// 将List转化成JSON
        /// </summary>
        /// <param name="ListT"></param>
        /// <returns></returns>
        public static string ToJson(List<T> ListT)
        {
            if (ListT == null) return null;
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            MemoryStream stream = new MemoryStream();
            XmlTextWriter xtw = new XmlTextWriter(stream, Encoding.UTF8);
            xtw.Formatting = Formatting.Indented;
            try
            {
                serializer.Serialize(stream, ListT);
            }
            catch { return null; }
            stream.Position = 0;
            string returnStr = string.Empty;
            using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    returnStr += line;
                }
            }
            return returnStr;
        }
        /// <summary>
        /// 将DataTable转化成JSON
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToJson(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            List<T> listT = ToList(dt);
            string Json = ToJson(listT);
            return Json;
        }
        /// <summary>
        /// 实体的复制
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T Copy(T t)
        {
            if (t == null)
            {
                return default(T);
            }
            T myEnrity = new T();
            Type myType = t.GetType();
            PropertyInfo currobj = null;
            PropertyInfo[] myProperties = myType.GetProperties();
            for (int i = 0; i < myProperties.Length; i++)
            {
                currobj = t.GetType().GetProperties()[i];
                currobj.SetValue(myEnrity, currobj.GetValue(t, null), null);
            }
            return myEnrity;
        }
        /// <summary>
        /// List的复制
        /// </summary>
        /// <param name="ListT"></param>
        /// <returns></returns>
        public static List<T> Copy(List<T> ListT)
        {
            if (ListT == null)
            {
                return null;
            }
            Type myType = ListT[0].GetType();
            List<T> myListT = new List<T>();
            PropertyInfo currobj = null;
            foreach (T t in ListT)
            {
                T t2 = new T();
                PropertyInfo[] myProperties = myType.GetProperties();
                for (int i = 0; i < myProperties.Length; i++)
                {
                    currobj = t.GetType().GetProperties()[i];
                    currobj.SetValue(t2, currobj.GetValue(t, null), null);
                }
                myListT.Add(t2);
            }
            return myListT;
        }
        /// <summary>
        /// 将一个实体插入List,如果List中已经存在该实体，则不插入。
        /// </summary>
        /// <param name="t">需要插入的实体</param>
        /// <param name="ListT">被插入的List</param>
        /// <param name="success">插入是否成功</param>
        /// <returns>插入成功，返回添加了新实体的List;插入失败，返回原来的List</returns>
        public static List<T> Insert(T t, List<T> ListT, out bool success)
        {
            success = true;
            if (t == null || ListT == null)
            {
                return null;
            }
            else if (ListT.Count == 0)
            {
                success = true;
            }
            else if (t != null && ListT.Count > 0)
            {
                string Json = ToJson(t);
                foreach (T myt in ListT)
                {
                    string myJson = ToJson(myt);
                    if (myJson == Json)
                    {
                        success = false;
                        break;
                    }
                }
            }
            if (success)
            {
                ListT.Add(t);
            }
            return ListT;
        }
    }
}