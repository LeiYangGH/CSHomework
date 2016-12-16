namespace WindowsFormsApplication4
{
    partial class spzl
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.select = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.xgbut = new System.Windows.Forms.Button();
            this.bcbtn = new System.Windows.Forms.Button();
            this.selectshuru = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(992, 521);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 9F);
            this.button1.Location = new System.Drawing.Point(55, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "新增";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // select
            // 
            this.select.Font = new System.Drawing.Font("宋体", 10F);
            this.select.Location = new System.Drawing.Point(699, 28);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(65, 23);
            this.select.TabIndex = 2;
            this.select.Text = "查询";
            this.select.UseVisualStyleBackColor = true;
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(485, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(174, 21);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F);
            this.label2.Location = new System.Drawing.Point(796, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "ps：清空后显示全部";
            // 
            // xgbut
            // 
            this.xgbut.Location = new System.Drawing.Point(159, 25);
            this.xgbut.Name = "xgbut";
            this.xgbut.Size = new System.Drawing.Size(57, 24);
            this.xgbut.TabIndex = 6;
            this.xgbut.Text = "修改";
            this.xgbut.UseVisualStyleBackColor = true;
            this.xgbut.Click += new System.EventHandler(this.xgbut_Click);
            // 
            // bcbtn
            // 
            this.bcbtn.Location = new System.Drawing.Point(269, 24);
            this.bcbtn.Name = "bcbtn";
            this.bcbtn.Size = new System.Drawing.Size(57, 24);
            this.bcbtn.TabIndex = 7;
            this.bcbtn.Text = "保存";
            this.bcbtn.UseVisualStyleBackColor = true;
            this.bcbtn.Click += new System.EventHandler(this.bcbtn_Click);
            // 
            // selectshuru
            // 
            this.selectshuru.AutoEllipsis = true;
            this.selectshuru.AutoSize = true;
            this.selectshuru.Location = new System.Drawing.Point(397, 34);
            this.selectshuru.Name = "selectshuru";
            this.selectshuru.Size = new System.Drawing.Size(59, 12);
            this.selectshuru.TabIndex = 8;
            this.selectshuru.Text = "商品名称:";
            this.selectshuru.Click += new System.EventHandler(this.selectshuru_Click);
            // 
            // spzl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 602);
            this.Controls.Add(this.selectshuru);
            this.Controls.Add(this.bcbtn);
            this.Controls.Add(this.xgbut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.select);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "spzl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商品资料";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.spzl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;


        private System.Windows.Forms.Button select;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button xgbut;
        private System.Windows.Forms.Button bcbtn;
        private System.Windows.Forms.Label selectshuru;
        
    }
}