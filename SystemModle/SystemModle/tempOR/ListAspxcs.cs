using System;
using System.Collections.Generic;
using System.Text;

namespace SystemModle.tempOR
{
  public  class ListAspxcs
    {
//      {0}:��Ҫ���õ������ռ�
//{1}:����
//{2}:�̳���

        string m_usingNamespace;
        /// <summary>
        /// {0}:���������ռ�
        /// </summary>
        public string UsingNamespace
        {
            get { return m_usingNamespace; }
            set { m_usingNamespace = value; }
        }

        string m_useTableName;
        /// <summary>
        /// ��������
        /// </summary>
        public string UseTableName
        {
            get { return m_useTableName; }
            set { m_useTableName = value; }
        }

        string m_namespace;
        /// <summary>
        /// {2}�̳���
        /// </summary>
        public string Namespace
        {
            get { return m_namespace; }
            set { m_namespace = value; }
        }

    }
}
