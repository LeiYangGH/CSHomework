using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 车行租车系统
{
    public partial class Car : Form
    {
        public Car()
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
        private void JieYue_Load(object sender, EventArgs e)
        {

            string SQL = "select * from TB_LeiXing";
            DataSet ds = DBHelper.GetDate(SQL);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "LeiXing";
            comboBox1.ValueMember = "ID";

            if (mID != "")
            {

                DataTable dt = new DataTable();
                dt = DBHelper.GetDate("select * from TB_CheLiang where ID=" + mID).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        this.textBox1.Text = dt.Rows[0]["ChePai"].ToString();
                        this.textBox2.Text = dt.Rows[0]["PingPai"].ToString();
                    this.comboBox1.Text = dt.Rows[0]["LeiXing"].ToString();
                    this.textBox3.Text = dt.Rows[0]["ZuJIn"].ToString();
                    this.textBox4.Text = dt.Rows[0]["YaSe"].ToString();
                    this.textBox7.Text = dt.Rows[0]["Memo"].ToString();
                    this.textBox1.ReadOnly = true;
                    Img = dt.Rows[0]["PIC"].ToString();
                    Img = Application.StartupPath + Img;
                        this.pictureBox1.Image = System.Drawing.Image.FromFile(Img);  //将图片文件存入到PictureBox控件中
                    }
                    catch
                    {


                    }
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

                DBHelper.Exec("INSERT INTO TB_CheLiang (ChePai,PingPai,ZuJIn,LeiXing,YaSe,Memo,PIC)VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + this.comboBox1.Text + "','" + textBox4.Text + "','" + textBox7.Text + "','" + Img + "')");
            }
            else
            {

                //修改
                DBHelper.Exec("UPDATE TB_CheLiang set ChePai = '" + textBox1.Text + "',PingPai = '" + textBox2.Text + "',LeiXing ='" + this.comboBox1.Text + "',ZuJIn = '" + textBox3.Text + "',YaSe = '" + textBox4.Text + "',Memo = '" + textBox7.Text + "',PIC = '" + Img  + "' WHERE ID=" + mID);

            }
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = null;
        }
        #region  将图片转换成字节数组
        public static byte[] imgBytesIn;  //用来存储图片的二进制数
        public static int Ima_n = 0;  //判断是否对图片进行了操作
        public static string Img = "";
        public void Read_Image(OpenFileDialog openF, PictureBox MyImage)
        {
            openF.Filter = "*.jpg|*.jpg|*.bmp|*.bmp";   //指定OpenFileDialog控件打开的文件格式
            if (openF.ShowDialog(this) == DialogResult.OK)  //如果打开了图片文件
            {
                try
                {
                    MyImage.Image = System.Drawing.Image.FromFile(openF.FileName);  //将图片文件存入到PictureBox控件中

                    string PICFile = "\\Image\\" + DateTime.Now.ToFileTime() + ".jpg";
                    Img = Application.StartupPath + PICFile;
                    File.Copy(openFileDialog1.FileName, Img);
                    Img = PICFile;
                }
                catch
                {
                    MessageBox.Show("您选择的图片不能被读取或文件类型不对！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pictureBox1.Image = null;
                }
            }
        }
        #endregion
        private void button3_Click(object sender, EventArgs e)
        {
            Read_Image(openFileDialog1, pictureBox1);
        }
    }
}
