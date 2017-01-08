using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace MovieManage
{
    public partial class ADDmovieForms : Form
    {
        List<MovieType> mvvs;
        MovieType mos;
        public Movie movie { get; set; }
        public ADDmovieForms()
        {
            InitializeComponent();
        }

        public ADDmovieForms(List<MovieType> mvvs)
            :this()
        {
            
            this.comboBox1.DisplayMember = "name";
            this.comboBox1.ValueMember = "id";
            this.comboBox1.DataSource = mvvs;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                InvalidInputName();
                InvalidInputType();
                InvalidInputType2();
                InvalidInputCheck();
                movie = new Movie();
                movie.Name = textBox2.Text;
                movie.MovieTypeId = Convert.ToByte(comboBox1.SelectedValue);
                movie.Duration = Convert.ToByte(textBox1.Text);
                movie.MovieTypeName = comboBox1.Text;

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception)
            {
               
            }
        }

        private void InvalidInputType2()
        {
            if (this.comboBox1.SelectedValue.Equals(this.comboBox1.DataSource))
            {
                MessageBox.Show("添加电影类型只能选择以下类型", "警告！");
                this.comboBox1.Focus();
                throw new Exception("");
            }

        }

        private void InvalidInputType()
        {
            if (this.comboBox1.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("添加的电影类型不能为空", "警告！");
                this.comboBox1.Focus();
                throw new Exception("");
            }
         
        }
        private void InvalidInputName()
        {
            
            if (this.textBox2.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("添加电影名称不能为空", "警告！");
                this.textBox2.Focus();
                throw new Exception("");
            }
        }

        private void InvalidInputCheck()
        {
            byte b;
            if (!byte.TryParse(textBox1.Text, out b) || b <= 0 || b > 255)
            {
                MessageBox.Show("电影时长输入的值必须是1-255","警告！");
                this.textBox1.Focus();
                throw new Exception("");
            }
        }

        private void ADDmovieForms_Load(object sender, EventArgs e)
        {

        }
    
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
