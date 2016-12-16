namespace CardManagement
{
    partial class Form_Download
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.下载考勤数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新员工打卡权限ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.换卡员工打卡权限ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.调整员工打卡权限ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.离职员工权限取消ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewDepartment = new System.Windows.Forms.ListView();
            this.TextBoxDisplay = new System.Windows.Forms.TextBox();
            this.ButtonEmpty = new System.Windows.Forms.Button();
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.ButtonDownload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewMachines = new HR.Controls.DataGridViewC();
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMachines)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.下载考勤数据ToolStripMenuItem,
            this.新员工打卡权限ToolStripMenuItem,
            this.换卡员工打卡权限ToolStripMenuItem,
            this.调整员工打卡权限ToolStripMenuItem,
            this.离职员工权限取消ToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 下载考勤数据ToolStripMenuItem
            // 
            this.下载考勤数据ToolStripMenuItem.Name = "下载考勤数据ToolStripMenuItem";
            this.下载考勤数据ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.下载考勤数据ToolStripMenuItem.Text = "下载考勤数据";
            // 
            // 新员工打卡权限ToolStripMenuItem
            // 
            this.新员工打卡权限ToolStripMenuItem.Name = "新员工打卡权限ToolStripMenuItem";
            this.新员工打卡权限ToolStripMenuItem.Size = new System.Drawing.Size(104, 21);
            this.新员工打卡权限ToolStripMenuItem.Text = "新员工打卡权限";
            // 
            // 换卡员工打卡权限ToolStripMenuItem
            // 
            this.换卡员工打卡权限ToolStripMenuItem.Name = "换卡员工打卡权限ToolStripMenuItem";
            this.换卡员工打卡权限ToolStripMenuItem.Size = new System.Drawing.Size(116, 21);
            this.换卡员工打卡权限ToolStripMenuItem.Text = "换卡员工打卡权限";
            // 
            // 调整员工打卡权限ToolStripMenuItem
            // 
            this.调整员工打卡权限ToolStripMenuItem.Name = "调整员工打卡权限ToolStripMenuItem";
            this.调整员工打卡权限ToolStripMenuItem.Size = new System.Drawing.Size(116, 21);
            this.调整员工打卡权限ToolStripMenuItem.Text = "调整员工打卡权限";
            // 
            // 离职员工权限取消ToolStripMenuItem
            // 
            this.离职员工权限取消ToolStripMenuItem.Name = "离职员工权限取消ToolStripMenuItem";
            this.离职员工权限取消ToolStripMenuItem.Size = new System.Drawing.Size(140, 21);
            this.离职员工权限取消ToolStripMenuItem.Text = "离职员工打卡权限撤销";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 21);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewDepartment);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TextBoxDisplay);
            this.splitContainer1.Panel2.Controls.Add(this.ButtonEmpty);
            this.splitContainer1.Panel2.Controls.Add(this.ButtonUpdate);
            this.splitContainer1.Panel2.Controls.Add(this.ButtonDownload);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewMachines);
            this.splitContainer1.Size = new System.Drawing.Size(784, 462);
            this.splitContainer1.SplitterDistance = 111;
            this.splitContainer1.TabIndex = 2;
            // 
            // listViewDepartment
            // 
            this.listViewDepartment.LabelWrap = false;
            this.listViewDepartment.Location = new System.Drawing.Point(0, 11);
            this.listViewDepartment.MultiSelect = false;
            this.listViewDepartment.Name = "listViewDepartment";
            this.listViewDepartment.Size = new System.Drawing.Size(107, 283);
            this.listViewDepartment.TabIndex = 0;
            this.listViewDepartment.UseCompatibleStateImageBehavior = false;
            this.listViewDepartment.SelectedIndexChanged += new System.EventHandler(this.listViewDepartment_SelectedIndexChanged);
            // 
            // TextBoxDisplay
            // 
            this.TextBoxDisplay.AcceptsReturn = true;
            this.TextBoxDisplay.AcceptsTab = true;
            this.TextBoxDisplay.Location = new System.Drawing.Point(12, 316);
            this.TextBoxDisplay.Multiline = true;
            this.TextBoxDisplay.Name = "TextBoxDisplay";
            this.TextBoxDisplay.Size = new System.Drawing.Size(548, 130);
            this.TextBoxDisplay.TabIndex = 5;
            // 
            // ButtonEmpty
            // 
            this.ButtonEmpty.Location = new System.Drawing.Point(566, 423);
            this.ButtonEmpty.Name = "ButtonEmpty";
            this.ButtonEmpty.Size = new System.Drawing.Size(75, 23);
            this.ButtonEmpty.TabIndex = 4;
            this.ButtonEmpty.Text = "清空数据";
            this.ButtonEmpty.UseVisualStyleBackColor = true;
            this.ButtonEmpty.Click += new System.EventHandler(this.ButtonEmpty_Click);
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Location = new System.Drawing.Point(566, 370);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(75, 23);
            this.ButtonUpdate.TabIndex = 3;
            this.ButtonUpdate.Text = "更新时间";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // ButtonDownload
            // 
            this.ButtonDownload.Location = new System.Drawing.Point(566, 316);
            this.ButtonDownload.Name = "ButtonDownload";
            this.ButtonDownload.Size = new System.Drawing.Size(75, 23);
            this.ButtonDownload.TabIndex = 2;
            this.ButtonDownload.Text = "下载数据";
            this.ButtonDownload.UseVisualStyleBackColor = true;
            this.ButtonDownload.Click += new System.EventHandler(this.ButtonDownload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "卡机列表";
            // 
            // dataGridViewMachines
            // 
            this.dataGridViewMachines.AllowUserToAddRows = false;
            this.dataGridViewMachines.AllowUserToDeleteRows = false;
            this.dataGridViewMachines.AllowUserToOrderColumns = true;
            this.dataGridViewMachines.BackgroundColor = System.Drawing.Color.Linen;
            this.dataGridViewMachines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridViewMachines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMachines.GridColor = System.Drawing.Color.Green;
            this.dataGridViewMachines.HRAllowColumnSort = true;
            this.dataGridViewMachines.HRFormID = 0;
            this.dataGridViewMachines.Location = new System.Drawing.Point(12, 36);
            this.dataGridViewMachines.Name = "dataGridViewMachines";
            this.dataGridViewMachines.ReadOnly = true;
            this.dataGridViewMachines.RowTemplate.Height = 23;
            this.dataGridViewMachines.Size = new System.Drawing.Size(629, 258);
            this.dataGridViewMachines.TabIndex = 0;
            this.dataGridViewMachines.VirtualMode = true;
            // 
            // Form_Download
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Download";
            this.Text = "下载考勤数据";
            this.Load += new System.EventHandler(this.Form_Download_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMachines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 下载考勤数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新员工打卡权限ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 换卡员工打卡权限ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 调整员工打卡权限ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 离职员工权限取消ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listViewDepartment;
        private System.Windows.Forms.Button ButtonEmpty;
        private System.Windows.Forms.Button ButtonUpdate;
        private System.Windows.Forms.Button ButtonDownload;
        private System.Windows.Forms.Label label1;
        private HR.Controls.DataGridViewC dataGridViewMachines;
        private System.Windows.Forms.TextBox TextBoxDisplay;
    }
}