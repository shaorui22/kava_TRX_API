using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace TRX_KAVA_API.DAL
{
    public class DBHelper_SQLServer
    {
        #region 准备连接、命令变量
        /// <summary>
        /// 建立mysql数据库链接
        /// </summary>
        /// <returns></returns>
        public static SqlConnection getSqlCon()
        {
            String mysqlStr = System.Configuration.ConfigurationManager.AppSettings["dbConStrSQLServer"].ToString();
            //String mysqlStr = System.Configuration.ConfigurationManager.ConnectionStrings["dbConStrSQLServer"].ToString();
            SqlConnection mysql = new SqlConnection(mysqlStr);
            return mysql;
        }
        /// <summary>
        /// 建立执行命令语句对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="mysql"></param>
        /// <returns></returns>
        public static SqlCommand getSqlCommand(String sql, SqlConnection mysql)
        {
            SqlCommand mySqlCommand = new SqlCommand(sql, mysql);
            return mySqlCommand;
        }

        /// <summary>
        /// Command预处理
        /// </summary>
        /// <param name="conn">SqlConnection对象</param>
        /// <param name="trans">SqlTransaction对象，可为null</param>
        /// <param name="cmd">SqlCommand对象</param>
        /// <param name="cmdType">CommandType，存储过程或命令行</param>
        /// <param name="cmdText">SQL语句或存储过程名</param>
        /// <param name="cmdParms">SqlCommand参数数组，可为null</param>  
        public static void PrepareCommand(SqlConnection conn, SqlTransaction trans, SqlCommand cmd, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)

                conn.Open();

            cmd.Connection = conn;

            cmd.CommandText = cmdText;

            if (trans != null)

                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {

                foreach (SqlParameter parm in cmdParms)

                    cmd.Parameters.Add(parm);

            }

        }

        #endregion

        #region 查询类

        public static DataTable dtGetTableSchemaInfo(string tableName, string schemaName)
        {
            StringBuilder sbSqlTableInfo = new StringBuilder();
            sbSqlTableInfo.Append("SELECT  CASE WHEN col.colorder = 1 THEN obj.name  ELSE ''  END AS 表名, col.colorder AS 序号 ,  col.name AS 列名 , ISNULL(ep.[value], '') AS 列说明 ,  t.name AS 数据类型 ,  ");
            sbSqlTableInfo.Append("        col.length AS 长度 ,  ISNULL(COLUMNPROPERTY(col.id, col.name, 'Scale'), 0) AS 小数位数 ,");
            sbSqlTableInfo.Append("        CASE WHEN COLUMNPROPERTY(col.id, col.name, 'IsIdentity') = 1 THEN 'Y'  ELSE '' END AS 标识 ,");
            sbSqlTableInfo.Append("         CASE WHEN EXISTS ( SELECT 1 FROM     dbo.sysindexes si INNER JOIN dbo.sysindexkeys sik ON si.id = sik.id  AND si.indid = sik.indid");
            sbSqlTableInfo.Append("                            INNER JOIN dbo.syscolumns sc ON sc.id = sik.id AND sc.colid = sik.colid INNER JOIN dbo.sysobjects so ON so.name = si.name AND so.xtype = 'PK'");
            sbSqlTableInfo.Append("                            WHERE  sc.id = col.id  AND sc.colid = col.colid ) THEN 'Y'  ELSE '' END AS 主键 ,");
            sbSqlTableInfo.Append("         CASE WHEN col.isnullable = 1 THEN 'Y'  ELSE '' END AS 允许空 ,  ISNULL(comm.text, '') AS 默认值 ");
            sbSqlTableInfo.Append("FROM    dbo.syscolumns col  LEFT  JOIN dbo.systypes t ON col.xtype = t.xusertype  inner JOIN dbo.sysobjects obj ON col.id = obj.id AND obj.xtype = 'U' AND obj.status >= 0");
            sbSqlTableInfo.Append("         LEFT  JOIN dbo.syscomments comm ON col.cdefault = comm.id  LEFT  JOIN sys.extended_properties ep ON col.id = ep.major_id  AND col.colid = ep.minor_id AND ep.name = 'MS_Description' ");
            sbSqlTableInfo.Append("          LEFT  JOIN sys.extended_properties epTwo ON obj.id = epTwo.major_id  AND epTwo.minor_id = 0 AND epTwo.name = 'MS_Description'");
            sbSqlTableInfo.Append("  WHERE   obj.name = '" + tableName + "' ORDER BY col.colorder ;");
            return ExecuteDataTable(sbSqlTableInfo.ToString());
        }

        public static DataSet ExecuteDataSet(string cmdText)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection mysql = getSqlCon())
            {

                PrepareCommand(mysql, null, cmd, CommandType.Text, cmdText, null);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);

                mysql.Close();

                cmd.Parameters.Clear();

                return ds;

            }

        }

        public static DataTable ExecuteDataTable(string sql_text)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection sqlConn = getSqlCon())
            {

                PrepareCommand(sqlConn, null, cmd, CommandType.Text, sql_text, null);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("table1");

                da.Fill(dt);

                sqlConn.Close();

                cmd.Parameters.Clear();

                return dt;

            }
        }


        public DataTable Query(string SQLString)
        {
            DataTable dt = new DataTable();

            SqlConnection sqlConn = new SqlConnection();

            try
            {
                sqlConn = new SqlConnection(
                Convert.ToString(ConfigurationManager.AppSettings["dbConStrSQLServer"].ToString()));

                sqlConn.Open();


                SqlDataAdapter dataAdapter = new SqlDataAdapter(SQLString, sqlConn);

                dataAdapter.Fill(dt);

                sqlConn.Close();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (sqlConn.State != System.Data.ConnectionState.Closed)
                    sqlConn.Close();
            }

            return dt;
        }

        public static DataTable Query_ERP(string SQLString)
        {
            DataTable dt = new DataTable();

            SqlConnection sqlConn = new SqlConnection();

            try
            {
                sqlConn = new SqlConnection(
                Convert.ToString(ConfigurationManager.AppSettings["dbSQLServer2012"].ToString()));

                sqlConn.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(SQLString, sqlConn);

                dataAdapter.Fill(dt);

                sqlConn.Close();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (sqlConn.State != System.Data.ConnectionState.Closed)
                    sqlConn.Close();
            }

            return dt;
        }


        public static DataTable ExecuteDataTable(string sql_text, SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection sqlConn = getSqlCon())
            {

                PrepareCommand(sqlConn, null, cmd, CommandType.Text, sql_text, cmdParms);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("dt1");

                da.Fill(dt);

                sqlConn.Close();

                cmd.Parameters.Clear();

                return dt;

            }
        }
        public static T GetDataValue<T>(IDataReader dr, string columnName)
        {
            // NOTE: GetOrdinal() is used to automatically determine where the column
            //       is physically located in the database table. This allows the
            //       schema to be changed without affecting this piece of code.
            //       This of course sacrifices a little performance for maintainability.
            int i = dr.GetOrdinal(columnName);

            if (!dr.IsDBNull(i))
                return (T)dr.GetValue(i);
            else
                return default(T);
        }

        public static SqlDataReader ExecuteReader(string cmdText, params SqlParameter[] cmdParms)
        {
            //数据库操作命令对象
            SqlCommand cmd = new SqlCommand();
            //数据库连接
            SqlConnection conn = getSqlCon();

            try
            {

                PrepareCommand(conn, null, cmd, CommandType.Text, cmdText, cmdParms);

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                cmd.Parameters.Clear();

                return dr;

            }

            catch (Exception exc)
            {

                conn.Close();
                LogHelper.Error("执行查询Reader语句错误：" + cmdText + "\r\n" + exc.Message + "\r\n" + exc.StackTrace);
                return null;

            }
        }

        /// <summary>
        /// 执行SQL语句查询 (带参数 及命令类型，如存储过程)，返回第一行，第一列内容
        /// </summary>
        /// <param name="strSQL">要执行的SQL语句</param>
        /// <param name="paras">参数列表，没有参数填入null</param>
        /// <returns>返回影响行数</returns>
        public static object ExcuteScalarSQL(string strSQL, SqlParameter[] paras, CommandType cmdType)
        {
            object i = null;
            using (SqlConnection conn = getSqlCon())
            {
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                cmd.CommandType = cmdType;
                if (paras != null)
                {
                    cmd.Parameters.AddRange(paras);
                }
                conn.Open();
                i = cmd.ExecuteScalar();
                conn.Close();
            }
            return i;
        }
        /// <summary>
        /// 执行SQL语句查询（带参数），返回第一行，第一列内容
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static object ExcuteScalarSQL(string strSQL, SqlParameter[] paras)
        {
            return ExcuteScalarSQL(strSQL, paras, CommandType.Text);
        }
        /// <summary>
        /// 执行SQL语句查询（不带参数），返回第一行，第一列内容
        /// </summary>
        /// <param name="strSQL"></param>
        /// <returns></returns>
        public static object ExcuteScalarSQL(string strSQL)
        {
            return ExcuteScalarSQL(strSQL, null);
        }
        #endregion

        #region 非查询类，增删改
        public static bool UpdateSQL(string sql_text)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = getSqlCon();
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = sql_text;
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery();   //执行非查询语句，返回受影响的数据行数。
                cmd.Parameters.Clear();
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
                if (i > 0)  //更新成功
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exc)  //捕捉到错误，也返回失败。
            {
                cmd.Parameters.Clear();
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
                ////写错误日志
                LogHelper.Error("执行更新语句错误：" + cmd.CommandText + "\r\n" + exc.Message + "\r\n" + exc.StackTrace);
                return false;
            }

        }

        public static int ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                //using映入命名空间
                using (SqlConnection conn = getSqlCon())
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    cmd.Connection = conn;
                    int val = cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                    return val;
                }
            }
            catch (Exception exc)
            {
                LogHelper.Error("执行语句遇到错误\r\n" + exc.Message + "语句：" + cmd.CommandText + "\r\n" + exc.StackTrace);
                return 0;
            }

        }
        /// <summary>
        /// 根据SQL语句，返回object对象
        /// </summary>
        /// <param name="sqlstr">SQL语句</param>
        /// <param name="pas">参数数组</param>
        /// <param name="cmdtype">Commad类型</param>
        /// <returns>返回值object对象数组，即参数数组中的返回值</returns>
        /// //存储过程
        public static object[] ExecuteProcedure(string procedureName, ref SqlParameter[] pas)
        {
            List<object> rtn = new List<object>();

            using (SqlConnection conn = getSqlCon())
            {

                SqlCommand cmd = new SqlCommand();
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procedureName;
                    #region 引用本方法前，添加参数示例
                    //SqlParameter[] parm = new SqlParameter[3];
                    ////in
                    //parm[0] = new OracleParameter("skus", OracleDbType.Varchar2, 32767);   // 与SQL区别,sql存储过程需要在定义与此处,在其参数前加"@"符号;
                    //parm[1] = new OracleParameter("dateSpan", OracleDbType.Varchar2);

                    ////out
                    //parm[2] = new OracleParameter("rsult", OracleDbType.Clob);


                    ////指明参数是输入还是输出型
                    //for (int i = 0; i < parm.Length - 1; i++)
                    //{
                    //    parm[i].Direction = ParameterDirection.Input;
                    //}
                    //parm[2].Direction = ParameterDirection.InputOutput;


                    ////给参数赋值
                    //parm[0].Value = skus;
                    //parm[1].Value = dateSpan;
                    //parm[2].Value = rtn; 
                    #endregion

                    //传递参数给cmd命令 
                    for (int i = 0; i < pas.Length; i++)
                    {
                        cmd.Parameters.Add(pas[i]);
                    }

                    //打开连接
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    cmd.Connection = conn;
                    int va = cmd.ExecuteNonQuery();

                    //取出返回值
                    foreach (var item in pas)
                    {
                        if (item.Direction == ParameterDirection.ReturnValue || item.Direction == ParameterDirection.Output || item.Direction == ParameterDirection.InputOutput)
                        {
                            rtn.Add(item);
                        }
                    }

                }
                catch  (Exception exc)
                {
                    LogHelper.Error("执行存储过程"+ procedureName + "错误："+exc.Message+"\r\n"+exc.StackTrace);
                }
                finally
                {
                    //关闭连接,释放空间.
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }

            }
            return rtn.ToArray();
        }
        #endregion
         
        /// <summary>
        /// 根据传入的表名、主键字段名、主键值、参数字典来更新某条记录的部分字段。
        /// </summary>
        /// <param name="TableName">要更新的表名</param>
        /// <param name="PKColumnName">该表主键字段</param>
        /// <param name="PKValue">这次更新的记录所在主键值</param>
        /// <param name="ParamentKVLPs">要更新的字段及值字典</param>
        /// <returns>执行更新成功返回true,更新失败返回false</returns>
        public static bool updateByMulityColumnValuesAndPK(string TableName, string PKColumnName, object PKValue, List<KVP> ParamentKVLPs)
        {

            StringBuilder sb_update = new StringBuilder();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            sb_update.Append(" update  " + TableName + " set ");
            int paraTerm = 0;
            try
            {
                foreach (var item in ParamentKVLPs)
                {
                    if (PKColumnName != item.Key)
                    {
                        #region 非主键列
                        if (paraTerm < ParamentKVLPs.Count - 2)
                        {
                            sb_update.Append(item.Key + " = @" + item.Key + ",");
                        }
                        else
                        {
                            sb_update.Append(item.Key + " = @" + item.Key);   ////最后一列不能再加逗号
                        }
                        var kkk = item.Value.GetType().ToString().ToLower();
                        switch (kkk)  //根据参数值的类型，来赋予该参数的类型
                        {
                            #region 赋予该参数的类型
                            case "system.string":
                                {
                                    cmd.Parameters.Add(new SqlParameter("@" + item.Key, SqlDbType.NVarChar) { Value = item.Value });
                                    break;
                                }
                            case "system.int32":
                                {
                                    cmd.Parameters.Add(new SqlParameter("@" + item.Key, SqlDbType.Int) { Value = item.Value });
                                    break;
                                }
                            case "system.decimal":
                                {
                                    cmd.Parameters.Add(new SqlParameter("@" + item.Key, SqlDbType.Decimal) { Value = item.Value });
                                    break;
                                }
                            case "system.datetime":
                                {
                                    cmd.Parameters.Add(new SqlParameter("@" + item.Key, SqlDbType.DateTime) { Value = item.Value });
                                    break;
                                }
                            case "system.float":
                                {
                                    cmd.Parameters.Add(new SqlParameter("@" + item.Key, SqlDbType.Float) { Value = item.Value });
                                    break;
                                }
                            case "system.bool":
                                {
                                    cmd.Parameters.Add(new SqlParameter("@" + item.Key, SqlDbType.Bit) { Value = item.Value });
                                    break;
                                }
                            case "system.boolean":
                                {
                                    cmd.Parameters.Add(new SqlParameter("@" + item.Key, SqlDbType.Bit) { Value = item.Value });
                                    break;
                                }
                                #endregion
                        }
                        #endregion
                    }
                    paraTerm++;
                }
                sb_update.Append(" where  " + PKColumnName + " = @" + PKColumnName);   //根据主键的值 找到要更新的记录行,也是以参数化的形式加入。
                var vvv = PKValue.GetType().ToString().ToLower();
                switch (vvv)  //主键有字符串型也有整型
                {
                    case "system.string":
                        {
                            cmd.Parameters.Add(new SqlParameter("@" + PKColumnName, SqlDbType.NVarChar, 150) { Value = PKValue });
                            break;
                        }
                    case "system.int32":
                        {
                            cmd.Parameters.Add(new SqlParameter("@" + PKColumnName, SqlDbType.Int) { Value = PKValue });
                            break;
                        }
                }
                cmd.CommandText = sb_update.ToString();
                int val = ExecuteNonQuery(cmd);
                if (val > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exc)
            {
                LogHelper.Error("执行更新语句错误：" + cmd.CommandText + "\r\n" + exc.Message + "\r\n" + exc.StackTrace);
                return false;
            }
        }


        public static bool InsertByTableName(string TableName, List<KVP> ParamentKVLPs)
        {
            StringBuilder sb_insert = new StringBuilder();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            int paraTerm = 0;
            try
            {

                sb_insert.Append("Insert into " + TableName + "( ");
                string valuestr = ") values (";
                foreach (var item in ParamentKVLPs)
                {
                    if (paraTerm < ParamentKVLPs.Count - 1)
                    {
                        sb_insert.Append(item.Key + ",");
                        valuestr += "@" + item.Key + ",";
                    }
                    else
                    {
                        sb_insert.Append(item.Key);   ////最后一列不能再加逗号
                        valuestr += "@" + item.Key + ")";
                    }
                    var kkk = item.Value.GetType().ToString().ToLower();
                    switch (kkk)  //根据参数值的类型，来赋予该参数的类型
                    {
                        #region 赋予该参数的类型
                        case "system.string":
                            {
                                cmd.Parameters.Add(new SqlParameter("@" + item.Key, SqlDbType.NVarChar) { Value = item.Value });
                                break;
                            }
                        case "system.int32":
                            {
                                cmd.Parameters.Add(new SqlParameter("@" + item.Key, SqlDbType.Int) { Value = item.Value });
                                break;
                            }
                        case "system.int":
                            {
                                cmd.Parameters.Add(new SqlParameter("@" + item.Key, SqlDbType.Int) { Value = item.Value });
                                break;
                            }
                        case "system.decimal":
                            {
                                cmd.Parameters.Add(new SqlParameter("@" + item.Key, SqlDbType.Decimal) { Value = item.Value });
                                break;
                            }
                        case "system.datetime":
                            {
                                cmd.Parameters.Add(new SqlParameter("@" + item.Key, SqlDbType.DateTime) { Value = item.Value });
                                break;
                            }
                        case "system.float":
                            {
                                cmd.Parameters.Add(new SqlParameter("@" + item.Key, SqlDbType.Float) { Value = item.Value });
                                break;
                            }
                        case "system.double":
                            {
                                cmd.Parameters.Add(new SqlParameter("@" + item.Key, SqlDbType.Float) { Value = item.Value });
                                break;
                            }
                        case "system.bool":
                            {
                                cmd.Parameters.Add(new SqlParameter("@" + item.Key, SqlDbType.Bit) { Value = item.Value });
                                break;
                            }
                        case "system.boolean":
                            {
                                cmd.Parameters.Add(new SqlParameter("@" + item.Key, SqlDbType.Bit) { Value = item.Value });
                                break;
                            }
                            #endregion
                    }

                    paraTerm++;
                }
                sb_insert.Append(valuestr);

                cmd.CommandText = sb_insert.ToString();
                int val = ExecuteNonQuery(cmd);
                if (val > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exc)
            {
                LogHelper.Error("插入语句错误：" + cmd.CommandText + "\r\n" + exc.Message + "\r\n" + exc.StackTrace);
                return false;
            }
        }



        internal static DataTable GetOneRowRecordByTableNameAndPKvalue(string Tablename, string pkColumnname, object objPK)
        {
            StringBuilder sb = new StringBuilder();
            SqlParameter p = new SqlParameter();

            sb.Append(" select * from ");
            sb.Append(Tablename);
            sb.Append(" where ");
            sb.Append(pkColumnname + "=@" + pkColumnname);
            var vvv = objPK.GetType().ToString().ToLower();
            switch (vvv)  //主键有字符串型也有整型
            {
                case "system.string":
                    {
                        p = new SqlParameter("@" + pkColumnname, SqlDbType.NVarChar, 150);
                        p.Value = objPK;
                        break;
                    }
                case "system.int32":
                    {
                        p = new SqlParameter("@" + pkColumnname, SqlDbType.Int);
                        p.Value = objPK;
                        break;
                    }
            }
            return ExecuteDataTable(sb.ToString(), new SqlParameter[] { p });

        }


        #region ERP数据库链接
        public static int ExecuteNonQueryp(SqlCommand cmd)
        {
            try
            {
                //using映入命名空间
                using (SqlConnection conn = getSqlCon())
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    cmd.Connection = conn;
                    int val = cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                    return val;
                }
            }
            catch (Exception exc)
            {
                LogHelper.Error("执行语句遇到错误\r\n" + exc.Message + "语句：" + cmd.CommandText + "\r\n" + exc.StackTrace);
                return 0;
            }

        }
        #endregion


    }
}