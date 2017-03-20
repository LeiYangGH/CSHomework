namespace 工资管理系统
{
    partial class zhuce
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
            this.Xygbh = new System.Windows.Forms.Label();
            this.Xmm = new System.Windows.Forms.Label();
            this.Xqrmm = new System.Windows.Forms.Label();
            this.Xsrygbh = new System.Windows.Forms.MaskedTextBox();
            this.Xqrdmm = new System.Windows.Forms.MaskedTextBox();
            this.Xsrmm = new System.Windows.Forms.MaskedTextBox();
            this.ZC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Xygbh
            // 
            this.Xygbh.AutoSize = true;
            this.Xygbh.Location = new System.Drawing.Point(30, 52);
            this.Xygbh.Name = "Xygbh";
            this.Xygbh.Size = new System.Drawing.Size(65, 12);
            this.Xygbh.TabIndex = 0;
            this.Xygbh.Text = "新员工编号";
            // 
            // Xmm
            // 
            this.Xmm.AutoSize = true;
            this.Xmm.Location = new System.Drawing.Point(32, 84);
            this.Xmm.Name = "Xmm";
            this.Xmm.Size = new System.Drawing.Size(53, 12);
            this.Xmm.TabIndex = 1;
            this.Xmm.Text = "输入密码";
            // 
            // Xqrmm
            // 
            this.Xqrmm.AutoSize = true;
            this.Xqrmm.Location = new System.Drawing.Point(30, 133);
            this.Xqrmm.Name = "Xqrmm";
            this.Xqrmm.Size = new System.Drawing.Size(53, 12);
            this.Xqrmm.TabIndex = 2;
            this.Xqrmm.Text = "确认密码";
            // 
            // Xsrygbh
            // 
            this.Xsrygbh.Location = new System.Drawing.Point(116, 43);
            this.Xsrygbh.Name = "Xsrygbh";
            this.Xsrygbh.Size = new System.Drawing.Size(100, 21);
            this.Xsrygbh.TabIndex = 4;
            // 
            // Xqrdmm
            // 
            this.Xqrdmm.Location = new System.Drawing.Point(116, 124);
            this.Xqrdmm.Name = "Xqrdmm";
            this.Xqrdmm.Size = new System.Drawing.Size(100, 21);
            this.Xqrdmm.TabIndex = 7;
            // 
            // Xsrmm
            // 
            this.Xsrmm.Location = new System.Drawing.Point(116, 84);
            this.Xsrmm.Name = "Xsrmm";
            this.Xsrmm.Size = new System.Drawing.Size(100, 21);
            this.Xsrmm.TabIndex = 8;
            // 
            // ZC
            // 
            this.ZC.Location = new System.Drawing.Point(128, 189);
            this.ZC.Name = "ZC";
            this.ZC.Size = new System.Drawing.Size(75, 23);
            this.ZC.TabIndex = 9;
            this.ZC.Text = "注册";
            this.ZC.UseVisualStyleBackColor = true;
            this.ZC.Click += new System.EventHandler(this.button1_Click);
            // 
            // zhuce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 251);
            this.Controls.Add(this.ZC);
            this.Controls.Add(this.Xsrmm);
            this.Controls.Add(this.Xqrdmm);
            this.Controls.Add(this.Xsrygbh);
            this.Controls.Add(this.Xqrmm);
            this.Controls.Add(this.Xmm);
            this.Controls.Add(this.Xygbh);
            this.Name = "zhuce";
            this.Text = "注册新员工";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Xygbh;
        private System.Windows.Forms.Label Xmm;
        private System.Windows.Forms.Label Xqrmm;
        private System.Windows.Forms.MaskedTextBox Xsrygbh;
        private System.Windows.Forms.MaskedTextBox Xqrdmm;
        private System.Windows.Forms.MaskedTextBox Xsrmm;
        private System.Windows.Forms.Button ZC;
    }
}