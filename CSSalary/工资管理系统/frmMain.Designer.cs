namespace 工资管理系统
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.添加新记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工资管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.版权ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bumenbiaoTableAdapter = new 工资管理系统.biyeshejiDataSetTableAdapters.bumenbiaoTableAdapter();
            this.biyeshejiDataSet = new 工资管理系统.biyeshejiDataSet();
            this.ztlQM = new System.Windows.Forms.ToolStripStatusLabel();
            this.ztlHM = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.bumenbiaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gongzibiaoALLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gongzibiaoALLTableAdapter = new 工资管理系统.biyeshejiDataSetTableAdapters.gongzibiaoALLTableAdapter();
            this.tableAdapterManager = new 工资管理系统.biyeshejiDataSetTableAdapters.TableAdapterManager();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.biyeshejiDataSet)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bumenbiaoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gongzibiaoALLBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // 添加新记录ToolStripMenuItem
            // 
            this.添加新记录ToolStripMenuItem.Name = "添加新记录ToolStripMenuItem";
            this.添加新记录ToolStripMenuItem.Size = new System.Drawing.Size(119, 29);
            this.添加新记录ToolStripMenuItem.Text = "添加新员工";
            this.添加新记录ToolStripMenuItem.Click += new System.EventHandler(this.添加新记录ToolStripMenuItem_Click);
            // 
            // 工资管理ToolStripMenuItem
            // 
            this.工资管理ToolStripMenuItem.Name = "工资管理ToolStripMenuItem";
            this.工资管理ToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
            this.工资管理ToolStripMenuItem.Text = "工资管理";
            this.工资管理ToolStripMenuItem.Click += new System.EventHandler(this.工资修改ToolStripMenuItem_Click);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(62, 29);
            this.查询ToolStripMenuItem.Text = "查询";
            this.查询ToolStripMenuItem.Click += new System.EventHandler(this.查询ToolStripMenuItem_Click);
            // 
            // 系统ToolStripMenuItem
            // 
            this.系统ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出系统ToolStripMenuItem,
            this.版权ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.系统ToolStripMenuItem.Name = "系统ToolStripMenuItem";
            this.系统ToolStripMenuItem.Size = new System.Drawing.Size(62, 29);
            this.系统ToolStripMenuItem.Text = "系统";
            // 
            // 退出系统ToolStripMenuItem
            // 
            this.退出系统ToolStripMenuItem.Name = "退出系统ToolStripMenuItem";
            this.退出系统ToolStripMenuItem.Size = new System.Drawing.Size(173, 30);
            this.退出系统ToolStripMenuItem.Text = "退出系统";
            this.退出系统ToolStripMenuItem.Click += new System.EventHandler(this.退出系统ToolStripMenuItem_Click);
            // 
            // 版权ToolStripMenuItem
            // 
            this.版权ToolStripMenuItem.Name = "版权ToolStripMenuItem";
            this.版权ToolStripMenuItem.Size = new System.Drawing.Size(173, 30);
            this.版权ToolStripMenuItem.Text = "版权";
            this.版权ToolStripMenuItem.Click += new System.EventHandler(this.版权ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(173, 30);
            this.帮助ToolStripMenuItem.Text = "帮助";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加新记录ToolStripMenuItem,
            this.工资管理ToolStripMenuItem,
            this.查询ToolStripMenuItem,
            this.系统ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(806, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bumenbiaoTableAdapter
            // 
            this.bumenbiaoTableAdapter.ClearBeforeFill = true;
            // 
            // biyeshejiDataSet
            // 
            this.biyeshejiDataSet.DataSetName = "biyeshejiDataSet";
            this.biyeshejiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ztlQM
            // 
            this.ztlQM.Name = "ztlQM";
            this.ztlQM.Size = new System.Drawing.Size(270, 25);
            this.ztlQM.Text = "设计者：张程晨 201305006065";
            // 
            // ztlHM
            // 
            this.ztlHM.Name = "ztlHM";
            this.ztlHM.Size = new System.Drawing.Size(513, 25);
            this.ztlHM.Spring = true;
            this.ztlHM.Text = "此处以后将显示登录信息";
            this.ztlHM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ztlHM.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ztlHM.Click += new System.EventHandler(this.ztlHM_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ztlQM,
            this.ztlHM});
            this.statusStrip1.Location = new System.Drawing.Point(0, 382);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(806, 30);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // bumenbiaoBindingSource
            // 
            this.bumenbiaoBindingSource.DataMember = "bumenbiao";
            this.bumenbiaoBindingSource.DataSource = this.biyeshejiDataSet;
            // 
            // gongzibiaoALLBindingSource
            // 
            this.gongzibiaoALLBindingSource.DataMember = "gongzibiaoALL";
            this.gongzibiaoALLBindingSource.DataSource = this.biyeshejiDataSet;
            // 
            // gongzibiaoALLTableAdapter
            // 
            this.gongzibiaoALLTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.bumenbiaoTableAdapter = this.bumenbiaoTableAdapter;
            this.tableAdapterManager.gongzibiaoALLTableAdapter = this.gongzibiaoALLTableAdapter;
            this.tableAdapterManager.gongzibiaoTableAdapter = null;
            this.tableAdapterManager.guanliyuanTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = 工资管理系统.biyeshejiDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.usersTableAdapter = null;
            this.tableAdapterManager.yuangongbiaoTableAdapter = null;
            // 
            // first
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 412);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "first";
            this.Text = "工资管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.first_FormClosing);
            this.Load += new System.EventHandler(this.gongziguanli_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.biyeshejiDataSet)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bumenbiaoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gongzibiaoALLBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem 添加新记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工资管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 版权ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private biyeshejiDataSetTableAdapters.bumenbiaoTableAdapter bumenbiaoTableAdapter;
        private biyeshejiDataSet biyeshejiDataSet;
        private System.Windows.Forms.ToolStripStatusLabel ztlQM;
        private System.Windows.Forms.ToolStripStatusLabel ztlHM;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.BindingSource bumenbiaoBindingSource;
        private System.Windows.Forms.BindingSource gongzibiaoALLBindingSource;
        private biyeshejiDataSetTableAdapters.gongzibiaoALLTableAdapter gongzibiaoALLTableAdapter;
        private biyeshejiDataSetTableAdapters.TableAdapterManager tableAdapterManager;
    }
}