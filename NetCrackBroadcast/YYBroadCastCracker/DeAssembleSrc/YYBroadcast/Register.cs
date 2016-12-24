using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace YYBroadcast
{
    public class Register : Form
    {
        private LoginForm loginForm = new LoginForm();
        //private YYClient YY = new YYClient();
        private IContainer components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private TextBox textBoxUserName;
        private TextBox textBoxRepeatPassword;
        private TextBox textBoxPassword;
        private Label labelUserName;
        private Label labelPassword;
        private Label labelRepeatPassword;
        public Register()
        {
            this.InitializeComponent();
        }
        private void Register_Load(object sender, EventArgs e)
        {
        }
        private void textBoxUserName_MouseLeave(object sender, EventArgs e)
        {
        }
        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.loginForm.Show();
        }
        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            try
            {
                int length = this.textBoxPassword.Text.Trim().Length;
                if (length < 6)
                {
                    this.labelPassword.Text = "密码的位数应大于或等于6位";
                    this.labelPassword.BackColor = Color.Fuchsia;
                }
                else
                {
                    this.labelPassword.Text = "正确";
                    this.labelPassword.BackColor = Color.Transparent;
                }
            }
            catch
            {
            }
        }
        private void textBoxRepeatPassword_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.textBoxPassword.Text.Trim() == this.textBoxRepeatPassword.Text.Trim())
                {
                    if (this.textBoxPassword.Text.Trim() == "")
                    {
                        this.labelRepeatPassword.Text = "密码的位数应大于或等于6位";
                        this.labelRepeatPassword.BackColor = Color.Fuchsia;
                    }
                    else
                    {
                        if (this.textBoxRepeatPassword.Text.Trim().Length < 6)
                        {
                            this.labelRepeatPassword.Text = "密码的位数应大于或等于6位";
                            this.labelRepeatPassword.BackColor = Color.Fuchsia;
                        }
                        else
                        {
                            this.labelRepeatPassword.Text = "正确";
                        }
                    }
                }
                else
                {
                    this.labelRepeatPassword.Text = "与第一次输入的密码不同";
                    this.labelRepeatPassword.BackColor = Color.Fuchsia;
                }
            }
            catch
            {
            }
        }
        private void textBoxUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                if (e.KeyChar < 'A' || e.KeyChar > 'Z')
                {
                    if (e.KeyChar < 'a' || e.KeyChar > 'z')
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        private void textBoxUserName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.textBoxUserName.Text == "")
                {
                    this.labelUserName.Text = "用户名不能为空";
                    this.labelUserName.BackColor = Color.Fuchsia;
                }
                else
                {
                    //DataTable userName = this.YY.GetUserName(this.textBoxUserName.Text.Trim());
                    //if (userName.Rows.Count <= 0)
                    if ("取消注册".Length > 0)
                    {
                        this.labelUserName.Text = "正确";
                        this.labelUserName.BackColor = Color.Transparent;
                    }
                    else
                    {
                        this.labelUserName.Text = "用户名已经存在，请更换";
                        this.labelUserName.BackColor = Color.Fuchsia;
                    }
                }
            }
            catch
            {
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.labelUserName.Text == "正确" && this.labelPassword.Text == "正确" && this.labelRepeatPassword.Text == "正确")
                {
                    string addressIP;
                    try
                    {
                        addressIP = "注册IP";
                    }
                    catch
                    {
                        addressIP = "未查询到IP地址";
                    }
                    //string hardId = Method.GetHardId();
                    //string mac = Method.GetMac();
                    //string onlyID = hardId + mac;
                    //DataTable onlyID2 = this.YY.GetOnlyID(onlyID);
                    //if (onlyID2.Rows.Count >= 2)
                    if ("取消注册".Length < 0)
                    {
                        MessageBox.Show("一台电脑最多只能申请两个账户");
                        base.Close();
                    }
                    else
                    {
                        string name = this.textBoxUserName.Text.Trim();
                        string password = this.textBoxPassword.Text.Trim();
                        //this.YY.WriteRegisterInfo(name, password, addressIP, onlyID);
                        base.Close();
                        MessageBox.Show("恭喜您，注册成功");
                        this.loginForm.Show();
                    }
                }
                else
                {
                    if (this.textBoxPassword.Text == "")
                    {
                        this.labelPassword.Text = "密码的位数应大于或等于6位";
                        this.labelPassword.BackColor = Color.Fuchsia;
                    }
                    if (this.textBoxRepeatPassword.Text == "")
                    {
                        this.labelRepeatPassword.Text = "密码的位数应大于或等于6位";
                        this.labelRepeatPassword.BackColor = Color.Fuchsia;
                    }
                }
            }
            catch
            {
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
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.button1 = new Button();
            this.textBoxUserName = new TextBox();
            this.textBoxRepeatPassword = new TextBox();
            this.textBoxPassword = new TextBox();
            this.labelUserName = new Label();
            this.labelPassword = new Label();
            this.labelRepeatPassword = new Label();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(41, 47);
            this.label1.Name = "label1";
            this.label1.Size = new Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "用户名";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(41, 87);
            this.label2.Name = "label2";
            this.label2.Size = new Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "密码";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(41, 135);
            this.label3.Name = "label3";
            this.label3.Size = new Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "确认密码";
            this.button1.Location = new Point(130, 170);
            this.button1.Name = "button1";
            this.button1.Size = new Size(105, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "注册";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.textBoxUserName.Location = new Point(97, 44);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new Size(179, 21);
            this.textBoxUserName.TabIndex = 0;
            this.textBoxUserName.KeyPress += new KeyPressEventHandler(this.textBoxUserName_KeyPress);
            this.textBoxUserName.Leave += new EventHandler(this.textBoxUserName_Leave);
            this.textBoxUserName.MouseLeave += new EventHandler(this.textBoxUserName_MouseLeave);
            this.textBoxRepeatPassword.Location = new Point(97, 132);
            this.textBoxRepeatPassword.Name = "textBoxRepeatPassword";
            this.textBoxRepeatPassword.Size = new Size(179, 21);
            this.textBoxRepeatPassword.TabIndex = 2;
            this.textBoxRepeatPassword.Leave += new EventHandler(this.textBoxRepeatPassword_Leave);
            this.textBoxPassword.Location = new Point(97, 84);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new Size(179, 21);
            this.textBoxPassword.TabIndex = 1;
            this.textBoxPassword.Leave += new EventHandler(this.textBoxPassword_Leave);
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new Point(294, 47);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new Size(113, 12);
            this.labelUserName.TabIndex = 7;
            this.labelUserName.Text = "只能使用字母和数字";
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new Point(294, 87);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new Size(47, 12);
            this.labelPassword.TabIndex = 8;
            this.labelPassword.Text = "最少6位";
            this.labelRepeatPassword.AutoSize = true;
            this.labelRepeatPassword.Location = new Point(294, 135);
            this.labelRepeatPassword.Name = "labelRepeatPassword";
            this.labelRepeatPassword.Size = new Size(0, 12);
            this.labelRepeatPassword.TabIndex = 9;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(192, 255, 192);
            base.ClientSize = new Size(463, 226);
            base.Controls.Add(this.labelRepeatPassword);
            base.Controls.Add(this.labelPassword);
            base.Controls.Add(this.labelUserName);
            base.Controls.Add(this.textBoxPassword);
            base.Controls.Add(this.textBoxRepeatPassword);
            base.Controls.Add(this.textBoxUserName);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Name = "Register";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "注册";
            base.FormClosing += new FormClosingEventHandler(this.Register_FormClosing);
            base.Load += new EventHandler(this.Register_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}
