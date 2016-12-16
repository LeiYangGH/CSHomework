namespace SqlImageCompare
{
    partial class Form1
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
            this.txtImage1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseImage1 = new System.Windows.Forms.Button();
            this.txtImage2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseImage2 = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.txtSql = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtImageToCompare = new System.Windows.Forms.TextBox();
            this.btnBrowseImageToCompare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtImage1
            // 
            this.txtImage1.Location = new System.Drawing.Point(169, 48);
            this.txtImage1.Name = "txtImage1";
            this.txtImage1.ReadOnly = true;
            this.txtImage1.Size = new System.Drawing.Size(799, 26);
            this.txtImage1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image1";
            // 
            // btnBrowseImage1
            // 
            this.btnBrowseImage1.Location = new System.Drawing.Point(1009, 44);
            this.btnBrowseImage1.Name = "btnBrowseImage1";
            this.btnBrowseImage1.Size = new System.Drawing.Size(110, 35);
            this.btnBrowseImage1.TabIndex = 2;
            this.btnBrowseImage1.Text = "浏览图片1";
            this.btnBrowseImage1.UseVisualStyleBackColor = true;
            this.btnBrowseImage1.Click += new System.EventHandler(this.btnBrowseImage1_Click);
            // 
            // txtImage2
            // 
            this.txtImage2.Location = new System.Drawing.Point(169, 121);
            this.txtImage2.Name = "txtImage2";
            this.txtImage2.ReadOnly = true;
            this.txtImage2.Size = new System.Drawing.Size(799, 26);
            this.txtImage2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Image2";
            // 
            // btnBrowseImage2
            // 
            this.btnBrowseImage2.Location = new System.Drawing.Point(1009, 117);
            this.btnBrowseImage2.Name = "btnBrowseImage2";
            this.btnBrowseImage2.Size = new System.Drawing.Size(110, 35);
            this.btnBrowseImage2.TabIndex = 2;
            this.btnBrowseImage2.Text = "浏览图片2";
            this.btnBrowseImage2.UseVisualStyleBackColor = true;
            this.btnBrowseImage2.Click += new System.EventHandler(this.btnBrowseImage2_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(984, 202);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(221, 43);
            this.btnInsert.TabIndex = 3;
            this.btnInsert.Text = "把以上两个图片插入新行";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtSql
            // 
            this.txtSql.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSql.Location = new System.Drawing.Point(35, 391);
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(1084, 97);
            this.txtSql.TabIndex = 4;
            this.txtSql.Text = "SELECT count(*) FROM [ImageDb].[dbo].[T] where [Image1] = {0} and [Image2] = {0}";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(984, 573);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(135, 36);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "执行sql返回符合的行数";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 505);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(797, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "注意：只能修改where后面的部分，可以去掉任意条件，或者把and 改成 or， 但必须保证修改后的sql语法正确。";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "本地要比较的图片";
            // 
            // txtImageToCompare
            // 
            this.txtImageToCompare.Location = new System.Drawing.Point(174, 272);
            this.txtImageToCompare.Name = "txtImageToCompare";
            this.txtImageToCompare.ReadOnly = true;
            this.txtImageToCompare.Size = new System.Drawing.Size(794, 26);
            this.txtImageToCompare.TabIndex = 8;
            // 
            // btnBrowseImageToCompare
            // 
            this.btnBrowseImageToCompare.Location = new System.Drawing.Point(1009, 263);
            this.btnBrowseImageToCompare.Name = "btnBrowseImageToCompare";
            this.btnBrowseImageToCompare.Size = new System.Drawing.Size(149, 38);
            this.btnBrowseImageToCompare.TabIndex = 9;
            this.btnBrowseImageToCompare.Text = "浏览要比较的图片";
            this.btnBrowseImageToCompare.UseVisualStyleBackColor = true;
            this.btnBrowseImageToCompare.Click += new System.EventHandler(this.btnBrowseImageToCompare_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 621);
            this.Controls.Add(this.btnBrowseImageToCompare);
            this.Controls.Add(this.txtImageToCompare);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtSql);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnBrowseImage2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseImage1);
            this.Controls.Add(this.txtImage2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtImage1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtImage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseImage1;
        private System.Windows.Forms.TextBox txtImage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseImage2;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TextBox txtSql;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtImageToCompare;
        private System.Windows.Forms.Button btnBrowseImageToCompare;
    }
}

