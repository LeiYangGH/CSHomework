namespace WindowsFormsApplication4
{
    partial class UCFoodMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mylablsj = new System.Windows.Forms.Label();
            this.mylabid = new System.Windows.Forms.Label();
            this.mylabname = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mylablsj
            // 
            this.mylablsj.AutoSize = true;
            this.mylablsj.Location = new System.Drawing.Point(-4, 45);
            this.mylablsj.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mylablsj.Name = "mylablsj";
            this.mylablsj.Size = new System.Drawing.Size(51, 20);
            this.mylablsj.TabIndex = 5;
            this.mylablsj.Text = "label3";
            // 
            // mylabid
            // 
            this.mylabid.AutoSize = true;
            this.mylabid.Location = new System.Drawing.Point(-4, 16);
            this.mylabid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mylabid.Name = "mylabid";
            this.mylabid.Size = new System.Drawing.Size(51, 20);
            this.mylabid.TabIndex = 4;
            this.mylabid.Text = "label2";
            // 
            // mylabname
            // 
            this.mylabname.AutoSize = true;
            this.mylabname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mylabname.Location = new System.Drawing.Point(55, 29);
            this.mylabname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mylabname.Name = "mylabname";
            this.mylabname.Size = new System.Drawing.Size(70, 25);
            this.mylabname.TabIndex = 3;
            this.mylabname.Text = "label1";
            // 
            // UCFoodMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mylablsj);
            this.Controls.Add(this.mylabid);
            this.Controls.Add(this.mylabname);
            this.Name = "UCFoodMenu";
            this.Size = new System.Drawing.Size(121, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mylablsj;
        private System.Windows.Forms.Label mylabid;
        private System.Windows.Forms.Label mylabname;
    }
}
