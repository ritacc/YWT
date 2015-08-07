using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SystemModle
{
    public partial class frmPermissionSet : Form
    {
        private BindingSource _BindingSource;
        /// <summary>
        /// 数据源
        /// </summary>
        public BindingSource BindingSource
        {
            set { _BindingSource = value; }
        }

        private bool _isEdit = false;
        /// <summary>
        /// 是否为编辑
        /// </summary>
        public bool isEdit
        {
            set { _isEdit = value; }
        }

        // 数据库连接
        private OleDbConnection _Connection = null;
        /// <summary>
        /// 数据库连接
        /// </summary>
        public OleDbConnection Connection
        {
            set { _Connection = value; }
        }

        // 数据库访问类
        private DBCommond db = new DBCommond();

        // 当前选择的行
        DataRowView _CurrentRow;

        public frmPermissionSet()
        {
            InitializeComponent();
        }

        private void frmPermissionSet_Load(object sender, EventArgs e)
        {
            _CurrentRow = ((DataRowView)_BindingSource.Current);
            if (_isEdit)
            {
                if (_CurrentRow["sort"].ToString() == "0")
                {
                    nudSort.Value = 0;
                    nudSort.Enabled = false;
                }
                else
                {
                    nudSort.Minimum = 1;
                    nudSort.Maximum = _BindingSource.Count - 1;
                }
            }
            else
            {

                nudSort.Minimum = 1;
                nudSort.Value = nudSort.Maximum = _BindingSource.Count;
            }
            db.Connection = _Connection;
            loadPageUrl();
        }

        private void loadPageUrl()
        {
            if (_isEdit)
            {
                tbxCode.Enabled = _CurrentRow["is_default"].ToString() == "N";
                tbxCode.Text = _CurrentRow["code"].ToString();
                tbxName.Text = _CurrentRow["permission_name"].ToString();
                nudSort.Value = Convert.ToDecimal(_CurrentRow["sort"]);
                tbxDesc.Text = _CurrentRow["permission_desc"].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbxCode.Text.Trim() == "")
            {
                MessageBox.Show(this, "请填写权限代码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tbxName.Text.Trim() == "")
            {
                MessageBox.Show(this, "请填写权限名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int oldSort;
                string sql = string.Empty;
                string guid = string.Empty;
                string code = tbxCode.Text.Replace("'", "").Trim();
                object mod_url = _CurrentRow["mode_url"];
                string permission_name = tbxName.Text.Replace("'", "").Trim();
                string permission_desc = tbxDesc.Text.Replace("'", "").Trim();
                int sort = Convert.ToInt32(nudSort.Value);
                List<string> sqls = new List<string>();
                if (_CurrentRow["is_default"].ToString() == "N")
                {
                    code = code.ToUpper();
                }

                string strInserPremissionSQL = "insert into t_sys_permissions (guid, code ,mode_url, permission_name, permission_desc, sort, is_default) values ('{0}','{1}', '{2}', '{3}', '{4}', '{5}', 'N')";
                string strUpdatePremissionSQL = "update t_sys_permissions set code = '{0}', mode_url = '{1}' , permission_name = '{2}', permission_desc = '{3}' where guid = '{4}'";
                string strUpdateSortAllSQL = "update set t_sys_permissions set sort = sort + 1 where mod_url = '{1}' and guid <> '{2}' and sort between {3} and {4}";
                if (!_isEdit)
                {
                    guid = Guid.NewGuid().ToString();
                    oldSort = _BindingSource.Count;
                    // 插入权限SQL 语句
                    sql = string.Format(strInserPremissionSQL, guid, mod_url, permission_name, permission_desc, sort);
                }
                else
                {
                    guid = _CurrentRow["guid"].ToString();
                    // 是否编辑模块权限（编辑模块权限不更新页面地址）
                    oldSort = Convert.ToInt32(_CurrentRow["sort"]);
                    sql = string.Format(strUpdatePremissionSQL, code, mod_url, permission_name, permission_desc, guid);
                }
                sqls.Add(sql);
                
                //判断顺序是往升还是往下降
                int diff = sort - oldSort;

                // 顺序没变就不重新排序
                if (diff != 0)
                {
                    if (diff < 0)
                    {
                        sql = string.Format(strUpdateSortAllSQL, "+", mod_url, guid, sort, oldSort);
                    }
                    else
                    {
                        sql = string.Format(strUpdateSortAllSQL, "-", mod_url, guid, oldSort, sort);
                    }
                    sqls.Add(sql);
                }

                if (!db.ExecuteNoQuery(sqls))
                {
                    MessageBox.Show(this, "设置失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void frmPermissionSet_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}