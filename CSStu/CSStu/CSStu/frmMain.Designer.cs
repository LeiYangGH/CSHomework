namespace CSStu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.courseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboStu = new System.Windows.Forms.ComboBox();
            this.cboCourse = new System.Windows.Forms.ComboBox();
            this.dgvScore = new System.Windows.Forms.DataGridView();
            this.numMark = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtMajor = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMark)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.courseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1031, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // courseToolStripMenuItem
            // 
            this.courseToolStripMenuItem.Name = "courseToolStripMenuItem";
            this.courseToolStripMenuItem.Size = new System.Drawing.Size(79, 29);
            this.courseToolStripMenuItem.Text = "Course";
            this.courseToolStripMenuItem.Click += new System.EventHandler(this.courseToolStripMenuItem_Click);
            // 
            // cboStu
            // 
            this.cboStu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStu.FormattingEnabled = true;
            this.cboStu.Location = new System.Drawing.Point(55, 69);
            this.cboStu.Name = "cboStu";
            this.cboStu.Size = new System.Drawing.Size(278, 28);
            this.cboStu.TabIndex = 1;
            this.cboStu.SelectedIndexChanged += new System.EventHandler(this.cboStu_SelectedIndexChanged);
            // 
            // cboCourse
            // 
            this.cboCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCourse.FormattingEnabled = true;
            this.cboCourse.Location = new System.Drawing.Point(545, 69);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(278, 28);
            this.cboCourse.TabIndex = 1;
            this.cboCourse.SelectedIndexChanged += new System.EventHandler(this.cboCourse_SelectedIndexChanged);
            // 
            // dgvScore
            // 
            this.dgvScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScore.Location = new System.Drawing.Point(43, 221);
            this.dgvScore.Name = "dgvScore";
            this.dgvScore.RowTemplate.Height = 28;
            this.dgvScore.Size = new System.Drawing.Size(780, 256);
            this.dgvScore.TabIndex = 2;
            // 
            // numMark
            // 
            this.numMark.Location = new System.Drawing.Point(844, 261);
            this.numMark.Name = "numMark";
            this.numMark.Size = new System.Drawing.Size(178, 26);
            this.numMark.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(844, 355);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(149, 44);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定修改";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(853, 428);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 49);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存成绩到文件";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtMajor
            // 
            this.txtMajor.Location = new System.Drawing.Point(853, 168);
            this.txtMajor.Name = "txtMajor";
            this.txtMajor.Size = new System.Drawing.Size(147, 26);
            this.txtMajor.TabIndex = 6;
            this.txtMajor.TextChanged += new System.EventHandler(this.txtMajor_TextChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 514);
            this.Controls.Add(this.txtMajor);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.numMark);
            this.Controls.Add(this.dgvScore);
            this.Controls.Add(this.cboCourse);
            this.Controls.Add(this.cboStu);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMark)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem courseToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboStu;
        private System.Windows.Forms.ComboBox cboCourse;
        private System.Windows.Forms.DataGridView dgvScore;
        private System.Windows.Forms.NumericUpDown numMark;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtMajor;
    }
}

