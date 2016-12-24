using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace YYBroadcast
{
    public class LoginForm : Form
    {
        //private YYClient YY = new YYClient();
        private IContainer components = null;
        private Label label1;
        private Label label2;
        private TextBox textBoxUserName;
        private TextBox textBoxPassword;
        private Button buttonLogin;
        private Button buttonRegister;
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern int GetClassNameW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern int GetWindowTextW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpString, int nMaxCount);
        public LoginForm()
        {
            this.InitializeComponent();
            this.Activated += LoginForm_Activated;
        }

        private void LoginForm_Activated(object sender, EventArgs e)
        {
            this.Activated -= this.LoginForm_Activated;
            this.buttonLogin_Click(null, null);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //StringBuilder stringBuilder = new StringBuilder(256);
            //LoginForm.GetClassNameW(base.Handle, stringBuilder, stringBuilder.Capacity);
            //IntPtr value = IntPtr.Zero;
            //value = LoginForm.FindWindow(stringBuilder.ToString(), "YY广播1.0");
            //if (value != IntPtr.Zero)
            //{
            //    MessageBox.Show("同时只能登陆一个广播器");
            //    base.Close();
            //}
            //else
            {
                //DataTable userInfo = this.YY.GetUserInfo(this.textBoxUserName.Text.Trim(), this.textBoxPassword.Text.Trim());
                //if (userInfo.Rows.Count <= 0)
                //{
                //    MessageBox.Show("用户名或者密码错误");
                //    this.textBoxPassword.Clear();
                //    this.textBoxUserName.Clear();
                //    this.textBoxUserName.Focus();
                //}
                //else
                {
                    string addressIp;
                    try
                    {
                        addressIp = "IP";
                    }
                    catch
                    {
                        addressIp = "未查询到IP地址";
                    }
                    GlobalVariable.UserName = "没登录所以也没用户名";
                    GlobalVariable.SystemTime = DateTime.Now.ToString();
                    GlobalVariable.Vip = "true";
                    GlobalVariable.VipDate = "2055-5-15 55:55:55";
                    FormYYBroadast formYYBroadast = new FormYYBroadast();
                    this.Hide();
                    formYYBroadast.Show();
                    //MessageBox.Show("已（假）登录");

                    //}
                    //else
                    //{
                    //    GlobalVariable.Vip = "false";
                    //    MessageBox.Show("VIP已经过期");
                    //}
                }
            }
        }
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            MessageBox.Show("登录都取消了，还注册干嘛啊");
            //Register register = new Register();
            //register.Show();
            //base.Hide();
        }
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {


            //try
            //{
            //    StringBuilder stringBuilder = new StringBuilder(256);
            //    LoginForm.GetWindowTextW(base.Handle, stringBuilder, stringBuilder.Capacity);
            //    DataTable version = this.YY.GetVersion();
            //    string b = version.Rows[0][0].ToString();
            //    string fileName = version.Rows[0][1].ToString();
            //    GlobalVariable.GongGao = version.Rows[0][2].ToString();
            //    string str = version.Rows[0][3].ToString();
            //    if (!(stringBuilder.ToString() == b))
            //    {
            //        MessageBox.Show("发现新版本,点击确认下载\n下载完成后请使用最新版本\n\n" + str);
            //        Process.Start(fileName);
            //        LoginForm.SendMessage(base.Handle, 16, 0, 0);
            //    }
            //}
            //catch
            //{
            //}
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
            this.textBoxUserName = new TextBox();
            this.textBoxPassword = new TextBox();
            this.buttonLogin = new Button();
            this.buttonRegister = new Button();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(41, 55);
            this.label1.Name = "label1";
            this.label1.Size = new Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "账号：";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(41, 109);
            this.label2.Name = "label2";
            this.label2.Size = new Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码：";
            this.textBoxUserName.Location = new Point(97, 52);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new Size(154, 21);
            this.textBoxUserName.Text = "1";//ly
            this.textBoxUserName.TabIndex = 2;
            this.textBoxPassword.Location = new Point(97, 106);
            this.textBoxPassword.Name = "textBoxPassword";
            //this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Text = "1";
            this.textBoxPassword.Size = new Size(154, 21);
            this.textBoxPassword.TabIndex = 3;
            this.buttonLogin.Location = new Point(51, 160);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new Size(87, 27);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "登录";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new EventHandler(this.buttonLogin_Click);
            this.buttonRegister.Location = new Point(164, 160);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new Size(87, 27);
            this.buttonRegister.TabIndex = 5;
            this.buttonRegister.Text = "注册";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new EventHandler(this.buttonRegister_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BackColor = Color.FromArgb(192, 255, 192);
            base.ClientSize = new Size(293, 219);
            base.Controls.Add(this.buttonRegister);
            base.Controls.Add(this.buttonLogin);
            base.Controls.Add(this.textBoxPassword);
            base.Controls.Add(this.textBoxUserName);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.MaximizeBox = false;
            base.Name = "LoginForm";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "YY广播2.2--登录";
            base.FormClosing += new FormClosingEventHandler(this.LoginForm_FormClosing);
            base.Load += new EventHandler(this.LoginForm_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}
