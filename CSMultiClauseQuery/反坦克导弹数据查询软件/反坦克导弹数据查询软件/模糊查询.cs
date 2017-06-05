using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 反坦克导弹数据查询软件
{
    public partial class 模糊查询 : Form
    {
        OleDbConnection myconnection;
        OleDbDataAdapter myadapter;
        DataSet ds;
        DataTable mytable;
        DataRow myrow;
        int rownumber;
        public bool OpenDb()
        {
            string SQLstr = "";
            SQLstr = "select * from AKD";
            try
            {
                myconnection = new OleDbConnection("provider=" + "microsoft.Jet.OLEDB.4.0;Data Source=DD.mdb");
                myadapter = new OleDbDataAdapter(SQLstr, myconnection);
                ds = new DataSet();
                myadapter.Fill(ds, "AKD");
                mytable = ds.Tables[0];
                rownumber = 0;
                myrow = mytable.Rows[rownumber];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "错误", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        public 模糊查询()
        {
            InitializeComponent();
            OpenDb();
   
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.Show();
            this.Hide();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            增加 form = new 增加();
            form.Show();
            this.Hide();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            删除 form = new 删除();
            form.Show();
            this.Hide();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            数据展示 form = new 数据展示();
            form.Show();
            this.Hide();
        }

        private void BtSearch_Click(object sender, EventArgs e)
        {
            string searchSQLStr = "";
            OleDbDataAdapter searchcmd;
            DataSet searchds = new DataSet();
            DataTable searchtable;
            DataRow searchrow;
            switch(Cmbtype.SelectedIndex)
            {
                case -1:
                    {
                        MessageBox.Show("请先选择查询类型", "查询操作失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                case 0:
                    if (txtSearch.Text.Length == 0)
                    {
                        MessageBox.Show("请输入查询的条件", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string MHCX = "%" + txtSearch.Text + "%";
                    searchSQLStr = "select * from AKD where 导弹名称 like '" + MHCX + "' ";
                    break;
                case 1:
                    if (txtSearch.Text.Length == 0)
                    {
                        MessageBox.Show("请输入查询的条件", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string MHCXGJ = "%" + txtSearch.Text + "%";
                    searchSQLStr = "select * from AKD where 国家 like '" + MHCXGJ + "' ";
                    break;

            }
            searchcmd = new OleDbDataAdapter(searchSQLStr, "provider=microsoft.Jet.OLEDB.4.0;data source=DD.mdb");
            searchcmd.Fill(searchds, "AKD");
            searchtable = searchds.Tables[0];
            try
            {
                searchrow = searchtable.Rows[0];
              
            }
            catch
            {
                MessageBox.Show("没有找到该导弹的信息", "查询结果", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dataGridView1.DataSource = searchtable;
      
            
        }

        
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            DialogResult myresult;
            myresult = MessageBox.Show("是否退出程序", "退出提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(myresult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if(myresult == DialogResult.No)
            {
                return;
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            用户管理 form = new 用户管理();
            form.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                导弹名称.Text = dataGridView1.CurrentRow.Cells["导弹名称"].Value.ToString();
                国家.Text = dataGridView1.CurrentRow.Cells["国家"].Value.ToString();
                导弹弹长.Text = dataGridView1.CurrentRow.Cells["导弹弹长"].Value.ToString();
                导弹弹径.Text = dataGridView1.CurrentRow.Cells["导弹弹径"].Value.ToString();
                导弹翼展.Text = dataGridView1.CurrentRow.Cells["导弹翼展"].Value.ToString();
                导弹弹重.Text = dataGridView1.CurrentRow.Cells["导弹弹重"].Value.ToString();
                导弹最小射程.Text = dataGridView1.CurrentRow.Cells["导弹最小射程"].Value.ToString();
                导弹最大射程.Text = dataGridView1.CurrentRow.Cells["导弹最大射程"].Value.ToString();
                飞行速度.Text = dataGridView1.CurrentRow.Cells["飞行速度"].Value.ToString();
                破甲厚度.Text = dataGridView1.CurrentRow.Cells["破甲厚度"].Value.ToString();
                战斗部.Text = dataGridView1.CurrentRow.Cells["战斗部"].Value.ToString();
                制导方式.Text = dataGridView1.CurrentRow.Cells["制导方式"].Value.ToString();
                导引头.Text = dataGridView1.CurrentRow.Cells["导引头"].Value.ToString();
                动力装置.Text = dataGridView1.CurrentRow.Cells["动力装置"].Value.ToString();
                命中概率.Text = dataGridView1.CurrentRow.Cells["命中概率"].Value.ToString();
                发射载体.Text = dataGridView1.CurrentRow.Cells["发射载体"].Value.ToString();
                使用条件.Text = dataGridView1.CurrentRow.Cells["使用条件"].Value.ToString();
                生产厂家.Text = dataGridView1.CurrentRow.Cells["生产厂家"].Value.ToString();
                

            } 
        }

        private void 模糊查询_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            修改 form = new 修改();
            form.Show();
            this.Hide();
        }
        
    }
}
