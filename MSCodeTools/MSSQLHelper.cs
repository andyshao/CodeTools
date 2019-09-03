using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCodeTools
{
  public  class MSSQLHelper
    {
        //只读的静态数据库连接字符串
        public static readonly string connString = "Data Source=ip,port;Initial Catalog=database;User Id=username;Password=pass;";
        #region 完成数据的查询，返回DataTable
        /// <summary>
        /// 完成数据的查询，返回DataTable
        /// </summary>
        /// <param name="Sql">要执行的Sql</param>
        /// <param name="param">参数</param>
        /// <returns>DataTable</returns>
        public static DataTable GetTable(string connStr, string sql, params SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            //实例化连接对象，并指定连接字符串，自动释放资源，不用关闭
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter adp = new SqlDataAdapter(sql, conn))
            {
                if (param != null)
                {
                    adp.SelectCommand.Parameters.AddRange(param);
                }
                adp.Fill(dt);
            }
            return dt;
        }
        #endregion
        #region 判断连接是否成功
        public static string  CheckConn(string connStr)
        {
            string msg=string.Empty;
            try{
            //实例化连接对象，并指定连接字符串，自动释放资源，不用关闭
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                    //打开连接
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        msg="连接成功！";
                    }
                }
                return msg;
            }
           catch(Exception ex)
            {
                msg=string.Format(@"连接异常，{0}",ex.ToString());
               return msg;
           }
        }
        #endregion
    }
}
