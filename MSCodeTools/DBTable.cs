using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSCodeTools
{
    public partial class DBTable : Form
    {
        public string myConn = "";
        public bool isLogin = false; //登录标志
        public DBTable()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("真的要退出程序吗？", "退出程序", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Dispose();
                this.Close();
            }         
        }

        private void DBTable_Load(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            login lf = new login();
            lf.mainForm = this;
            lf.ShowDialog();
            if (isLogin)
            {
                tree.Nodes.Clear();
                string getTables = " SELECT name FROM sysobjects  WHERE xtype = 'U' ";
                DataTable dt = MSSQLHelper.GetTable(myConn, getTables);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tree.Nodes.Add(dt.Rows[i]["name"].ToString());
                }
                #region listview
                //this.lv_table.Columns.Clear();  //好习惯，先清除再添加保证数据的一致性
                //this.lv_table.Columns.Add("name"); 
                //int length = dt.Rows.Count;
                //for (int i = 0; i < length; i++)
                //{
                //    ListViewItem lvi = new ListViewItem(dt.Rows[i]["name"].ToString());  //ListView的第一个Item作为主项需要单独添加
                //    lvi.SubItems.Add(dt.Rows[i]["name"].ToString());   //后面添加的Item都为SubItems ，即为子项
                //    this.lv_table.Items.Add(lvi);//最后进行添加
                //}
                #endregion
            }
            else
            {
                this.Close();
            }
        }

        private void tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string name = e.Node.Text.ToString();
            Dictionary<string, Dictionary<string, string>> r = DBConvertOther.GetTableInfo(myConn, name);
            string myModel= DBConvertOther.ModelFactory(r);
            string myDB = DBConvertOther.DBFactory(r);
            string myParam = DBConvertOther.ParamFactory(r);
            t_model.Text = myModel;
            t_sql.Text = myDB;
            t_param.Text = myParam;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (isLogin)
            {
                tree.Nodes.Clear();
                string getTables = string.Format(" SELECT name FROM sysobjects  WHERE xtype = 'U' and name like '%{0}%' ", this.text_like.Text);
                DataTable dt = MSSQLHelper.GetTable(myConn, getTables);
                //DataRow[] dr = dt.Select(string.Format("name='{}'"));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tree.Nodes.Add(dt.Rows[i]["name"].ToString());
                }
            }
            else
            {
                this.Close();
            }
        }
    }
}
