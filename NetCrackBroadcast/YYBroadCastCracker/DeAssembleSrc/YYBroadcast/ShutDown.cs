using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace YYBroadcast
{
	public class ShutDown : Form
	{
		private IContainer components = null;
		private Button button1;
		private Button button2;
		private Label label1;
		private Label label2;
		private TextBox textBoxHour;
		private TextBox textBoxMinute;
		private Label label4;
		private Label label5;
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);
		public ShutDown()
		{
			this.InitializeComponent();
		}
		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				Process process = new Process();
				process.StartInfo.FileName = "cmd.exe";
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardError = true;
				process.StartInfo.RedirectStandardInput = true;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.CreateNoWindow = true;
				process.Start();
				string value = "Shutdown -a";
				process.StandardInput.WriteLine(value);
			}
			catch
			{
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				string text = this.textBoxHour.Text.Trim();
				string text2 = this.textBoxMinute.Text.Trim();
				if (text == "")
				{
					text = "0";
				}
				if (text2 == "")
				{
					text2 = "0";
				}
				if (text != "0" || text2 != "0")
				{
					int num = Convert.ToInt32(text) * 3600 + Convert.ToInt32(text2) * 60;
					Process process = new Process();
					process.StartInfo.FileName = "cmd.exe";
					process.StartInfo.UseShellExecute = false;
					process.StartInfo.RedirectStandardError = true;
					process.StartInfo.RedirectStandardInput = true;
					process.StartInfo.RedirectStandardOutput = true;
					process.StartInfo.CreateNoWindow = true;
					process.Start();
					string value = "Shutdown -s -t " + num.ToString();
					process.StandardInput.WriteLine(value);
				}
				else
				{
					MessageBox.Show("请输入正确的时间");
				}
			}
			catch
			{
			}
		}
		private void label3_Click(object sender, EventArgs e)
		{
		}
		private void ShutDown_Load(object sender, EventArgs e)
		{
			ShutDown.SetWindowPos(base.Handle, -1, 0, 0, 0, 0, 3);
			this.textBoxHour.Text = "0";
			this.textBoxMinute.Text = "0";
		}
		private void textBoxHour_TextChanged(object sender, EventArgs e)
		{
		}
		private void textBoxMinute_TextChanged(object sender, EventArgs e)
		{
		}
		private void textBoxHour_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
			{
				e.Handled = true;
			}
		}
		private void textBoxMinute_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
			{
				e.Handled = true;
			}
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
			this.button1 = new Button();
			this.button2 = new Button();
			this.label1 = new Label();
			this.label2 = new Label();
			this.textBoxHour = new TextBox();
			this.textBoxMinute = new TextBox();
			this.label4 = new Label();
			this.label5 = new Label();
			base.SuspendLayout();
			this.button1.Location = new Point(55, 117);
			this.button1.Name = "button1";
			this.button1.Size = new Size(90, 37);
			this.button1.TabIndex = 3;
			this.button1.Text = "确认关机";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.button2.Location = new Point(184, 117);
			this.button2.Name = "button2";
			this.button2.Size = new Size(90, 37);
			this.button2.TabIndex = 4;
			this.button2.Text = "取消关机";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new EventHandler(this.button2_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new Point(53, 9);
			this.label1.Name = "label1";
			this.label1.Size = new Size(89, 12);
			this.label1.TabIndex = 5;
			this.label1.Text = "自动关机未启动";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(53, 60);
			this.label2.Name = "label2";
			this.label2.Size = new Size(53, 12);
			this.label2.TabIndex = 6;
			this.label2.Text = "倒计时：";
			this.textBoxHour.Location = new Point(113, 57);
			this.textBoxHour.Name = "textBoxHour";
			this.textBoxHour.Size = new Size(45, 21);
			this.textBoxHour.TabIndex = 8;
			this.textBoxHour.Text = "0";
			this.textBoxHour.TextChanged += new EventHandler(this.textBoxHour_TextChanged);
			this.textBoxHour.KeyPress += new KeyPressEventHandler(this.textBoxHour_KeyPress);
			this.textBoxMinute.Location = new Point(204, 57);
			this.textBoxMinute.Name = "textBoxMinute";
			this.textBoxMinute.Size = new Size(27, 21);
			this.textBoxMinute.TabIndex = 9;
			this.textBoxMinute.Text = "0";
			this.textBoxMinute.TextChanged += new EventHandler(this.textBoxMinute_TextChanged);
			this.textBoxMinute.KeyPress += new KeyPressEventHandler(this.textBoxMinute_KeyPress);
			this.label4.AutoSize = true;
			this.label4.Location = new Point(163, 60);
			this.label4.Name = "label4";
			this.label4.Size = new Size(29, 12);
			this.label4.TabIndex = 11;
			this.label4.Text = "小时";
			this.label5.AutoSize = true;
			this.label5.Location = new Point(240, 60);
			this.label5.Name = "label5";
			this.label5.Size = new Size(29, 12);
			this.label5.TabIndex = 12;
			this.label5.Text = "分钟";
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.BackColor = Color.FromArgb(192, 255, 192);
			base.ClientSize = new Size(321, 181);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.textBoxMinute);
			base.Controls.Add(this.textBoxHour);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.MaximizeBox = false;
			base.Name = "ShutDown";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "自动关机";
			base.Load += new EventHandler(this.ShutDown_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
