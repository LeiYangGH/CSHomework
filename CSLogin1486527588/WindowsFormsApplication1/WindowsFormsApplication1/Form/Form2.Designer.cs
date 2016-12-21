namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmnDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.入库信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.出库信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.药品查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnCourse = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnDepartment,
            this.tsmnCourse,
            this.tsmnHelp,
            this.tsmnQuit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(700, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmnDepartment
            // 
            this.tsmnDepartment.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.入库信息ToolStripMenuItem,
            this.出库信息ToolStripMenuItem,
            this.药品查询ToolStripMenuItem});
            this.tsmnDepartment.Name = "tsmnDepartment";
            this.tsmnDepartment.Size = new System.Drawing.Size(83, 20);
            this.tsmnDepartment.Text = "药品管理(&D)";
            // 
            // 入库信息ToolStripMenuItem
            // 
            this.入库信息ToolStripMenuItem.Name = "入库信息ToolStripMenuItem";
            this.入库信息ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.入库信息ToolStripMenuItem.Text = "入库信息";
            // 
            // 出库信息ToolStripMenuItem
            // 
            this.出库信息ToolStripMenuItem.Name = "出库信息ToolStripMenuItem";
            this.出库信息ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.出库信息ToolStripMenuItem.Text = "出库信息";
            // 
            // 药品查询ToolStripMenuItem
            // 
            this.药品查询ToolStripMenuItem.Name = "药品查询ToolStripMenuItem";
            this.药品查询ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.药品查询ToolStripMenuItem.Text = "药品查询";
            this.药品查询ToolStripMenuItem.Click += new System.EventHandler(this.药品查询ToolStripMenuItem_Click);
            // 
            // tsmnCourse
            // 
            this.tsmnCourse.Name = "tsmnCourse";
            this.tsmnCourse.Size = new System.Drawing.Size(83, 20);
            this.tsmnCourse.Text = "药品目录(&C)";
            this.tsmnCourse.Click += new System.EventHandler(this.tsmnCourse_Click);
            // 
            // tsmnHelp
            // 
            this.tsmnHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnAbout});
            this.tsmnHelp.Name = "tsmnHelp";
            this.tsmnHelp.Size = new System.Drawing.Size(59, 20);
            this.tsmnHelp.Text = "帮助(&H)";
            // 
            // tsmnAbout
            // 
            this.tsmnAbout.Name = "tsmnAbout";
            this.tsmnAbout.Size = new System.Drawing.Size(152, 22);
            this.tsmnAbout.Text = "关于(&A)";
            this.tsmnAbout.Click += new System.EventHandler(this.tsmnAbout_Click);
            // 
            // tsmnQuit
            // 
            this.tsmnQuit.Name = "tsmnQuit";
            this.tsmnQuit.Size = new System.Drawing.Size(59, 20);
            this.tsmnQuit.Text = "退出(&Q)";
            this.tsmnQuit.Click += new System.EventHandler(this.tsmnQuit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(700, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(173, 17);
            this.toolStripStatusLabel1.Text = "欢迎使用药品进销存管理系统！";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(700, 426);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form2";
            this.Text = "药品进销存管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmnDepartment;
        private System.Windows.Forms.ToolStripMenuItem tsmnCourse;
        private System.Windows.Forms.ToolStripMenuItem tsmnHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmnAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmnQuit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 入库信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 出库信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 药品查询ToolStripMenuItem;
    }
}