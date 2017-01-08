using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MovieManage
{

    public partial class UPDATEmovieForms : Form
    {
        public List<MovieType> mvvs;
        public Movie mv;
        
        MovieDAL ml = new MovieDAL();
        public UPDATEmovieForms()
        {
            InitializeComponent();
        }

        public UPDATEmovieForms(Movie mv,List<MovieType> mvvs)
            : this()
        {
            this.mv = mv;
           
            this.comboBox1.DisplayMember = "name";
            this.comboBox1.ValueMember = "id";
            this.comboBox1.DataSource = mvvs;
            textBox2.Text = mv.Name;
            comboBox1.SelectedValue = mv.MovieTypeId;
            textBox1.Text = Convert.ToString(mv.Duration);

        }
        private void UPDATEmovieForms_Load(object sender, EventArgs e)
        {

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
                InvalidInputCheck();
                mv.Name = textBox2.Text;
                mv.MovieTypeId = Convert.ToByte(comboBox1.SelectedValue);
                mv.Duration = Convert.ToByte(textBox1.Text);
                ml.Update(mv);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception)
            {

            }
        }

    

        private void InvalidInputType()
        {
            if (this.comboBox1.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("修改的电影类型不能为空", "警告！");
                this.comboBox1.Focus();
                throw new Exception("");
            }
        }

        private void InvalidInputName()
        {

            if (this.textBox2.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("修改的电影名称不能为空", "警告！");
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
                textBox1.Focus();
                throw new Exception("");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
