namespace 反坦克导弹数据查询软件
{
    partial class 登录
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
            this.btlogin = new System.Windows.Forms.Button();
            this.btlogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.manager = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.用户 = new System.Windows.Forms.TextBox();
            this.部职别 = new System.Windows.Forms.TextBox();
            this.用户类型 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btlogin
            // 
            this.btlogin.Location = new System.Drawing.Point(30, 229);
            this.btlogin.Name = "btlogin";
            this.btlogin.Size = new System.Drawing.Size(80, 32);
            this.btlogin.TabIndex = 0;
            this.btlogin.Text = "登录";
            this.btlogin.UseVisualStyleBackColor = true;
            this.btlogin.Click += new System.EventHandler(this.btlogin_Click);
            // 
            // btlogout
            // 
            this.btlogout.Location = new System.Drawing.Point(231, 229);
            this.btlogout.Name = "btlogout";
            this.btlogout.Size = new System.Drawing.Size(84, 32);
            this.btlogout.TabIndex = 1;
            this.btlogout.Text = "退出";
            this.btlogout.UseVisualStyleBackColor = true;
            this.btlogout.Click += new System.EventHandler(this.btlogout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(58, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(58, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "密  码";
            // 
            // manager
            // 
            this.manager.Location = new System.Drawing.Point(180, 26);
            this.manager.Name = "manager";
            this.manager.Size = new System.Drawing.Size(138, 21);
            this.manager.TabIndex = 4;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(180, 65);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(138, 21);
            this.password.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.用户);
            this.groupBox1.Controls.Add(this.部职别);
            this.groupBox1.Controls.Add(this.用户类型);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.manager);
            this.groupBox1.Controls.Add(this.password);
            this.groupBox1.Controls.Add(this.btlogin);
            this.groupBox1.Controls.Add(this.btlogout);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(164, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 318);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(129, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "注册";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 用户
            // 
            this.用户.Location = new System.Drawing.Point(180, 154);
            this.用户.Name = "用户";
            this.用户.Size = new System.Drawing.Size(138, 21);
            this.用户.TabIndex = 16;
            // 
            // 部职别
            // 
            this.部职别.Location = new System.Drawing.Point(180, 110);
            this.部职别.Name = "部职别";
            this.部职别.Size = new System.Drawing.Size(138, 21);
            this.部职别.TabIndex = 15;
            // 
            // 用户类型
            // 
            this.用户类型.AutoSize = true;
            this.用户类型.Location = new System.Drawing.Point(57, 157);
            this.用户类型.Name = "用户类型";
            this.用户类型.Size = new System.Drawing.Size(53, 12);
            this.用户类型.TabIndex = 14;
            this.用户类型.Text = "用户类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "部 职 别";
            // 
            // 登录
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 556);
            this.Controls.Add(this.groupBox1);
            this.Name = "登录";
            this.Text = "登录";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btlogin;
        private System.Windows.Forms.Button btlogout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox manager;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox 用户;
        private System.Windows.Forms.TextBox 部职别;
        private System.Windows.Forms.Label 用户类型;
        private System.Windows.Forms.Label label3;
    }
}

