using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 车行租车系统
{
    public partial class LeiXing : Form
    {
        public LeiXing()
        {
            InitializeComponent();
        }
        private string mID = "";
        public string ID
        {
            get
            {
                return mID;
            }
            set
            {
                mID = value;
            }
        }
        private void LeiXing_Load(object sender, EventArgs e)
        {
            if (mID != "")
            {

                DataTable dt = new DataTable();
                dt = DBHelper.GetDate("select * from TB_LeiXing where ID=" + mID ).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    this.textBox1.Text = dt.Rows[0]["LeiXing"].ToString();

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mID == "")
            {
                if (this.textBox1.Text == "")
                {
                    MessageBox.Show("车辆类型不能为空");
                    return;
                }
                if (DBHelper.GetDate("select * from TB_LeiXing where LeiXing='" + textBox1.Text + "'").Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("车辆类型重复");
                    return;
                }
                DBHelper.Exec("INSERT INTO TB_LeiXing (LeiXing  ) VALUES ('" + textBox1.Text + "')");
            }
            else
            {

                //修改
                DBHelper.Exec("UPDATE TB_LeiXing set LeiXing = '" + textBox1.Text + "' WHERE ID=" + mID);

            }
            this.Close();
        }
    }
}
