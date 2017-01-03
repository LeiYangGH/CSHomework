using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Model;

namespace ShouPiao
{
    public partial class frmMain : Form
    {
        DbSqlHelper db = new DbSqlHelper();
        DataSet ds = null;
        Hashtable dta = new Hashtable();
        public frmMain()
        {
            InitializeComponent();
        }


        private void FrmCinema_Load(object sender, EventArgs e)
        {
            //加载treeview
            BingTreeView();
            dgvPosition.RowCount = 10;
            dgvPosition.ColumnCount = 10;
        }


        private void tvMovies_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        /// <summary>
        /// 获取放映列表绑定到TreeView
        /// </summary>
        private void BingTreeView()
        {
            this.tvMovies.Nodes.Clear();
            //加载数据库数据
            string sql = "select distinct a.id,a.name,b.beginTime from movie a,play b";
            ds = new DataSet();
            ds.Clear();
            ds = DbSqlHelper.Query(sql);
            DataTable dt = DbSqlHelper.Query(sql).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string id = dt.Rows[i]["id"].ToString();
                string name = dt.Rows[i]["name"].ToString();
                string ss = id + ":" + name;
                string beginTime = dt.Rows[i]["beginTime"].ToString();
                if (dta[ss] == null)
                {
                    dta.Add(ss, beginTime);
                }
                else
                {
                    dta[ss] = dta[ss] + "&" + beginTime;
                }
            }
            //绑定到TreeView
            TreeNode root = null;
            foreach (string item in dta.Keys)
            {
                string p = dta[item].ToString();
                string []tis=p.Split('&');
                if (root == null || root.Text != item.Split(':')[1])
                {
                    //根节点
                    root = new TreeNode(item.Split(':')[1]);
                    this.tvMovies.Nodes.Add(root);
                }
                //子节点
                for (int m = 0; m < tis.Length; m++)
                {
                    root.Nodes.Add(tis[m].Substring(0,tis[m].LastIndexOf(":")));
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tpCinema_Click(object sender, EventArgs e)
        {

        }
        private void FillDataGridView(List<Position> posList)
        {
            int rowMin = int.MaxValue, colMin = int.MaxValue;
            int rowMax = int.MinValue, colMax = int.MinValue;
            foreach (Position p in posList)
            {
                if (rowMin > p.RowNum) rowMin = p.RowNum;
                if (rowMax < p.RowNum) rowMax = p.RowNum;
                if (colMin > p.ColNum) colMin = p.ColNum;
                if (colMax < p.ColNum) colMax = p.ColNum;
            }
            int rows = rowMax - rowMin + 1;
            int cols = colMax - colMin + 1;

            dgvPosition.Rows.Clear();
            dgvPosition.ColumnCount = cols;
            dgvPosition.RowCount = rows;

            foreach (Position p in posList)
            {
                DataGridViewCell cell =
                    dgvPosition.Rows[p.RowNum - rowMin].Cells[p.ColNum - colMin];
                cell.Value = p;
                cell.ToolTipText = p.PositionTypeName;
            }
        }
    }
}


