namespace WindowsFormsApplication1
{
    partial class Form3
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
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFind2 = new System.Windows.Forms.TextBox();
            this.cbo1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHighFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFind1 = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.cboSpecial2 = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.cboSpecial2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.gridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(621, 309);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "查询";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFind2);
            this.groupBox2.Controls.Add(this.cbo1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnHighFind);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(316, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 96);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "高级查询";
            // 
            // txtFind2
            // 
            this.txtFind2.Location = new System.Drawing.Point(78, 60);
            this.txtFind2.Name = "txtFind2";
            this.txtFind2.Size = new System.Drawing.Size(133, 21);
            this.txtFind2.TabIndex = 4;
            // 
            // cbo1
            // 
            this.cbo1.FormattingEnabled = true;
            this.cbo1.Location = new System.Drawing.Point(80, 24);
            this.cbo1.Name = "cbo1";
            this.cbo1.Size = new System.Drawing.Size(133, 20);
            this.cbo1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "药品名称：";
            // 
            // btnHighFind
            // 
            this.btnHighFind.Location = new System.Drawing.Point(219, 41);
            this.btnHighFind.Name = "btnHighFind";
            this.btnHighFind.Size = new System.Drawing.Size(56, 23);
            this.btnHighFind.TabIndex = 0;
            this.btnHighFind.Text = "查询";
            this.btnHighFind.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "药品批次：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFind1);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(14, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 96);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "普通查询";
            // 
            // txtFind1
            // 
            this.txtFind1.Location = new System.Drawing.Point(78, 35);
            this.txtFind1.Name = "txtFind1";
            this.txtFind1.Size = new System.Drawing.Size(132, 21);
            this.txtFind1.TabIndex = 2;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(216, 35);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(56, 23);
            this.btnFind.TabIndex = 0;
            this.btnFind.Text = "查询";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "药品名称：";
            // 
            // gridView
            // 
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Location = new System.Drawing.Point(14, 123);
            this.gridView.Name = "gridView";
            this.gridView.RowTemplate.Height = 23;
            this.gridView.Size = new System.Drawing.Size(593, 175);
            this.gridView.TabIndex = 6;
            // 
            // cboSpecial2
            // 
            this.cboSpecial2.Controls.Add(this.tabPage1);
            this.cboSpecial2.Location = new System.Drawing.Point(-4, -1);
            this.cboSpecial2.Name = "cboSpecial2";
            this.cboSpecial2.SelectedIndex = 0;
            this.cboSpecial2.Size = new System.Drawing.Size(629, 335);
            this.cboSpecial2.TabIndex = 5;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 379);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboSpecial2);
            this.Name = "Form3";
            this.Text = "药品查询";
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.cboSpecial2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFind2;
        private System.Windows.Forms.ComboBox cbo1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHighFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFind1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.TabControl cboSpecial2;
    }
}