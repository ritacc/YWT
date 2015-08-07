using System;
using System.Collections.Generic;
using System.Text;

namespace SystemModle.tempOR
{
  public  class ListAspxcs
    {
//      {0}:需要引用的命名空间
//{1}:表名
//{2}:继承类

        string m_usingNamespace;
        /// <summary>
        /// {0}:引用命名空间
        /// </summary>
        public string UsingNamespace
        {
            get { return m_usingNamespace; }
            set { m_usingNamespace = value; }
        }

        string m_useTableName;
        /// <summary>
        /// 引用类名
        /// </summary>
        public string UseTableName
        {
            get { return m_useTableName; }
            set { m_useTableName = value; }
        }

        string m_namespace;
        /// <summary>
        /// {2}继承类
        /// </summary>
        public string Namespace
        {
            get { return m_namespace; }
            set { m_namespace = value; }
        }

    }
}
