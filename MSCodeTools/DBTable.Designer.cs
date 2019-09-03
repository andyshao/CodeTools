namespace MSCodeTools
{
    partial class DBTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBTable));
            this.btn_exit = new System.Windows.Forms.Button();
            this.tree = new System.Windows.Forms.TreeView();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.tologin = new System.Windows.Forms.ToolStripLabel();
            this.t_model = new System.Windows.Forms.TextBox();
            this.t_sql = new System.Windows.Forms.TextBox();
            this.t_param = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.text_like = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.tools.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(1141, 558);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 0;
            this.btn_exit.Text = "退出";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // tree
            // 
            this.tree.Location = new System.Drawing.Point(3, 48);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(174, 533);
            this.tree.TabIndex = 1;
            this.tree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_NodeMouseClick);
            // 
            // tools
            // 
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tologin});
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(1228, 25);
            this.tools.TabIndex = 2;
            this.tools.Text = "菜单";
            // 
            // tologin
            // 
            this.tologin.Name = "tologin";
            this.tologin.Size = new System.Drawing.Size(32, 22);
            this.tologin.Text = "登录";
            this.tologin.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // t_model
            // 
            this.t_model.Location = new System.Drawing.Point(183, 48);
            this.t_model.Multiline = true;
            this.t_model.Name = "t_model";
            this.t_model.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.t_model.Size = new System.Drawing.Size(518, 533);
            this.t_model.TabIndex = 3;
            // 
            // t_sql
            // 
            this.t_sql.Location = new System.Drawing.Point(707, 48);
            this.t_sql.Multiline = true;
            this.t_sql.Name = "t_sql";
            this.t_sql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.t_sql.Size = new System.Drawing.Size(256, 533);
            this.t_sql.TabIndex = 4;
            // 
            // t_param
            // 
            this.t_param.Location = new System.Drawing.Point(969, 48);
            this.t_param.Multiline = true;
            this.t_param.Name = "t_param";
            this.t_param.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.t_param.Size = new System.Drawing.Size(247, 504);
            this.t_param.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "实体：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(705, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "数据库语句：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(967, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "天鸽param：";
            // 
            // text_like
            // 
            this.text_like.Location = new System.Drawing.Point(3, 26);
            this.text_like.Name = "text_like";
            this.text_like.Size = new System.Drawing.Size(100, 21);
            this.text_like.TabIndex = 9;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(103, 25);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 10;
            this.btn_search.Text = "筛选";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // DBTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 584);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.text_like);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.t_param);
            this.Controls.Add(this.t_sql);
            this.Controls.Add(this.t_model);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.tree);
            this.Controls.Add(this.btn_exit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DBTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "代码生成器";
            this.Load += new System.EventHandler(this.DBTable_Load);
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.ToolStripLabel tologin;
        private System.Windows.Forms.TextBox t_model;
        private System.Windows.Forms.TextBox t_sql;
        private System.Windows.Forms.TextBox t_param;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_like;
        private System.Windows.Forms.Button btn_search;
    }
}