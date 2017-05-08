namespace CSBike
{
    partial class frmBike
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
            this.lbBike = new System.Windows.Forms.ListBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnMaintain = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDOP = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.btnCLose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbBike
            // 
            this.lbBike.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbBike.FormattingEnabled = true;
            this.lbBike.ItemHeight = 16;
            this.lbBike.Location = new System.Drawing.Point(26, 50);
            this.lbBike.Name = "lbBike";
            this.lbBike.Size = new System.Drawing.Size(257, 276);
            this.lbBike.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNew.Location = new System.Drawing.Point(100, 389);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(110, 38);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "建卡";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnMaintain
            // 
            this.btnMaintain.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMaintain.Location = new System.Drawing.Point(222, 389);
            this.btnMaintain.Name = "btnMaintain";
            this.btnMaintain.Size = new System.Drawing.Size(110, 38);
            this.btnMaintain.TabIndex = 2;
            this.btnMaintain.Text = "修改";
            this.btnMaintain.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.Location = new System.Drawing.Point(344, 389);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 38);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(362, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(316, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "购入日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(348, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "价格";
            // 
            // lblDOP
            // 
            this.lblDOP.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDOP.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDOP.Location = new System.Drawing.Point(390, 144);
            this.lblDOP.Name = "lblDOP";
            this.lblDOP.Size = new System.Drawing.Size(204, 30);
            this.lblDOP.TabIndex = 7;
            // 
            // lblPrice
            // 
            this.lblPrice.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPrice.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPrice.Location = new System.Drawing.Point(390, 183);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(204, 30);
            this.lblPrice.TabIndex = 8;
            // 
            // lblID
            // 
            this.lblID.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblID.Location = new System.Drawing.Point(390, 105);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(204, 30);
            this.lblID.TabIndex = 9;
            // 
            // btnCLose
            // 
            this.btnCLose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCLose.Location = new System.Drawing.Point(466, 389);
            this.btnCLose.Name = "btnCLose";
            this.btnCLose.Size = new System.Drawing.Size(110, 38);
            this.btnCLose.TabIndex = 3;
            this.btnCLose.Text = "关闭";
            this.btnCLose.UseVisualStyleBackColor = true;
            this.btnCLose.Click += new System.EventHandler(this.btnCLose_Click);
            // 
            // frmBike
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 457);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblDOP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCLose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnMaintain);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lbBike);
            this.Name = "frmBike";
            this.Text = "自行车管理";
            this.Load += new System.EventHandler(this.frmBike_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbBike;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnMaintain;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDOP;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnCLose;
    }
}