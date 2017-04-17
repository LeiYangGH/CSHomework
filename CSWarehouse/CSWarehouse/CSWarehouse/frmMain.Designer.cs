namespace CSWarehouse
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
            this.dgvOut = new System.Windows.Forms.DataGridView();
            this.dgvIn = new System.Windows.Forms.DataGridView();
            this.btnAddIn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnEditIn = new System.Windows.Forms.Button();
            this.btnDelIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIn)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOut
            // 
            this.dgvOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOut.Location = new System.Drawing.Point(56, 394);
            this.dgvOut.Name = "dgvOut";
            this.dgvOut.RowTemplate.Height = 28;
            this.dgvOut.Size = new System.Drawing.Size(879, 203);
            this.dgvOut.TabIndex = 2;
            // 
            // dgvIn
            // 
            this.dgvIn.AllowUserToAddRows = false;
            this.dgvIn.AllowUserToDeleteRows = false;
            this.dgvIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIn.Location = new System.Drawing.Point(56, 67);
            this.dgvIn.MultiSelect = false;
            this.dgvIn.Name = "dgvIn";
            this.dgvIn.ReadOnly = true;
            this.dgvIn.RowTemplate.Height = 28;
            this.dgvIn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIn.Size = new System.Drawing.Size(879, 245);
            this.dgvIn.TabIndex = 2;
            // 
            // btnAddIn
            // 
            this.btnAddIn.Location = new System.Drawing.Point(950, 67);
            this.btnAddIn.Name = "btnAddIn";
            this.btnAddIn.Size = new System.Drawing.Size(134, 38);
            this.btnAddIn.TabIndex = 3;
            this.btnAddIn.Text = "添加入库";
            this.btnAddIn.UseVisualStyleBackColor = true;
            this.btnAddIn.Click += new System.EventHandler(this.btnAddIn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(950, 480);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 37);
            this.button3.TabIndex = 4;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnEditIn
            // 
            this.btnEditIn.Location = new System.Drawing.Point(950, 130);
            this.btnEditIn.Name = "btnEditIn";
            this.btnEditIn.Size = new System.Drawing.Size(134, 41);
            this.btnEditIn.TabIndex = 5;
            this.btnEditIn.Text = "编辑入库";
            this.btnEditIn.UseVisualStyleBackColor = true;
            this.btnEditIn.Click += new System.EventHandler(this.btnEditIn_Click);
            // 
            // btnDelIn
            // 
            this.btnDelIn.Location = new System.Drawing.Point(950, 198);
            this.btnDelIn.Name = "btnDelIn";
            this.btnDelIn.Size = new System.Drawing.Size(134, 41);
            this.btnDelIn.TabIndex = 6;
            this.btnDelIn.Text = "删除入库";
            this.btnDelIn.UseVisualStyleBackColor = true;
            this.btnDelIn.Click += new System.EventHandler(this.btnDelIn_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 679);
            this.Controls.Add(this.btnDelIn);
            this.Controls.Add(this.btnEditIn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnAddIn);
            this.Controls.Add(this.dgvIn);
            this.Controls.Add(this.dgvOut);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvOut;
        private System.Windows.Forms.DataGridView dgvIn;
        private System.Windows.Forms.Button btnAddIn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnEditIn;
        private System.Windows.Forms.Button btnDelIn;
    }
}

