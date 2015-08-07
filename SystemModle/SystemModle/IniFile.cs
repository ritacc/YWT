using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SystemModle
{
    public sealed class IniFile
    {
        private string path;

        /// <summary>
        /// ʵ����ʼ��Ϊָ��·����INI�ļ���
        /// </summary>
        /// <param name="path">INI�ļ�·����</param>
        public IniFile(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// ��ȡINI�ļ���·����
        /// </summary>
        public string Path
        {
            get
            {
                return path;
            }
        }

        /// <summary>
        /// ��ȡָ��С����ָ����Ŀ���ַ�����
        /// </summary>
        /// <param name="sectionName">�������в�����Ŀ��С�����ơ�����ִ������ִ�Сд��</param>
        /// <param name="keyName">����ȡ����������Ŀ��������ִ������ִ�Сд��</param>
        /// <param name="defaultValue">ָ������Ŀû���ҵ�ʱ���ص�Ĭ��ֵ��</param>
        /// <returns>ָ��С����ָ����Ŀ���ַ�����</returns>
        /// <remarks>���sectionNameΪnull���򷵻�����С�ڵ��б����keyNameΪnull��ָ��С����������б�</remarks>
        public string ReadString(string sectionName, string keyName, string defaultValue)
        {
            const int MAXSIZE = 255;
            StringBuilder temp = new StringBuilder(MAXSIZE);
            GetPrivateProfileString(sectionName, keyName, defaultValue, temp, 255, this.path);
            return temp.ToString();
        }

        public void WriteString(string sectionName, string keyName, string value)
        {
            WritePrivateProfileString(sectionName, keyName, value, this.path);
        }

        public int ReadInteger(string sectionName, string keyName, int defaultValue)
        {
            return GetPrivateProfileInt(sectionName, keyName, defaultValue, this.path);
        }

        public void WriteInteger(string sectionName, string keyName, int value)
        {
            WritePrivateProfileString(sectionName, keyName, value.ToString(), this.path);
        }

        public bool ReadBoolean(string sectionName, string keyName, bool defaultValue)
        {
            int temp = defaultValue ? 1 : 0;
            int result = GetPrivateProfileInt(sectionName, keyName, temp, this.path);
            return result != 0;
        }

        public void WriteBoolean(string sectionName, string keyName, bool value)
        {
            string temp = value ? "1" : "0";
            WritePrivateProfileString(sectionName, keyName, temp, this.path);
        }

        /// <summary>
        /// ɾ����������е��ִ���
        /// </summary>
        /// <param name="sectionName">Ҫ���õ���������Ŀ��������ִ������ִ�Сд��</param>
        /// <param name="keyName">Ҫɾ������������Ŀ��������ִ������ִ�Сд��</param>
        public void DeleteKey(string sectionName, string keyName)
        {
            WritePrivateProfileString(sectionName, keyName, null, this.path);
        }

        /// <summary>
        /// ɾ�����С�ڵ����������
        /// </summary>
        /// <param name="sectionName">Ҫɾ����С����������ִ������ִ�Сд��</param>
        public void EraseSection(string sectionName)
        {
            WritePrivateProfileString(sectionName, null, null, this.path);
        }

        [DllImport("kernel32")]
        public static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileInt(string lpApplicationName, string lpKeyName, int nDefault, string lpFileName);
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
    }
}
