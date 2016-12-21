namespace CSStu
{
    partial class frmAveByCourse
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
            this.dgvAveCourse = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAveCourse)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAveCourse
            // 
            this.dgvAveCourse.AllowUserToAddRows = false;
            this.dgvAveCourse.AllowUserToDeleteRows = false;
            this.dgvAveCourse.AllowUserToOrderColumns = true;
            this.dgvAveCourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAveCourse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAveCourse.Location = new System.Drawing.Point(0, 0);
            this.dgvAveCourse.Name = "dgvAveCourse";
            this.dgvAveCourse.ReadOnly = true;
            this.dgvAveCourse.RowTemplate.Height = 28;
            this.dgvAveCourse.Size = new System.Drawing.Size(680, 415);
            this.dgvAveCourse.TabIndex = 0;
            // 
            // frmAveByCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 415);
            this.Controls.Add(this.dgvAveCourse);
            this.Name = "frmAveByCourse";
            this.Text = "frmAveByCourse";
            this.Load += new System.EventHandler(this.frmAveByCourse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAveCourse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAveCourse;
    }
}