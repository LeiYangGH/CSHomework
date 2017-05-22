namespace 模拟考试
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
            this.lstClass = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbM = new System.Windows.Forms.RadioButton();
            this.rdbF = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstClass
            // 
            this.lstClass.FormattingEnabled = true;
            this.lstClass.ItemHeight = 20;
            this.lstClass.Items.AddRange(new object[] {
            "数学系1班",
            "数学系2班",
            "计算机系3班"});
            this.lstClass.Location = new System.Drawing.Point(188, 152);
            this.lstClass.Name = "lstClass";
            this.lstClass.Size = new System.Drawing.Size(209, 64);
            this.lstClass.TabIndex = 10;
            this.lstClass.SelectedIndexChanged += new System.EventHandler(this.lstClass_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "性别";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "班级";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(188, 97);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(209, 26);
            this.txtName.TabIndex = 8;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "姓名";
            // 
            // txtNO
            // 
            this.txtNO.Location = new System.Drawing.Point(188, 38);
            this.txtNO.Name = "txtNO";
            this.txtNO.Size = new System.Drawing.Size(209, 26);
            this.txtNO.TabIndex = 9;
            this.txtNO.TextChanged += new System.EventHandler(this.txtNO_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "学号";
            // 
            // rdbM
            // 
            this.rdbM.AutoSize = true;
            this.rdbM.Checked = true;
            this.rdbM.Location = new System.Drawing.Point(188, 254);
            this.rdbM.Name = "rdbM";
            this.rdbM.Size = new System.Drawing.Size(50, 24);
            this.rdbM.TabIndex = 11;
            this.rdbM.TabStop = true;
            this.rdbM.Text = "男";
            this.rdbM.UseVisualStyleBackColor = true;
            this.rdbM.CheckedChanged += new System.EventHandler(this.rdbM_CheckedChanged);
            // 
            // rdbF
            // 
            this.rdbF.AutoSize = true;
            this.rdbF.Location = new System.Drawing.Point(303, 254);
            this.rdbF.Name = "rdbF";
            this.rdbF.Size = new System.Drawing.Size(50, 24);
            this.rdbF.TabIndex = 11;
            this.rdbF.Text = "女";
            this.rdbF.UseVisualStyleBackColor = true;
            this.rdbF.CheckedChanged += new System.EventHandler(this.rdbF_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(160, 384);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(165, 58);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "开始考试";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 488);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.rdbF);
            this.Controls.Add(this.rdbM);
            this.Controls.Add(this.lstClass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNO);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "考试系统";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstClass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbM;
        private System.Windows.Forms.RadioButton rdbF;
        private System.Windows.Forms.Button btnStart;
    }
}

