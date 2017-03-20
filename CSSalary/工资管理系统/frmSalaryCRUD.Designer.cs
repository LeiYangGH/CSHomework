namespace 工资管理系统
{
    partial class frmSalaryCRUD
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gongzibiaoALLTableAdapter = new 工资管理系统.biyeshejiDataSetTableAdapters.gongzibiaoALLTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.gongzibiaoALLDataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.grpCRUD = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtYearSalary = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBasicSalary = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBonus = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDeduct = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gongzibiaoALLDataGridView)).BeginInit();
            this.grpCRUD.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(126, 20);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(570, 10);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(148, 26);
            this.textBox2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "员工编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(518, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "姓名";
            // 
            // gongzibiaoALLTableAdapter
            // 
            this.gongzibiaoALLTableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 9;
            // 
            // gongzibiaoALLDataGridView
            // 
            this.gongzibiaoALLDataGridView.AllowUserToAddRows = false;
            this.gongzibiaoALLDataGridView.AllowUserToDeleteRows = false;
            this.gongzibiaoALLDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gongzibiaoALLDataGridView.Location = new System.Drawing.Point(-3, 382);
            this.gongzibiaoALLDataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gongzibiaoALLDataGridView.Name = "gongzibiaoALLDataGridView";
            this.gongzibiaoALLDataGridView.RowTemplate.Height = 23;
            this.gongzibiaoALLDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gongzibiaoALLDataGridView.Size = new System.Drawing.Size(1317, 310);
            this.gongzibiaoALLDataGridView.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(286, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 38);
            this.button1.TabIndex = 10;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grpCRUD
            // 
            this.grpCRUD.Controls.Add(this.btnSave);
            this.grpCRUD.Controls.Add(this.btnDel);
            this.grpCRUD.Controls.Add(this.btnUpdate);
            this.grpCRUD.Controls.Add(this.btnAdd);
            this.grpCRUD.Controls.Add(this.txtDeduct);
            this.grpCRUD.Controls.Add(this.txtBonus);
            this.grpCRUD.Controls.Add(this.label7);
            this.grpCRUD.Controls.Add(this.label6);
            this.grpCRUD.Controls.Add(this.txtBasicSalary);
            this.grpCRUD.Controls.Add(this.label5);
            this.grpCRUD.Controls.Add(this.txtYearSalary);
            this.grpCRUD.Controls.Add(this.label4);
            this.grpCRUD.Location = new System.Drawing.Point(12, 93);
            this.grpCRUD.Name = "grpCRUD";
            this.grpCRUD.Size = new System.Drawing.Size(1302, 261);
            this.grpCRUD.TabIndex = 12;
            this.grpCRUD.TabStop = false;
            this.grpCRUD.Text = "增删改查";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "工龄工资";
            // 
            // txtYearSalary
            // 
            this.txtYearSalary.Location = new System.Drawing.Point(114, 30);
            this.txtYearSalary.Name = "txtYearSalary";
            this.txtYearSalary.Size = new System.Drawing.Size(148, 26);
            this.txtYearSalary.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "基本工资";
            // 
            // txtBasicSalary
            // 
            this.txtBasicSalary.Location = new System.Drawing.Point(114, 71);
            this.txtBasicSalary.Name = "txtBasicSalary";
            this.txtBasicSalary.Size = new System.Drawing.Size(148, 26);
            this.txtBasicSalary.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "奖金";
            // 
            // txtBonus
            // 
            this.txtBonus.Location = new System.Drawing.Point(114, 122);
            this.txtBonus.Name = "txtBonus";
            this.txtBonus.Size = new System.Drawing.Size(148, 26);
            this.txtBonus.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "扣款";
            // 
            // txtDeduct
            // 
            this.txtDeduct.Location = new System.Drawing.Point(114, 170);
            this.txtDeduct.Name = "txtDeduct";
            this.txtDeduct.Size = new System.Drawing.Size(148, 26);
            this.txtDeduct.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(394, 32);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 39);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "增加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(394, 88);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(86, 39);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(394, 142);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(86, 39);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(542, 88);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 39);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存到数据库";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // frmSalaryCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 805);
            this.Controls.Add(this.grpCRUD);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gongzibiaoALLDataGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSalaryCRUD";
            this.Text = "工资管理";
            this.Load += new System.EventHandler(this.gongziguanli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gongzibiaoALLDataGridView)).EndInit();
            this.grpCRUD.ResumeLayout(false);
            this.grpCRUD.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private biyeshejiDataSetTableAdapters.gongzibiaoALLTableAdapter gongzibiaoALLTableAdapter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gongzibiaoALLDataGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox grpCRUD;
        private System.Windows.Forms.TextBox txtDeduct;
        private System.Windows.Forms.TextBox txtBonus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBasicSalary;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtYearSalary;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
    }
}