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
            this.txtBikeID = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBikeID
            // 
            this.txtBikeID.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBikeID.Location = new System.Drawing.Point(73, 142);
            this.txtBikeID.Name = "txtBikeID";
            this.txtBikeID.Size = new System.Drawing.Size(217, 33);
            this.txtBikeID.TabIndex = 3;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl.Location = new System.Drawing.Point(126, 83);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(106, 22);
            this.lbl.TabIndex = 13;
            this.lbl.Text = "输入车票编号";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(130, 257);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(81, 37);
            this.button4.TabIndex = 15;
            this.button4.Text = "关闭";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 364);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.txtBikeID);
            this.Name = "Form7";
            this.Text = "退票";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBikeID;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button button4;
    }
}