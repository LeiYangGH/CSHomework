namespace FolderStatistic
{
    partial class FolderStatistic
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PathtxtBox = new System.Windows.Forms.TextBox();
            this.gvDetail = new System.Windows.Forms.DataGridView();
            this.FileType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gvAll = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnStatistic = new System.Windows.Forms.Button();
            this.gvTest = new System.Windows.Forms.DataGridView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.FilesCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FilesNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTest)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 11F);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择要统计的文件夹";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 11F);
            this.label2.Location = new System.Drawing.Point(744, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "统计详情";
            // 
            // PathtxtBox
            // 
            this.PathtxtBox.Location = new System.Drawing.Point(10, 73);
            this.PathtxtBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PathtxtBox.Name = "PathtxtBox";
            this.PathtxtBox.Size = new System.Drawing.Size(342, 26);
            this.PathtxtBox.TabIndex = 2;
            this.PathtxtBox.TextChanged += new System.EventHandler(this.PathtxtBox_TextChanged);
            // 
            // gvDetail
            // 
            this.gvDetail.AllowUserToAddRows = false;
            this.gvDetail.AllowUserToDeleteRows = false;
            this.gvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileType,
            this.FileNumber,
            this.FileSize});
            this.gvDetail.Location = new System.Drawing.Point(606, 43);
            this.gvDetail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.ReadOnly = true;
            this.gvDetail.RowTemplate.Height = 23;
            this.gvDetail.Size = new System.Drawing.Size(550, 547);
            this.gvDetail.TabIndex = 3;
            // 
            // FileType
            // 
            this.FileType.HeaderText = "文件类型";
            this.FileType.Name = "FileType";
            this.FileType.ReadOnly = true;
            // 
            // FileNumber
            // 
            this.FileNumber.HeaderText = "文件个数";
            this.FileNumber.Name = "FileNumber";
            this.FileNumber.ReadOnly = true;
            // 
            // FileSize
            // 
            this.FileSize.HeaderText = "文件大小";
            this.FileSize.Name = "FileSize";
            this.FileSize.ReadOnly = true;
            // 
            // gvAll
            // 
            this.gvAll.AllowUserToAddRows = false;
            this.gvAll.AllowUserToDeleteRows = false;
            this.gvAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAll.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.gvAll.Location = new System.Drawing.Point(10, 175);
            this.gvAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gvAll.Name = "gvAll";
            this.gvAll.ReadOnly = true;
            this.gvAll.RowTemplate.Height = 23;
            this.gvAll.Size = new System.Drawing.Size(364, 73);
            this.gvAll.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "文件个数";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "文件大小";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 11F);
            this.label3.Location = new System.Drawing.Point(10, 145);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "统计概况";
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("SimSun", 11F);
            this.btnSelect.Location = new System.Drawing.Point(363, 70);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(80, 38);
            this.btnSelect.TabIndex = 6;
            this.btnSelect.Text = "选择";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnStatistic
            // 
            this.btnStatistic.Enabled = false;
            this.btnStatistic.Font = new System.Drawing.Font("SimSun", 11F);
            this.btnStatistic.Location = new System.Drawing.Point(442, 70);
            this.btnStatistic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStatistic.Name = "btnStatistic";
            this.btnStatistic.Size = new System.Drawing.Size(80, 38);
            this.btnStatistic.TabIndex = 7;
            this.btnStatistic.Text = "统计";
            this.btnStatistic.UseVisualStyleBackColor = true;
            this.btnStatistic.Click += new System.EventHandler(this.btnStatistic_Click);
            // 
            // gvTest
            // 
            this.gvTest.AllowUserToAddRows = false;
            this.gvTest.AllowUserToDeleteRows = false;
            this.gvTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTest.Location = new System.Drawing.Point(275, 417);
            this.gvTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gvTest.Name = "gvTest";
            this.gvTest.ReadOnly = true;
            this.gvTest.RowTemplate.Height = 23;
            this.gvTest.Size = new System.Drawing.Size(88, 140);
            this.gvTest.TabIndex = 8;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FilesCount,
            this.FilesNumber});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(98, 365);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(83, 204);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // FilesCount
            // 
            this.FilesCount.Text = "文件个数";
            // 
            // FilesNumber
            // 
            this.FilesNumber.Text = "文件大小";
            // 
            // FolderStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 610);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.gvTest);
            this.Controls.Add(this.btnStatistic);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gvAll);
            this.Controls.Add(this.gvDetail);
            this.Controls.Add(this.PathtxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FolderStatistic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件夹统计";
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PathtxtBox;
        private System.Windows.Forms.DataGridView gvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileType;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
        private System.Windows.Forms.DataGridView gvAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnStatistic;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridView gvTest;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader FilesCount;
        private System.Windows.Forms.ColumnHeader FilesNumber;
    }
}

