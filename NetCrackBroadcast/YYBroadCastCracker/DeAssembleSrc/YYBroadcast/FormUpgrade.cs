using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace YYBroadcast
{
    public class FormUpgrade : Form
    {
        //private YYClient YY = new YYClient();
        private IContainer components = null;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public FormUpgrade()
        {
            this.InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string text = this.textBox1.Text.Trim();
                int num = text.IndexOf("-");
                string date = text.Substring(num + 1, text.Length - num - 1);
                //DataTable license = this.YY.GetLicense(text);
                //if (license.Rows.Count > 0)
                //{
                //this.YY.WriteVipAndNumber(GlobalVariable.UserName, date, text);

                MessageBox.Show("(此处取消了一个注册认证)升级成功,请重新登录广播器");
                FormUpgrade.SendMessage(GlobalVariable.HwndMain, 16, 0, 0);
                //}
                //else
                //{
                //	MessageBox.Show("注册码不正确或者已经被使用");
                //}
            }
            catch
            {
            }
        }
        private void FormUpgrade_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        private void FormUpgrade_Load(object sender, EventArgs e)
        {
            FormUpgrade.SetWindowPos(base.Handle, -1, 0, 0, 0, 0, 3);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            this.button1 = new Button();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(30, 65);
            this.label1.Name = "label1";
            this.label1.Size = new Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "注册码：";
            this.textBox1.Location = new Point(89, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(150, 21);
            this.textBox1.TabIndex = 1;
            this.button1.Location = new Point(119, 110);
            this.button1.Name = "button1";
            this.button1.Size = new Size(86, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "升级";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            base.ClientSize = new Size(284, 162);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.textBox1);
            base.Controls.Add(this.label1);
            base.MaximizeBox = false;
            base.Name = "FormUpgrade";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "升级为VIP";
            base.FormClosing += new FormClosingEventHandler(this.FormUpgrade_FormClosing);
            base.Load += new EventHandler(this.FormUpgrade_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}
