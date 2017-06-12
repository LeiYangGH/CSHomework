namespace P23
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
            this.btnBike.Location = new System.Drawing.Point(458, 100);
            this.btnBike.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBike.Name = "btnBike";
            this.btnBike.Size = new System.Drawing.Size(378, 82);
            this.btnBike.TabIndex = 1;
            this.btnBike.Text = "车票管理";
            this.btnBike.UseVisualStyleBackColor = true;
            this.btnBike.Click += new System.EventHandler(this.btnBike_Click);
            // 
            // btnUser
            // 
            this.btnUser.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUser.Location = new System.Drawing.Point(458, 203);
            this.btnUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(378, 82);
            this.btnUser.TabIndex = 2;
            this.btnUser.Text = "客户管理";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdmin.Location = new System.Drawing.Point(458, 317);
            this.btnAdmin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(378, 82);
            this.btnAdmin.TabIndex = 3;
            this.btnAdmin.Text = "管理员管理";
            this.btnAdmin.UseVisualStyleBackColor = true;
            // 
            // btnTransaction
            // 
            this.btnTransaction.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTransaction.Location = new System.Drawing.Point(458, 672);
            this.btnTransaction.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(378, 82);
            this.btnTransaction.TabIndex = 4;
            this.btnTransaction.Text = "交易管理";
            this.btnTransaction.UseVisualStyleBackColor = true;
            // 
            // btnBorrow
            // 
            this.btnBorrow.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBorrow.Location = new System.Drawing.Point(458, 440);
            this.btnBorrow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(378, 82);
            this.btnBorrow.TabIndex = 5;
            this.btnBorrow.Text = "售票";
            this.btnBorrow.UseVisualStyleBackColor = true;
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReturn.Location = new System.Drawing.Point(458, 557);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(378, 82);
            this.btnReturn.TabIndex = 6;
            this.btnReturn.Text = "退票";
            this.btnReturn.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(458, 795);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(378, 82);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // frmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 897);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.btnTransaction);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnUser);
            this.Controls.Add(this.btnBike);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmStart";
            this.Text = "start";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStart_FormClosing);
            this.Load += new System.EventHandler(this.frmStart_Load);
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

