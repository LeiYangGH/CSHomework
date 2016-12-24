using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Dictionary<CheckBox, string> dicCheckBoxFileName;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fns = this.Controls.OfType<CheckBox>()
                .OrderBy(ch => ch.Name)
                .Where(ch => ch.Checked)
                .Select(ch => this.dicCheckBoxFileName[ch]);
            this.downTotalCnt = fns.Count();
            this.downDoneCnt = 0;
            this.progressBar.Value = 0;
            Task.Run(() => this.MergeFilesToTxt4(fns));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dicCheckBoxFileName = new Dictionary<CheckBox, string>()
            {
                {this.checkBox1,@"https://www.asp.net/ajax/cdn"},
                {this.checkBox2,@"https://jquery.com/download/"},
                {this.checkBox3,@"http://www.coreldraw.com/cn/"},
            };
        }

        private void UpdateReadProgress(ReadProgress rProgress)
        {
            this.progressBar.InvokeIfRequired(() =>
            {
                this.progressBar.Value = rProgress.ReadingPercent;
            });
        }

        private void MergeFilesToTxt4(IEnumerable<string> urls)
        {
            string fn4 = @"4.txt";
            File.Create(fn4).Dispose();
            foreach (string url in urls)
            {
                var task = this.GetWebContents(url,
                    new Progress<ReadProgress>(p => this.UpdateReadProgress(p)));
                var content = task.Result;
                File.AppendAllText(fn4, content);
            }
            MessageBox.Show("ok");
        }

        int downDoneCnt;
        int downTotalCnt;
        private async Task<string> GetWebContents(string url, IProgress<ReadProgress> progress)
        {
            WebClient cl = new WebClient();
            cl.Encoding = Encoding.UTF8;
            string s = await cl.DownloadStringTaskAsync(new Uri(url));
            if (progress != null)
            {
                var rprogress = new ReadProgress(++this.downDoneCnt, this.downTotalCnt);
                progress.Report(rprogress);
            }
            return s;

            //string content = cl.DownloadString(url);
            //return "\r\n\r\n\r\n\r\n\r\n符号只是为了方便测试时候确定内容是从某个网址下载的\r\n==============" + url + "=================\r\n\r\n\r\n\r\n" + content;
        }

        int timerCount;
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblTimer.Text = (++this.timerCount).ToString();
        }
        //button1
        //checkbox1 对应D:\1.txt 中的内容: 111
        //checkbox2 对应D:\2.txt 中的内容: 222
        //checkbox3 对应D:\3.txt 中的内容: 333

        //假设勾选了checkbox1和checkbox2
        //点击 button1 时就将checkbox1和checkbox2 的1.txt + 2.txt 中的内容保存到D:\4.txt文本内容大概为 111 222

        //假设勾选了checkbox1和checkbox3
        //点击 button1 时就将checkbox1和checkbox3的1.txt + 3.txt 中的内容保存到D:\4.txt文本内容大概为 111 333

        //假设勾选了checkbox2和checkbox3
        //点击 button1 时就将checkbox2和checkbox3的2.txt + 3.txt 中的内容保存到D:\4.txt文本内容大概为 222 333

    }

    public struct ReadProgress
    {
        public ReadProgress(int done, int total)
        {
            this.ReadingLinesCount = done;

            this.ReadingPercent = (int)(ReadingLinesCount / (double)total * 100d);
        }
        public int ReadingLinesCount;
        public int ReadingPercent;
    }

    public static class ExtensionClass
    {
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
