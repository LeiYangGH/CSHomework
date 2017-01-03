using BLL;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieManage
{
    public partial class frmMain : Form
    {
        MovieBLL mb = new MovieBLL();
        MovieDAL ml=new MovieDAL();
        MovieTypeDAL mte = new MovieTypeDAL();
        List<Movie> mes;
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowLeiXi();
           
        }

        private void ShowLeiXi()
        {
            List<MovieType> mts =mte.GetLeixi();
            MovieType mt = new MovieType()
            {
                Name = "全部",
                Id = Convert.ToByte(0)
                
            };
            mts.Insert(0, mt);
            this.comboBox1.DisplayMember = "name";
            this.comboBox1.ValueMember = "id";
            this.comboBox1.DataSource = mts;
           
           
        }

   

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = string.Format("{0}-{1}", this.comboBox1.Text, this.comboBox1.SelectedValue);
            this.Text = text;

            byte depID = Convert.ToByte(this.comboBox1.SelectedValue);
             mes = ml.GetAllFromSqlSever(depID);
            movieBindingSource.DataSource = mes;
            this.dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog1.ShowDialog();
            if(result==DialogResult.Cancel)
            { return; }
            string filename = this.openFileDialog1.FileName;
            this.pictureBox1.BackgroundImage = Image.FromFile(filename);
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private byte[] Get2bytes(Image image)
        {
            MemoryStream ms = new MemoryStream();
            Bitmap bt = new Bitmap(image);
            bt.Save(ms, ImageFormat.Jpeg);
            byte[] bytes = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(bytes, 0, (int)ms.Length);
            ms.Close();
            return bytes;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Movie me = movieBindingSource.Current as Movie;
          
                byte[] img = Get2bytes(this.pictureBox1.BackgroundImage);
                string movieId = me.Id;
            try
            {
                ml.Update(movieId,img);
                MessageBox.Show("照片修改成功！"); 
                me.Poster = this.pictureBox1.BackgroundImage;
            }
            catch (Exception)
            {
                
                throw;
            }
            }

        private void movieBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Movie mo = movieBindingSource.Current as Movie;
            if (mo==null)
            {
                return;
            }
               
            this.pictureBox1.BackgroundImage = mo.Poster;
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex==-1)
            {
                return;
            }
            if(e.Button!=MouseButtons.Right)
            {
                return;
            }
            this.contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            this.dataGridView1.ClearSelection();
            this.dataGridView1.Rows[e.RowIndex].Selected = true;
            movieBindingSource.Position = e.RowIndex;
        }

        private void 删除电影ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Movie mo = movieBindingSource.Current as Movie;
            string name = string.Format("确定删除【{0}】吗？", mo.Name);
            DialogResult result = MessageBox.Show(name, "警告", MessageBoxButtons.YesNo);
            if(result ==DialogResult.No)
                return;
           
            try
            {
                ml.Delete(mo.Id);
                movieBindingSource.RemoveCurrent();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void 添加电影ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<MovieType> mes = this.comboBox1.DataSource as List<MovieType>;
            ADDmovieForms df = new ADDmovieForms(mes);
            DialogResult result = df.ShowDialog();
            if (result != DialogResult.OK)
                return;
            ml.Insert(df.movie);
            this.movieBindingSource.Add(df.movie);
            this.dataGridView1.Refresh();

        }

        private void 修改电影ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<MovieType> mvs = this.comboBox1.DataSource as List<MovieType>;
            Movie mv = this.movieBindingSource.Current as Movie;
            UPDATEmovieForms updates = new UPDATEmovieForms(mvs, mv);
       
            DialogResult result = updates.ShowDialog();
            if (result != DialogResult.OK)
                return;
            

            this.dataGridView1.Refresh();
        }

       

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte movieTypeId = Convert.ToByte(this.textBox1.Text);
         

            List<Movie> mos = ml.Search(movieTypeId);
            movieBindingSource.DataSource = mos;
        }

   

        private List<Movie> GettypeID(byte typeID)
        {
            throw new NotImplementedException();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

       
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string unclearName =Convert.ToString(this.textBox2.Text);
            List<Movie> mos = ml.Search(unclearName);
            movieBindingSource.DataSource = mos;
        }
    }
    }

