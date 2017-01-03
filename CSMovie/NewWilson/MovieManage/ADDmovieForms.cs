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
        private List<MovieType> mes;
        public Movie movie { get; set; }
        public ADDmovieForms()
        {
            InitializeComponent();
        }

        public ADDmovieForms(List<MovieType> mes)
            :this()
        {
            this.mes = mes;
            this.comboBox1.DisplayMember = "name";
            this.comboBox1.ValueMember = "id";
            MovieType mo = new MovieType()
            {
                Name = "全部"
            };
            mes.RemoveAt(0);
            this.comboBox1.DataSource = mes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            movie = new Movie();
            movie.Name = textBox2.Text;
            movie.MovieTypeId= Convert.ToByte(comboBox1.SelectedValue);
            movie.Duration = Convert.ToByte(textBox1.Text);
            movie.MovieTypeName = comboBox1.Text;
           
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ADDmovieForms_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '3' || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;

            }
          
                
                
        }
    }
}
