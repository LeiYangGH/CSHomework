namespace 反坦克导弹数据查询软件
{
    partial class frmUpdate
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dDDataSet = new 反坦克导弹数据查询软件.DDDataSet();
            this.aKDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aKDTableAdapter = new 反坦克导弹数据查询软件.DDDataSetTableAdapters.AKDTableAdapter();
            this.导弹名称DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.国家DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.导弹弹长DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.导弹弹径DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.导弹翼展DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.导弹弹重DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.导弹最小射程DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.导弹最大射程DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.飞行速度DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.破甲厚度DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.战斗部DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.制导方式DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.导引头DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.动力装置DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.命中概率DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.发射载体DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.使用条件DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.生产厂家DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.图片DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dDDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aKDBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.导弹名称DataGridViewTextBoxColumn,
            this.国家DataGridViewTextBoxColumn,
            this.导弹弹长DataGridViewTextBoxColumn,
            this.导弹弹径DataGridViewTextBoxColumn,
            this.导弹翼展DataGridViewTextBoxColumn,
            this.导弹弹重DataGridViewTextBoxColumn,
            this.导弹最小射程DataGridViewTextBoxColumn,
            this.导弹最大射程DataGridViewTextBoxColumn,
            this.飞行速度DataGridViewTextBoxColumn,
            this.破甲厚度DataGridViewTextBoxColumn,
            this.战斗部DataGridViewTextBoxColumn,
            this.制导方式DataGridViewTextBoxColumn,
            this.导引头DataGridViewTextBoxColumn,
            this.动力装置DataGridViewTextBoxColumn,
            this.命中概率DataGridViewTextBoxColumn,
            this.发射载体DataGridViewTextBoxColumn,
            this.使用条件DataGridViewTextBoxColumn,
            this.生产厂家DataGridViewTextBoxColumn,
            this.图片DataGridViewTextBoxColumn,
            this.kDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.aKDBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(31, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(745, 543);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(808, 217);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(121, 57);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dDDataSet
            // 
            this.dDDataSet.DataSetName = "DDDataSet";
            this.dDDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aKDBindingSource
            // 
            this.aKDBindingSource.DataMember = "AKD";
            this.aKDBindingSource.DataSource = this.dDDataSet;
            // 
            // aKDTableAdapter
            // 
            this.aKDTableAdapter.ClearBeforeFill = true;
            // 
            // 导弹名称DataGridViewTextBoxColumn
            // 
            this.导弹名称DataGridViewTextBoxColumn.DataPropertyName = "导弹名称";
            this.导弹名称DataGridViewTextBoxColumn.HeaderText = "导弹名称";
            this.导弹名称DataGridViewTextBoxColumn.Name = "导弹名称DataGridViewTextBoxColumn";
            // 
            // 国家DataGridViewTextBoxColumn
            // 
            this.国家DataGridViewTextBoxColumn.DataPropertyName = "国家";
            this.国家DataGridViewTextBoxColumn.HeaderText = "国家";
            this.国家DataGridViewTextBoxColumn.Name = "国家DataGridViewTextBoxColumn";
            // 
            // 导弹弹长DataGridViewTextBoxColumn
            // 
            this.导弹弹长DataGridViewTextBoxColumn.DataPropertyName = "导弹弹长";
            this.导弹弹长DataGridViewTextBoxColumn.HeaderText = "导弹弹长";
            this.导弹弹长DataGridViewTextBoxColumn.Name = "导弹弹长DataGridViewTextBoxColumn";
            // 
            // 导弹弹径DataGridViewTextBoxColumn
            // 
            this.导弹弹径DataGridViewTextBoxColumn.DataPropertyName = "导弹弹径";
            this.导弹弹径DataGridViewTextBoxColumn.HeaderText = "导弹弹径";
            this.导弹弹径DataGridViewTextBoxColumn.Name = "导弹弹径DataGridViewTextBoxColumn";
            // 
            // 导弹翼展DataGridViewTextBoxColumn
            // 
            this.导弹翼展DataGridViewTextBoxColumn.DataPropertyName = "导弹翼展";
            this.导弹翼展DataGridViewTextBoxColumn.HeaderText = "导弹翼展";
            this.导弹翼展DataGridViewTextBoxColumn.Name = "导弹翼展DataGridViewTextBoxColumn";
            // 
            // 导弹弹重DataGridViewTextBoxColumn
            // 
            this.导弹弹重DataGridViewTextBoxColumn.DataPropertyName = "导弹弹重";
            this.导弹弹重DataGridViewTextBoxColumn.HeaderText = "导弹弹重";
            this.导弹弹重DataGridViewTextBoxColumn.Name = "导弹弹重DataGridViewTextBoxColumn";
            // 
            // 导弹最小射程DataGridViewTextBoxColumn
            // 
            this.导弹最小射程DataGridViewTextBoxColumn.DataPropertyName = "导弹最小射程";
            this.导弹最小射程DataGridViewTextBoxColumn.HeaderText = "导弹最小射程";
            this.导弹最小射程DataGridViewTextBoxColumn.Name = "导弹最小射程DataGridViewTextBoxColumn";
            // 
            // 导弹最大射程DataGridViewTextBoxColumn
            // 
            this.导弹最大射程DataGridViewTextBoxColumn.DataPropertyName = "导弹最大射程";
            this.导弹最大射程DataGridViewTextBoxColumn.HeaderText = "导弹最大射程";
            this.导弹最大射程DataGridViewTextBoxColumn.Name = "导弹最大射程DataGridViewTextBoxColumn";
            // 
            // 飞行速度DataGridViewTextBoxColumn
            // 
            this.飞行速度DataGridViewTextBoxColumn.DataPropertyName = "飞行速度";
            this.飞行速度DataGridViewTextBoxColumn.HeaderText = "飞行速度";
            this.飞行速度DataGridViewTextBoxColumn.Name = "飞行速度DataGridViewTextBoxColumn";
            // 
            // 破甲厚度DataGridViewTextBoxColumn
            // 
            this.破甲厚度DataGridViewTextBoxColumn.DataPropertyName = "破甲厚度";
            this.破甲厚度DataGridViewTextBoxColumn.HeaderText = "破甲厚度";
            this.破甲厚度DataGridViewTextBoxColumn.Name = "破甲厚度DataGridViewTextBoxColumn";
            // 
            // 战斗部DataGridViewTextBoxColumn
            // 
            this.战斗部DataGridViewTextBoxColumn.DataPropertyName = "战斗部";
            this.战斗部DataGridViewTextBoxColumn.HeaderText = "战斗部";
            this.战斗部DataGridViewTextBoxColumn.Name = "战斗部DataGridViewTextBoxColumn";
            // 
            // 制导方式DataGridViewTextBoxColumn
            // 
            this.制导方式DataGridViewTextBoxColumn.DataPropertyName = "制导方式";
            this.制导方式DataGridViewTextBoxColumn.HeaderText = "制导方式";
            this.制导方式DataGridViewTextBoxColumn.Name = "制导方式DataGridViewTextBoxColumn";
            // 
            // 导引头DataGridViewTextBoxColumn
            // 
            this.导引头DataGridViewTextBoxColumn.DataPropertyName = "导引头";
            this.导引头DataGridViewTextBoxColumn.HeaderText = "导引头";
            this.导引头DataGridViewTextBoxColumn.Name = "导引头DataGridViewTextBoxColumn";
            // 
            // 动力装置DataGridViewTextBoxColumn
            // 
            this.动力装置DataGridViewTextBoxColumn.DataPropertyName = "动力装置";
            this.动力装置DataGridViewTextBoxColumn.HeaderText = "动力装置";
            this.动力装置DataGridViewTextBoxColumn.Name = "动力装置DataGridViewTextBoxColumn";
            // 
            // 命中概率DataGridViewTextBoxColumn
            // 
            this.命中概率DataGridViewTextBoxColumn.DataPropertyName = "命中概率";
            this.命中概率DataGridViewTextBoxColumn.HeaderText = "命中概率";
            this.命中概率DataGridViewTextBoxColumn.Name = "命中概率DataGridViewTextBoxColumn";
            // 
            // 发射载体DataGridViewTextBoxColumn
            // 
            this.发射载体DataGridViewTextBoxColumn.DataPropertyName = "发射载体";
            this.发射载体DataGridViewTextBoxColumn.HeaderText = "发射载体";
            this.发射载体DataGridViewTextBoxColumn.Name = "发射载体DataGridViewTextBoxColumn";
            // 
            // 使用条件DataGridViewTextBoxColumn
            // 
            this.使用条件DataGridViewTextBoxColumn.DataPropertyName = "使用条件";
            this.使用条件DataGridViewTextBoxColumn.HeaderText = "使用条件";
            this.使用条件DataGridViewTextBoxColumn.Name = "使用条件DataGridViewTextBoxColumn";
            // 
            // 生产厂家DataGridViewTextBoxColumn
            // 
            this.生产厂家DataGridViewTextBoxColumn.DataPropertyName = "生产厂家";
            this.生产厂家DataGridViewTextBoxColumn.HeaderText = "生产厂家";
            this.生产厂家DataGridViewTextBoxColumn.Name = "生产厂家DataGridViewTextBoxColumn";
            // 
            // 图片DataGridViewTextBoxColumn
            // 
            this.图片DataGridViewTextBoxColumn.DataPropertyName = "图片";
            this.图片DataGridViewTextBoxColumn.HeaderText = "图片";
            this.图片DataGridViewTextBoxColumn.Name = "图片DataGridViewTextBoxColumn";
            // 
            // kDataGridViewTextBoxColumn
            // 
            this.kDataGridViewTextBoxColumn.DataPropertyName = "K";
            this.kDataGridViewTextBoxColumn.HeaderText = "K";
            this.kDataGridViewTextBoxColumn.Name = "kDataGridViewTextBoxColumn";
            // 
            // frmUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 622);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmUpdate";
            this.Text = "frmUpdate";
            this.Load += new System.EventHandler(this.frmUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dDDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aKDBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnUpdate;
        private DDDataSet dDDataSet;
        private System.Windows.Forms.BindingSource aKDBindingSource;
        private DDDataSetTableAdapters.AKDTableAdapter aKDTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn 导弹名称DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 国家DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 导弹弹长DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 导弹弹径DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 导弹翼展DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 导弹弹重DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 导弹最小射程DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 导弹最大射程DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 飞行速度DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 破甲厚度DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 战斗部DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 制导方式DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 导引头DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 动力装置DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 命中概率DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 发射载体DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 使用条件DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 生产厂家DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 图片DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kDataGridViewTextBoxColumn;
    }
}