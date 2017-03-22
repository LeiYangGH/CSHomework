namespace 工资管理系统
{
    partial class frmAddUser
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
            this.txtID = new System.Windows.Forms.MaskedTextBox();
            this.txtPwd2 = new System.Windows.Forms.MaskedTextBox();
            this.txtPwd = new System.Windows.Forms.MaskedTextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Xygbh
            // 
            this.Xygbh.AutoSize = true;
            this.Xygbh.Location = new System.Drawing.Point(45, 87);
            this.Xygbh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Xygbh.Name = "Xygbh";
            this.Xygbh.Size = new System.Drawing.Size(89, 20);
            this.Xygbh.TabIndex = 0;
            this.Xygbh.Text = "新员工编号";
            // 
            // Xmm
            // 
            this.Xmm.AutoSize = true;
            this.Xmm.Location = new System.Drawing.Point(48, 140);
            this.Xmm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Xmm.Name = "Xmm";
            this.Xmm.Size = new System.Drawing.Size(73, 20);
            this.Xmm.TabIndex = 1;
            this.Xmm.Text = "输入密码";
            // 
            // Xqrmm
            // 
            this.Xqrmm.AutoSize = true;
            this.Xqrmm.Location = new System.Drawing.Point(45, 222);
            this.Xqrmm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Xqrmm.Name = "Xqrmm";
            this.Xqrmm.Size = new System.Drawing.Size(73, 20);
            this.Xqrmm.TabIndex = 2;
            this.Xqrmm.Text = "确认密码";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(174, 72);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(148, 26);
            this.txtID.TabIndex = 4;
            // 
            // txtPwd2
            // 
            this.txtPwd2.Location = new System.Drawing.Point(174, 207);
            this.txtPwd2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPwd2.Name = "txtPwd2";
            this.txtPwd2.Size = new System.Drawing.Size(148, 26);
            this.txtPwd2.TabIndex = 7;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(174, 140);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(148, 26);
            this.txtPwd.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(192, 315);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 38);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "注册";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "姓名";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(174, 29);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 26);
            this.txtName.TabIndex = 11;
            // 
            // frmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 418);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtPwd2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.Xqrmm);
            this.Controls.Add(this.Xmm);
            this.Controls.Add(this.Xygbh);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "注册新员工";
            this.Load += new System.EventHandler(this.frmAddUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Xygbh;
        private System.Windows.Forms.Label Xmm;
        private System.Windows.Forms.Label Xqrmm;
        private System.Windows.Forms.MaskedTextBox txtID;
        private System.Windows.Forms.MaskedTextBox txtPwd2;
        private System.Windows.Forms.MaskedTextBox txtPwd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
    }
}