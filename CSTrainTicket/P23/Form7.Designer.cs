namespace P23
{
    partial class Form7
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
            this.txtT = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtT
            // 
            this.txtT.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtT.Location = new System.Drawing.Point(110, 237);
            this.txtT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtT.Name = "txtT";
            this.txtT.Size = new System.Drawing.Size(324, 45);
            this.txtT.TabIndex = 3;
            this.txtT.TextChanged += new System.EventHandler(this.txtT_TextChanged);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl.Location = new System.Drawing.Point(189, 138);
            this.lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(158, 31);
            this.lbl.TabIndex = 13;
            this.lbl.Text = "输入车票编号";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(338, 386);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(122, 62);
            this.button4.TabIndex = 15;
            this.button4.Text = "关闭";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(110, 386);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(96, 76);
            this.btnReturn.TabIndex = 16;
            this.btnReturn.Text = "确定退票";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 607);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.txtT);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form7";
            this.Text = "退票";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtT;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnReturn;
    }
}