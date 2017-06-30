namespace WpfApplicationxxx
{
    partial class peifang
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.peifang2DataSet1 = new WpfApplicationxxx.peifang2DataSet();
            this.peifang2TableAdapter1 = new WpfApplicationxxx.peifang2DataSetTableAdapters.peifang2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peifang2DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(35, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(620, 214);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // peifang2DataSet1
            // 
            this.peifang2DataSet1.DataSetName = "peifang2DataSet";
            this.peifang2DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // peifang2TableAdapter1
            // 
            this.peifang2TableAdapter1.ClearBeforeFill = true;
            // 
            // peifang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 262);
            this.Controls.Add(this.dataGridView1);
            this.Name = "peifang";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.peifang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peifang2DataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

       

        private System.Windows.Forms.DataGridView dataGridView1;
        private peifang2DataSet peifang2DataSet1;
        private peifang2DataSetTableAdapters.peifang2TableAdapter peifang2TableAdapter1;
    }
}