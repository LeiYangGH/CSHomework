using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Mulu : Form
    {
        public const string CAPTION = "操作提示";
        public Mulu()
        {
            InitializeComponent();
        }

        private void Mulu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvResult.Items.Count > 0)
            {
                lvResult.Items.Clear();
            }
            // 构建 SQL 语句
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("SELECT [ypbh],[ypmc],[cd],[pzwh],[bzq],[gg],[yfyl] FROM YPXX");                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
           

            // 查询并显示
           
            DBHelper dbHelper = new DBHelper();
            try
            {
                SqlCommand command = new SqlCommand(sql.ToString(), dbHelper.Connection);
                dbHelper.OpenConnection();
                SqlDataReader reader = command.ExecuteReader();

                if (!reader.HasRows)
                {
                    MessageBox.Show("没有要查找的记录！", CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    while (reader.Read())
                    {
                        // 获得查询到的数据
                        string A = reader["ypbh"].ToString(); 
                        string B = reader["ypmc"].ToString();
                        string C = reader["cd"].ToString();
                        string D = reader["pzwh"].ToString();
                        string E = reader["bzq"].ToString();
                        string F = reader["gg"].ToString();
                        string G = reader["yfyl"].ToString();
                        // 创建ListViewItem
                        ListViewItem item = new ListViewItem(A);

                        // 添加子项
                        item.SubItems.Add(B);
                        item.SubItems.Add(C);
                        item.SubItems.Add(D);
                        item.SubItems.Add(E);
                        item.SubItems.Add(F);
                        item.SubItems.Add(G);

                        // 将ListViewItem添加到ListView中
                        lvResult.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统出现错误！" + ex.Message, CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
