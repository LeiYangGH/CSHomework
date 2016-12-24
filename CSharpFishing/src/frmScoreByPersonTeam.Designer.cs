namespace Main_interface
{
    partial class frmScoreByPersonTeam
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
            this.dgvPeron = new System.Windows.Forms.DataGridView();
            this.btnByWeight = new System.Windows.Forms.Button();
            this.btnByCount = new System.Windows.Forms.Button();
            this.dgvTeam = new System.Windows.Forms.DataGridView();
            this.btnTeamWeight = new System.Windows.Forms.Button();
            this.btnTeamCount = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeron)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPeron
            // 
            this.dgvPeron.AllowUserToAddRows = false;
            this.dgvPeron.AllowUserToDeleteRows = false;
            this.dgvPeron.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeron.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPeron.Location = new System.Drawing.Point(0, 0);
            this.dgvPeron.Name = "dgvPeron";
            this.dgvPeron.ReadOnly = true;
            this.dgvPeron.RowTemplate.Height = 28;
            this.dgvPeron.Size = new System.Drawing.Size(1603, 259);
            this.dgvPeron.TabIndex = 0;
            // 
            // btnByWeight
            // 
            this.btnByWeight.Location = new System.Drawing.Point(322, 288);
            this.btnByWeight.Name = "btnByWeight";
            this.btnByWeight.Size = new System.Drawing.Size(164, 42);
            this.btnByWeight.TabIndex = 1;
            this.btnByWeight.Text = "按重量计算";
            this.btnByWeight.UseVisualStyleBackColor = true;
            this.btnByWeight.Click += new System.EventHandler(this.btnByWeight_Click);
            // 
            // btnByCount
            // 
            this.btnByCount.Location = new System.Drawing.Point(577, 288);
            this.btnByCount.Name = "btnByCount";
            this.btnByCount.Size = new System.Drawing.Size(164, 42);
            this.btnByCount.TabIndex = 1;
            this.btnByCount.Text = "按尾数计算";
            this.btnByCount.UseVisualStyleBackColor = true;
            this.btnByCount.Click += new System.EventHandler(this.btnByCount_Click);
            // 
            // dgvTeam
            // 
            this.dgvTeam.AllowUserToAddRows = false;
            this.dgvTeam.AllowUserToDeleteRows = false;
            this.dgvTeam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeam.Location = new System.Drawing.Point(12, 352);
            this.dgvTeam.Name = "dgvTeam";
            this.dgvTeam.ReadOnly = true;
            this.dgvTeam.RowTemplate.Height = 28;
            this.dgvTeam.Size = new System.Drawing.Size(1564, 230);
            this.dgvTeam.TabIndex = 2;
            // 
            // btnTeamWeight
            // 
            this.btnTeamWeight.Location = new System.Drawing.Point(332, 615);
            this.btnTeamWeight.Name = "btnTeamWeight";
            this.btnTeamWeight.Size = new System.Drawing.Size(154, 37);
            this.btnTeamWeight.TabIndex = 3;
            this.btnTeamWeight.Text = "按重量";
            this.btnTeamWeight.UseVisualStyleBackColor = true;
            this.btnTeamWeight.Click += new System.EventHandler(this.btnTeamWeight_Click);
            // 
            // btnTeamCount
            // 
            this.btnTeamCount.Location = new System.Drawing.Point(587, 615);
            this.btnTeamCount.Name = "btnTeamCount";
            this.btnTeamCount.Size = new System.Drawing.Size(154, 37);
            this.btnTeamCount.TabIndex = 3;
            this.btnTeamCount.Text = "按尾数";
            this.btnTeamCount.UseVisualStyleBackColor = true;
            this.btnTeamCount.Click += new System.EventHandler(this.btnTeamCount_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(40, 603);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 26);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // frmScoreByPersonTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1603, 664);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btnTeamCount);
            this.Controls.Add(this.btnTeamWeight);
            this.Controls.Add(this.dgvTeam);
            this.Controls.Add(this.btnByCount);
            this.Controls.Add(this.btnByWeight);
            this.Controls.Add(this.dgvPeron);
            this.Name = "frmScoreByPersonTeam";
            this.Text = "frmScoreByPersonTeam";
            this.Load += new System.EventHandler(this.frmScoreByPersonTeam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeron)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPeron;
        private System.Windows.Forms.Button btnByWeight;
        private System.Windows.Forms.Button btnByCount;
        private System.Windows.Forms.DataGridView dgvTeam;
        private System.Windows.Forms.Button btnTeamWeight;
        private System.Windows.Forms.Button btnTeamCount;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}