﻿namespace CSPluginDemo
{
    partial class frmContainer
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
            this.容器菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.刷新插件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.容器菜单ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(827, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 容器菜单ToolStripMenuItem
            // 
            this.容器菜单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新插件ToolStripMenuItem});
            this.容器菜单ToolStripMenuItem.Name = "容器菜单ToolStripMenuItem";
            this.容器菜单ToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
            this.容器菜单ToolStripMenuItem.Text = "容器菜单";
            this.容器菜单ToolStripMenuItem.Click += new System.EventHandler(this.容器菜单ToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(23, 62);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(743, 485);
            this.textBox1.TabIndex = 1;
            // 
            // 刷新插件ToolStripMenuItem
            // 
            this.刷新插件ToolStripMenuItem.Name = "刷新插件ToolStripMenuItem";
            this.刷新插件ToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.刷新插件ToolStripMenuItem.Text = "刷新插件";
            this.刷新插件ToolStripMenuItem.Click += new System.EventHandler(this.刷新插件ToolStripMenuItem_Click);
            // 
            // frmContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 582);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmContainer";
            this.Text = "容器";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 容器菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新插件ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
    }
}

