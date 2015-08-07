using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.ConnectionUI;
using System.Data.OleDb;
using System.IO;
using System.Xml;

namespace SystemModle
{
    public partial class frmMain : Form
    {
        // 数据库交互对象
        private OleDbCommand _Command = null;
        // Ini文件访问类
        private IniFile _IniFile = null;

        private int depth = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化Ini配置文件地址
        /// </summary>
        private void InitIniFile()
        {
            if (null == _IniFile)
            {
                string path = Application.StartupPath + "\\setting.ini";
                _IniFile = new IniFile(path);
            }
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            // 初始化Ini配置文件地址
            InitIniFile();

            // 加载默认值
            tbxPath.Text = _IniFile.ReadString("MAIN", "SITEMAPPATH", string.Empty);
            tbxConnectString.Text = _IniFile.ReadString("MAIN", "CONNECTSTRING", string.Empty);
            bool isLevel2 = _IniFile.ReadInteger("MAIN", "MENUDEPTH", 3) == 2;
            rbtLevel2.Checked = isLevel2;
            rbtLevel3.Checked = !isLevel2;

            btnSetPermission.Enabled = tbxConnectString.Text != "";
            btnBuildCodeFile.Enabled = tbxConnectString.Text != "";
            btnBuildMod.Enabled = tbxConnectString.Text != "" && tbxPath.Text != "";
        }

       

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            //添加站点地图
            ofdSiteMap.Filter = "SiteMap(*.sitemap)|*.sitemap";
            if (ofdSiteMap.ShowDialog(this) == DialogResult.OK)
            {
                tbxPath.Text = ofdSiteMap.FileName;
                btnBuildMod.Enabled = tbxConnectString.Text != "";
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            DataConnectionDialog dialog = new DataConnectionDialog();
            //添加数据源列表，可以向窗口中添加自己程序所需要的数据源类型
            dialog.DataSources.Add(DataSource.SqlDataSource);
            dialog.DataSources.Add(DataSource.OracleDataSource);
            //只能够通过DataConnectionDialog类的静态方法Show出对话框
            //不同使用dialog.Show()或dialog.ShowDialog()来呈现对话框
            if (DataConnectionDialog.Show(dialog, this) == DialogResult.OK)
            {
                tbxConnectString.Text = dialog.ConnectionString;
                btnBuildMod.Enabled = tbxPath.Text != "";
                btnBuildCodeFile.Enabled = true;
                btnSetPermission.Enabled = true;
            }
        }

        private void btnBuildMod_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "是否确认生成系统模块？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string path = tbxPath.Text;
                // 判断文件是否存在
                if (File.Exists(path))
                {
                    OleDbConnection conn = GetConnection();
                    OleDbTransaction tran = null;
                    try
                    {
                        conn.Open();
                        _Command = conn.CreateCommand();
                        _Command.Connection = conn;
                        tran = conn.BeginTransaction();
                        _Command.Transaction = tran;

                        // 删除模块表
                        _Command.CommandText = "delete t_sys_mods";
                        _Command.ExecuteNonQuery();

                        // 删除模块表
                        _Command.CommandText = "delete t_sys_permissions where is_default = 'Y'";
                        _Command.ExecuteNonQuery();

                        //// 删除页面表
                        //_Command.CommandText = "delete t_sys_pages";
                        //_Command.ExecuteNonQuery();

                        // 读取网站地图文件
                        XmlDocument document = new XmlDocument();
                        document.Load(path);
                        XmlNode xnRoot = document.ChildNodes[1].FirstChild;
                        depth = rbtLevel2.Checked ? 2 : 3;

                        InsertNode(xnRoot, "root", 0, 0);

                        //保存Ini配置文件
                        SaveIniFile();

                        tran.Commit();

                        MessageBox.Show(this, "生成成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // 回滚事务
                        if (null != tran)
                        {
                            tran.Rollback();
                        }
                        MessageBox.Show(this, ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                            conn.Dispose();
                        }
                        if (null != _Command)
                        {
                            _Command.Dispose();
                        }
                    }
                }
                else
                {
                    // 文件不存在！
                    MessageBox.Show(this, "文件不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// 保存Ini配置文件
        /// </summary>
        private void SaveIniFile()
        {
            _IniFile.WriteString("MAIN", "SITEMAPPATH", tbxPath.Text);
            _IniFile.WriteString("MAIN", "CONNECTSTRING", tbxConnectString.Text);
            _IniFile.WriteInteger("MAIN", "MENUDEPTH", rbtLevel2.Checked ? 2 : 3);
        }

        /// <summary>
        /// 递归加载系统模块
        /// </summary>
        /// <param name="xn">节点</param>
        /// <param name="parentUrl">父节点Url</param>
        /// <param name="iSort">排序</param>
        /// <param name="iLevel">级别</param>
        private void InsertNode(XmlNode xn, string parentUrl, int iSort, int iLevel)
        {
            // 插入系统模块表SQL 语句
            string strInsertModSQL = "insert into t_sys_mods (mod_url, mod_name, parent_url, sort, mod_level, mod_desc) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')";

            //// 删除模块权限SQL 语句
            //string strDeletePremissionSQL = "delete t_sys_permissions where code = '{0}' and is_default = 'Y'";

            // 插入权限SQL 语句
            string strInserPremissionSQL = "insert into t_sys_permissions (code, mod_url, permission_name, permission_desc, sort, is_default) values ('{0}', '{1}', '{2}', '{3}', '{4}', 'Y')";

            // 判断是否为模块
            if (iLevel <= depth)
            {
                // 插入模块
                _Command.CommandText = string.Format(strInsertModSQL, xn.Attributes["url"].Value, xn.Attributes["title"].Value, parentUrl, iSort, iLevel, xn.Attributes["description"].Value);
                _Command.ExecuteNonQuery();

                //// 删除模块权限
                //_Command.CommandText = string.Format(strDeletePremissionSQL, xn.Attributes["url"].Value); ;
                //_Command.ExecuteNonQuery();

                // 插入模块权限
                _Command.CommandText = string.Format(strInserPremissionSQL, xn.Attributes["url"].Value, xn.Attributes["url"].Value, xn.Attributes["title"].Value, xn.Attributes["title"].Value + "浏览权限", 0);
                _Command.ExecuteNonQuery();
            }
            else
            {
                // 插入页面权限
                _Command.CommandText = string.Format(strInserPremissionSQL, xn.Attributes["url"].Value, parentUrl, xn.Attributes["title"].Value, xn.Attributes["title"].Value + "浏览权限", iSort + 1);
                _Command.ExecuteNonQuery();
            }

            int i = 0;
            foreach(XmlNode xnChild in xn.ChildNodes)
            {
                InsertNode(xnChild, xn.Attributes["url"].Value, i++, iLevel + 1);
            }
        }

        private void btnSetPermission_Click(object sender, EventArgs e)
        {
            //保存Ini配置文件
            SaveIniFile();

            frmPermission frm = new frmPermission();
            frm.Connection = GetConnection();
            frm.ShowDialog();
        }

        private OleDbConnection GetConnection()
        {
            return new OleDbConnection(tbxConnectString.Text);
        }
        private void btnBuildCodeFile_Click(object sender, EventArgs e)
        {
            //保存Ini配置文件
            SaveIniFile();
            frmBuildCode frm = new frmBuildCode(tbxConnectString.Text);
           // frm.Connection = GetConnection();
            frm.ShowDialog();
        }
    }
}