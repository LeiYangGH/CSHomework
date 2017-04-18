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
            this.btnAddOut = new System.Windows.Forms.Button();
            this.btnEditIn = new System.Windows.Forms.Button();
            this.btnDelIn = new System.Windows.Forms.Button();
            this.btnEditOut = new System.Windows.Forms.Button();
            this.btnDeleteOut = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIn)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOut
            // 
            this.dgvOut.AllowUserToAddRows = false;
            this.dgvOut.AllowUserToDeleteRows = false;
            this.dgvOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOut.Location = new System.Drawing.Point(56, 394);
            this.dgvOut.MultiSelect = false;
            this.dgvOut.Name = "dgvOut";
            this.dgvOut.ReadOnly = true;
            this.dgvOut.RowTemplate.Height = 28;
            this.dgvOut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
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
            // btnAddOut
            // 
            this.btnAddOut.Location = new System.Drawing.Point(950, 420);
            this.btnAddOut.Name = "btnAddOut";
            this.btnAddOut.Size = new System.Drawing.Size(134, 37);
            this.btnAddOut.TabIndex = 4;
            this.btnAddOut.Text = "添加出库";
            this.btnAddOut.UseVisualStyleBackColor = true;
            this.btnAddOut.Click += new System.EventHandler(this.btnAddOut_Click);
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
            // btnEditOut
            // 
            this.btnEditOut.Location = new System.Drawing.Point(950, 478);
            this.btnEditOut.Name = "btnEditOut";
            this.btnEditOut.Size = new System.Drawing.Size(134, 37);
            this.btnEditOut.TabIndex = 4;
            this.btnEditOut.Text = "编辑出库";
            this.btnEditOut.UseVisualStyleBackColor = true;
            this.btnEditOut.Click += new System.EventHandler(this.btnEditOut_Click);
            // 
            // btnDeleteOut
            // 
            this.btnDeleteOut.Location = new System.Drawing.Point(950, 536);
            this.btnDeleteOut.Name = "btnDeleteOut";
            this.btnDeleteOut.Size = new System.Drawing.Size(134, 37);
            this.btnDeleteOut.TabIndex = 4;
            this.btnDeleteOut.Text = "删除出库";
            this.btnDeleteOut.UseVisualStyleBackColor = true;
            this.btnDeleteOut.Click += new System.EventHandler(this.btnDeleteOut_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1096, 32);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            this.查询ToolStripMenuItem.Text = "查询";
            this.查询ToolStripMenuItem.Click += new System.EventHandler(this.查询ToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 679);
            this.Controls.Add(this.btnDelIn);
            this.Controls.Add(this.btnEditIn);
            this.Controls.Add(this.btnDeleteOut);
            this.Controls.Add(this.btnEditOut);
            this.Controls.Add(this.btnAddOut);
            this.Controls.Add(this.btnAddIn);
            this.Controls.Add(this.dgvIn);
            this.Controls.Add(this.dgvOut);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "汽车配件出入库";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIn)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvOut;
        private System.Windows.Forms.DataGridView dgvIn;
        private System.Windows.Forms.Button btnAddIn;
        private System.Windows.Forms.Button btnAddOut;
        private System.Windows.Forms.Button btnEditIn;
        private System.Windows.Forms.Button btnDelIn;
        private System.Windows.Forms.Button btnEditOut;
        private System.Windows.Forms.Button btnDeleteOut;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
    }
}

