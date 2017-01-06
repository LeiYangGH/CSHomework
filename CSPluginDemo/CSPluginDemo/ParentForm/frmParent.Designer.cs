namespace ParentForm
{
    partial class frmParent
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.卸载插件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新插件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pMenuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1251, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pMenuToolStripMenuItem
            // 
            this.pMenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.卸载插件ToolStripMenuItem,
            this.刷新插件ToolStripMenuItem});
            this.pMenuToolStripMenuItem.Name = "pMenuToolStripMenuItem";
            this.pMenuToolStripMenuItem.Size = new System.Drawing.Size(79, 29);
            this.pMenuToolStripMenuItem.Text = "PMenu";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(963, 218);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(211, 164);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // 卸载插件ToolStripMenuItem
            // 
            this.卸载插件ToolStripMenuItem.Name = "卸载插件ToolStripMenuItem";
            this.卸载插件ToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.卸载插件ToolStripMenuItem.Text = "卸载插件";
            this.卸载插件ToolStripMenuItem.Click += new System.EventHandler(this.卸载插件ToolStripMenuItem_Click);
            // 
            // 刷新插件ToolStripMenuItem
            // 
            this.刷新插件ToolStripMenuItem.Name = "刷新插件ToolStripMenuItem";
            this.刷新插件ToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.刷新插件ToolStripMenuItem.Text = "刷新插件";
            this.刷新插件ToolStripMenuItem.Click += new System.EventHandler(this.刷新插件ToolStripMenuItem_Click);
            // 
            // frmParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 577);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmParent";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 卸载插件ToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem 刷新插件ToolStripMenuItem;
    }
}

