using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigJob
{
    public partial class userInfo : Form
    {
        public userInfo()
        {
            InitializeComponent();
        }
        database link = new database();

        private DataSet ds = new DataSet();
        private DataTable myTable;
        private DataRow myRow;   //数据库中的一行
        private string sql = "SELECT User_code,User_name,User_per_code from S_users";


        public void userInfo_Load(object sender, EventArgs e)
        {
            ds = link.SelectDataBase(sql, "users");

            bindingSource1.DataSource = ds.Tables[0];//为BindingSource组件设置数据源
            bindingSource1.Sort = "User_code";//设置BindingSource组件的排序列
            toolStripStatusLabel1.Text = "总记录条数：" + bindingSource1.Count;//获取总记录条数
            ShowInfo();//显示信息

            button1.Anchor = (AnchorStyles.Top);
            /*button2.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom) | (AnchorStyles.Left) | (AnchorStyles.Right);
            button3.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom) | (AnchorStyles.Left) | (AnchorStyles.Right);
            button9.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom) | (AnchorStyles.Left) | (AnchorStyles.Right);
            button5.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom) | (AnchorStyles.Left) | (AnchorStyles.Right);
            button6.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom) | (AnchorStyles.Left) | (AnchorStyles.Right);
            button7.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom) | (AnchorStyles.Left) | (AnchorStyles.Right);
            button8.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom) | (AnchorStyles.Left) | (AnchorStyles.Right);
            */

        }

        private void ShowInfo()
        {
            int index = bindingSource1.Position;//获取BindingSource数据源的当前索引
            DataRowView DRView = (DataRowView)bindingSource1[index];//获取BindingSource数据源的当前行
            toolStripStatusLabel3.Text = "当前记录是第" + (index + 1) + "条";//显示当前记录
            textBox1.Text = DRView[0].ToString();
            textBox2.Text = DRView[1].ToString();
            textBox3.Text = DRView[2].ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveFirst();//转到第一条记录
            ShowInfo();//显示信息
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bindingSource1.MovePrevious();//转到上一条记录
            ShowInfo();//显示信息
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveNext();//转到下一条记录
            ShowInfo();//显示信息
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveLast();//转到最后一条记录
            ShowInfo();//显示信息
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userInfoAdd uid = new userInfoAdd();
            uid.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定删除此记录吗?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    
                    string sql = string.Format("delete  from S_users where User_code='{0}'", textBox1.Text.Trim());
                    link.UpdateDataBase(sql);
                    MessageBox.Show("删除成功!");

                    foreach (Control ctrl in this.Controls)//或为groupBox1.Controls/panel1.Controls
                    {
                        if (ctrl is TextBox)
                            ctrl.Text = "";
                    }
                    userInfo_Load(this, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定修改此记录吗?", "操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    string sql = string.Format("update S_users set User_code='{0}',User_name='{1}',User_per_code='{2}'", textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim());
                    link.UpdateDataBase(sql);
                    MessageBox.Show("修改成功");
                    userInfo_Load(this, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //清除数据
            foreach (Control ctrl in this.Controls)//或为groupBox1.Controls/panel1.Controls
            {
                if (ctrl is TextBox)
                    ctrl.Text = "";
            }
            userInfoSearch uis = new userInfoSearch();
            uis.ShowDialog();
        }
    }
}
