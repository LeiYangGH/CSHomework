namespace PlayManager
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
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("一部电影");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("另一部电影");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("暑期档", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("好看的电影");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("不好看的电影");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("寒假档", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("没有电影");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("节后档", new System.Windows.Forms.TreeNode[] {
            treeNode15});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSelect = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMovie = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movieTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posterDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加档期ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.暑期档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.寒假档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.节后档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movieBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbUpdate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovie)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movieBindingSource)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode9.Name = "节点3";
            treeNode9.Text = "一部电影";
            treeNode10.Name = "节点4";
            treeNode10.Text = "另一部电影";
            treeNode11.Name = "节点0";
            treeNode11.Text = "暑期档";
            treeNode12.Name = "节点5";
            treeNode12.Text = "好看的电影";
            treeNode13.Name = "节点6";
            treeNode13.Text = "不好看的电影";
            treeNode14.Name = "节点1";
            treeNode14.Text = "寒假档";
            treeNode15.Name = "节点7";
            treeNode15.Text = "没有电影";
            treeNode16.Name = "节点2";
            treeNode16.Text = "节后档";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode14,
            treeNode16});
            this.treeView1.Size = new System.Drawing.Size(179, 467);
            this.treeView1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl1.Location = new System.Drawing.Point(185, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(597, 467);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSelect);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cmbClass);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dgvMovie);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(589, 441);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "安排档期";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(415, 19);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(50, 23);
            this.btnSelect.TabIndex = 25;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(290, 21);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 21);
            this.textBox1.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "电影名称";
            // 
            // cmbClass
            // 
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(94, 21);
            this.cmbClass.Margin = new System.Windows.Forms.Padding(2);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(119, 20);
            this.cmbClass.TabIndex = 19;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "选择类型";
            // 
            // dgvMovie
            // 
            this.dgvMovie.AllowUserToDeleteRows = false;
            this.dgvMovie.AutoGenerateColumns = false;
            this.dgvMovie.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovie.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvMovie.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMovie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovie.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.durationDataGridViewTextBoxColumn,
            this.movieTypeNameDataGridViewTextBoxColumn,
            this.posterDataGridViewImageColumn});
            this.dgvMovie.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvMovie.DataSource = this.movieBindingSource;
            this.dgvMovie.Location = new System.Drawing.Point(6, 63);
            this.dgvMovie.Name = "dgvMovie";
            this.dgvMovie.ReadOnly = true;
            this.dgvMovie.RowHeadersVisible = false;
            this.dgvMovie.RowTemplate.Height = 23;
            this.dgvMovie.Size = new System.Drawing.Size(577, 375);
            this.dgvMovie.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "影片名称";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // durationDataGridViewTextBoxColumn
            // 
            this.durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
            this.durationDataGridViewTextBoxColumn.HeaderText = "影片时长";
            this.durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            // 
            // movieTypeNameDataGridViewTextBoxColumn
            // 
            this.movieTypeNameDataGridViewTextBoxColumn.DataPropertyName = "MovieTypeName";
            this.movieTypeNameDataGridViewTextBoxColumn.HeaderText = "影片类型";
            this.movieTypeNameDataGridViewTextBoxColumn.Name = "movieTypeNameDataGridViewTextBoxColumn";
            // 
            // posterDataGridViewImageColumn
            // 
            this.posterDataGridViewImageColumn.DataPropertyName = "Poster";
            this.posterDataGridViewImageColumn.HeaderText = "影片海报";
            this.posterDataGridViewImageColumn.Name = "posterDataGridViewImageColumn";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加档期ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // 添加档期ToolStripMenuItem
            // 
            this.添加档期ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.暑期档ToolStripMenuItem,
            this.寒假档ToolStripMenuItem,
            this.节后档ToolStripMenuItem});
            this.添加档期ToolStripMenuItem.Name = "添加档期ToolStripMenuItem";
            this.添加档期ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.添加档期ToolStripMenuItem.Text = "添加档期";
            // 
            // 暑期档ToolStripMenuItem
            // 
            this.暑期档ToolStripMenuItem.Name = "暑期档ToolStripMenuItem";
            this.暑期档ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.暑期档ToolStripMenuItem.Text = "暑期档";
            // 
            // 寒假档ToolStripMenuItem
            // 
            this.寒假档ToolStripMenuItem.Name = "寒假档ToolStripMenuItem";
            this.寒假档ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.寒假档ToolStripMenuItem.Text = "寒假档";
            // 
            // 节后档ToolStripMenuItem
            // 
            this.节后档ToolStripMenuItem.Name = "节后档ToolStripMenuItem";
            this.节后档ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.节后档ToolStripMenuItem.Text = "节后档";
            // 
            // movieBindingSource
            // 
            this.movieBindingSource.DataSource = typeof(Model.Movie);
            this.movieBindingSource.CurrentChanged += new System.EventHandler(this.movieBindingSource_CurrentChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCancel);
            this.tabPage2.Controls.Add(this.btnYes);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.cmbUpdate);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(589, 441);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "修改档期";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(165, 324);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(74, 324);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 10;
            this.btnYes.Text = "确认";
            this.btnYes.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(119, 116);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(121, 21);
            this.textBox3.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "影片";
            // 
            // cmbUpdate
            // 
            this.cmbUpdate.FormattingEnabled = true;
            this.cmbUpdate.Location = new System.Drawing.Point(119, 244);
            this.cmbUpdate.Name = "cmbUpdate";
            this.cmbUpdate.Size = new System.Drawing.Size(121, 20);
            this.cmbUpdate.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "更改为";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "原档期";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(119, 180);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(121, 21);
            this.textBox2.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Location = new System.Drawing.Point(40, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 326);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "档期修改";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(279, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(235, 293);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // frmschedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 467);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmschedule";
            this.Text = "影片档期管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmschedule_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovie)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.movieBindingSource)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cmbUpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dgvMovie;
        private System.Windows.Forms.BindingSource movieBindingSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加档期ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 暑期档ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 寒假档ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 节后档ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn movieTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn posterDataGridViewImageColumn;
    }
}