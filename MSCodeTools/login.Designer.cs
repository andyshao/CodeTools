namespace MSCodeTools
{
    partial class login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.btn_conn = new System.Windows.Forms.Button();
            this.t_host = new System.Windows.Forms.TextBox();
            this.t_username = new System.Windows.Forms.TextBox();
            this.t_port = new System.Windows.Forms.TextBox();
            this.t_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.t_db = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.t_conn = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cb = new System.Windows.Forms.CheckBox();
            this.cb_pwd = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_conn
            // 
            this.btn_conn.Location = new System.Drawing.Point(109, 212);
            this.btn_conn.Name = "btn_conn";
            this.btn_conn.Size = new System.Drawing.Size(75, 23);
            this.btn_conn.TabIndex = 0;
            this.btn_conn.Text = "连接";
            this.btn_conn.UseVisualStyleBackColor = true;
            this.btn_conn.Click += new System.EventHandler(this.btn_conn_Click);
            // 
            // t_host
            // 
            this.t_host.Location = new System.Drawing.Point(54, 82);
            this.t_host.Name = "t_host";
            this.t_host.Size = new System.Drawing.Size(179, 21);
            this.t_host.TabIndex = 1;
            // 
            // t_username
            // 
            this.t_username.Location = new System.Drawing.Point(54, 140);
            this.t_username.Name = "t_username";
            this.t_username.Size = new System.Drawing.Size(179, 21);
            this.t_username.TabIndex = 2;
            // 
            // t_port
            // 
            this.t_port.Location = new System.Drawing.Point(268, 82);
            this.t_port.Name = "t_port";
            this.t_port.Size = new System.Drawing.Size(48, 21);
            this.t_port.TabIndex = 3;
            this.t_port.Text = "1433";
            // 
            // t_password
            // 
            this.t_password.Location = new System.Drawing.Point(54, 176);
            this.t_password.Name = "t_password";
            this.t_password.PasswordChar = '*';
            this.t_password.Size = new System.Drawing.Size(179, 21);
            this.t_password.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "服务器";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "用户名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "端口";
            // 
            // t_db
            // 
            this.t_db.Location = new System.Drawing.Point(54, 109);
            this.t_db.Name = "t_db";
            this.t_db.Size = new System.Drawing.Size(179, 21);
            this.t_db.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "数据库";
            // 
            // t_conn
            // 
            this.t_conn.Location = new System.Drawing.Point(54, 33);
            this.t_conn.Name = "t_conn";
            this.t_conn.PasswordChar = '*';
            this.t_conn.Size = new System.Drawing.Size(273, 21);
            this.t_conn.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "字符串";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.OrangeRed;
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "优先选择数据库字符串链接";
            // 
            // cb
            // 
            this.cb.AutoSize = true;
            this.cb.Location = new System.Drawing.Point(54, 60);
            this.cb.Name = "cb";
            this.cb.Size = new System.Drawing.Size(48, 16);
            this.cb.TabIndex = 14;
            this.cb.Text = "明文";
            this.cb.UseVisualStyleBackColor = true;
            this.cb.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
            // 
            // cb_pwd
            // 
            this.cb_pwd.AutoSize = true;
            this.cb_pwd.Location = new System.Drawing.Point(239, 181);
            this.cb_pwd.Name = "cb_pwd";
            this.cb_pwd.Size = new System.Drawing.Size(48, 16);
            this.cb_pwd.TabIndex = 15;
            this.cb_pwd.Text = "明文";
            this.cb_pwd.UseVisualStyleBackColor = true;
            this.cb_pwd.CheckedChanged += new System.EventHandler(this.cb_pwd_CheckedChanged);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 283);
            this.Controls.Add(this.cb_pwd);
            this.Controls.Add(this.cb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.t_conn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.t_db);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.t_password);
            this.Controls.Add(this.t_port);
            this.Controls.Add(this.t_username);
            this.Controls.Add(this.t_host);
            this.Controls.Add(this.btn_conn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_conn;
        private System.Windows.Forms.TextBox t_host;
        private System.Windows.Forms.TextBox t_username;
        private System.Windows.Forms.TextBox t_port;
        private System.Windows.Forms.TextBox t_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox t_db;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox t_conn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cb;
        private System.Windows.Forms.CheckBox cb_pwd;
    }
}

