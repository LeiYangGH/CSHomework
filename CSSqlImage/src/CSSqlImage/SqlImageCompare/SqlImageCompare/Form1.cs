using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SqlImageCompare
{

    public partial class Form1 : Form
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private static byte[] GetPhoto(string filePath)
        {
            try
            {
                FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(stream);
                byte[] photo = reader.ReadBytes((int)stream.Length);
                reader.Close();
                stream.Close();
                return photo;
            }
            catch (Exception)
            {
                return new byte[] { };
            }

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string fn1 = this.txtImage1.Text;
            string fn2 = this.txtImage2.Text;

            this.Insert2Images(fn1, fn2);
        }

        private void Insert2Images(string imgFn1, string imgFn2)
        {
            try
            {
                byte[] photo1 = GetPhoto(imgFn1);
                byte[] photo2 = GetPhoto(imgFn2);

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(
                      @"Insert [ImageDb].[dbo].[T]([Image1], [Image2]) values (@img1, @img2)", connection);
                    command.Parameters.Add("@img1", SqlDbType.Image, photo1.Length).Value = photo1;
                    command.Parameters.Add("@img2", SqlDbType.Image, photo2.Length).Value = photo2;
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("插入了两个图片到[ImageDb].[dbo].[T]的新行。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowseImage1_Click(object sender, EventArgs e)
        {
            this.txtImage1.Text = this.BrowseImage();
        }

        private string BrowseImage()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "图片|*.jpg;*.png;*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.FileName;
            }
            else
                return "";
        }

        private void btnBrowseImage2_Click(object sender, EventArgs e)
        {
            this.txtImage2.Text = this.BrowseImage();
        }

        private void ExecuteAndShowSelectCount(string sql, string imgToCompareFileName)
        {
            try
            {
                byte[] photo = GetPhoto(imgToCompareFileName);

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.Add("@imgcompare", SqlDbType.Image, photo.Length).Value = photo;
                    connection.Open();
                    object o = command.ExecuteScalar();
                    MessageBox.Show(string.Format("{0}行符合。", o.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 转换一下sql，主要是image类型不能直接比较，要转换成varbinary(max)就可以直接比较，
        /// 这个我记得最开始就给你qq发过，只是你领悟力不够
        /// http://stackoverflow.com/questions/13119639/comparing-image-data-types-in-sql
        /// </summary>
        /// <param name="inputSql"></param>
        /// <returns></returns>
        private string ConvertSql(string inputSql)
        {
            //具体的转换方式很多，可以写死，也可以用正则表达式等方式灵活运用
            inputSql = inputSql.Replace("[Image1]", " cast([Image1] as varbinary(max)) ");
            inputSql = inputSql.Replace("[Image2]", " cast([Image2] as varbinary(max)) ");

            return string.Format(inputSql, " cast(@imgcompare as varbinary(max)) ");
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string inputSql = this.txtSql.Text;
            string imgFileName = this.txtImageToCompare.Text;
            string convertedSql = this.ConvertSql(inputSql);
            //MessageBox.Show(string.Format(inputSql, "'" + imgFileName + "'"));

            MessageBox.Show(convertedSql);//这才是真正运行的sql

            this.ExecuteAndShowSelectCount(convertedSql, imgFileName);
        }

        private void btnBrowseImageToCompare_Click(object sender, EventArgs e)
        {
            this.txtImageToCompare.Text = this.BrowseImage();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //测试方便用
            //this.txtImage1.Text = @"C:\test\Capture.PNG";
            //this.txtImage2.Text = @"C:\test\Capture.PNG";
            //this.txtImageToCompare.Text = @"C:\test\Capture.PNG";
        }
    }
}
