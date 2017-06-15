namespace p22
{
    partial class 路线选择
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.姓名 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cboT = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboR = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.性别 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.身份证 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.电话 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.路线说明 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.价格 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.日期 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(369, 78);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 43);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(514, 78);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(120, 43);
            this.btnDel.TabIndex = 11;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(659, 78);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 43);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.姓名,
            this.性别,
            this.身份证,
            this.电话,
            this.路线说明,
            this.价格,
            this.日期});
            this.listView1.Location = new System.Drawing.Point(13, 152);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(811, 474);
            this.listView1.TabIndex = 16;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // 姓名
            // 
            this.姓名.Text = "姓名";
            this.姓名.Width = 128;
            // 
            // cboT
            // 
            this.cboT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboT.FormattingEnabled = true;
            this.cboT.Location = new System.Drawing.Point(148, 86);
            this.cboT.Name = "cboT";
            this.cboT.Size = new System.Drawing.Size(211, 28);
            this.cboT.TabIndex = 17;
            this.cboT.SelectedIndexChanged += new System.EventHandler(this.cboT_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "游客姓名";
            // 
            // cboR
            // 
            this.cboR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboR.FormattingEnabled = true;
            this.cboR.Location = new System.Drawing.Point(148, 35);
            this.cboR.Name = "cboR";
            this.cboR.Size = new System.Drawing.Size(211, 28);
            this.cboR.TabIndex = 17;
            this.cboR.SelectedIndexChanged += new System.EventHandler(this.cboR_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "旅游路线";
            // 
            // 性别
            // 
            this.性别.Text = "性别";
            this.性别.Width = 101;
            // 
            // 身份证
            // 
            this.身份证.Text = "身份证";
            this.身份证.Width = 117;
            // 
            // 电话
            // 
            this.电话.Text = "电话";
            this.电话.Width = 114;
            // 
            // 路线说明
            // 
            this.路线说明.Text = "路线说明";
            this.路线说明.Width = 104;
            // 
            // 价格
            // 
            this.价格.Text = "价格";
            this.价格.Width = 91;
            // 
            // 日期
            // 
            this.日期.Text = "日期";
            this.日期.Width = 114;
            // 
            // 路线选择
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 730);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboR);
            this.Controls.Add(this.cboT);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "路线选择";
            this.Text = "路线选择";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.路线选择_FormClosing);
            this.Load += new System.EventHandler(this.路线选择_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader 姓名;
        private System.Windows.Forms.ComboBox cboT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader 性别;
        private System.Windows.Forms.ColumnHeader 身份证;
        private System.Windows.Forms.ColumnHeader 电话;
        private System.Windows.Forms.ColumnHeader 路线说明;
        private System.Windows.Forms.ColumnHeader 价格;
        private System.Windows.Forms.ColumnHeader 日期;
    }
}