using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSCodeTools
{
    public partial class login : Form
    {
        private string msg = string.Empty;
        public DBTable mainForm; //获得主窗体引用，可以更新主窗体的登录标志
        public login()
        {
            InitializeComponent();
            string SQL_CONN_STR = System.Configuration.ConfigurationManager.AppSettings["ConnStr"];
            if (!string.IsNullOrWhiteSpace(SQL_CONN_STR) &&SQL_CONN_STR != "XXX")
            {
                t_conn.Text = SQL_CONN_STR;
            }
        }
        private void btn_conn_Click(object sender, EventArgs e)
        {
            string connStr = t_conn.Text == "" ? string.Format(@"Data Source={0},{1};Initial Catalog={2};User Id={3};Password={4};", t_host.Text, t_port.Text, t_db.Text, t_username.Text, t_password.Text) : t_conn.Text;
            Thread thread = new Thread(Check);     //执行的必须是无返回值的方法
            thread.Name = "子线程";
            thread.Start(connStr);                       //在此方法内传递参数，类型为object，发送和接收涉及到拆装箱操作

        }

        public void Check(object connStr)
        {
            msg = MSSQLHelper.CheckConn((string)connStr);
            if (msg == "连接成功！")
            {
                //MessageBox.Show(msg);
                #region 原主线程状态已弃用
                //DBTable db = new DBTable((string)connStr);
                //if (db.ShowDialog() == DialogResult.OK)
                //{
                //    Application.Run(new DBTable((string)connStr));
                //}
                //Application.OpenForms["login"].Close();
                //this.Hide();
                #endregion
                mainForm.isLogin = true;
                mainForm.myConn = (string)connStr;
                this.Invoke(new Action(this.Close));  //结束后，使用委托关闭该窗体
            }
            else
            {
                MessageBox.Show(msg);
            }
        }

        private void cb_CheckedChanged(object sender, EventArgs e)
        {
            if (cb.Checked)
            {
                //复选框被勾选，明文显示
                t_conn.PasswordChar = new char();
            }
            else
            {
                //复选框被取消勾选，密文显示
                t_conn.PasswordChar = '*';
            }
        }

        private void cb_pwd_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_pwd.Checked)
            {
                //复选框被勾选，明文显示
                t_password.PasswordChar = new char();
            }
            else
            {
                //复选框被取消勾选，密文显示
                t_password.PasswordChar = '*';
            }
        }
    }
}
