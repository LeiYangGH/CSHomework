namespace WindowsFormsApplication4
{
    partial class splbcx
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
            this.xzlbbtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ceshiDataSet1 = new WindowsFormsApplication4.ceshiDataSet1();
            this.splbBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splbTableAdapter = new WindowsFormsApplication4.ceshiDataSet1TableAdapters.splbTableAdapter();
            this.lbidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbmcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceshiDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splbBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // xzlbbtn
            // 
            this.xzlbbtn.Location = new System.Drawing.Point(37, 24);
            this.xzlbbtn.Name = "xzlbbtn";
            this.xzlbbtn.Size = new System.Drawing.Size(75, 23);
            this.xzlbbtn.TabIndex = 0;
            this.xzlbbtn.Text = "新增";
            this.xzlbbtn.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lbidDataGridViewTextBoxColumn,
            this.lbmcDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.splbBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(23, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(635, 310);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ceshiDataSet1
            // 
            this.ceshiDataSet1.DataSetName = "ceshiDataSet1";
            this.ceshiDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splbBindingSource
            // 
            this.splbBindingSource.DataMember = "splb";
            this.splbBindingSource.DataSource = this.ceshiDataSet1;
            // 
            // splbTableAdapter
            // 
            this.splbTableAdapter.ClearBeforeFill = true;
            // 
            // lbidDataGridViewTextBoxColumn
            // 
            this.lbidDataGridViewTextBoxColumn.DataPropertyName = "lbid";
            this.lbidDataGridViewTextBoxColumn.HeaderText = "类别编号";
            this.lbidDataGridViewTextBoxColumn.Name = "lbidDataGridViewTextBoxColumn";
            // 
            // lbmcDataGridViewTextBoxColumn
            // 
            this.lbmcDataGridViewTextBoxColumn.DataPropertyName = "lbmc";
            this.lbmcDataGridViewTextBoxColumn.HeaderText = "类别名称";
            this.lbmcDataGridViewTextBoxColumn.Name = "lbmcDataGridViewTextBoxColumn";
            // 
            // splbcx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 412);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.xzlbbtn);
            this.Name = "splbcx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品类别";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.splbcx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceshiDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splbBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button xzlbbtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ceshiDataSet1 ceshiDataSet1;
        private System.Windows.Forms.BindingSource splbBindingSource;
        private ceshiDataSet1TableAdapters.splbTableAdapter splbTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn lbidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lbmcDataGridViewTextBoxColumn;
    }
}