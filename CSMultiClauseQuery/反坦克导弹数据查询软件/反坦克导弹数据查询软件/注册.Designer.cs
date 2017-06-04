namespace 反坦克导弹数据查询软件
{
    partial class 注册
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
            this.label1 = new System.Windows.Forms.Label();
            this.姓名 = new System.Windows.Forms.TextBox();
            this.密码 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.用户类型 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.部职别 = new System.Windows.Forms.TextBox();
            this.用户 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓    名";
            // 
            // 姓名
            // 
            this.姓名.Location = new System.Drawing.Point(213, 118);
            this.姓名.Name = "姓名";
            this.姓名.Size = new System.Drawing.Size(226, 21);
            this.姓名.TabIndex = 1;
            // 
            // 密码
            // 
            this.密码.Location = new System.Drawing.Point(213, 167);
            this.密码.Name = "密码";
            this.密码.Size = new System.Drawing.Size(226, 21);
            this.密码.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密    码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "部 职 别";
            // 
            // 用户类型
            // 
            this.用户类型.AutoSize = true;
            this.用户类型.Location = new System.Drawing.Point(115, 265);
            this.用户类型.Name = "用户类型";
            this.用户类型.Size = new System.Drawing.Size(53, 12);
            this.用户类型.TabIndex = 6;
            this.用户类型.Text = "用户类型";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(131, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 31);
            this.button1.TabIndex = 10;
            this.button1.Text = "注册";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // 部职别
            // 
            this.部职别.Location = new System.Drawing.Point(213, 218);
            this.部职别.Name = "部职别";
            this.部职别.Size = new System.Drawing.Size(226, 21);
            this.部职别.TabIndex = 11;
            // 
            // 用户
            // 
            this.用户.Location = new System.Drawing.Point(213, 262);
            this.用户.Name = "用户";
            this.用户.Size = new System.Drawing.Size(226, 21);
            this.用户.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(257, 348);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 27);
            this.button2.TabIndex = 13;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(375, 346);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 31);
            this.button3.TabIndex = 14;
            this.button3.Text = "返回";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // 注册
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 518);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.用户);
            this.Controls.Add(this.部职别);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.用户类型);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.密码);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.姓名);
            this.Controls.Add(this.label1);
            this.Name = "注册";
            this.Text = "注册";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox 姓名;
        private System.Windows.Forms.TextBox 密码;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label 用户类型;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox 部职别;
        private System.Windows.Forms.TextBox 用户;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}