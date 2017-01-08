namespace HallManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ltHall = new System.Windows.Forms.ListBox();
            this.hallBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvPosition = new System.Windows.Forms.DataGridView();
            this.layoutBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpNewLayoutSet = new System.Windows.Forms.GroupBox();
            this.txtColNum = new System.Windows.Forms.TextBox();
            this.btnLayoutSaveNew = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRowNum = new System.Windows.Forms.TextBox();
            this.btnLayoutSaveChange = new System.Windows.Forms.Button();
            this.btnLayoutDelete = new System.Windows.Forms.Button();
            this.cboPositionType = new System.Windows.Forms.ComboBox();
            this.positionTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnLayoutCreate = new System.Windows.Forms.Button();
            this.txtStyle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmsPosition = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiPositionTypeChange = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPositionTypeState = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHallDrop = new System.Windows.Forms.Button();
            this.btnHallSaveChange = new System.Windows.Forms.Button();
            this.btnHallNew = new System.Windows.Forms.Button();
            this.txtHallName = new System.Windows.Forms.TextBox();
            this.cboLayout = new System.Windows.Forms.ComboBox();
            this.txtHallTheme = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHallId = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPositionTypeName = new System.Windows.Forms.TextBox();
            this.btnPositionTypeDelete = new System.Windows.Forms.Button();
            this.btnPositionTypeChangeName = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPositionTypeNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.hallBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutBindingSource)).BeginInit();
            this.grpNewLayoutSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionTypeBindingSource)).BeginInit();
            this.cmsPosition.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ltHall
            // 
            this.ltHall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ltHall.DataSource = this.hallBindingSource;
            this.ltHall.DisplayMember = "Name";
            this.ltHall.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ltHall.FormattingEnabled = true;
            this.ltHall.ItemHeight = 19;
            this.ltHall.Location = new System.Drawing.Point(12, 12);
            this.ltHall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ltHall.Name = "ltHall";
            this.ltHall.Size = new System.Drawing.Size(186, 479);
            this.ltHall.TabIndex = 0;
            // 
            // hallBindingSource
            // 
            this.hallBindingSource.DataMember = global::HallManager.Properties.Settings.Default.Name;
            this.hallBindingSource.DataSource = typeof(Model.Hall);
            this.hallBindingSource.CurrentChanged += new System.EventHandler(this.hallBindingSource_CurrentChanged);
            // 
            // dgvPosition
            // 
            this.dgvPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPosition.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPosition.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPosition.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPosition.Location = new System.Drawing.Point(204, 116);
            this.dgvPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPosition.Name = "dgvPosition";
            this.dgvPosition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPosition.Size = new System.Drawing.Size(929, 381);
            this.dgvPosition.TabIndex = 1;
            this.dgvPosition.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPosition_CellMouseClick);
            // 
            // layoutBindingSource
            // 
            this.layoutBindingSource.DataSource = typeof(Model.Layout);
            this.layoutBindingSource.CurrentChanged += new System.EventHandler(this.layoutBindingSource_CurrentChanged);
            // 
            // grpNewLayoutSet
            // 
            this.grpNewLayoutSet.Controls.Add(this.txtColNum);
            this.grpNewLayoutSet.Controls.Add(this.btnLayoutSaveNew);
            this.grpNewLayoutSet.Controls.Add(this.label6);
            this.grpNewLayoutSet.Controls.Add(this.label2);
            this.grpNewLayoutSet.Controls.Add(this.label8);
            this.grpNewLayoutSet.Controls.Add(this.txtRowNum);
            this.grpNewLayoutSet.Controls.Add(this.btnLayoutSaveChange);
            this.grpNewLayoutSet.Controls.Add(this.btnLayoutDelete);
            this.grpNewLayoutSet.Controls.Add(this.cboPositionType);
            this.grpNewLayoutSet.Controls.Add(this.btnLayoutCreate);
            this.grpNewLayoutSet.Controls.Add(this.txtStyle);
            this.grpNewLayoutSet.Controls.Add(this.label7);
            this.grpNewLayoutSet.Location = new System.Drawing.Point(565, 7);
            this.grpNewLayoutSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpNewLayoutSet.Name = "grpNewLayoutSet";
            this.grpNewLayoutSet.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpNewLayoutSet.Size = new System.Drawing.Size(317, 103);
            this.grpNewLayoutSet.TabIndex = 6;
            this.grpNewLayoutSet.TabStop = false;
            this.grpNewLayoutSet.Text = "布局设置";
            // 
            // txtColNum
            // 
            this.txtColNum.Location = new System.Drawing.Point(219, 41);
            this.txtColNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtColNum.Name = "txtColNum";
            this.txtColNum.Size = new System.Drawing.Size(76, 20);
            this.txtColNum.TabIndex = 10;
            // 
            // btnLayoutSaveNew
            // 
            this.btnLayoutSaveNew.Enabled = false;
            this.btnLayoutSaveNew.Location = new System.Drawing.Point(81, 73);
            this.btnLayoutSaveNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLayoutSaveNew.Name = "btnLayoutSaveNew";
            this.btnLayoutSaveNew.Size = new System.Drawing.Size(70, 24);
            this.btnLayoutSaveNew.TabIndex = 5;
            this.btnLayoutSaveNew.Text = "保存布局";
            this.btnLayoutSaveNew.UseVisualStyleBackColor = true;
            this.btnLayoutSaveNew.Click += new System.EventHandler(this.btnLayoutSaveNew_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "行数:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "位置类型:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(178, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "列数:";
            // 
            // txtRowNum
            // 
            this.txtRowNum.Location = new System.Drawing.Point(47, 41);
            this.txtRowNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRowNum.Name = "txtRowNum";
            this.txtRowNum.Size = new System.Drawing.Size(72, 20);
            this.txtRowNum.TabIndex = 11;
            // 
            // btnLayoutSaveChange
            // 
            this.btnLayoutSaveChange.Enabled = false;
            this.btnLayoutSaveChange.Location = new System.Drawing.Point(235, 73);
            this.btnLayoutSaveChange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLayoutSaveChange.Name = "btnLayoutSaveChange";
            this.btnLayoutSaveChange.Size = new System.Drawing.Size(72, 24);
            this.btnLayoutSaveChange.TabIndex = 5;
            this.btnLayoutSaveChange.Text = "保存更改";
            this.btnLayoutSaveChange.UseVisualStyleBackColor = true;
            this.btnLayoutSaveChange.Click += new System.EventHandler(this.btnLayoutSaveChange_Click);
            // 
            // btnLayoutDelete
            // 
            this.btnLayoutDelete.Enabled = false;
            this.btnLayoutDelete.Location = new System.Drawing.Point(157, 73);
            this.btnLayoutDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLayoutDelete.Name = "btnLayoutDelete";
            this.btnLayoutDelete.Size = new System.Drawing.Size(72, 24);
            this.btnLayoutDelete.TabIndex = 5;
            this.btnLayoutDelete.Text = "删除布局";
            this.btnLayoutDelete.UseVisualStyleBackColor = true;
            this.btnLayoutDelete.Click += new System.EventHandler(this.btnLayoutDelete_Click);
            // 
            // cboPositionType
            // 
            this.cboPositionType.DataSource = this.positionTypeBindingSource;
            this.cboPositionType.DisplayMember = "Name";
            this.cboPositionType.FormattingEnabled = true;
            this.cboPositionType.Location = new System.Drawing.Point(219, 15);
            this.cboPositionType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboPositionType.Name = "cboPositionType";
            this.cboPositionType.Size = new System.Drawing.Size(88, 21);
            this.cboPositionType.TabIndex = 12;
            this.cboPositionType.ValueMember = "Id";
            // 
            // positionTypeBindingSource
            // 
            this.positionTypeBindingSource.DataSource = typeof(Model.PositionType);
            // 
            // btnLayoutCreate
            // 
            this.btnLayoutCreate.Location = new System.Drawing.Point(4, 73);
            this.btnLayoutCreate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLayoutCreate.Name = "btnLayoutCreate";
            this.btnLayoutCreate.Size = new System.Drawing.Size(71, 24);
            this.btnLayoutCreate.TabIndex = 5;
            this.btnLayoutCreate.Text = "创建布局";
            this.btnLayoutCreate.UseVisualStyleBackColor = true;
            this.btnLayoutCreate.Click += new System.EventHandler(this.btnLayoutCreate_Click);
            // 
            // txtStyle
            // 
            this.txtStyle.Location = new System.Drawing.Point(47, 15);
            this.txtStyle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStyle.Name = "txtStyle";
            this.txtStyle.Size = new System.Drawing.Size(72, 20);
            this.txtStyle.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "风格:";
            // 
            // cmsPosition
            // 
            this.cmsPosition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPositionTypeChange,
            this.tsmiPositionTypeState});
            this.cmsPosition.Name = "cmsPosition";
            this.cmsPosition.Size = new System.Drawing.Size(156, 48);
            // 
            // tsmiPositionTypeChange
            // 
            this.tsmiPositionTypeChange.Name = "tsmiPositionTypeChange";
            this.tsmiPositionTypeChange.Size = new System.Drawing.Size(155, 22);
            this.tsmiPositionTypeChange.Text = "更改座位类型";
            // 
            // tsmiPositionTypeState
            // 
            this.tsmiPositionTypeState.Name = "tsmiPositionTypeState";
            this.tsmiPositionTypeState.Size = new System.Drawing.Size(155, 22);
            this.tsmiPositionTypeState.Text = " 更改可用状态";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHallDrop);
            this.groupBox1.Controls.Add(this.btnHallSaveChange);
            this.groupBox1.Controls.Add(this.btnHallNew);
            this.groupBox1.Controls.Add(this.txtHallName);
            this.groupBox1.Controls.Add(this.cboLayout);
            this.groupBox1.Controls.Add(this.txtHallTheme);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblHallId);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(204, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(355, 103);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "放映厅设置";
            // 
            // btnHallDrop
            // 
            this.btnHallDrop.Location = new System.Drawing.Point(187, 73);
            this.btnHallDrop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHallDrop.Name = "btnHallDrop";
            this.btnHallDrop.Size = new System.Drawing.Size(84, 24);
            this.btnHallDrop.TabIndex = 13;
            this.btnHallDrop.Text = "删除放映厅";
            this.btnHallDrop.UseVisualStyleBackColor = true;
            this.btnHallDrop.Click += new System.EventHandler(this.btnHallDrop_Click);
            // 
            // btnHallSaveChange
            // 
            this.btnHallSaveChange.Enabled = false;
            this.btnHallSaveChange.Location = new System.Drawing.Point(97, 73);
            this.btnHallSaveChange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHallSaveChange.Name = "btnHallSaveChange";
            this.btnHallSaveChange.Size = new System.Drawing.Size(84, 24);
            this.btnHallSaveChange.TabIndex = 13;
            this.btnHallSaveChange.Text = "保存更改";
            this.btnHallSaveChange.UseVisualStyleBackColor = true;
            this.btnHallSaveChange.Click += new System.EventHandler(this.btnHallSaveChange_Click);
            // 
            // btnHallNew
            // 
            this.btnHallNew.Location = new System.Drawing.Point(7, 73);
            this.btnHallNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHallNew.Name = "btnHallNew";
            this.btnHallNew.Size = new System.Drawing.Size(84, 24);
            this.btnHallNew.TabIndex = 13;
            this.btnHallNew.Text = "新放映厅";
            this.btnHallNew.UseVisualStyleBackColor = true;
            this.btnHallNew.Click += new System.EventHandler(this.btnHallNew_Click);
            // 
            // txtHallName
            // 
            this.txtHallName.Location = new System.Drawing.Point(249, 15);
            this.txtHallName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHallName.Name = "txtHallName";
            this.txtHallName.Size = new System.Drawing.Size(100, 20);
            this.txtHallName.TabIndex = 10;
            // 
            // cboLayout
            // 
            this.cboLayout.DataSource = this.layoutBindingSource;
            this.cboLayout.DisplayMember = "Style";
            this.cboLayout.FormattingEnabled = true;
            this.cboLayout.Location = new System.Drawing.Point(249, 41);
            this.cboLayout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboLayout.Name = "cboLayout";
            this.cboLayout.Size = new System.Drawing.Size(99, 21);
            this.cboLayout.TabIndex = 12;
            // 
            // txtHallTheme
            // 
            this.txtHallTheme.Location = new System.Drawing.Point(68, 41);
            this.txtHallTheme.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHallTheme.Name = "txtHallTheme";
            this.txtHallTheme.Size = new System.Drawing.Size(91, 20);
            this.txtHallTheme.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "影厅主题:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "影厅名字:";
            // 
            // lblHallId
            // 
            this.lblHallId.AutoSize = true;
            this.lblHallId.Location = new System.Drawing.Point(68, 20);
            this.lblHallId.Name = "lblHallId";
            this.lblHallId.Size = new System.Drawing.Size(37, 13);
            this.lblHallId.TabIndex = 7;
            this.lblHallId.Text = "00000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "影厅布局:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "影厅编号:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPositionTypeName);
            this.groupBox2.Controls.Add(this.btnPositionTypeDelete);
            this.groupBox2.Controls.Add(this.btnPositionTypeChangeName);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnPositionTypeNew);
            this.groupBox2.Location = new System.Drawing.Point(888, 7);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(239, 103);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "位置类型设置";
            // 
            // txtPositionTypeName
            // 
            this.txtPositionTypeName.Location = new System.Drawing.Point(70, 15);
            this.txtPositionTypeName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPositionTypeName.Name = "txtPositionTypeName";
            this.txtPositionTypeName.Size = new System.Drawing.Size(100, 20);
            this.txtPositionTypeName.TabIndex = 1;
            // 
            // btnPositionTypeDelete
            // 
            this.btnPositionTypeDelete.Location = new System.Drawing.Point(154, 73);
            this.btnPositionTypeDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPositionTypeDelete.Name = "btnPositionTypeDelete";
            this.btnPositionTypeDelete.Size = new System.Drawing.Size(68, 24);
            this.btnPositionTypeDelete.TabIndex = 0;
            this.btnPositionTypeDelete.Text = "删除类型";
            this.btnPositionTypeDelete.UseVisualStyleBackColor = true;
            this.btnPositionTypeDelete.Click += new System.EventHandler(this.btnPositionTypeDelete_Click);
            // 
            // btnPositionTypeChangeName
            // 
            this.btnPositionTypeChangeName.Location = new System.Drawing.Point(80, 73);
            this.btnPositionTypeChangeName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPositionTypeChangeName.Name = "btnPositionTypeChangeName";
            this.btnPositionTypeChangeName.Size = new System.Drawing.Size(68, 24);
            this.btnPositionTypeChangeName.TabIndex = 0;
            this.btnPositionTypeChangeName.Text = "更改名称";
            this.btnPositionTypeChangeName.UseVisualStyleBackColor = true;
            this.btnPositionTypeChangeName.Click += new System.EventHandler(this.btnPositionTypeChangeName_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "位置类型:";
            // 
            // btnPositionTypeNew
            // 
            this.btnPositionTypeNew.Location = new System.Drawing.Point(6, 73);
            this.btnPositionTypeNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPositionTypeNew.Name = "btnPositionTypeNew";
            this.btnPositionTypeNew.Size = new System.Drawing.Size(68, 24);
            this.btnPositionTypeNew.TabIndex = 0;
            this.btnPositionTypeNew.Text = "新增位置类型";
            this.btnPositionTypeNew.UseVisualStyleBackColor = true;
            this.btnPositionTypeNew.Click += new System.EventHandler(this.btnPositionTypeNew_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 500);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpNewLayoutSet);
            this.Controls.Add(this.dgvPosition);
            this.Controls.Add(this.ltHall);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.Text = "影院布局管理";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hallBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutBindingSource)).EndInit();
            this.grpNewLayoutSet.ResumeLayout(false);
            this.grpNewLayoutSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionTypeBindingSource)).EndInit();
            this.cmsPosition.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ltHall;
        private System.Windows.Forms.DataGridView dgvPosition;
        private System.Windows.Forms.GroupBox grpNewLayoutSet;
        private System.Windows.Forms.TextBox txtStyle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource hallBindingSource;
        private System.Windows.Forms.BindingSource layoutBindingSource;
        private System.Windows.Forms.Button btnLayoutDelete;
        private System.Windows.Forms.Button btnLayoutSaveNew;
        private System.Windows.Forms.Button btnLayoutCreate;
        private System.Windows.Forms.BindingSource positionTypeBindingSource;
        private System.Windows.Forms.ContextMenuStrip cmsPosition;
        private System.Windows.Forms.TextBox txtColNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPositionType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRowNum;
        private System.Windows.Forms.ToolStripMenuItem tsmiPositionTypeChange;
        private System.Windows.Forms.ToolStripMenuItem tsmiPositionTypeState;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtHallName;
        private System.Windows.Forms.ComboBox cboLayout;
        private System.Windows.Forms.TextBox txtHallTheme;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHallId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHallDrop;
        private System.Windows.Forms.Button btnHallSaveChange;
        private System.Windows.Forms.Button btnHallNew;
        private System.Windows.Forms.Button btnLayoutSaveChange;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPositionTypeName;
        private System.Windows.Forms.Button btnPositionTypeDelete;
        private System.Windows.Forms.Button btnPositionTypeChangeName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPositionTypeNew;
    }
}

