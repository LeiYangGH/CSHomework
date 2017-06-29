using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;
using System.Data.SqlClient;
namespace ConsoleApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\peifang2.mdb"); //Jet OLEDB:Database Password=
            OleDbCommand cmd = conn.CreateCommand();

            cmd.CommandText = "select * from peifang2";
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            if (dr.HasRows)
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    dt.Columns.Add(dr.GetName(i));
                }
                dt.Rows.Clear();
            }
            while (dr.Read())
            {
                DataRow row = dt.NewRow();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    row[i] = dr[i];
                }
                dt.Rows.Add(row);
            }
            cmd.Dispose();
            // conn.Close();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //弹出确认消息框
            DialogResult result = MessageBox.Show("确定要将修改保存到数据库吗？",
                "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                /*       try

                       {

                           SqlConnection scon = new SqlConnection("数据库连接字");

                           scon.Open();

                           SqlCommand scmd;

                           for (int i = 0; i < dataGridView1.Rows.Count; i++)

                           {

                               string id = dataGridView1.Rows[i].Cells["id"].EditedFormattedValue.ToString();

                               string name = dataGridView1.Rows[i].Cells["name"].EditedFormattedValue.ToString();

                               string age = dataGridView1.Rows[i].Cells["age"].EditedFormattedValue.ToString();

                               string address = dataGridView1.Rows[i].Cells["address"].EditedFormattedValue.ToString();

                               string scmdStr = "update studentInfo set name='" + name + "',age='" + age + "',address='" + address + "' where id ='" + id + "'";

                               scmd = new SqlCommand(scmdStr, scon);

                               scmd.ExecuteNonQuery();

                           }

                           scon.Close();

                       }

                       catch (Exception ex)

                       {

                           MessageBox.Show(ex.ToString());

                       }
                       */





                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {


                    string 骨料 = dataGridView1.Rows[i].Cells["骨料"].Value.ToString();
                    string 粉料 = dataGridView1.Rows[i].Cells["粉料"].Value.ToString();
                    string guliao3 = dataGridView1.Rows[i].Cells["水"].Value.ToString();
                    //   string fenliao = dataGridView1.Rows[1].Cells[2].Value.ToString();
                    //    string shui = dataGridView1.Rows[1].Cells[3].Value.ToString();


                    string inst = "INSERT INTO peifang2 values('" + 骨料 + "','" + 粉料 + "','" + guliao3 + "')";

                    SqlCommand cmd = new SqlCommand();
                  //  cmd.Connection = conn;

                 //   OleDbCommand cmd = new OleDbCommand(inst, conn);

                    cmd.ExecuteNonQuery();

                    //     string scmdStr = "update studentInfo set 骨料='" + 骨料 + "',粉料='" + 粉料 + "'";
                    //     OleDbCommand cmd = new OleDbCommand(scmdStr, conn);
                    //         cmd.ExecuteNonQuery();

                    // cmd = new SqlCommand(scmdStr, scon);

                    // scmd.ExecuteNonQuery();


                }


            }
            //conn.Close();
            MessageBox.Show("保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
