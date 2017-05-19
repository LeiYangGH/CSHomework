using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSAutoLogin
{
    public partial class Form1 : Form
    {
        string urlLogin = @"http://121.41.52.245/wp-login.php?redirect_to=http%3A%2F%2F121.41.52.245%2Fwp-admin%2Fpost-new.php&reauth=1";
        int step = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate(urlLogin);
        }



        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.Text = (step++).ToString();
            if (step == 1)//login
            {
                HtmlElement usr = webBrowser1.Document.GetElementById("user_login");
                usr.SetAttribute("value", "abcd");
                HtmlElement pwd = webBrowser1.Document.GetElementById("user_pass");
                pwd.SetAttribute("value", "abc123456");
                HtmlElement login = webBrowser1.Document.GetElementById("wp-submit");
                login.InvokeMember("Click");
            }
            else if (step == 2)
            {
                //this.webBrowser1.Document.ExecCommand("Copy", false, null);
                //HtmlElement input = webBrowser1.Document.GetElementById("content_ifr");
                //input.Focus();

                SendKeys.Send("{TAB}");
                //this.webBrowser1.Focus();
                //this.webBrowser1.Document.ExecCommand("Paste", true, null);
                timer2.Start();

                //SendKeys.Send("{TAB}");
            }
            else if (step == 3)
            {
                //this.webBrowser1.Document.ExecCommand("Paste", false, null);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.webBrowser1.Document.ExecCommand("Paste", false, null);
            timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Stop();
        }
    }
}
