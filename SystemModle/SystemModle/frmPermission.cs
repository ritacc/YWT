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
    public partial class frmPermission : Form
    {
        private DataTable DTMod;
        //
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

        public frmPermission()
        {
            InitializeComponent();
        }

        private void frmPermission_Load(object sender, EventArgs e)
        {
            if(null ==  _Connection)
            {
                this.Close();
                MessageBox.Show(this, "没有数加载数据库连接，不能执行该操作！", "非法", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                db.Connection = _Connection;
                gvPermissions.AutoGenerateColumns = false;
                InitForm();
            }
        }

        private void InitForm()
        {
            string sql = "select mod_url, mod_name, parent_url, sort, mod_level, mod_desc from t_sys_mods order by sort";
            DTMod = db.ExecuteQuery(sql);
            LoadTree(tvMod);
            tvMod.ExpandAll();
        }

        private void LoadTree(TreeView tv)
        {
            DTMod.DefaultView.RowFilter = "parent_url = 'root'";
            TreeNode tnChild;
            foreach (DataRowView row in DTMod.DefaultView)
            {
                tnChild = new TreeNode();
                tnChild.Text = row["mod_name"].ToString();
                tnChild.Name = row["mod_url"].ToString();
                tnChild.ToolTipText = row["mod_desc"].ToString();
                tv.Nodes.Add(tnChild);
                LoadTree(tnChild);
            }
        }

        private void LoadTree(TreeNode tn)
        {
            DTMod.DefaultView.RowFilter = "parent_url = '" + tn.Name + "'";
            TreeNode tnChild;
            foreach (DataRowView row in DTMod.DefaultView)
            {
                tnChild = new TreeNode();
                tnChild.Text = row["mod_name"].ToString();
                tnChild.Name = row["mod_url"].ToString();
                tnChild.ToolTipText = row["mod_desc"].ToString();
                tn.Nodes.Add(tnChild);
                LoadTree(tnChild);
            }
        }

        private void LoadPermissions(TreeNode tn)
        {
            bool isFoot = tn.Level == Convert.ToInt32(DTMod.Compute("max(mod_level)", string.Empty));
            btnAdd.Enabled = isFoot;

            string sql = "select guid, code, mod_url, permission_name, permission_desc, sort, is_default from t_sys_permissions where mod_url = '{0}'";
            sql = string.Format(sql, tn.Name);
            DataTable dt = db.ExecuteQuery(sql);
            bsPermissions.DataSource = dt.DefaultView;
            gvPermissions.DataSource = bsPermissions;
            btnEdit.Enabled = dt.Rows.Count != 0;
        }

        private void tvMod_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadPermissions(e.Node);
        }

        private void gvPermissions_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView _CurrentRow = ((DataRowView)bsPermissions.Current);
            // 是否为模块的根节点
            DTMod.DefaultView.Sort = "mod_level desc";
            bool isFoot = tvMod.SelectedNode.Nodes.Count == 0 && tvMod.SelectedNode.Level == Convert.ToInt32(DTMod.Compute("max(mod_level)", string.Empty));
            // 是否为页面的默认权限
            bool isPagePermissions = _CurrentRow["is_default"].ToString() == "N";
            btnDelete.Enabled = isFoot && isPagePermissions;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmPermissionSet frm = new frmPermissionSet();
            frm.Connection = _Connection;
            frm.BindingSource = bsPermissions;
            frm.isEdit = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadPermissions(tvMod.SelectedNode);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmPermissionSet frm = new frmPermissionSet();
            frm.Connection = _Connection;
            frm.BindingSource = bsPermissions;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadPermissions(tvMod.SelectedNode);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "是否确认删除该条记录？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<string> sqls = new List<string>();
                DataRowView _CurrentRow = ((DataRowView)bsPermissions.Current);

                string strDeletePermissionsSQL = "delete t_sys_permissions where guid = '{0}'";
                strDeletePermissionsSQL = string.Format(strDeletePermissionsSQL, _CurrentRow["guid"]);
                sqls.Add(strDeletePermissionsSQL);

                string strUpdateSortSQL = "update t_sys_permissions set sort = sort - 1 where mod_url = '{0}' and  sort > {1}";
                strUpdateSortSQL = string.Format(strUpdateSortSQL, _CurrentRow["mod_url"], _CurrentRow["sort"]);

                if (!db.ExecuteNoQuery(sqls))
                {
                    MessageBox.Show(this, "删除失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    LoadPermissions(tvMod.SelectedNode);
                }
            }
        }
    }
}