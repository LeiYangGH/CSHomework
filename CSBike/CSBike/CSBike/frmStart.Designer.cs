namespace CSBike
{
    partial class frmStart
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBike = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBike
            // 
            this.btnBike.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBike.Location = new System.Drawing.Point(128, 24);
            this.btnBike.Name = "btnBike";
            this.btnBike.Size = new System.Drawing.Size(252, 49);
            this.btnBike.TabIndex = 0;
            this.btnBike.Text = "自行车管理";
            this.btnBike.UseVisualStyleBackColor = true;
            this.btnBike.Click += new System.EventHandler(this.btnBike_Click);
            // 
            // btnUser
            // 
            this.btnUser.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUser.Location = new System.Drawing.Point(128, 76);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(252, 49);
            this.btnUser.TabIndex = 1;
            this.btnUser.Text = "用户管理";
            this.btnUser.UseVisualStyleBackColor = true;
            // 
            // btnAdmin
            // 
            this.btnAdmin.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdmin.Location = new System.Drawing.Point(128, 128);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(252, 49);
            this.btnAdmin.TabIndex = 2;
            this.btnAdmin.Text = "管理员管理";
            this.btnAdmin.UseVisualStyleBackColor = true;
            // 
            // btnTransaction
            // 
            this.btnTransaction.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTransaction.Location = new System.Drawing.Point(128, 180);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(252, 49);
            this.btnTransaction.TabIndex = 3;
            this.btnTransaction.Text = "交易管理";
            this.btnTransaction.UseVisualStyleBackColor = true;
            // 
            // btnBorrow
            // 
            this.btnBorrow.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBorrow.Location = new System.Drawing.Point(128, 232);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(252, 49);
            this.btnBorrow.TabIndex = 4;
            this.btnBorrow.Text = "借车";
            this.btnBorrow.UseVisualStyleBackColor = true;
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReturn.Location = new System.Drawing.Point(128, 284);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(252, 49);
            this.btnReturn.TabIndex = 5;
            this.btnReturn.Text = "还车";
            this.btnReturn.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(128, 336);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(252, 49);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 415);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.btnTransaction);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnUser);
            this.Controls.Add(this.btnBike);
            this.Name = "frmStart";
            this.Text = "Start";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBike;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnTransaction;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnClose;
    }
}

