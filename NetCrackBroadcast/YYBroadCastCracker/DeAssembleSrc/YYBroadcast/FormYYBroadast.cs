using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace YYBroadcast
{
    public class FormYYBroadast : Form
    {
        private int send_x = 575;
        private int send_y = 463;
        private Random random_1 = new Random();
        private Random random_2 = new Random();
        private Random random_3 = new Random();
        private Random random_4 = new Random();
        private Random random_5 = new Random();
        private int RandomKey_1 = 0;
        private int RandomKey_2 = 0;
        private int RandomKey_3 = 0;
        private int RandomKey_4 = 0;
        private int RandomKey_5 = 0;
        private string text1_1 = "";
        private string text1_2 = "";
        private string textTime1_1 = "";
        private string textTime1_2 = "";
        private string textTime1_3 = "";
        private List<string> text1_list = new List<string>();
        private List<string> text2_list = new List<string>();
        private List<string> textTime1_list = new List<string>();
        private List<string> textTime2_list = new List<string>();
        private List<string> textTime3_list = new List<string>();
        private string text2_1 = "";
        private string text2_2 = "";
        private string textTime2_1 = "";
        private string textTime2_2 = "";
        private string textTime2_3 = "";
        private string text3_1 = "";
        private string text3_2 = "";
        private string textTime3_1 = "";
        private string textTime3_2 = "";
        private string textTime3_3 = "";
        private string text4_1 = "";
        private string text4_2 = "";
        private string textTime4_1 = "";
        private string textTime4_2 = "";
        private string textTime4_3 = "";
        private string text5_1 = "";
        private string text5_2 = "";
        private string textTime5_1 = "";
        private string textTime5_2 = "";
        private string textTime5_3 = "";
        private string isClickRadioButtonTime1_1 = "select";
        private string isClickRadioButtonTime1_2 = "noSelect";
        private string isClickRadioButtonTime2_1 = "select";
        private string isClickRadioButtonTime2_2 = "noSelect";
        private string isClickRadioButtonTime3_1 = "select";
        private string isClickRadioButtonTime3_2 = "noSelect";
        private string isClickRadioButtonTime4_1 = "select";
        private string isClickRadioButtonTime4_2 = "noSelect";
        private string isClickRadioButtonTime5_1 = "select";
        private string isClickRadioButtonTime5_2 = "noSelect";
        private string isClickSend1 = "发送";
        private string isClickSend2 = "发送";
        private string isClickSend3 = "发送";
        private string isClickSend4 = "发送";
        private string isClickSend5 = "发送";
        private List<IntPtr> hwndYY_list = new List<IntPtr>();
        private List<IntPtr> YY_list = new List<IntPtr>();
        private List<IntPtr> hwndYYBroadcast_list = new List<IntPtr>();
        private List<string> nameYYBroadcast_list = new List<string>();
        private List<string> nameYYBroadcastID_list = new List<string>();
        private IntPtr hwndDesktop = FormYYBroadast.GetDesktopWindow();
        private List<string> textList = new List<string>();
        private IContainer components = null;
        private RadioButton radioButton2;
        private GroupBox groupBox1;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton1;
        private GroupBox groupBox2;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private TextBox textBox2;
        private Button buttonSend;
        private GroupBox groupBox3;
        private Label label3;
        private TextBox textBoxTime3;
        private TextBox textBoxTime2;
        private TextBox textBoxTime1;
        private RadioButton radioButtonTime2;
        private RadioButton radioButtonTime1;
        private GroupBox groupBox4;
        private Label labelState5;
        private Label labelState3;
        private Label labelState4;
        private Label labelState2;
        private Label labelState1;
        private Timer timer1;
        private Timer timer2;
        private Timer timer3;
        private Timer timer4;
        private Timer timer5;
        private Label labelGongGao;
        private Timer timer6;
        private Timer timer8;
        private Timer timer9;
        private Button buttonQQ;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton toolStripButton6;
        private Button YinCangButton;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr childAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern int GetWindowTextW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

#if TRIAL5
        private static int cnt;
        private static int x = 5 * 60;
        System.Timers.Timer t = new System.Timers.Timer(1000);
#endif

        public FormYYBroadast()
        {
            this.InitializeComponent();
#if TRIAL5
            t.Elapsed += T_Elapsed;
            t.Start();
#endif
        }

#if TRIAL5
        private void T_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (cnt++ > x)
            {
                this.t.Stop();
                Application.Exit();
            }
        }
#endif


        private void buttonFind_Click(object sender, EventArgs e)
        {
        }
        private void FormYYBroadast_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalVariable.HwndMain = base.Handle;
                this.labelGongGao.Left = base.Width;
                this.labelGongGao.Text = "VIP会员有效期： " + GlobalVariable.VipDate + "     " + GlobalVariable.GongGao;
                this.labelState1.Text = "";
                this.labelState2.Text = "";
                this.labelState3.Text = "";
                this.labelState4.Text = "";
                this.labelState5.Text = "";
                this.radioButton1.Visible = false;
                this.radioButton2.Visible = false;
                this.radioButton3.Visible = false;
                this.radioButton4.Visible = false;
                this.radioButton5.Visible = false;
                this.timer1.Enabled = false;
                this.timer2.Enabled = false;
                this.timer3.Enabled = false;
                this.timer4.Enabled = false;
                this.timer5.Enabled = false;
                this.radioButtonTime1.Checked = true;
                this.textBox1.Enabled = false;
                this.textBox2.Enabled = false;
                this.textBoxTime1.Enabled = false;
                this.textBoxTime2.Enabled = false;
                this.textBoxTime3.Enabled = false;
                this.radioButtonTime1.Enabled = false;
                this.radioButtonTime2.Enabled = false;
                this.buttonSend.Enabled = false;
                this.YinCangButton.Enabled = false;
            }
            catch
            {
            }
        }
        private void radioButton1_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder(256);
                FormYYBroadast.GetWindowTextW(this.hwndYYBroadcast_list[0], stringBuilder, stringBuilder.Capacity);
                if (stringBuilder.ToString() != this.nameYYBroadcast_list[0])
                {
                    MessageBox.Show("您点击的频道广播窗口不存在，请检查广播窗口是否打开，然后点击【添加频道】");
                    this.radioButton1.Text = "";
                    this.text1_1 = "";
                    this.text1_2 = "";
                    this.textTime1_1 = "";
                    this.textTime1_2 = "";
                    this.textTime1_3 = "";
                    this.isClickSend1 = "发送";
                    this.isClickRadioButtonTime1_1 = "select";
                    this.labelState1.Text = "";
                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.textBoxTime1.Text = "";
                    this.textBoxTime2.Text = "";
                    this.textBoxTime3.Text = "";
                    this.buttonSend.Text = "发送";
                    this.timer1.Enabled = false;
                    this.radioButton1.Visible = false;
                    this.textBox1.Enabled = false;
                    this.textBox2.Enabled = false;
                    this.textBoxTime1.Enabled = false;
                    this.textBoxTime2.Enabled = false;
                    this.textBoxTime3.Enabled = false;
                    this.buttonSend.Enabled = false;
                    this.YinCangButton.Enabled = false;
                    this.radioButtonTime1.Enabled = false;
                    this.radioButtonTime2.Enabled = false;
                    this.nameYYBroadcast_list[0] = "";
                }
                else
                {
                    bool flag = false;
                    if (this.hwndYYBroadcast_list.Count > 1)
                    {
                        for (int i = 0; i < this.hwndYYBroadcast_list.Count; i++)
                        {
                            if (this.nameYYBroadcast_list[i] == this.nameYYBroadcast_list[0] && i != 0)
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (flag)
                    {
                        FormYYBroadast.SetForegroundWindow(this.hwndYYBroadcast_list[0]);
                    }
                    this.buttonSend.Enabled = true;
                    this.YinCangButton.Enabled = true;
                    this.textBox1.Text = this.text1_1;
                    this.textBox2.Text = this.text1_2;
                    this.textBoxTime1.Text = this.textTime1_1;
                    this.textBoxTime2.Text = this.textTime1_2;
                    this.textBoxTime3.Text = this.textTime1_3;
                    if (this.isClickRadioButtonTime1_1 == "select")
                    {
                        this.radioButtonTime1.Checked = true;
                    }
                    else
                    {
                        this.radioButtonTime2.Checked = true;
                    }
                    this.buttonSend.Text = this.isClickSend1;
                    this.TextBoxEnabled(this.isClickSend1);
                    this.textBox1.Focus();
                    SendKeys.Send("{end}");
                }
            }
            catch
            {
            }
        }
        private void radioButton2_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder(256);
                FormYYBroadast.GetWindowTextW(this.hwndYYBroadcast_list[1], stringBuilder, stringBuilder.Capacity);
                if (stringBuilder.ToString() != this.nameYYBroadcast_list[1])
                {
                    MessageBox.Show("您点击的频道广播窗口不存在，请检查广播窗口是否打开，然后点击【添加频道】");
                    this.radioButton2.Text = "";
                    this.text2_1 = "";
                    this.text2_2 = "";
                    this.textTime2_1 = "";
                    this.textTime2_2 = "";
                    this.textTime2_3 = "";
                    this.isClickSend2 = "发送";
                    this.isClickRadioButtonTime2_1 = "select";
                    this.labelState2.Text = "";
                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.textBoxTime1.Text = "";
                    this.textBoxTime2.Text = "";
                    this.textBoxTime3.Text = "";
                    this.buttonSend.Text = "发送";
                    this.timer2.Enabled = false;
                    this.radioButton2.Visible = false;
                    this.textBox1.Enabled = false;
                    this.textBox2.Enabled = false;
                    this.textBoxTime1.Enabled = false;
                    this.textBoxTime2.Enabled = false;
                    this.textBoxTime3.Enabled = false;
                    this.buttonSend.Enabled = false;
                    this.YinCangButton.Enabled = false;
                    this.radioButtonTime1.Enabled = false;
                    this.radioButtonTime2.Enabled = false;
                    this.nameYYBroadcast_list[1] = "";
                }
                else
                {
                    bool flag = false;
                    if (this.hwndYYBroadcast_list.Count > 1)
                    {
                        for (int i = 0; i < this.hwndYYBroadcast_list.Count; i++)
                        {
                            if (this.nameYYBroadcast_list[i] == this.nameYYBroadcast_list[1] && i != 1)
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (flag)
                    {
                        FormYYBroadast.SetForegroundWindow(this.hwndYYBroadcast_list[1]);
                    }
                    this.buttonSend.Enabled = true;
                    this.YinCangButton.Enabled = true;
                    this.textBox1.Text = this.text2_1;
                    this.textBox2.Text = this.text2_2;
                    this.textBoxTime1.Text = this.textTime2_1;
                    this.textBoxTime2.Text = this.textTime2_2;
                    this.textBoxTime3.Text = this.textTime2_3;
                    if (this.isClickRadioButtonTime2_1 == "select")
                    {
                        this.radioButtonTime1.Checked = true;
                    }
                    else
                    {
                        this.radioButtonTime2.Checked = true;
                    }
                    this.buttonSend.Text = this.isClickSend2;
                    this.TextBoxEnabled(this.isClickSend2);
                    this.textBox1.Focus();
                    SendKeys.Send("{end}");
                }
            }
            catch
            {
            }
        }
        private void radioButton3_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder(256);
                FormYYBroadast.GetWindowTextW(this.hwndYYBroadcast_list[2], stringBuilder, stringBuilder.Capacity);
                if (stringBuilder.ToString() != this.nameYYBroadcast_list[2])
                {
                    MessageBox.Show("您点击的频道广播窗口不存在，请检查广播窗口是否打开，然后点击【添加频道】");
                    this.radioButton3.Text = "";
                    this.text3_1 = "";
                    this.text3_2 = "";
                    this.textTime3_1 = "";
                    this.textTime3_2 = "";
                    this.textTime3_3 = "";
                    this.isClickSend3 = "发送";
                    this.isClickRadioButtonTime3_1 = "select";
                    this.labelState3.Text = "";
                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.textBoxTime1.Text = "";
                    this.textBoxTime2.Text = "";
                    this.textBoxTime3.Text = "";
                    this.buttonSend.Text = "发送";
                    this.timer3.Enabled = false;
                    this.radioButton3.Visible = false;
                    this.textBox1.Enabled = false;
                    this.textBox2.Enabled = false;
                    this.textBoxTime1.Enabled = false;
                    this.textBoxTime2.Enabled = false;
                    this.textBoxTime3.Enabled = false;
                    this.buttonSend.Enabled = false;
                    this.YinCangButton.Enabled = false;
                    this.radioButtonTime1.Enabled = false;
                    this.radioButtonTime2.Enabled = false;
                    this.nameYYBroadcast_list[2] = "";
                }
                else
                {
                    bool flag = false;
                    if (this.hwndYYBroadcast_list.Count > 1)
                    {
                        for (int i = 0; i < this.hwndYYBroadcast_list.Count; i++)
                        {
                            if (this.nameYYBroadcast_list[i] == this.nameYYBroadcast_list[2] && i != 2)
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (flag)
                    {
                        FormYYBroadast.SetForegroundWindow(this.hwndYYBroadcast_list[2]);
                    }
                    this.buttonSend.Enabled = true;
                    this.YinCangButton.Enabled = true;
                    this.textBox1.Text = this.text3_1;
                    this.textBox2.Text = this.text3_2;
                    this.textBoxTime1.Text = this.textTime3_1;
                    this.textBoxTime2.Text = this.textTime3_2;
                    this.textBoxTime3.Text = this.textTime3_3;
                    if (this.isClickRadioButtonTime3_1 == "select")
                    {
                        this.radioButtonTime1.Checked = true;
                    }
                    else
                    {
                        this.radioButtonTime2.Checked = true;
                    }
                    this.buttonSend.Text = this.isClickSend3;
                    this.TextBoxEnabled(this.isClickSend3);
                    this.textBox1.Focus();
                    SendKeys.Send("{end}");
                }
            }
            catch
            {
            }
        }
        private void radioButton4_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder(256);
                FormYYBroadast.GetWindowTextW(this.hwndYYBroadcast_list[3], stringBuilder, stringBuilder.Capacity);
                if (stringBuilder.ToString() != this.nameYYBroadcast_list[3])
                {
                    MessageBox.Show("您点击的频道广播窗口不存在，请检查广播窗口是否打开，然后点击【添加频道】");
                    this.radioButton4.Text = "";
                    this.text4_1 = "";
                    this.text4_2 = "";
                    this.textTime4_1 = "";
                    this.textTime4_2 = "";
                    this.textTime4_3 = "";
                    this.isClickSend4 = "发送";
                    this.isClickRadioButtonTime4_1 = "select";
                    this.labelState4.Text = "";
                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.textBoxTime1.Text = "";
                    this.textBoxTime2.Text = "";
                    this.textBoxTime3.Text = "";
                    this.buttonSend.Text = "发送";
                    this.timer4.Enabled = false;
                    this.radioButton4.Visible = false;
                    this.textBox1.Enabled = false;
                    this.textBox2.Enabled = false;
                    this.textBoxTime1.Enabled = false;
                    this.textBoxTime2.Enabled = false;
                    this.textBoxTime3.Enabled = false;
                    this.buttonSend.Enabled = false;
                    this.YinCangButton.Enabled = false;
                    this.radioButtonTime1.Enabled = false;
                    this.radioButtonTime2.Enabled = false;
                    this.nameYYBroadcast_list[3] = "";
                }
                else
                {
                    bool flag = false;
                    if (this.hwndYYBroadcast_list.Count > 1)
                    {
                        for (int i = 0; i < this.hwndYYBroadcast_list.Count; i++)
                        {
                            if (this.nameYYBroadcast_list[i] == this.nameYYBroadcast_list[3] && i != 3)
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (flag)
                    {
                        FormYYBroadast.SetForegroundWindow(this.hwndYYBroadcast_list[3]);
                    }
                    this.buttonSend.Enabled = true;
                    this.YinCangButton.Enabled = true;
                    this.textBox1.Text = this.text4_1;
                    this.textBox2.Text = this.text4_2;
                    this.textBoxTime1.Text = this.textTime4_1;
                    this.textBoxTime2.Text = this.textTime4_2;
                    this.textBoxTime3.Text = this.textTime4_3;
                    if (this.isClickRadioButtonTime4_1 == "select")
                    {
                        this.radioButtonTime1.Checked = true;
                    }
                    else
                    {
                        this.radioButtonTime2.Checked = true;
                    }
                    this.buttonSend.Text = this.isClickSend4;
                    this.TextBoxEnabled(this.isClickSend4);
                    this.textBox1.Focus();
                    SendKeys.Send("{end}");
                }
            }
            catch
            {
            }
        }
        private void radioButton5_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder(256);
                FormYYBroadast.GetWindowTextW(this.hwndYYBroadcast_list[4], stringBuilder, stringBuilder.Capacity);
                if (stringBuilder.ToString() != this.nameYYBroadcast_list[4])
                {
                    MessageBox.Show("您点击的频道广播窗口不存在，请检查广播窗口是否打开，然后点击【添加频道】");
                    this.radioButton5.Text = "";
                    this.text5_1 = "";
                    this.text5_2 = "";
                    this.textTime5_1 = "";
                    this.textTime5_2 = "";
                    this.textTime5_3 = "";
                    this.isClickSend5 = "发送";
                    this.isClickRadioButtonTime5_1 = "select";
                    this.labelState5.Text = "";
                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.textBoxTime1.Text = "";
                    this.textBoxTime2.Text = "";
                    this.textBoxTime3.Text = "";
                    this.buttonSend.Text = "发送";
                    this.timer5.Enabled = false;
                    this.radioButton5.Visible = false;
                    this.textBox1.Enabled = false;
                    this.textBox2.Enabled = false;
                    this.textBoxTime1.Enabled = false;
                    this.textBoxTime2.Enabled = false;
                    this.textBoxTime3.Enabled = false;
                    this.buttonSend.Enabled = false;
                    this.YinCangButton.Enabled = false;
                    this.radioButtonTime1.Enabled = false;
                    this.radioButtonTime2.Enabled = false;
                    this.nameYYBroadcast_list[4] = "";
                }
                else
                {
                    bool flag = false;
                    if (this.hwndYYBroadcast_list.Count > 1)
                    {
                        for (int i = 0; i < this.hwndYYBroadcast_list.Count; i++)
                        {
                            if (this.nameYYBroadcast_list[i] == this.nameYYBroadcast_list[4] && i != 4)
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (flag)
                    {
                        FormYYBroadast.SetForegroundWindow(this.hwndYYBroadcast_list[4]);
                    }
                    this.buttonSend.Enabled = true;
                    this.YinCangButton.Enabled = true;
                    this.textBox1.Text = this.text5_1;
                    this.textBox2.Text = this.text5_2;
                    this.textBoxTime1.Text = this.textTime5_1;
                    this.textBoxTime2.Text = this.textTime5_2;
                    this.textBoxTime3.Text = this.textTime5_3;
                    if (this.isClickRadioButtonTime5_1 == "select")
                    {
                        this.radioButtonTime1.Checked = true;
                    }
                    else
                    {
                        this.radioButtonTime2.Checked = true;
                    }
                    this.buttonSend.Text = this.isClickSend5;
                    this.TextBoxEnabled(this.isClickSend5);
                    this.textBox1.Focus();
                    SendKeys.Send("{end}");
                }
            }
            catch
            {
            }
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.buttonSend.Text == "发送")
                {
                    if (this.radioButton1.Checked)
                    {
                        this.MethodSend(1);
                    }
                    else
                    {
                        if (this.radioButton2.Checked)
                        {
                            this.MethodSend(2);
                        }
                        else
                        {
                            if (this.radioButton3.Checked)
                            {
                                this.MethodSend(3);
                            }
                            else
                            {
                                if (this.radioButton4.Checked)
                                {
                                    this.MethodSend(4);
                                }
                                else
                                {
                                    this.MethodSend(5);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (this.radioButton1.Checked)
                    {
                        this.timer1.Enabled = false;
                        this.buttonSend.Text = "发送";
                        this.isClickSend1 = "发送";
                        this.TextBoxEnabled(this.isClickSend1);
                        this.labelState1.Text = "暂停中▪ ▪ ▪ ▪";
                    }
                    else
                    {
                        if (this.radioButton2.Checked)
                        {
                            this.timer2.Enabled = false;
                            this.buttonSend.Text = "发送";
                            this.isClickSend2 = "发送";
                            this.TextBoxEnabled(this.isClickSend2);
                            this.labelState2.Text = "暂停中▪ ▪ ▪ ▪";
                        }
                        else
                        {
                            if (this.radioButton3.Checked)
                            {
                                this.timer3.Enabled = false;
                                this.buttonSend.Text = "发送";
                                this.isClickSend3 = "发送";
                                this.TextBoxEnabled(this.isClickSend3);
                                this.labelState3.Text = "暂停中▪ ▪ ▪ ▪";
                            }
                            else
                            {
                                if (this.radioButton4.Checked)
                                {
                                    this.timer4.Enabled = false;
                                    this.buttonSend.Text = "发送";
                                    this.isClickSend4 = "发送";
                                    this.TextBoxEnabled(this.isClickSend4);
                                    this.labelState4.Text = "暂停中▪ ▪ ▪ ▪";
                                }
                                else
                                {
                                    this.timer5.Enabled = false;
                                    this.buttonSend.Text = "发送";
                                    this.isClickSend5 = "发送";
                                    this.TextBoxEnabled(this.isClickSend5);
                                    this.labelState5.Text = "暂停中▪ ▪ ▪ ▪";
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.isClickRadioButtonTime1_2 == "select")
                {
                    this.RandomKey_1 = this.random_1.Next(Convert.ToInt32(this.textTime1_2), Convert.ToInt32(this.textTime1_3));
                    this.timer1.Interval = this.RandomKey_1 * 1000;
                }
                Method.ShowCursor(this.hwndYYBroadcast_list[0]);
                if (GlobalVariable.NeiRongBianHao1 % 2 == 1)
                {
                    Method.InputBroadcastContent(this.text1_1, this.hwndYYBroadcast_list[0]);
                }
                else
                {
                    Method.InputBroadcastContent(this.text1_2, this.hwndYYBroadcast_list[0]);
                }
                FormYYBroadast.SendMessage(this.hwndYYBroadcast_list[0], 513, 0, this.send_x + (this.send_y << 16));
                FormYYBroadast.SendMessage(this.hwndYYBroadcast_list[0], 514, 0, this.send_x + (this.send_y << 16));
                GlobalVariable.NeiRongBianHao1++;
            }
            catch
            {
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.isClickRadioButtonTime2_2 == "select")
                {
                    this.RandomKey_2 = this.random_2.Next(Convert.ToInt32(this.textTime2_2), Convert.ToInt32(this.textTime2_3));
                    this.timer2.Interval = this.RandomKey_2 * 1000;
                }
                Method.ShowCursor(this.hwndYYBroadcast_list[1]);
                if (GlobalVariable.NeiRongBianHao2 % 2 == 1)
                {
                    Method.InputBroadcastContent(this.text2_1, this.hwndYYBroadcast_list[1]);
                }
                else
                {
                    Method.InputBroadcastContent(this.text2_2, this.hwndYYBroadcast_list[1]);
                }
                FormYYBroadast.SendMessage(this.hwndYYBroadcast_list[1], 513, 0, this.send_x + (this.send_y << 16));
                FormYYBroadast.SendMessage(this.hwndYYBroadcast_list[1], 514, 0, this.send_x + (this.send_y << 16));
                GlobalVariable.NeiRongBianHao2++;
            }
            catch
            {
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.isClickRadioButtonTime3_2 == "select")
                {
                    this.RandomKey_3 = this.random_3.Next(Convert.ToInt32(this.textTime3_2), Convert.ToInt32(this.textTime3_3));
                    this.timer3.Interval = this.RandomKey_3 * 1000;
                }
                Method.ShowCursor(this.hwndYYBroadcast_list[2]);
                if (GlobalVariable.NeiRongBianHao3 % 2 == 1)
                {
                    Method.InputBroadcastContent(this.text3_1, this.hwndYYBroadcast_list[2]);
                }
                else
                {
                    Method.InputBroadcastContent(this.text3_2, this.hwndYYBroadcast_list[2]);
                }
                FormYYBroadast.SendMessage(this.hwndYYBroadcast_list[2], 513, 0, this.send_x + (this.send_y << 16));
                FormYYBroadast.SendMessage(this.hwndYYBroadcast_list[2], 514, 0, this.send_x + (this.send_y << 16));
                GlobalVariable.NeiRongBianHao3++;
            }
            catch
            {
            }
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.isClickRadioButtonTime4_2 == "select")
                {
                    this.RandomKey_4 = this.random_4.Next(Convert.ToInt32(this.textTime4_2), Convert.ToInt32(this.textTime4_3));
                    this.timer4.Interval = this.RandomKey_4 * 1000;
                }
                Method.ShowCursor(this.hwndYYBroadcast_list[3]);
                if (GlobalVariable.NeiRongBianHao4 % 2 == 1)
                {
                    Method.InputBroadcastContent(this.text4_1, this.hwndYYBroadcast_list[3]);
                }
                else
                {
                    Method.InputBroadcastContent(this.text4_2, this.hwndYYBroadcast_list[3]);
                }
                FormYYBroadast.SendMessage(this.hwndYYBroadcast_list[3], 513, 0, this.send_x + (this.send_y << 16));
                FormYYBroadast.SendMessage(this.hwndYYBroadcast_list[3], 514, 0, this.send_x + (this.send_y << 16));
                GlobalVariable.NeiRongBianHao4++;
            }
            catch
            {
            }
        }
        private void timer5_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.isClickRadioButtonTime5_2 == "select")
                {
                    this.RandomKey_5 = this.random_5.Next(Convert.ToInt32(this.textTime5_2), Convert.ToInt32(this.textTime5_3));
                    this.timer5.Interval = this.RandomKey_5 * 1000;
                }
                Method.ShowCursor(this.hwndYYBroadcast_list[4]);
                if (GlobalVariable.NeiRongBianHao5 % 2 == 1)
                {
                    Method.InputBroadcastContent(this.text5_1, this.hwndYYBroadcast_list[4]);
                }
                else
                {
                    Method.InputBroadcastContent(this.text5_2, this.hwndYYBroadcast_list[4]);
                }
                FormYYBroadast.SendMessage(this.hwndYYBroadcast_list[4], 513, 0, this.send_x + (this.send_y << 16));
                FormYYBroadast.SendMessage(this.hwndYYBroadcast_list[4], 514, 0, this.send_x + (this.send_y << 16));
                GlobalVariable.NeiRongBianHao5++;
            }
            catch
            {
            }
        }
        private void textBoxTime1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void textBoxTime2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void textBoxTime3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                this.TextBoxLeave(ref this.text1_1, ref this.text2_1, ref this.text3_1, ref this.text4_1, ref this.text5_1, this.textBox1.Text);
            }
            catch
            {
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            try
            {
                this.TextBoxLeave(ref this.text1_2, ref this.text2_2, ref this.text3_2, ref this.text4_2, ref this.text5_2, this.textBox2.Text);
            }
            catch
            {
            }
        }
        private void textBoxTime1_Leave(object sender, EventArgs e)
        {
            try
            {
                this.TextBoxLeave(ref this.textTime1_1, ref this.textTime2_1, ref this.textTime3_1, ref this.textTime4_1, ref this.textTime5_1, this.textBoxTime1.Text);
            }
            catch
            {
            }
        }
        private void textBoxTime2_Leave(object sender, EventArgs e)
        {
            try
            {
                this.TextBoxLeave(ref this.textTime1_2, ref this.textTime2_2, ref this.textTime3_2, ref this.textTime4_2, ref this.textTime5_2, this.textBoxTime2.Text);
            }
            catch
            {
            }
        }
        private void textBoxTime3_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.textBoxTime2.Text.Trim() != "" && this.textBoxTime3.Text.Trim() != "")
                {
                    if (Convert.ToInt32(this.textBoxTime2.Text.Trim()) >= Convert.ToInt32(this.textBoxTime3.Text.Trim()))
                    {
                        MessageBox.Show("您输入的第二个时间应该大于第一个时间");
                        this.textBoxTime3.Focus();
                    }
                }
                this.TextBoxLeave(ref this.textTime1_3, ref this.textTime2_3, ref this.textTime3_3, ref this.textTime4_3, ref this.textTime5_3, this.textBoxTime3.Text);
            }
            catch
            {
            }
        }
        private void ClearTextAndTime()
        {
            try
            {
                this.text1_1 = "";
                this.text1_2 = "";
                this.textTime1_1 = "";
                this.textTime1_2 = "";
                this.textTime1_3 = "";
                this.text2_1 = "";
                this.text2_2 = "";
                this.textTime2_1 = "";
                this.textTime2_2 = "";
                this.textTime2_3 = "";
                this.text3_1 = "";
                this.text3_2 = "";
                this.textTime3_1 = "";
                this.textTime3_2 = "";
                this.textTime3_3 = "";
                this.text4_1 = "";
                this.text4_2 = "";
                this.textTime4_1 = "";
                this.textTime4_2 = "";
                this.textTime4_3 = "";
                this.text5_1 = "";
                this.text5_2 = "";
                this.textTime5_1 = "";
                this.textTime5_2 = "";
                this.textTime5_3 = "";
                this.radioButtonTime1.Checked = true;
            }
            catch
            {
            }
        }
        private void TextBoxEnabled(string str)
        {
            try
            {
                if (str == "发送")
                {
                    this.textBox1.Enabled = true;
                    this.textBox2.Enabled = true;
                    this.textBoxTime1.Enabled = true;
                    this.textBoxTime2.Enabled = true;
                    this.textBoxTime3.Enabled = true;
                    this.radioButtonTime1.Enabled = true;
                    this.radioButtonTime2.Enabled = true;
                }
                else
                {
                    this.textBox1.Enabled = false;
                    this.textBox2.Enabled = false;
                    this.textBoxTime1.Enabled = false;
                    this.textBoxTime2.Enabled = false;
                    this.textBoxTime3.Enabled = false;
                    this.radioButtonTime1.Enabled = false;
                    this.radioButtonTime2.Enabled = false;
                }
            }
            catch
            {
            }
        }
        private void TextBoxLeave(ref string text1, ref string text2, ref string text3, ref string text4, ref string text5, string textBox)
        {
            try
            {
                if (this.radioButton1.Checked)
                {
                    text1 = textBox;
                }
                else
                {
                    if (this.radioButton2.Checked)
                    {
                        text2 = textBox;
                    }
                    else
                    {
                        if (this.radioButton3.Checked)
                        {
                            text3 = textBox;
                        }
                        else
                        {
                            if (this.radioButton4.Checked)
                            {
                                text4 = textBox;
                            }
                            else
                            {
                                if (this.radioButton5.Checked)
                                {
                                    text5 = textBox;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void MethodSend(int j)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder(256);
                FormYYBroadast.GetWindowTextW(this.hwndYYBroadcast_list[j - 1], stringBuilder, stringBuilder.Capacity);
                if (stringBuilder.ToString() != this.nameYYBroadcast_list[j - 1])
                {
                    MessageBox.Show("您点击的频道广播窗口不存在，请检查广播窗口是否打开，然后点击【添加频道】");
                    switch (j)
                    {
                        case 1:
                            this.radioButton1.Text = "";
                            this.text1_1 = "";
                            this.text1_2 = "";
                            this.textTime1_1 = "";
                            this.textTime1_2 = "";
                            this.textTime1_3 = "";
                            this.isClickSend1 = "发送";
                            this.isClickRadioButtonTime1_1 = "select";
                            this.labelState1.Text = "";
                            this.textBox1.Text = "";
                            this.textBox2.Text = "";
                            this.textBoxTime1.Text = "";
                            this.textBoxTime2.Text = "";
                            this.textBoxTime3.Text = "";
                            this.buttonSend.Text = "发送";
                            this.timer1.Enabled = false;
                            this.radioButton1.Visible = false;
                            this.textBox1.Enabled = false;
                            this.textBox2.Enabled = false;
                            this.textBoxTime1.Enabled = false;
                            this.textBoxTime2.Enabled = false;
                            this.textBoxTime3.Enabled = false;
                            this.buttonSend.Enabled = false;
                            this.YinCangButton.Enabled = false;
                            this.radioButtonTime1.Enabled = false;
                            this.radioButtonTime2.Enabled = false;
                            this.nameYYBroadcast_list[0] = "";
                            break;
                        case 2:
                            this.radioButton2.Text = "";
                            this.text2_1 = "";
                            this.text2_2 = "";
                            this.textTime2_1 = "";
                            this.textTime2_2 = "";
                            this.textTime2_3 = "";
                            this.isClickSend2 = "发送";
                            this.isClickRadioButtonTime2_1 = "select";
                            this.labelState2.Text = "";
                            this.textBox1.Text = "";
                            this.textBox2.Text = "";
                            this.textBoxTime1.Text = "";
                            this.textBoxTime2.Text = "";
                            this.textBoxTime3.Text = "";
                            this.buttonSend.Text = "发送";
                            this.timer2.Enabled = false;
                            this.radioButton2.Visible = false;
                            this.textBox1.Enabled = false;
                            this.textBox2.Enabled = false;
                            this.textBoxTime1.Enabled = false;
                            this.textBoxTime2.Enabled = false;
                            this.textBoxTime3.Enabled = false;
                            this.buttonSend.Enabled = false;
                            this.YinCangButton.Enabled = false;
                            this.radioButtonTime1.Enabled = false;
                            this.radioButtonTime2.Enabled = false;
                            this.nameYYBroadcast_list[1] = "";
                            break;
                        case 3:
                            this.radioButton3.Text = "";
                            this.text3_1 = "";
                            this.text3_2 = "";
                            this.textTime3_1 = "";
                            this.textTime3_2 = "";
                            this.textTime3_3 = "";
                            this.isClickSend3 = "发送";
                            this.isClickRadioButtonTime3_1 = "select";
                            this.labelState3.Text = "";
                            this.textBox1.Text = "";
                            this.textBox2.Text = "";
                            this.textBoxTime1.Text = "";
                            this.textBoxTime2.Text = "";
                            this.textBoxTime3.Text = "";
                            this.buttonSend.Text = "发送";
                            this.timer3.Enabled = false;
                            this.radioButton3.Visible = false;
                            this.textBox1.Enabled = false;
                            this.textBox2.Enabled = false;
                            this.textBoxTime1.Enabled = false;
                            this.textBoxTime2.Enabled = false;
                            this.textBoxTime3.Enabled = false;
                            this.buttonSend.Enabled = false;
                            this.YinCangButton.Enabled = false;
                            this.radioButtonTime1.Enabled = false;
                            this.radioButtonTime2.Enabled = false;
                            this.nameYYBroadcast_list[2] = "";
                            break;
                        case 4:
                            this.radioButton4.Text = "";
                            this.text4_1 = "";
                            this.text4_2 = "";
                            this.textTime4_1 = "";
                            this.textTime4_2 = "";
                            this.textTime4_3 = "";
                            this.isClickSend4 = "发送";
                            this.isClickRadioButtonTime4_1 = "select";
                            this.labelState4.Text = "";
                            this.textBox1.Text = "";
                            this.textBox2.Text = "";
                            this.textBoxTime1.Text = "";
                            this.textBoxTime2.Text = "";
                            this.textBoxTime3.Text = "";
                            this.buttonSend.Text = "发送";
                            this.timer4.Enabled = false;
                            this.radioButton4.Visible = false;
                            this.textBox1.Enabled = false;
                            this.textBox2.Enabled = false;
                            this.textBoxTime1.Enabled = false;
                            this.textBoxTime2.Enabled = false;
                            this.textBoxTime3.Enabled = false;
                            this.buttonSend.Enabled = false;
                            this.YinCangButton.Enabled = false;
                            this.radioButtonTime1.Enabled = false;
                            this.radioButtonTime2.Enabled = false;
                            this.nameYYBroadcast_list[3] = "";
                            break;
                        case 5:
                            this.radioButton5.Text = "";
                            this.text5_1 = "";
                            this.text5_2 = "";
                            this.textTime5_1 = "";
                            this.textTime5_2 = "";
                            this.textTime5_3 = "";
                            this.isClickSend5 = "发送";
                            this.isClickRadioButtonTime5_1 = "select";
                            this.labelState5.Text = "";
                            this.textBox1.Text = "";
                            this.textBox2.Text = "";
                            this.textBoxTime1.Text = "";
                            this.textBoxTime2.Text = "";
                            this.textBoxTime3.Text = "";
                            this.buttonSend.Text = "发送";
                            this.timer5.Enabled = false;
                            this.radioButton5.Visible = false;
                            this.textBox1.Enabled = false;
                            this.textBox2.Enabled = false;
                            this.textBoxTime1.Enabled = false;
                            this.textBoxTime2.Enabled = false;
                            this.textBoxTime3.Enabled = false;
                            this.buttonSend.Enabled = false;
                            this.YinCangButton.Enabled = false;
                            this.radioButtonTime1.Enabled = false;
                            this.radioButtonTime2.Enabled = false;
                            this.nameYYBroadcast_list[4] = "";
                            break;
                    }
                }
                else
                {
                    if (this.textBox1.Text.Trim() == "" || this.textBox2.Text.Trim() == "")
                    {
                        MessageBox.Show("请输入广播的内容");
                        if (this.textBox1.Text.Trim() == "")
                        {
                            this.textBox1.Focus();
                        }
                        else
                        {
                            this.textBox2.Focus();
                        }
                    }
                    else
                    {
                        if (this.textBox1.Text.Trim() == this.textBox2.Text.Trim())
                        {
                            MessageBox.Show("两条广播内容不能相同");
                            this.textBox1.Focus();
                        }
                        else
                        {
                            if (this.radioButtonTime1.Checked)
                            {
                                if (this.textBoxTime1.Text.Trim() == "")
                                {
                                    MessageBox.Show("请输入时间");
                                    this.textBoxTime1.Focus();
                                    return;
                                }
                                switch (j)
                                {
                                    case 1:
                                        this.timer1.Interval = Convert.ToInt32(this.textBoxTime1.Text.Trim()) * 1000;
                                        this.timer1.Enabled = true;
                                        break;
                                    case 2:
                                        this.timer2.Interval = Convert.ToInt32(this.textBoxTime1.Text.Trim()) * 1000;
                                        this.timer2.Enabled = true;
                                        break;
                                    case 3:
                                        this.timer3.Interval = Convert.ToInt32(this.textBoxTime1.Text.Trim()) * 1000;
                                        this.timer3.Enabled = true;
                                        break;
                                    case 4:
                                        this.timer4.Interval = Convert.ToInt32(this.textBoxTime1.Text.Trim()) * 1000;
                                        this.timer4.Enabled = true;
                                        break;
                                    case 5:
                                        this.timer5.Interval = Convert.ToInt32(this.textBoxTime1.Text.Trim()) * 1000;
                                        this.timer5.Enabled = true;
                                        break;
                                }
                                this.textBox1.Enabled = false;
                                this.textBox2.Enabled = false;
                                this.textBoxTime1.Enabled = false;
                                this.textBoxTime2.Enabled = false;
                                this.textBoxTime3.Enabled = false;
                                this.radioButtonTime1.Enabled = false;
                                this.radioButtonTime2.Enabled = false;
                            }
                            else
                            {
                                if (this.textBoxTime2.Text.Trim() == "" || this.textBoxTime3.Text.Trim() == "")
                                {
                                    MessageBox.Show("请输入时间");
                                    if (this.textBoxTime2.Text.Trim() == "")
                                    {
                                        this.textBoxTime2.Focus();
                                    }
                                    else
                                    {
                                        this.textBoxTime3.Focus();
                                    }
                                    return;
                                }
                                if (Convert.ToInt32(this.textBoxTime2.Text.Trim()) >= Convert.ToInt32(this.textBoxTime3.Text.Trim()))
                                {
                                    MessageBox.Show("您输入的第二个时间应该大于第一个时间");
                                    this.textBoxTime3.Focus();
                                    return;
                                }
                                switch (j)
                                {
                                    case 1:
                                        this.RandomKey_1 = this.random_1.Next(Convert.ToInt32(this.textBoxTime2.Text.Trim()), Convert.ToInt32(this.textBoxTime3.Text.Trim()));
                                        this.timer1.Interval = this.RandomKey_1 * 1000;
                                        this.timer1.Enabled = true;
                                        break;
                                    case 2:
                                        this.RandomKey_2 = this.random_2.Next(Convert.ToInt32(this.textBoxTime2.Text.Trim()), Convert.ToInt32(this.textBoxTime3.Text.Trim()));
                                        this.timer2.Interval = this.RandomKey_2 * 1000;
                                        this.timer2.Enabled = true;
                                        break;
                                    case 3:
                                        this.RandomKey_3 = this.random_3.Next(Convert.ToInt32(this.textBoxTime2.Text.Trim()), Convert.ToInt32(this.textBoxTime3.Text.Trim()));
                                        this.timer3.Interval = this.RandomKey_3 * 1000;
                                        this.timer3.Enabled = true;
                                        break;
                                    case 4:
                                        this.RandomKey_4 = this.random_4.Next(Convert.ToInt32(this.textBoxTime2.Text.Trim()), Convert.ToInt32(this.textBoxTime3.Text.Trim()));
                                        this.timer4.Interval = this.RandomKey_4 * 1000;
                                        this.timer4.Enabled = true;
                                        break;
                                    case 5:
                                        this.RandomKey_5 = this.random_5.Next(Convert.ToInt32(this.textBoxTime2.Text.Trim()), Convert.ToInt32(this.textBoxTime3.Text.Trim()));
                                        this.timer5.Interval = this.RandomKey_5 * 1000;
                                        this.timer5.Enabled = true;
                                        break;
                                }
                                this.textBox1.Enabled = false;
                                this.textBox2.Enabled = false;
                                this.textBoxTime1.Enabled = false;
                                this.textBoxTime2.Enabled = false;
                                this.textBoxTime3.Enabled = false;
                                this.radioButtonTime1.Enabled = false;
                                this.radioButtonTime2.Enabled = false;
                            }
                            this.buttonSend.Text = "暂停";
                            switch (j)
                            {
                                case 1:
                                    this.isClickSend1 = "暂停";
                                    this.labelState1.Text = "发送中▪ ▪ ▪ ▪";
                                    break;
                                case 2:
                                    this.isClickSend2 = "暂停";
                                    this.labelState2.Text = "发送中▪ ▪ ▪ ▪";
                                    break;
                                case 3:
                                    this.isClickSend3 = "暂停";
                                    this.labelState3.Text = "发送中▪ ▪ ▪ ▪";
                                    break;
                                case 4:
                                    this.isClickSend4 = "暂停";
                                    this.labelState4.Text = "发送中▪ ▪ ▪ ▪";
                                    break;
                                case 5:
                                    this.isClickSend5 = "暂停";
                                    this.labelState5.Text = "发送中▪ ▪ ▪ ▪";
                                    break;
                            }
                            Method.ShowCursor(this.hwndYYBroadcast_list[j - 1]);
                            string text = "";
                            if (this.radioButton1.Checked)
                            {
                                if (GlobalVariable.NeiRongBianHao1 % 2 == 1)
                                {
                                    text = this.textBox1.Text;
                                }
                                else
                                {
                                    text = this.textBox2.Text;
                                }
                                GlobalVariable.NeiRongBianHao1++;
                            }
                            else
                            {
                                if (this.radioButton2.Checked)
                                {
                                    if (GlobalVariable.NeiRongBianHao2 % 2 == 1)
                                    {
                                        text = this.textBox1.Text;
                                    }
                                    else
                                    {
                                        text = this.textBox2.Text;
                                    }
                                    GlobalVariable.NeiRongBianHao2++;
                                }
                                else
                                {
                                    if (this.radioButton3.Checked)
                                    {
                                        if (GlobalVariable.NeiRongBianHao3 % 2 == 1)
                                        {
                                            text = this.textBox1.Text;
                                        }
                                        else
                                        {
                                            text = this.textBox2.Text;
                                        }
                                        GlobalVariable.NeiRongBianHao3++;
                                    }
                                    else
                                    {
                                        if (this.radioButton4.Checked)
                                        {
                                            if (GlobalVariable.NeiRongBianHao4 % 2 == 1)
                                            {
                                                text = this.textBox1.Text;
                                            }
                                            else
                                            {
                                                text = this.textBox2.Text;
                                            }
                                            GlobalVariable.NeiRongBianHao4++;
                                        }
                                        else
                                        {
                                            if (this.radioButton5.Checked)
                                            {
                                                if (GlobalVariable.NeiRongBianHao5 % 2 == 1)
                                                {
                                                    text = this.textBox1.Text;
                                                }
                                                else
                                                {
                                                    text = this.textBox2.Text;
                                                }
                                                GlobalVariable.NeiRongBianHao5++;
                                            }
                                        }
                                    }
                                }
                            }

                            Method.InputBroadcastContent(text + ".~", this.hwndYYBroadcast_list[j - 1]);//?
                            FormYYBroadast.SendMessage(this.hwndYYBroadcast_list[j - 1], 513, 0, this.send_x + (this.send_y << 16));
                            FormYYBroadast.SendMessage(this.hwndYYBroadcast_list[j - 1], 514, 0, this.send_x + (this.send_y << 16));
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void radioButtonTime1_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBoxTime1.Focus();
                SendKeys.Send("{end}");
                if (this.radioButton1.Checked)
                {
                    this.isClickRadioButtonTime1_1 = "select";
                    this.isClickRadioButtonTime1_2 = "noSelect";
                }
                else
                {
                    if (this.radioButton2.Checked)
                    {
                        this.isClickRadioButtonTime2_1 = "select";
                        this.isClickRadioButtonTime2_2 = "noSelect";
                    }
                    else
                    {
                        if (this.radioButton3.Checked)
                        {
                            this.isClickRadioButtonTime3_1 = "select";
                            this.isClickRadioButtonTime3_2 = "noSelect";
                        }
                        else
                        {
                            if (this.radioButton4.Checked)
                            {
                                this.isClickRadioButtonTime4_1 = "select";
                                this.isClickRadioButtonTime4_2 = "noSelect";
                            }
                            else
                            {
                                if (this.radioButton5.Checked)
                                {
                                    this.isClickRadioButtonTime5_1 = "select";
                                    this.isClickRadioButtonTime5_2 = "noSelect";
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void radioButtonTime2_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBoxTime2.Focus();
                SendKeys.Send("{end}");
                if (this.radioButton1.Checked)
                {
                    this.isClickRadioButtonTime1_1 = "noSelect";
                    this.isClickRadioButtonTime1_2 = "select";
                }
                else
                {
                    if (this.radioButton2.Checked)
                    {
                        this.isClickRadioButtonTime2_1 = "noSelect";
                        this.isClickRadioButtonTime2_2 = "select";
                    }
                    else
                    {
                        if (this.radioButton3.Checked)
                        {
                            this.isClickRadioButtonTime3_1 = "noSelect";
                            this.isClickRadioButtonTime3_2 = "select";
                        }
                        else
                        {
                            if (this.radioButton4.Checked)
                            {
                                this.isClickRadioButtonTime4_1 = "noSelect";
                                this.isClickRadioButtonTime4_2 = "select";
                            }
                            else
                            {
                                if (this.radioButton5.Checked)
                                {
                                    this.isClickRadioButtonTime5_1 = "noSelect";
                                    this.isClickRadioButtonTime5_2 = "select";
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void textBoxTime3_MouseLeave(object sender, EventArgs e)
        {
        }
        private void timer6_Tick(object sender, EventArgs e)
        {
            try
            {
                this.labelGongGao.Left -= 2;
                if (this.labelGongGao.Right < 0)
                {
                    this.labelGongGao.Left = base.Width;
                }
            }
            catch
            {
            }
        }
        private void FormYYBroadast_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void timer7_Tick(object sender, EventArgs e)
        {
            MessageBox.Show(this, "您使用的是免费版本", "免费版提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        //private void timer8_Tick(object sender, EventArgs e)
        //{
        //	try
        //	{
        //		string isLogin = this.YY.GetIsLogin(GlobalVariable.UserName);
        //		if (!(isLogin == GlobalVariable.SystemTime))
        //		{
        //			this.timer8.Enabled = false;
        //			this.timer9.Enabled = true;
        //			this.timer9.Interval = 30000;
        //			MessageBox.Show("您的账号在其他地方登陆，30秒后自动退出 ", "异地登陆提醒", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //		}
        //	}
        //	catch
        //	{
        //	}
        //}
        private void timer9_Tick(object sender, EventArgs e)
        {
            FormYYBroadast.SendMessage(base.Handle, 16, 0, 0);
        }
        private void buttonQQ_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://wpa.qq.com/msgrd?v=3&uin=651619988&site=qq&menu=yes");
            }
            catch
            {
            }
        }
        private void buttonAppend_Click(object sender, EventArgs e)
        {
        }
        private void buttonUpgrade_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("11111");
        }
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (GlobalVariable.HuoQuPinDao != 0)
            {
                if (MessageBox.Show("此操作将会使您正在发送的广播终止，广播内容被清空\n您确定要这样做请点击【确定】\n如果您想添加一个新的频道，又不希望影响正在发送的广播\n请点击【取消】，然后点击【添加频道】", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                {
                    return;
                }
            }
            try
            {
                this.buttonSend.Text = "发送";
                this.labelState1.Text = "";
                this.labelState2.Text = "";
                this.labelState3.Text = "";
                this.labelState4.Text = "";
                this.labelState5.Text = "";
                this.isClickRadioButtonTime1_1 = "select";
                this.isClickRadioButtonTime1_2 = "noSelect";
                this.isClickRadioButtonTime2_1 = "select";
                this.isClickRadioButtonTime2_2 = "noSelect";
                this.isClickRadioButtonTime3_1 = "select";
                this.isClickRadioButtonTime3_2 = "noSelect";
                this.isClickRadioButtonTime4_1 = "select";
                this.isClickRadioButtonTime4_2 = "noSelect";
                this.isClickRadioButtonTime5_1 = "select";
                this.isClickRadioButtonTime5_2 = "noSelect";
                this.timer1.Enabled = false;
                this.timer2.Enabled = false;
                this.timer3.Enabled = false;
                this.timer4.Enabled = false;
                this.timer5.Enabled = false;
                this.isClickSend1 = "发送";
                this.isClickSend2 = "发送";
                this.isClickSend3 = "发送";
                this.isClickSend4 = "发送";
                this.isClickSend5 = "发送";
                this.hwndYY_list.Clear();
                this.hwndYYBroadcast_list.Clear();
                this.nameYYBroadcast_list.Clear();
                this.nameYYBroadcastID_list.Clear();
                this.radioButton1.Visible = false;
                this.radioButton2.Visible = false;
                this.radioButton3.Visible = false;
                this.radioButton4.Visible = false;
                this.radioButton5.Visible = false;
                this.radioButton1.Checked = false;
                this.radioButton2.Checked = false;
                this.radioButton3.Checked = false;
                this.radioButton4.Checked = false;
                this.radioButton5.Checked = false;
                this.textBox1.Enabled = false;
                this.textBox2.Enabled = false;
                this.textBoxTime1.Enabled = false;
                this.textBoxTime2.Enabled = false;
                this.textBoxTime3.Enabled = false;
                this.radioButtonTime1.Enabled = false;
                this.radioButtonTime2.Enabled = false;
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBoxTime1.Text = "";
                this.textBoxTime2.Text = "";
                this.textBoxTime3.Text = "";
                this.buttonSend.Enabled = false;
                this.YinCangButton.Enabled = false;
                this.ClearTextAndTime();
                this.hwndYY_list = Method.GetWindowEX(this.hwndDesktop);
                List<IntPtr> list = new List<IntPtr>();
                for (int i = 0; i < this.hwndYY_list.Count - 1; i++)
                {
                    StringBuilder stringBuilder = new StringBuilder(256);
                    FormYYBroadast.GetWindowTextW(this.hwndYY_list[i], stringBuilder, stringBuilder.Capacity);
                    if (stringBuilder.Length != 0)
                    {
                        list.Add(this.hwndYY_list[i]);
                    }
                }
                for (int j = 0; j < list.Count - 1; j++)
                {
                    StringBuilder stringBuilder = new StringBuilder(256);
                    FormYYBroadast.GetWindowTextW(list[j], stringBuilder, stringBuilder.Capacity);
                    int num = stringBuilder.ToString().IndexOf("广播");
                    if (num == 0)
                    {
                        StringBuilder stringBuilder2 = new StringBuilder(256);
                        FormYYBroadast.GetWindowTextW(list[j + 1], stringBuilder2, stringBuilder2.Capacity);
                        int length = stringBuilder2.ToString().IndexOf("-");
                        string str = stringBuilder2.ToString().Substring(0, length);
                        string text = stringBuilder.ToString().Replace("广播-", "");
                        text = str + text;
                        this.YY_list.Add(list[j + 1]);
                        this.hwndYYBroadcast_list.Add(list[j]);
                        this.nameYYBroadcastID_list.Add(text);
                        this.nameYYBroadcast_list.Add(stringBuilder.ToString());
                    }
                }
                if (this.hwndYYBroadcast_list.Count > 0)
                {
                    GlobalVariable.HuoQuPinDao++;
                    this.textBox1.Enabled = true;
                    this.textBox2.Enabled = true;
                    this.textBoxTime1.Enabled = true;
                    this.textBoxTime2.Enabled = true;
                    this.textBoxTime3.Enabled = true;
                    this.radioButtonTime1.Enabled = true;
                    this.radioButtonTime2.Enabled = true;
                    this.buttonSend.Enabled = true;
                    this.YinCangButton.Enabled = true;
                    this.textBox1.Focus();
                    switch (this.hwndYYBroadcast_list.Count)
                    {
                        case 1:
                            this.radioButton1.Text = this.nameYYBroadcastID_list[0];
                            this.radioButton1.Visible = true;
                            this.radioButton1.Checked = true;
                            break;
                        case 2:
                            this.radioButton1.Text = this.nameYYBroadcastID_list[0];
                            this.radioButton2.Text = this.nameYYBroadcastID_list[1];
                            this.radioButton1.Visible = true;
                            this.radioButton2.Visible = true;
                            this.radioButton1.Checked = true;
                            break;
                        case 3:
                            this.radioButton1.Text = this.nameYYBroadcastID_list[0];
                            this.radioButton2.Text = this.nameYYBroadcastID_list[1];
                            this.radioButton3.Text = this.nameYYBroadcastID_list[2];
                            this.radioButton1.Visible = true;
                            this.radioButton2.Visible = true;
                            this.radioButton3.Visible = true;
                            this.radioButton1.Checked = true;
                            break;
                        case 4:
                            this.radioButton1.Text = this.nameYYBroadcastID_list[0];
                            this.radioButton2.Text = this.nameYYBroadcastID_list[1];
                            this.radioButton3.Text = this.nameYYBroadcastID_list[2];
                            this.radioButton4.Text = this.nameYYBroadcastID_list[3];
                            this.radioButton1.Visible = true;
                            this.radioButton2.Visible = true;
                            this.radioButton3.Visible = true;
                            this.radioButton4.Visible = true;
                            this.radioButton1.Checked = true;
                            break;
                        case 5:
                            this.radioButton1.Text = this.nameYYBroadcastID_list[0];
                            this.radioButton2.Text = this.nameYYBroadcastID_list[1];
                            this.radioButton3.Text = this.nameYYBroadcastID_list[2];
                            this.radioButton4.Text = this.nameYYBroadcastID_list[3];
                            this.radioButton5.Text = this.nameYYBroadcastID_list[4];
                            this.radioButton1.Visible = true;
                            this.radioButton2.Visible = true;
                            this.radioButton3.Visible = true;
                            this.radioButton4.Visible = true;
                            this.radioButton5.Visible = true;
                            this.radioButton1.Checked = true;
                            break;
                    }
                }
                else
                {
                    this.radioButton1.Visible = false;
                    this.radioButton2.Visible = false;
                    this.radioButton3.Visible = false;
                    this.radioButton4.Visible = false;
                    this.radioButton5.Visible = false;
                    MessageBox.Show("您没有打开任何广播窗口");
                }
            }
            catch
            {
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.radioButton1.Visible || this.radioButton2.Visible || this.radioButton3.Visible || this.radioButton4.Visible || this.radioButton5.Visible)
                {
                    List<IntPtr> windowEX = Method.GetWindowEX(this.hwndDesktop);
                    List<IntPtr> list = new List<IntPtr>();
                    List<IntPtr> list2 = new List<IntPtr>();
                    List<string> list3 = new List<string>();
                    List<string> list4 = new List<string>();
                    List<IntPtr> list5 = new List<IntPtr>();
                    for (int i = 0; i < windowEX.Count - 1; i++)
                    {
                        StringBuilder stringBuilder = new StringBuilder(256);
                        FormYYBroadast.GetWindowTextW(windowEX[i], stringBuilder, stringBuilder.Capacity);
                        if (stringBuilder.Length != 0)
                        {
                            list5.Add(windowEX[i]);
                        }
                    }
                    for (int j = 0; j < list5.Count - 1; j++)
                    {
                        StringBuilder stringBuilder = new StringBuilder(256);
                        FormYYBroadast.GetWindowTextW(list5[j], stringBuilder, stringBuilder.Capacity);
                        int num = stringBuilder.ToString().IndexOf("广播");
                        if (num == 0)
                        {
                            StringBuilder stringBuilder2 = new StringBuilder(256);
                            FormYYBroadast.GetWindowTextW(list5[j + 1], stringBuilder2, stringBuilder2.Capacity);
                            int length = stringBuilder2.ToString().IndexOf("-");
                            string str = stringBuilder2.ToString().Substring(0, length);
                            string text = stringBuilder.ToString().Replace("广播-", "");
                            text = str + text;
                            list.Add(list5[j + 1]);
                            list2.Add(list5[j]);
                            list3.Add(text);
                            list4.Add(stringBuilder.ToString());
                        }
                    }
                    string a = "丢失";
                    for (int k = 0; k < this.hwndYYBroadcast_list.Count; k++)
                    {
                        for (int l = 0; l < list2.Count; l++)
                        {
                            if (this.hwndYYBroadcast_list[k] == list2[l])
                            {
                                a = "没有丢失";
                                break;
                            }
                        }
                        if (a == "丢失")
                        {
                            switch (k + 1)
                            {
                                case 1:
                                    if (this.radioButton1.Visible)
                                    {
                                        this.radioButton1.Text = "";
                                        this.text1_1 = "";
                                        this.text1_2 = "";
                                        this.textTime1_1 = "";
                                        this.textTime1_2 = "";
                                        this.textTime1_3 = "";
                                        this.isClickSend1 = "发送";
                                        this.isClickRadioButtonTime1_1 = "select";
                                        this.labelState1.Text = "";
                                        this.textBox1.Text = "";
                                        this.textBox2.Text = "";
                                        this.textBoxTime1.Text = "";
                                        this.textBoxTime2.Text = "";
                                        this.textBoxTime3.Text = "";
                                        this.buttonSend.Text = "发送";
                                        this.timer1.Enabled = false;
                                        this.radioButton1.Visible = false;
                                        this.textBox1.Enabled = false;
                                        this.textBox2.Enabled = false;
                                        this.textBoxTime1.Enabled = false;
                                        this.textBoxTime2.Enabled = false;
                                        this.textBoxTime3.Enabled = false;
                                        this.buttonSend.Enabled = false;
                                        this.YinCangButton.Enabled = false;
                                        this.radioButtonTime1.Enabled = false;
                                        this.radioButtonTime2.Enabled = false;
                                        this.nameYYBroadcast_list[0] = "";
                                    }
                                    break;
                                case 2:
                                    if (this.radioButton2.Visible)
                                    {
                                        this.radioButton2.Text = "";
                                        this.text2_1 = "";
                                        this.text2_2 = "";
                                        this.textTime2_1 = "";
                                        this.textTime2_2 = "";
                                        this.textTime2_3 = "";
                                        this.isClickSend2 = "发送";
                                        this.isClickRadioButtonTime2_1 = "select";
                                        this.labelState2.Text = "";
                                        this.textBox1.Text = "";
                                        this.textBox2.Text = "";
                                        this.textBoxTime1.Text = "";
                                        this.textBoxTime2.Text = "";
                                        this.textBoxTime3.Text = "";
                                        this.buttonSend.Text = "发送";
                                        this.timer2.Enabled = false;
                                        this.radioButton2.Visible = false;
                                        this.textBox1.Enabled = false;
                                        this.textBox2.Enabled = false;
                                        this.textBoxTime1.Enabled = false;
                                        this.textBoxTime2.Enabled = false;
                                        this.textBoxTime3.Enabled = false;
                                        this.buttonSend.Enabled = false;
                                        this.YinCangButton.Enabled = false;
                                        this.radioButtonTime1.Enabled = false;
                                        this.radioButtonTime2.Enabled = false;
                                        this.nameYYBroadcast_list[1] = "";
                                    }
                                    break;
                                case 3:
                                    if (this.radioButton3.Visible)
                                    {
                                        this.radioButton3.Text = "";
                                        this.text3_1 = "";
                                        this.text3_2 = "";
                                        this.textTime3_1 = "";
                                        this.textTime3_2 = "";
                                        this.textTime3_3 = "";
                                        this.isClickSend3 = "发送";
                                        this.isClickRadioButtonTime3_1 = "select";
                                        this.labelState3.Text = "";
                                        this.textBox1.Text = "";
                                        this.textBox2.Text = "";
                                        this.textBoxTime1.Text = "";
                                        this.textBoxTime2.Text = "";
                                        this.textBoxTime3.Text = "";
                                        this.buttonSend.Text = "发送";
                                        this.timer3.Enabled = false;
                                        this.radioButton3.Visible = false;
                                        this.textBox1.Enabled = false;
                                        this.textBox2.Enabled = false;
                                        this.textBoxTime1.Enabled = false;
                                        this.textBoxTime2.Enabled = false;
                                        this.textBoxTime3.Enabled = false;
                                        this.buttonSend.Enabled = false;
                                        this.YinCangButton.Enabled = false;
                                        this.radioButtonTime1.Enabled = false;
                                        this.radioButtonTime2.Enabled = false;
                                        this.nameYYBroadcast_list[2] = "";
                                    }
                                    break;
                                case 4:
                                    if (this.radioButton4.Visible)
                                    {
                                        this.radioButton4.Text = "";
                                        this.text4_1 = "";
                                        this.text4_2 = "";
                                        this.textTime4_1 = "";
                                        this.textTime4_2 = "";
                                        this.textTime4_3 = "";
                                        this.isClickSend4 = "发送";
                                        this.isClickRadioButtonTime4_1 = "select";
                                        this.labelState4.Text = "";
                                        this.textBox1.Text = "";
                                        this.textBox2.Text = "";
                                        this.textBoxTime1.Text = "";
                                        this.textBoxTime2.Text = "";
                                        this.textBoxTime3.Text = "";
                                        this.buttonSend.Text = "发送";
                                        this.timer4.Enabled = false;
                                        this.radioButton4.Visible = false;
                                        this.textBox1.Enabled = false;
                                        this.textBox2.Enabled = false;
                                        this.textBoxTime1.Enabled = false;
                                        this.textBoxTime2.Enabled = false;
                                        this.textBoxTime3.Enabled = false;
                                        this.buttonSend.Enabled = false;
                                        this.YinCangButton.Enabled = false;
                                        this.radioButtonTime1.Enabled = false;
                                        this.radioButtonTime2.Enabled = false;
                                        this.nameYYBroadcast_list[3] = "";
                                    }
                                    break;
                                case 5:
                                    if (this.radioButton5.Visible)
                                    {
                                        this.radioButton5.Text = "";
                                        this.text5_1 = "";
                                        this.text5_2 = "";
                                        this.textTime5_1 = "";
                                        this.textTime5_2 = "";
                                        this.textTime5_3 = "";
                                        this.isClickSend5 = "发送";
                                        this.isClickRadioButtonTime5_1 = "select";
                                        this.labelState5.Text = "";
                                        this.textBox1.Text = "";
                                        this.textBox2.Text = "";
                                        this.textBoxTime1.Text = "";
                                        this.textBoxTime2.Text = "";
                                        this.textBoxTime3.Text = "";
                                        this.buttonSend.Text = "发送";
                                        this.timer5.Enabled = false;
                                        this.radioButton5.Visible = false;
                                        this.textBox1.Enabled = false;
                                        this.textBox2.Enabled = false;
                                        this.textBoxTime1.Enabled = false;
                                        this.textBoxTime2.Enabled = false;
                                        this.textBoxTime3.Enabled = false;
                                        this.buttonSend.Enabled = false;
                                        this.YinCangButton.Enabled = false;
                                        this.radioButtonTime1.Enabled = false;
                                        this.radioButtonTime2.Enabled = false;
                                        this.nameYYBroadcast_list[4] = "";
                                    }
                                    break;
                            }
                        }
                        a = "丢失";
                    }
                    string a2 = "新增";
                    for (int m = 0; m < list2.Count; m++)
                    {
                        for (int n = 0; n < this.hwndYYBroadcast_list.Count; n++)
                        {
                            if (list2[m] == this.hwndYYBroadcast_list[n])
                            {
                                a2 = "相同";
                                break;
                            }
                        }
                        if (a2 == "新增")
                        {
                            if (!this.radioButton1.Visible)
                            {
                                this.radioButton1.Text = list3[m];
                                this.radioButton1.Visible = true;
                                this.YY_list[0] = list[m];
                                this.hwndYYBroadcast_list[0] = list2[m];
                                this.nameYYBroadcast_list[0] = list4[m];
                                this.nameYYBroadcastID_list[0] = list3[m];
                            }
                            else
                            {
                                if (!this.radioButton2.Visible)
                                {
                                    this.radioButton2.Text = list3[m];
                                    this.radioButton2.Visible = true;
                                    if (this.hwndYYBroadcast_list.Count > 1)
                                    {
                                        this.YY_list[1] = list[m];
                                        this.hwndYYBroadcast_list[1] = list2[m];
                                        this.nameYYBroadcast_list[1] = list4[m];
                                        this.nameYYBroadcastID_list[1] = list3[m];
                                    }
                                    else
                                    {
                                        this.YY_list.Add(list[m]);
                                        this.hwndYYBroadcast_list.Add(list2[m]);
                                        this.nameYYBroadcast_list.Add(list4[m]);
                                        this.nameYYBroadcastID_list.Add(list3[m]);
                                    }
                                }
                                else
                                {
                                    if (!this.radioButton3.Visible)
                                    {
                                        this.radioButton3.Text = list3[m];
                                        this.radioButton3.Visible = true;
                                        if (this.hwndYYBroadcast_list.Count > 2)
                                        {
                                            this.YY_list[2] = list[m];
                                            this.hwndYYBroadcast_list[2] = list2[m];
                                            this.nameYYBroadcast_list[2] = list4[m];
                                            this.nameYYBroadcastID_list[2] = list3[m];
                                        }
                                        else
                                        {
                                            this.YY_list.Add(list[m]);
                                            this.hwndYYBroadcast_list.Add(list2[m]);
                                            this.nameYYBroadcast_list.Add(list4[m]);
                                            this.nameYYBroadcastID_list.Add(list3[m]);
                                        }
                                    }
                                    else
                                    {
                                        if (!this.radioButton4.Visible)
                                        {
                                            this.radioButton4.Text = list3[m];
                                            this.radioButton4.Visible = true;
                                            if (this.hwndYYBroadcast_list.Count > 3)
                                            {
                                                this.YY_list[3] = list[m];
                                                this.hwndYYBroadcast_list[3] = list2[m];
                                                this.nameYYBroadcast_list[3] = list4[m];
                                                this.nameYYBroadcastID_list[3] = list3[m];
                                            }
                                            else
                                            {
                                                this.YY_list.Add(list[m]);
                                                this.hwndYYBroadcast_list.Add(list2[m]);
                                                this.nameYYBroadcast_list.Add(list4[m]);
                                                this.nameYYBroadcastID_list.Add(list3[m]);
                                            }
                                        }
                                        else
                                        {
                                            if (!this.radioButton5.Visible)
                                            {
                                                this.radioButton5.Text = list3[m];
                                                this.radioButton5.Visible = true;
                                                if (this.hwndYYBroadcast_list.Count > 4)
                                                {
                                                    this.YY_list[4] = list[m];
                                                    this.hwndYYBroadcast_list[4] = list2[m];
                                                    this.nameYYBroadcast_list[4] = list4[m];
                                                    this.nameYYBroadcastID_list[4] = list3[m];
                                                }
                                                else
                                                {
                                                    this.YY_list.Add(list[m]);
                                                    this.hwndYYBroadcast_list.Add(list2[m]);
                                                    this.nameYYBroadcast_list.Add(list4[m]);
                                                    this.nameYYBroadcastID_list.Add(list3[m]);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        a2 = "新增";
                    }
                    if (this.radioButton1.Checked)
                    {
                        if (!this.radioButton1.Visible)
                        {
                            this.radioButtonTime1.Checked = true;
                            this.textBox1.Enabled = false;
                            this.textBox2.Enabled = false;
                            this.textBoxTime1.Enabled = false;
                            this.textBoxTime2.Enabled = false;
                            this.textBoxTime3.Enabled = false;
                            this.radioButtonTime1.Enabled = false;
                            this.radioButtonTime2.Enabled = false;
                            this.buttonSend.Enabled = false;
                            this.YinCangButton.Enabled = false;
                        }
                        else
                        {
                            this.buttonSend.Enabled = true;
                            this.YinCangButton.Enabled = true;
                            this.textBox1.Text = this.text1_1;
                            this.textBox2.Text = this.text1_2;
                            this.textBoxTime1.Text = this.textTime1_1;
                            this.textBoxTime2.Text = this.textTime1_2;
                            this.textBoxTime3.Text = this.textTime1_3;
                            if (this.isClickRadioButtonTime1_1 == "select")
                            {
                                this.radioButtonTime1.Checked = true;
                            }
                            else
                            {
                                this.radioButtonTime2.Checked = true;
                            }
                            this.buttonSend.Text = this.isClickSend1;
                            this.TextBoxEnabled(this.isClickSend1);
                            this.textBox1.Focus();
                            SendKeys.Send("{end}");
                        }
                    }
                    else
                    {
                        if (this.radioButton2.Checked)
                        {
                            if (!this.radioButton2.Visible)
                            {
                                this.radioButtonTime1.Checked = true;
                                this.textBox1.Enabled = false;
                                this.textBox2.Enabled = false;
                                this.textBoxTime1.Enabled = false;
                                this.textBoxTime2.Enabled = false;
                                this.textBoxTime3.Enabled = false;
                                this.radioButtonTime1.Enabled = false;
                                this.radioButtonTime2.Enabled = false;
                                this.buttonSend.Enabled = false;
                                this.YinCangButton.Enabled = false;
                            }
                            else
                            {
                                this.buttonSend.Enabled = true;
                                this.YinCangButton.Enabled = true;
                                this.textBox1.Text = this.text2_1;
                                this.textBox2.Text = this.text2_2;
                                this.textBoxTime1.Text = this.textTime2_1;
                                this.textBoxTime2.Text = this.textTime2_2;
                                this.textBoxTime3.Text = this.textTime2_3;
                                if (this.isClickRadioButtonTime2_1 == "select")
                                {
                                    this.radioButtonTime1.Checked = true;
                                }
                                else
                                {
                                    this.radioButtonTime2.Checked = true;
                                }
                                this.buttonSend.Text = this.isClickSend2;
                                this.TextBoxEnabled(this.isClickSend2);
                                this.textBox1.Focus();
                                SendKeys.Send("{end}");
                            }
                        }
                        else
                        {
                            if (this.radioButton3.Checked)
                            {
                                if (!this.radioButton3.Visible)
                                {
                                    this.radioButtonTime1.Checked = true;
                                    this.textBox1.Enabled = false;
                                    this.textBox2.Enabled = false;
                                    this.textBoxTime1.Enabled = false;
                                    this.textBoxTime2.Enabled = false;
                                    this.textBoxTime3.Enabled = false;
                                    this.radioButtonTime1.Enabled = false;
                                    this.radioButtonTime2.Enabled = false;
                                    this.buttonSend.Enabled = false;
                                    this.YinCangButton.Enabled = false;
                                }
                                else
                                {
                                    this.buttonSend.Enabled = true;
                                    this.YinCangButton.Enabled = true;
                                    this.textBox1.Text = this.text3_1;
                                    this.textBox2.Text = this.text3_2;
                                    this.textBoxTime1.Text = this.textTime3_1;
                                    this.textBoxTime2.Text = this.textTime3_2;
                                    this.textBoxTime3.Text = this.textTime3_3;
                                    if (this.isClickRadioButtonTime3_1 == "select")
                                    {
                                        this.radioButtonTime1.Checked = true;
                                    }
                                    else
                                    {
                                        this.radioButtonTime2.Checked = true;
                                    }
                                    this.buttonSend.Text = this.isClickSend3;
                                    this.TextBoxEnabled(this.isClickSend3);
                                    this.textBox1.Focus();
                                    SendKeys.Send("{end}");
                                }
                            }
                            else
                            {
                                if (this.radioButton4.Checked)
                                {
                                    if (!this.radioButton4.Visible)
                                    {
                                        this.radioButtonTime1.Checked = true;
                                        this.textBox1.Enabled = false;
                                        this.textBox2.Enabled = false;
                                        this.textBoxTime1.Enabled = false;
                                        this.textBoxTime2.Enabled = false;
                                        this.textBoxTime3.Enabled = false;
                                        this.radioButtonTime1.Enabled = false;
                                        this.radioButtonTime2.Enabled = false;
                                        this.buttonSend.Enabled = false;
                                        this.YinCangButton.Enabled = false;
                                    }
                                    else
                                    {
                                        this.buttonSend.Enabled = true;
                                        this.YinCangButton.Enabled = true;
                                        this.textBox1.Text = this.text4_1;
                                        this.textBox2.Text = this.text4_2;
                                        this.textBoxTime1.Text = this.textTime4_1;
                                        this.textBoxTime2.Text = this.textTime4_2;
                                        this.textBoxTime3.Text = this.textTime4_3;
                                        if (this.isClickRadioButtonTime4_1 == "select")
                                        {
                                            this.radioButtonTime1.Checked = true;
                                        }
                                        else
                                        {
                                            this.radioButtonTime2.Checked = true;
                                        }
                                        this.buttonSend.Text = this.isClickSend4;
                                        this.TextBoxEnabled(this.isClickSend4);
                                        this.textBox1.Focus();
                                        SendKeys.Send("{end}");
                                    }
                                }
                                else
                                {
                                    if (this.radioButton5.Checked)
                                    {
                                        if (!this.radioButton5.Visible)
                                        {
                                            this.radioButtonTime1.Checked = true;
                                            this.textBox1.Enabled = false;
                                            this.textBox2.Enabled = false;
                                            this.textBoxTime1.Enabled = false;
                                            this.textBoxTime2.Enabled = false;
                                            this.textBoxTime3.Enabled = false;
                                            this.radioButtonTime1.Enabled = false;
                                            this.radioButtonTime2.Enabled = false;
                                            this.buttonSend.Enabled = false;
                                            this.YinCangButton.Enabled = false;
                                        }
                                        else
                                        {
                                            this.buttonSend.Enabled = true;
                                            this.YinCangButton.Enabled = true;
                                            this.textBox1.Text = this.text5_1;
                                            this.textBox2.Text = this.text5_2;
                                            this.textBoxTime1.Text = this.textTime5_1;
                                            this.textBoxTime2.Text = this.textTime5_2;
                                            this.textBoxTime3.Text = this.textTime5_3;
                                            if (this.isClickRadioButtonTime5_1 == "select")
                                            {
                                                this.radioButtonTime1.Checked = true;
                                            }
                                            else
                                            {
                                                this.radioButtonTime2.Checked = true;
                                            }
                                            this.buttonSend.Text = this.isClickSend5;
                                            this.TextBoxEnabled(this.isClickSend5);
                                            this.textBox1.Focus();
                                            SendKeys.Send("{end}");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FormUpgrade formUpgrade = new FormUpgrade();
            formUpgrade.Show();
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            FormYYBroadast.ShowWindow(base.Handle, 6);
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            ShutDown shutDown = new ShutDown();
            shutDown.Show();
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int num;
                if (this.radioButton1.Checked)
                {
                    num = 1;
                }
                else
                {
                    if (this.radioButton2.Checked)
                    {
                        num = 2;
                    }
                    else
                    {
                        if (this.radioButton3.Checked)
                        {
                            num = 3;
                        }
                        else
                        {
                            if (this.radioButton4.Checked)
                            {
                                num = 4;
                            }
                            else
                            {
                                num = 5;
                            }
                        }
                    }
                }
                bool flag = FormYYBroadast.ShowWindow(this.YY_list[num - 1], 5);
                FormYYBroadast.ShowWindow(this.hwndYYBroadcast_list[num - 1], 5);
                if (flag)
                {
                    FormYYBroadast.ShowWindow(this.YY_list[num - 1], 0);
                    FormYYBroadast.ShowWindow(this.hwndYYBroadcast_list[num - 1], 0);
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
            this.components = new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FormYYBroadast));
            this.radioButton2 = new RadioButton();
            this.groupBox1 = new GroupBox();
            this.radioButton5 = new RadioButton();
            this.radioButton4 = new RadioButton();
            this.radioButton3 = new RadioButton();
            this.radioButton1 = new RadioButton();
            this.groupBox2 = new GroupBox();
            this.label2 = new Label();
            this.label1 = new Label();
            this.textBox2 = new TextBox();
            this.textBox1 = new TextBox();
            this.buttonSend = new Button();
            this.groupBox3 = new GroupBox();
            this.label3 = new Label();
            this.textBoxTime3 = new TextBox();
            this.textBoxTime2 = new TextBox();
            this.textBoxTime1 = new TextBox();
            this.radioButtonTime2 = new RadioButton();
            this.radioButtonTime1 = new RadioButton();
            this.groupBox4 = new GroupBox();
            this.labelState5 = new Label();
            this.labelState3 = new Label();
            this.labelState4 = new Label();
            this.labelState2 = new Label();
            this.labelState1 = new Label();
            this.timer1 = new Timer(this.components);
            this.timer2 = new Timer(this.components);
            this.timer3 = new Timer(this.components);
            this.timer4 = new Timer(this.components);
            this.timer5 = new Timer(this.components);
            this.labelGongGao = new Label();
            this.timer6 = new Timer(this.components);
            this.timer8 = new Timer(this.components);
            this.timer9 = new Timer(this.components);
            this.buttonQQ = new Button();
            this.toolStrip1 = new ToolStrip();
            this.toolStripButton1 = new ToolStripButton();
            this.toolStripButton2 = new ToolStripButton();
            this.toolStripLabel1 = new ToolStripLabel();
            this.toolStripButton3 = new ToolStripButton();
            this.toolStripButton6 = new ToolStripButton();
            this.YinCangButton = new Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            base.SuspendLayout();
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new Point(8, 52);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new Size(14, 13);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new EventHandler(this.radioButton2_CheckedChanged);
            this.radioButton2.Click += new EventHandler(this.radioButton2_Click);
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new Point(3, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(343, 141);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "频道信息";
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new Point(8, 118);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new Size(14, 13);
            this.radioButton5.TabIndex = 5;
            this.radioButton5.TabStop = true;
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.Click += new EventHandler(this.radioButton5_Click);
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new Point(8, 96);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new Size(14, 13);
            this.radioButton4.TabIndex = 4;
            this.radioButton4.TabStop = true;
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.Click += new EventHandler(this.radioButton4_Click);
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new Point(8, 74);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new Size(14, 13);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Click += new EventHandler(this.radioButton3_Click);
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new Point(8, 30);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new Size(14, 13);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new EventHandler(this.radioButton1_CheckedChanged_1);
            this.radioButton1.Click += new EventHandler(this.radioButton1_Click);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new Point(3, 199);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(479, 229);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "广播内容";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(210, 121);
            this.label2.Name = "label2";
            this.label2.Size = new Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "内容2";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(210, 17);
            this.label1.Name = "label1";
            this.label1.Size = new Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "内容1";
            this.textBox2.Location = new Point(6, 138);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Size(467, 81);
            this.textBox2.TabIndex = 1;
            this.textBox2.Leave += new EventHandler(this.textBox2_Leave);
            this.textBox1.Location = new Point(6, 35);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(467, 79);
            this.textBox1.TabIndex = 0;
            this.textBox1.Leave += new EventHandler(this.textBox1_Leave);
            this.buttonSend.Location = new Point(488, 237);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new Size(110, 35);
            this.buttonSend.TabIndex = 6;
            this.buttonSend.Text = "发送广播";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new EventHandler(this.buttonSend_Click);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBoxTime3);
            this.groupBox3.Controls.Add(this.textBoxTime2);
            this.groupBox3.Controls.Add(this.textBoxTime1);
            this.groupBox3.Controls.Add(this.radioButtonTime2);
            this.groupBox3.Controls.Add(this.radioButtonTime1);
            this.groupBox3.Location = new Point(453, 52);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(152, 141);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "时间（秒）";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(93, 88);
            this.label3.Name = "label3";
            this.label3.Size = new Size(17, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "--";
            this.textBoxTime3.Location = new Point(114, 83);
            this.textBoxTime3.Name = "textBoxTime3";
            this.textBoxTime3.Size = new Size(32, 21);
            this.textBoxTime3.TabIndex = 5;
            this.textBoxTime3.KeyPress += new KeyPressEventHandler(this.textBoxTime3_KeyPress);
            this.textBoxTime3.Leave += new EventHandler(this.textBoxTime3_Leave);
            this.textBoxTime3.MouseLeave += new EventHandler(this.textBoxTime3_MouseLeave);
            this.textBoxTime2.Location = new Point(58, 83);
            this.textBoxTime2.Name = "textBoxTime2";
            this.textBoxTime2.Size = new Size(32, 21);
            this.textBoxTime2.TabIndex = 4;
            this.textBoxTime2.KeyPress += new KeyPressEventHandler(this.textBoxTime2_KeyPress);
            this.textBoxTime2.Leave += new EventHandler(this.textBoxTime2_Leave);
            this.textBoxTime1.Location = new Point(58, 39);
            this.textBoxTime1.Name = "textBoxTime1";
            this.textBoxTime1.Size = new Size(87, 21);
            this.textBoxTime1.TabIndex = 3;
            this.textBoxTime1.KeyPress += new KeyPressEventHandler(this.textBoxTime1_KeyPress);
            this.textBoxTime1.Leave += new EventHandler(this.textBoxTime1_Leave);
            this.radioButtonTime2.AutoSize = true;
            this.radioButtonTime2.Location = new Point(6, 86);
            this.radioButtonTime2.Name = "radioButtonTime2";
            this.radioButtonTime2.Size = new Size(59, 16);
            this.radioButtonTime2.TabIndex = 2;
            this.radioButtonTime2.TabStop = true;
            this.radioButtonTime2.Text = "随机：";
            this.radioButtonTime2.UseVisualStyleBackColor = true;
            this.radioButtonTime2.Click += new EventHandler(this.radioButtonTime2_Click);
            this.radioButtonTime1.AutoSize = true;
            this.radioButtonTime1.Location = new Point(6, 40);
            this.radioButtonTime1.Name = "radioButtonTime1";
            this.radioButtonTime1.Size = new Size(59, 16);
            this.radioButtonTime1.TabIndex = 1;
            this.radioButtonTime1.TabStop = true;
            this.radioButtonTime1.Text = "固定：";
            this.radioButtonTime1.UseVisualStyleBackColor = true;
            this.radioButtonTime1.Click += new EventHandler(this.radioButtonTime1_Click);
            this.groupBox4.Controls.Add(this.labelState5);
            this.groupBox4.Controls.Add(this.labelState3);
            this.groupBox4.Controls.Add(this.labelState4);
            this.groupBox4.Controls.Add(this.labelState2);
            this.groupBox4.Controls.Add(this.labelState1);
            this.groupBox4.Location = new Point(352, 52);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(93, 140);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "状态";
            this.labelState5.AutoSize = true;
            this.labelState5.Location = new Point(11, 122);
            this.labelState5.Name = "labelState5";
            this.labelState5.Size = new Size(11, 12);
            this.labelState5.TabIndex = 4;
            this.labelState5.Text = "5";
            this.labelState3.AutoSize = true;
            this.labelState3.Location = new Point(11, 76);
            this.labelState3.Name = "labelState3";
            this.labelState3.Size = new Size(11, 12);
            this.labelState3.TabIndex = 3;
            this.labelState3.Text = "3";
            this.labelState4.AutoSize = true;
            this.labelState4.Location = new Point(11, 100);
            this.labelState4.Name = "labelState4";
            this.labelState4.Size = new Size(11, 12);
            this.labelState4.TabIndex = 2;
            this.labelState4.Text = "4";
            this.labelState2.AutoSize = true;
            this.labelState2.Location = new Point(11, 52);
            this.labelState2.Name = "labelState2";
            this.labelState2.Size = new Size(11, 12);
            this.labelState2.TabIndex = 1;
            this.labelState2.Text = "2";
            this.labelState1.AutoSize = true;
            this.labelState1.Location = new Point(10, 32);
            this.labelState1.Name = "labelState1";
            this.labelState1.Size = new Size(71, 12);
            this.labelState1.TabIndex = 0;
            this.labelState1.Text = "发送中▪ ▪ ▪ ▪";
            this.timer1.Interval = 5000;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.timer2.Tick += new EventHandler(this.timer2_Tick);
            this.timer3.Tick += new EventHandler(this.timer3_Tick);
            this.timer4.Tick += new EventHandler(this.timer4_Tick);
            this.timer5.Tick += new EventHandler(this.timer5_Tick);
            this.labelGongGao.AutoSize = true;
            this.labelGongGao.Font = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.labelGongGao.Location = new Point(9, 438);
            this.labelGongGao.Name = "labelGongGao";
            this.labelGongGao.Size = new Size(623, 14);
            this.labelGongGao.TabIndex = 9;
            this.labelGongGao.Text = "欢迎使用YY自动广播，您有任何意见或者建议，可以联系QQ客服，我们会尽可能改进，多谢您的支持";
            this.timer6.Enabled = true;
            this.timer6.Interval = 60;
            this.timer6.Tick += new EventHandler(this.timer6_Tick);
            this.timer8.Enabled = true;
            this.timer8.Interval = 6000;
            //this.timer8.Tick += new EventHandler(this.timer8_Tick);
            this.timer9.Interval = 5000;
            this.timer9.Tick += new EventHandler(this.timer9_Tick);
            this.buttonQQ.Image = (Image)componentResourceManager.GetObject("buttonQQ.Image");
            this.buttonQQ.Location = new Point(488, 371);
            this.buttonQQ.Name = "buttonQQ";
            this.buttonQQ.Size = new Size(110, 35);
            this.buttonQQ.TabIndex = 10;
            this.buttonQQ.UseVisualStyleBackColor = true;
            this.buttonQQ.Click += new EventHandler(this.buttonQQ_Click);
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = Color.FromArgb(192, 255, 192);
            this.toolStrip1.Items.AddRange(new ToolStripItem[]
            {
                this.toolStripButton1,
                this.toolStripButton2,
                this.toolStripLabel1,
                this.toolStripButton3,
                this.toolStripButton6
            });
            this.toolStrip1.Location = new Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new Size(610, 35);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new Font("微软雅黑", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.toolStripButton1.Image = (Image)componentResourceManager.GetObject("toolStripButton1.Image");
            this.toolStripButton1.ImageTransparentColor = Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new Size(70, 32);
            this.toolStripButton1.Text = "获取频道";
            this.toolStripButton1.Click += new EventHandler(this.toolStripButton1_Click_1);
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = (Image)componentResourceManager.GetObject("toolStripButton2.Image");
            this.toolStripButton2.ImageTransparentColor = Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new Size(70, 32);
            this.toolStripButton2.Text = "添加频道";
            this.toolStripButton2.Click += new EventHandler(this.toolStripButton2_Click);
            this.toolStripLabel1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new Size(120, 32);
            this.toolStripLabel1.Text = "                            ";
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = (Image)componentResourceManager.GetObject("toolStripButton3.Image");
            this.toolStripButton3.ImageTransparentColor = Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new Size(70, 32);
            this.toolStripButton3.Text = "升级VIP";
            this.toolStripButton3.Click += new EventHandler(this.toolStripButton3_Click);
            this.toolStripButton6.AutoSize = false;
            this.toolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Text;
            this.toolStripButton6.Image = (Image)componentResourceManager.GetObject("toolStripButton6.Image");
            this.toolStripButton6.ImageTransparentColor = Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new Size(70, 32);
            this.toolStripButton6.Text = "自动关机";
            this.toolStripButton6.Click += new EventHandler(this.toolStripButton6_Click);
            this.YinCangButton.Location = new Point(488, 305);
            this.YinCangButton.Name = "YinCangButton";
            this.YinCangButton.Size = new Size(110, 35);
            this.YinCangButton.TabIndex = 14;
            this.YinCangButton.Text = "隐藏(显示) YY";
            this.YinCangButton.UseVisualStyleBackColor = true;
            this.YinCangButton.Click += new EventHandler(this.button2_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BackColor = Color.FromArgb(192, 255, 192);
            base.ClientSize = new Size(610, 471);
            base.Controls.Add(this.YinCangButton);
            base.Controls.Add(this.toolStrip1);
            base.Controls.Add(this.buttonQQ);
            base.Controls.Add(this.labelGongGao);
            base.Controls.Add(this.groupBox4);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.buttonSend);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.MaximizeBox = false;
            base.Name = "FormYYBroadast";
            base.StartPosition = FormStartPosition.CenterScreen;
            //this.Text = "YY广播2.2";
            this.Text = "YY广播2.2(编码2取消延迟)";
            base.FormClosing += new FormClosingEventHandler(this.FormYYBroadast_FormClosing);
            base.Load += new EventHandler(this.FormYYBroadast_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}
