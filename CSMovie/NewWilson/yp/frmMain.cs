using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private Dictionary<string, Form> FormCache { get; set; } = new Dictionary<string, Form>();
        private void frmMain_Load(object sender, EventArgs e)
        {
            ConnectionTest();
        }
        private void ConnectionTest()
        {
            SqlConnection conn;
            try
            {
                conn = new SqlConnection(SqlHelper.ConnString);
                conn.Open();
            }
            catch (Exception ex)
            {
                string errmsg = null;
                if (ex is InvalidOperationException)
                    errmsg = "配置文件失效" + ex.Message;
                else if (ex is SqlException)
                    errmsg = "连接错误" + ex.Message;
                else
                    errmsg = "配置文件不正确" + ex.Message;
                MessageBox.Show(errmsg);
                this.Close();
            }
        }
        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = sender as Form;
            FormCache.Remove(frm.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = sender as ToolStripButton;
            if (tsb == null) return;
            Form frm;
            if (FormCache.TryGetValue(tsb.Text, out frm) == false)
            {
                frm = new HallManager.frmMain();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Text = tsb.Text;
                frm.FormClosed += Frm_FormClosed;
                FormCache.Add(tsb.Text, frm);
                frm.Show();
            }
            else
            {
                frm.Activate();
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = sender as ToolStripButton;
            if (tsb == null) return;
            Form frm;
            if (FormCache.TryGetValue(tsb.Text, out frm) == false)
            {
                frm = new MovieManage.frmMain();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Text = tsb.Text;
                frm.FormClosed += Frm_FormClosed;
                FormCache.Add(tsb.Text, frm);
                frm.Show();
            }
            else
            {
                frm.Activate();
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = sender as ToolStripButton;
            if (tsb == null) return;
            Form frm;
            if (FormCache.TryGetValue(tsb.Text, out frm) == false)
            {
                frm = new PlayManager.frmMain();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Text = tsb.Text;
                frm.FormClosed += Frm_FormClosed;
                FormCache.Add(tsb.Text, frm);
                frm.Show();
            }
            else
            {
                frm.Activate();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = sender as ToolStripButton;
            if (tsb == null) return;
            Form frm;
            if (FormCache.TryGetValue(tsb.Text, out frm) == false)
            {
                frm = new DiscountManager.frmMain();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Text = tsb.Text;
                frm.FormClosed += Frm_FormClosed;
                FormCache.Add(tsb.Text, frm);
                frm.Show();
            }
            else
            {
                frm.Activate();
            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = sender as ToolStripButton;
            if (tsb == null) return;
            Form frm;
            if (FormCache.TryGetValue(tsb.Text, out frm) == false)
            {
                frm = new TicketManager.frmMain();
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Text = tsb.Text;
                frm.FormClosed += Frm_FormClosed;
                FormCache.Add(tsb.Text, frm);
                frm.Show();
            }
            else
            {
                frm.Activate();
            }
        }
    }
}
