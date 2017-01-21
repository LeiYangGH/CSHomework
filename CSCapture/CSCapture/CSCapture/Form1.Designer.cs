namespace CSCapture
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
            this.btnDesktop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDesktop
            // 
            this.btnDesktop.Location = new System.Drawing.Point(205, 207);
            this.btnDesktop.Name = "btnDesktop";
            this.btnDesktop.Size = new System.Drawing.Size(133, 39);
            this.btnDesktop.TabIndex = 0;
            this.btnDesktop.Text = "全屏截图";
            this.btnDesktop.UseVisualStyleBackColor = true;
            this.btnDesktop.Click += new System.EventHandler(this.btnDesktop_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 272);
            this.Controls.Add(this.btnDesktop);
            this.Name = "frmMain";
            this.Text = "截图示例";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDesktop;
    }
}

