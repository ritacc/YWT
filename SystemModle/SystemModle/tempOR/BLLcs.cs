using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

namespace SystemModle.tempOR
{
    public abstract class BLLcs : Common
    {

        protected string m_usingNamespace;
        /// <summary>
        /// {0}:引用命名空间
        /// </summary>
        public string UsingNamespace
        {
            get { return m_usingNamespace; }
            set { m_usingNamespace = value; }
        }

        protected string m_namespace;
        /// <summary>
        /// {1}命名空间
        /// </summary>
        public string Namespace
        {
            get { return m_namespace; }
            set { m_namespace = value; }
        }
        protected string m_tableTitle;
        /// <summary>
        /// {2}表标题
        /// </summary>
        public string TableTitle
        {
            get { return m_tableTitle; }
            set { m_tableTitle = value; }
        }

        protected string m_className;
        /// <summary>
        /// {3}表名
        /// </summary>
        public string ClassName
        {
            get { return m_className; }
            set { m_className = value; }
        }

        protected string m_orContent;
        /// <summary>
        /// {4}内容
        /// </summary>
        public string OrContent
        {
            get { return m_orContent; }
            set { m_orContent = value; }
        }

        protected string m_tableAllName;
        /// <summary>
        /// 数据库中表的名称,上面的为，最后的名称，没有t_<模块>
        /// </summary>
        public string TableAllName
        {
            get { return m_tableAllName; }
            set { m_tableAllName = value; }
        }

        public abstract void getContent(DataTable dt, SystemModle.Access.AccessDB accessDB, List<string> primaryKeys);

    }

    public class BLLCsOracle : BLLcs
    {
        public override void getContent(DataTable dt, SystemModle.Access.AccessDB accessDB, List<string> primaryKeys)
        {
            StringBuilder sbKeyParameter = new StringBuilder();
            StringBuilder sbParameter = new StringBuilder();
            StringBuilder sbDbNull = new StringBuilder();

            string paramClassName;  // 实体类的参数 如 SysMods 其声明的参数 为 sysMods            
            string validatorType = string.Empty; // 验证类型
            string modelName;
            string m_SC = getSC(m_className);
            StringBuilder sb = new StringBuilder();
            modelName = m_namespace;
            paramClassName = m_className.Substring(0, 1).ToLower() + m_className.Substring(1);
            string paramKey = string.Empty;
            string whereKey = string.Empty;
            string formatKey = string.Empty;
            string updateKey = string.Empty;
            string s = string.Empty;
            string key = string.Empty;

            sbKeyParameter = new StringBuilder();
            string selectField = string.Empty;
            string updateField = string.Empty;
            string paramField = string.Empty;
            sbParameter = new StringBuilder();
            sbDbNull = new StringBuilder();
            //据跟据条件查询数
            sb.AppendLine("#region 查询\n");
            sb.AppendLine("        public DataTable SelectAllByWhere(string strWhere, int startIndex, int endIndex, out int RecordCount)");
            sb.AppendLine("        {");
            sb.AppendLine("            RecordCount = 0;");
            sb.AppendLine("            return new " + m_className + "DA().SelectAllByWhere(strWhere,  startIndex,  endIndex, out  RecordCount);");
            sb.AppendLine("        }");


            //选择一条数据
            sb.AppendLine(string.Format("        public {0}OR selectARowDate(string m_id)", m_className));
            sb.AppendLine("        {");
            sb.AppendLine("            return new " + m_className + "DA().selectARowDate(m_id);");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");

            // INSERT
            sb.AppendLine("        #region 插入");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 插入");
            sb.AppendLine("        /// </summary>");


            sb.AppendLine(string.Format("        public  bool Insert({0}OR {1})", m_className, paramClassName));
            sb.AppendLine("        {");
            sb.AppendLine("            return new " + m_className + "DA().Insert(" + paramClassName + ");");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");


            // UPDATE            
            sb.AppendLine("        #region 更新");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 更新");
            sb.AppendLine("        /// </summary>");
            sb.Append("        public bool Update(");
            sb.Append(m_className);
            sb.Append("OR ");
            sb.Append(paramClassName);
            sb.AppendLine(")");
            sb.AppendLine("        {");
            sb.AppendLine("            return new " + m_className + "DA().Update(" +  paramClassName + ");");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");

            // DELETE
            sb.AppendLine("        #region 删除");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 删除");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public bool Delete(string id)");
            sb.AppendLine("        {");
            sb.AppendLine("            return new " + m_className + "DA().Delete(id);");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");

            m_orContent = sb.ToString();
        }
    }

    public class BLLCsSql : BLLcs
    {
        public override void getContent(DataTable dt, SystemModle.Access.AccessDB accessDB, List<string> primaryKeys)
        {
            StringBuilder sbKeyParameter = new StringBuilder();
            StringBuilder sbParameter = new StringBuilder();
            StringBuilder sbDbNull = new StringBuilder();

            string paramClassName;  // 实体类的参数 如 SysMods 其声明的参数 为 sysMods            
            string validatorType = string.Empty; // 验证类型
            string modelName;
            string m_SC = getSC(m_className);
            StringBuilder sb = new StringBuilder();
            modelName = m_namespace;
            paramClassName = m_className.Substring(0, 1).ToLower() + m_className.Substring(1);
            string paramKey = string.Empty;
            string whereKey = string.Empty;
            string formatKey = string.Empty;
            string updateKey = string.Empty;
            string s = string.Empty;
            string key = string.Empty;

            sbKeyParameter = new StringBuilder();
            string selectField = string.Empty;
            string updateField = string.Empty;
            string paramField = string.Empty;
            sbParameter = new StringBuilder();
            sbDbNull = new StringBuilder();
            //据跟据条件查询数
            sb.AppendLine("#region 查询\n");
            sb.AppendLine("        public DataTable SelectAllByWhere(string strWhere, int startIndex, int endIndex, out int RecordCount)");
            sb.AppendLine("        {");
            sb.AppendLine("            RecordCount = 0;");
            sb.AppendLine("            return new " + m_className + "DA().SelectAllByWhere(strWhere,  startIndex,  endIndex, out  RecordCount);");
            sb.AppendLine("        }");


            //选择一条数据
            sb.AppendLine(string.Format("        public {0}OR selectARowDate(string m_id)", m_className));
            sb.AppendLine("        {");
            sb.AppendLine("            return new " + m_className + "DA().selectARowDate(m_id);");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");

            // INSERT
            sb.AppendLine("        #region 插入");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 插入");
            sb.AppendLine("        /// </summary>");


            sb.AppendLine(string.Format("        public  bool Insert({0}OR {1})", m_className, paramClassName));
            sb.AppendLine("        {");
            sb.AppendLine("            return new " + m_className + "DA().Insert(" + paramClassName + ");");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");


            // UPDATE            
            sb.AppendLine("        #region 更新");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 更新");
            sb.AppendLine("        /// </summary>");
            sb.Append("        public bool Update(");
            sb.Append(m_className);
            sb.Append("OR ");
            sb.Append(paramClassName);
            sb.AppendLine(")");
            sb.AppendLine("        {");
            sb.AppendLine("            return new " + m_className + "DA().Update(" + paramClassName + ");");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");

            // DELETE
            sb.AppendLine("        #region 删除");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 删除");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public bool Delete(string id)");
            sb.AppendLine("        {");
            sb.AppendLine("            return new " + m_className + "DA().Delete(id);");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");

            m_orContent = sb.ToString();
        }
    }

    public class BLLCsMysql : BLLcs
    {
        public override void getContent(DataTable dt, SystemModle.Access.AccessDB accessDB, List<string> primaryKeys)
        {
            StringBuilder sbKeyParameter = new StringBuilder();
            StringBuilder sbParameter = new StringBuilder();
            StringBuilder sbDbNull = new StringBuilder();

            string paramClassName;  // 实体类的参数 如 SysMods 其声明的参数 为 sysMods            
            string validatorType = string.Empty; // 验证类型
            string modelName;
            string m_SC = getSC(m_className);
            StringBuilder sb = new StringBuilder();
            modelName = m_namespace;
            paramClassName = m_className.Substring(0, 1).ToLower() + m_className.Substring(1);
            string paramKey = string.Empty;
            string whereKey = string.Empty;
            string formatKey = string.Empty;
            string updateKey = string.Empty;
            string s = string.Empty;
            string key = string.Empty;

            sbKeyParameter = new StringBuilder();
            string selectField = string.Empty;
            string updateField = string.Empty;
            string paramField = string.Empty;
            sbParameter = new StringBuilder();
            sbDbNull = new StringBuilder();
            //据跟据条件查询数
            sb.AppendLine("#region 查询\n");
            sb.AppendLine("        public DataTable SelectAllByWhere(string strWhere, int startIndex, int endIndex, out int RecordCount)");
            sb.AppendLine("        {");
            sb.AppendLine("            RecordCount = 0;");
            sb.AppendLine("            return new " + m_className + "DA().SelectAllByWhere(strWhere,  startIndex,  endIndex, out  RecordCount);");
            sb.AppendLine("        }");


            //选择一条数据
            sb.AppendLine(string.Format("        public {0}OR selectARowDate(string m_id)", m_className));
            sb.AppendLine("        {");
            sb.AppendLine("            return new " + m_className + "DA().selectARowDate(m_id);");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");

            // INSERT
            sb.AppendLine("        #region");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 插入");
            sb.AppendLine("        /// </summary>");


            sb.AppendLine(string.Format("        public  bool Insert({0}OR {1})", m_className, paramClassName));
            sb.AppendLine("        {");
            sb.AppendLine("            return new " + m_className + "DA().Insert(" + string.Format("{0}OR {1})", m_className, paramClassName) + ");");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");


            // UPDATE            
            sb.AppendLine("        #region");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 更新");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public bool Update(");
            sb.Append(m_className);
            sb.Append("OR ");
            sb.Append(paramClassName);
            sb.Append(")");
            sb.AppendLine("        {");
            sb.AppendLine("            return new " + m_className + "DA().Update(" + string.Format("{0}OR {1})", m_className, paramClassName) + ");");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");

            // DELETE
            sb.AppendLine("        #region");
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// 删除");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        public bool Delete(string id)");
            sb.AppendLine("        {");
            sb.AppendLine("            return new " + m_className + "DA().Delete(id);");
            sb.AppendLine("        }");
            sb.AppendLine("        #endregion");

            m_orContent = sb.ToString();
        }

        private string GetRepleceVariable(string dataType, string Filds)
        {
            if (dataType == "string")
                return Filds;
            else if (dataType == "bool")
                return string.Format("boolGetFlag({0})", Filds);
            else if (dataType == "int")
                return string.Format("{0}.ToString()", Filds);
            else
                return Filds;
        }

        private string GetInsertValues(string dataType, string Filds)
        {
            if (dataType == "string")
                return string.Format("'@{0}'", Filds);
            else
                return Filds;
        }
    }

    public class BLLcsFactory
    {
        public static BLLcs Create()
        {
            BLLcs _bl = null;
            if (frmBuildCode.Privider == "MSDAORA")
            {
                _bl = new BLLCsOracle();
            }
            else if (frmBuildCode.Privider == "SQLOLEDB")
            {
                _bl = new BLLCsSql();
            }
            return _bl;
        }
    }
}
