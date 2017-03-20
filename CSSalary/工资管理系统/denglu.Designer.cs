namespace 工资管理系统
{
    partial class dl
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dlan = new System.Windows.Forms.Button();
            this.tcan = new System.Windows.Forms.Button();
            this.gly = new System.Windows.Forms.CheckBox();
            this.srygbh = new System.Windows.Forms.Label();
            this.srmm = new System.Windows.Forms.Label();
            this.ygbh = new System.Windows.Forms.TextBox();
            this.mm = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dlan
            // 
            this.dlan.Location = new System.Drawing.Point(112, 157);
            this.dlan.Name = "dlan";
            this.dlan.Size = new System.Drawing.Size(75, 23);
            this.dlan.TabIndex = 0;
            this.dlan.Text = "登录";
            this.dlan.UseVisualStyleBackColor = true;
            this.dlan.Click += new System.EventHandler(this.dlan_Click);
            // 
            // tcan
            // 
            this.tcan.Location = new System.Drawing.Point(270, 157);
            this.tcan.Name = "tcan";
            this.tcan.Size = new System.Drawing.Size(75, 23);
            this.tcan.TabIndex = 1;
            this.tcan.Text = "退出";
            this.tcan.UseVisualStyleBackColor = true;
            this.tcan.Click += new System.EventHandler(this.tcan_Click);
            // 
            // gly
            // 
            this.gly.AutoSize = true;
            this.gly.Location = new System.Drawing.Point(209, 119);
            this.gly.Name = "gly";
            this.gly.Size = new System.Drawing.Size(60, 16);
            this.gly.TabIndex = 2;
            this.gly.Text = "管理员";
            this.gly.UseVisualStyleBackColor = true;
            this.gly.CheckedChanged += new System.EventHandler(this.gly_CheckedChanged);
            // 
            // srygbh
            // 
            this.srygbh.AutoSize = true;
            this.srygbh.Location = new System.Drawing.Point(162, 48);
            this.srygbh.Name = "srygbh";
            this.srygbh.Size = new System.Drawing.Size(77, 12);
            this.srygbh.TabIndex = 3;
            this.srygbh.Text = "输入员工编号";
            this.srygbh.Click += new System.EventHandler(this.label1_Click);
            // 
            // srmm
            // 
            this.srmm.AutoSize = true;
            this.srmm.Location = new System.Drawing.Point(172, 75);
            this.srmm.Name = "srmm";
            this.srmm.Size = new System.Drawing.Size(53, 12);
            this.srmm.TabIndex = 4;
            this.srmm.Text = "输入密码";
            // 
            // ygbh
            // 
            this.ygbh.Location = new System.Drawing.Point(245, 45);
            this.ygbh.Name = "ygbh";
            this.ygbh.Size = new System.Drawing.Size(100, 21);
            this.ygbh.TabIndex = 5;
            this.ygbh.Text = "20170619001";
            this.ygbh.UseWaitCursor = true;
            // 
            // mm
            // 
            this.mm.Location = new System.Drawing.Point(245, 72);
            this.mm.Name = "mm";
            this.mm.Size = new System.Drawing.Size(100, 21);
            this.mm.TabIndex = 6;
            this.mm.Text = "777001";
            this.mm.UseSystemPasswordChar = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(27, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 110);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // dl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 233);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mm);
            this.Controls.Add(this.ygbh);
            this.Controls.Add(this.srmm);
            this.Controls.Add(this.srygbh);
            this.Controls.Add(this.gly);
            this.Controls.Add(this.tcan);
            this.Controls.Add(this.dlan);
            this.Name = "dl";
            this.Text = "欢迎登录zcc工资管理系统";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dlan;
        private System.Windows.Forms.Button tcan;
        private System.Windows.Forms.CheckBox gly;
        private System.Windows.Forms.Label srygbh;
        private System.Windows.Forms.Label srmm;
        private System.Windows.Forms.TextBox ygbh;
        private System.Windows.Forms.TextBox mm;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

