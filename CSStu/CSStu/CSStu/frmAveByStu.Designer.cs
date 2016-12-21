namespace CSStu
{
    partial class frmAveByStu
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
            this.dgvAveStu = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cboStu = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAveStu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAveStu
            // 
            this.dgvAveStu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAveStu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvAveStu.Location = new System.Drawing.Point(0, 80);
            this.dgvAveStu.Name = "dgvAveStu";
            this.dgvAveStu.RowTemplate.Height = 28;
            this.dgvAveStu.Size = new System.Drawing.Size(801, 388);
            this.dgvAveStu.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "请选择学生姓名";
            // 
            // cboStu
            // 
            this.cboStu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStu.FormattingEnabled = true;
            this.cboStu.Location = new System.Drawing.Point(190, 26);
            this.cboStu.Name = "cboStu";
            this.cboStu.Size = new System.Drawing.Size(293, 28);
            this.cboStu.TabIndex = 2;
            this.cboStu.SelectedIndexChanged += new System.EventHandler(this.cboStu_SelectedIndexChanged);
            // 
            // frmAveByStu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 468);
            this.Controls.Add(this.cboStu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAveStu);
            this.Name = "frmAveByStu";
            this.Text = "frmAveByStu";
            this.Load += new System.EventHandler(this.frmAveByStu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAveStu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAveStu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboStu;
    }
}