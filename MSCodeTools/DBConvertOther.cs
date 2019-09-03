using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCodeTools
{
  public  class DBConvertOther
    {
        #region 全局变量
        static string ModelNameSpace = "Model";
        static char DicSplit = '≡';//分隔符，注意：代码不是因此出错，建议不要修改 
        #endregion
      #region 得到数据库中所有表及字段

      public static Dictionary<string, Dictionary<string, string>> GetDBInfo(string connStr)
      {
          //Dictionary<{表,说明},Dictionary<{字段,说明},数据类型>>
          Dictionary<string, Dictionary<string, string>> dicR = new Dictionary<string, Dictionary<string, string>>();
          string getTables = " SELECT name FROM sysobjects  WHERE xtype = 'U' ";

          DataTable dt = MSSQLHelper.GetTable(connStr, getTables);
          foreach (DataRow item in dt.Rows)
          {
              string tblName = item[0].ToString();
              //"SELECT COLUMN_NAME,DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='" + tblName+"' ";
              string getTblFields = @"SELECT 
                    表名       = case when a.colorder=1 then d.name else '' end,
                    表说明     = case when a.colorder=1 then isnull(f.value,'') else '' end,
                    字段序号   = a.colorder,
                    字段名     = a.name,
                    标识       = case when COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 then '√'else '' end,
                    主键       = case when exists(SELECT 1 FROM sysobjects where xtype='PK' and parent_obj=a.id and name in (
                                     SELECT name FROM sysindexes WHERE indid in( SELECT indid FROM sysindexkeys WHERE id = a.id AND colid=a.colid))) then '√' else '' end,
                    类型       = b.name,
                    占用字节数 = a.length,
                    长度       = COLUMNPROPERTY(a.id,a.name,'PRECISION'),
                    小数位数   = isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0),
                    允许空     = case when a.isnullable=1 then '√'else '' end,
                    默认值     = isnull(e.text,''),
                    字段说明   = isnull(g.[value],'')
                FROM 
                    syscolumns a
                left join 
                    systypes b 
                on 
                    a.xusertype=b.xusertype
                inner join 
                    sysobjects d 
                on 
                    a.id=d.id  and d.xtype='U' and  d.name<>'dtproperties'
                left join 
                    syscomments e 
                on 
                    a.cdefault=e.id
                left join 
                sys.extended_properties   g 
                on 
                    a.id=G.major_id and a.colid=g.minor_id  
                left join
                sys.extended_properties f
                on 
                    d.id=f.major_id and f.minor_id=0
                where   d.name='" + tblName + "'   order by  a.id,a.colorder";
              DataTable dtTbl = MSSQLHelper.GetTable(connStr, getTblFields);
              Dictionary<string, string> dicItem = new Dictionary<string, string>();
              foreach (DataRow tbl in dtTbl.Rows)
              {
                  if (tbl[1].ToString() != "")
                      tblName += DicSplit + tbl[1].ToString();
                  string COLUMN_NAME = tbl[3].ToString() + DicSplit + tbl[12].ToString();
                  string DATA_TYPE = tbl[6].ToString();
                  dicItem.Add(COLUMN_NAME, DATA_TYPE);
              }
              dicR.Add(tblName, dicItem);
          }
          return dicR;
      }
      #endregion


        #region 获取单表及字段
      public static Dictionary<string, Dictionary<string, string>> GetTableInfo(string connStr, string tblName)
      {
          //Dictionary<{表,说明},Dictionary<{字段,说明},数据类型>>
          Dictionary<string, Dictionary<string, string>> dicR = new Dictionary<string, Dictionary<string, string>>();
          //"SELECT COLUMN_NAME,DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='" + tblName+"' ";
          string getTblFields = @"SELECT 
                    表名       = case when a.colorder=1 then d.name else '' end,
                    表说明     = case when a.colorder=1 then isnull(f.value,'') else '' end,
                    字段序号   = a.colorder,
                    字段名     = a.name,
                    标识       = case when COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 then '√'else '' end,
                    主键       = case when exists(SELECT 1 FROM sysobjects where xtype='PK' and parent_obj=a.id and name in (
                                     SELECT name FROM sysindexes WHERE indid in( SELECT indid FROM sysindexkeys WHERE id = a.id AND colid=a.colid))) then '√' else '' end,
                    类型       = b.name,
                    占用字节数 = a.length,
                    长度       = COLUMNPROPERTY(a.id,a.name,'PRECISION'),
                    小数位数   = isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0),
                    允许空     = case when a.isnullable=1 then '√'else '' end,
                    默认值     = isnull(e.text,''),
                    字段说明   = isnull(g.[value],'')
                FROM 
                    syscolumns a
                left join 
                    systypes b 
                on 
                    a.xusertype=b.xusertype
                inner join 
                    sysobjects d 
                on 
                    a.id=d.id  and d.xtype='U' and  d.name<>'dtproperties'
                left join 
                    syscomments e 
                on 
                    a.cdefault=e.id
                left join 
                sys.extended_properties   g 
                on 
                    a.id=G.major_id and a.colid=g.minor_id  
                left join
                sys.extended_properties f
                on 
                    d.id=f.major_id and f.minor_id=0
                where   d.name='" + tblName + "'   order by  a.id,a.colorder";
          DataTable dtTbl = MSSQLHelper.GetTable(connStr, getTblFields);
          Dictionary<string, string> dicItem = new Dictionary<string, string>();
          foreach (DataRow tbl in dtTbl.Rows)
          {
              if (tbl[1].ToString() != "")
                  tblName += DicSplit + tbl[1].ToString();
              string COLUMN_NAME = tbl[3].ToString() + DicSplit + tbl[12].ToString();
              string DATA_TYPE = tbl[6].ToString();
              dicItem.Add(COLUMN_NAME, DATA_TYPE);
          }
          dicR.Add(tblName, dicItem);
          return dicR;
      }
        #endregion


      #region 遍历生成Model层代码
      public static string ModelFactory(Dictionary<string, Dictionary<string, string>> dic)
      {
          StringBuilder re = new StringBuilder();
          foreach (var item in dic)
          {
              #region 类模板
              StringBuilder sb = new StringBuilder();
              sb.Append("  using System;                                        \r\n");
              sb.Append("  using System.Text;                                   \r\n");
              sb.Append("                                                       \r\n");
              sb.Append("  /**************************************************  \r\n");
              sb.Append("   * 类 名 称 :  【类名称】                            \r\n");
              sb.Append("   * 版 本 号 :  v1.0.0.0                              \r\n");
              sb.Append("   * 说    明 :  【表职责】                            \r\n");
              sb.Append("   * 作    者 :                                        \r\n");
              sb.Append("   * 创建时间 : 【时间戳】                                \r\n");
              sb.Append("  **************************************************/  \r\n");
              sb.Append("  namespace 【命名空间】                                  \r\n");
              sb.Append("  {                                                    \r\n");
              sb.Append("      public class 【表】                               \r\n ");
              sb.Append("      {                                                \r\n");
              sb.Append("                                                       \r\n");
              sb.Append("          public 【表】()                              \r\n");
              sb.Append("          {                                           \r\n ");
              sb.Append("          }                                           \r\n ");
              sb.Append("         【属性部分】                                  \r\n ");
              sb.Append("     }                                                \r\n ");
              sb.Append("  }                                                   \r\n ");

              #endregion

              #region 属性部分
              StringBuilder propPart = new StringBuilder();
              foreach (var field in item.Value)
              {
                  string[] key = field.Key.Split(DicSplit);
                  string type = ChangeToCSharpType(field.Value.ToString());//Dictionary<{表,说明},Dictionary<{字段,说明},数据类型>>
                  string fName = key[0];
                  string fRemark = key.Length == 2 ? key[1] : "";
                  string first = field.Key.Substring(0, 1);//第一个字母
                  fName = fName.Substring(1, fName.Length - 1);//不含第一个字母
                  string _f = first.ToLower() + fName;
                  string pF = first.ToUpper() + fName;
                  propPart.Append("                                                  \r\n");
                  propPart.AppendFormat("    private {0} {1};                          \r\n", type, _f);
                  propPart.AppendFormat("    //{0}                                       \r\n", fRemark);
                  propPart.AppendFormat("    public {0} {1}                              \r\n", type, pF);
                  propPart.Append("          {                                            \r\n");
                  propPart.Append("              get { return " + _f + "; }                     \r\n");
                  propPart.Append("              set { " + _f + " = value; }                    \r\n");
                  propPart.Append("          }                                            \r\n");
              }
              #endregion

              string[] tableInfo = item.Key.Split(DicSplit);
              string tblName = tableInfo[0];
              string tblWork = tableInfo.Length == 2 ? tableInfo[1] : "";
              string r = sb.ToString()
                      .Replace("【类名称】", tblName + "表实体类")
                      .Replace("【时间戳】", DateTime.Now.ToString())
                      .Replace("【命名空间】", ModelNameSpace)
                      .Replace("【表】", tblName)
                      .Replace("【表职责】", tblWork)
                      .Replace("【属性部分】", propPart.ToString());
              re.Append(r).Append("\r\n");
          }
          return re.ToString();

      }
      #endregion

      #region 遍历生成数据库代码
      public static string DBFactory(Dictionary<string, Dictionary<string, string>> dic)
      {
          StringBuilder re = new StringBuilder();
          foreach (var item in dic)
          {
              string[] tableInfo = item.Key.Split(DicSplit);
              string tblName = tableInfo[0];
              #region 查询
              StringBuilder sb1 = new StringBuilder();
              StringBuilder sb2 = new StringBuilder();
              StringBuilder sb3 = new StringBuilder();
              #endregion

              #region 参数部分
              StringBuilder propPart = new StringBuilder();
              int oneT = 0;
              propPart.Append(" --传入参数部分                                            \r\n");
              foreach (var field in item.Value)
              {
                  string[] key = field.Key.Split(DicSplit);
                  string type = field.Value.ToString();//Dictionary<{表,说明},Dictionary<{字段,说明},数据类型>>
                  string fName = key[0];
                  if (type == "nvarchar")
                  {
                      type = "nvarchar(50)";
                  }
                  if (type == "varchar")
                  {
                      type = "varchar(50)";
                  }
                  string fRemark = key.Length == 2 ? key[1] : "";
                  string first = field.Key.Substring(0, 1);//第一个字母
                  fName = fName.Substring(1, fName.Length - 1);//不含第一个字母
                  string _f = first.ToLower() + fName;
                  propPart.AppendFormat("@{0} {1},                          \r\n", _f, type);
                  oneT++;
              }
              #endregion

              #region 查询更新插入部分
              int twoT = 0;
              propPart.Append(" \r\n \r\n \r\n --查询部分                                            \r\n");
              propPart.Append("select ");

              sb1.Append(" \r\n\r\n \r\n  --更新部分                                            \r\n");
              sb1.AppendFormat("update {0} set ", tblName);

              sb2.Append(" \r\n\r\n \r\n  --插入部分                                            \r\n");
              sb2.AppendFormat("insert into {0}(", tblName);
              sb3.Append(" values(");
              foreach (var field in item.Value)
              {
                  twoT++;
                  string[] key = field.Key.Split(DicSplit);
                  string fName = key[0];
                  string fRemark = key.Length == 2 ? key[1] : "";
                  string first = field.Key.Substring(0, 1);//第一个字母
                  fName = fName.Substring(1, fName.Length - 1);//不含第一个字母
                  string _f = first.ToLower() + fName;
                  if (twoT % 5 == 0)
                  {
                      propPart.Append("\n");
                      sb1.Append("\n");
                      sb2.Append("\n");
                      sb3.Append("\n");
                  }
                  if (twoT == oneT)
                  {
                      propPart.AppendFormat("[{0}] ", _f);
                      sb1.AppendFormat("[{0}]=@{0}", _f);
                      sb2.AppendFormat("[{0}])", _f);
                      sb3.AppendFormat("@{0})", _f);
                  }
                  else
                  {
                      propPart.AppendFormat("[{0}],", _f);
                      sb1.AppendFormat("[{0}]=@{0},", _f);
                      sb2.AppendFormat("[{0}],", _f);
                      sb3.AppendFormat("@{0},", _f);
                  }
              }
              propPart.AppendFormat("from {0}", tblName);
              #endregion

              string r = propPart.ToString()+sb1.ToString()+sb2.ToString()+sb3.ToString();
              re.Append(r).Append("\r\n");
          }
          return re.ToString();

      }
      #endregion


      #region 遍历生成param代码
      public static string ParamFactory(Dictionary<string, Dictionary<string, string>> dic)
      {
          StringBuilder re = new StringBuilder();
          foreach (var item in dic)
          {
              #region param参数部分
              StringBuilder propPart = new StringBuilder();
              int x = 0;
              propPart.Append("///param参数部分                                            \r\n");
              propPart.Append("SqlParameter[] p = {\r\n");
              foreach (var field in item.Value)
              {
                  string[] key = field.Key.Split(DicSplit);
                  string type = field.Value.ToString();//Dictionary<{表,说明},Dictionary<{字段,说明},数据类型>>
                  string fName = key[0];
                  string fRemark = key.Length == 2 ? key[1] : "";
                  string first = field.Key.Substring(0, 1);//第一个字母
                  fName = fName.Substring(1, fName.Length - 1);//不含第一个字母
                  string _f = first.ToUpper() + fName;
                  if(x==0)
                      propPart.AppendFormat("    SqlHelper.MakeInParam(\"@{0}\",SqlDbType.{1},{2},{0}) \r\n", _f, ParaType(type), GetTypeNumb(type));
                  else
                      propPart.AppendFormat("    ,SqlHelper.MakeInParam(\"@{0}\",SqlDbType.{1},{2},{0}) \r\n", _f, ParaType(type), GetTypeNumb(type));

                  x++;
              }
              #endregion
              string r = propPart.Append(" };").ToString();
              re.Append(r).Append("\r\n");
          }
          return re.ToString();

      }
      #endregion


        #region sqlServer与C#类型对照
      // 数据库中与C#中的数据类型对照
      private static string ChangeToCSharpType(string type)
      {
          string reval = string.Empty;
          switch (type.ToLower())
          {
              case "int":
                  reval = "int";
                  break;
              case "text":
                  reval = "string";
                  break;
              case "bigint":
                  reval = "int";
                  break;
              case "binary":
                  reval = "byte[]";
                  break;
              case "bit":
                  reval = "bool";
                  break;
              case "char":
                  reval = "string";
                  break;
              case "datetime":
                  reval = "DateTime";
                  break;
              case "decimal":
                  reval = "decimal";
                  break;
              case "float":
                  reval = "double";
                  break;
              case "image":
                  reval = "byte[]";
                  break;
              case "money":
                  reval = "decimal";
                  break;
              case "nchar":
                  reval = "string";
                  break;
              case "ntext":
                  reval = "string";
                  break;
              case "numeric":
                  reval = "decimal";
                  break;
              case "nvarchar":
                  reval = "string";
                  break;
              case "real":
                  reval = "single";
                  break;
              case "smalldatetime":
                  reval = "DateTime";
                  break;
              case "smallint":
                  reval = "int";
                  break;
              case "smallmoney":
                  reval = "decimal";
                  break;
              case "timestamp":
                  reval = "DateTime";
                  break;
              case "tinyint":
                  reval = "int";
                  break;
              case "uniqueidentifier":
                  reval = "System.Guid";
                  break;
              case "varbinary":
                  reval = "byte[]";
                  break;
              case "varchar":
                  reval = "string";
                  break;
              case "Variant":
                  reval = "Object";
                  break;
              default:
                  reval = "string";
                  break;
          }
          return reval;
      }
        #endregion

      #region sqlServer类型对照
     private static string ParaType(string type)
      {
          string reval = string.Empty;
          switch (type.ToLower())
          {
              case "int":
                  reval = "Int";
                  break;
              case "text":
                  reval = "Text";
                  break;
              case "bigint":
                  reval = "BigInt";
                  break;
              case "binary":
                  reval = "Binary";
                  break;
              case "bit":
                  reval = "Bit";
                  break;
              case "char":
                  reval = "Char";
                  break;
              case "datetime":
                  reval = "DateTime";
                  break;
              case "decimal":
                  reval = "Decimal";
                  break;
              case "float":
                  reval = "Float";
                  break;
              case "image":
                  reval = "Image";
                  break;
              case "money":
                  reval = "Money";
                  break;
              case "nchar":
                  reval = "NChar";
                  break;
              case "ntext":
                  reval = "NText";
                  break;
              case "numeric":
                  reval = "Numeric";
                  break;
              case "nvarchar":
                  reval = "NVarChar";
                  break;
              case "real":
                  reval = "Real";
                  break;
              case "smalldatetime":
                  reval = "SmallDateTime";
                  break;
              case "smallint":
                  reval = "SmallInt";
                  break;
              case "smallmoney":
                  reval = "SmallMoney";
                  break;
              case "timestamp":
                  reval = "TimeStamp";
                  break;
              case "tinyint":
                  reval = "TinyInt";
                  break;
              case "uniqueidentifier":
                  reval = "Uniqueidentifier";
                  break;
              case "varbinary":
                  reval = "VarBinary";
                  break;
              case "varchar":
                  reval = "VarChar";
                  break;
              case "Variant":
                  reval = "Variant";
                  break;
              default:
                  reval = "NVarChar";
                  break;
          }
          return reval;
      }
      #endregion

        #region 类型转个数
      private static int GetTypeNumb(string type)
      {
          int reval = 8;
          switch (type.ToLower())
          {
              case "int":
                  reval = 8;
                  break;
              case "text":
                  reval = 99999;
                  break;
              case "bigint":
                  reval = 16;
                  break;
              case "bit":
                  reval = 4;
                  break;
              case "char":
                  reval = 4;
                  break;
              case "datetime":
                  reval = 20;
                  break;
              case "decimal":
                  reval = 18;
                  break;
              case "float":
                  reval = 18;
                  break;
              case "money":
                  reval = 18;
                  break;
              case "nchar":
                  reval = 50;
                  break;
              case "ntext":
                  reval = 50;
                  break;
              case "numeric":
                  reval = 18;
                  break;
              case "nvarchar":
                  reval = 50;
                  break;
              case "smalldatetime":
                  reval = 20;
                  break;
              case "smallint":
                  reval =4;
                  break;
              case "smallmoney":
                  reval = 18;
                  break;
              case "timestamp":
                  reval = 20;
                  break;
              case "tinyint":
                  reval = 4;
                  break;
              case "varchar":
                  reval = 50;
                  break;
              default:
                  reval = 99999;
                  break;
          }
          return reval;
      }
        #endregion
    }
}
