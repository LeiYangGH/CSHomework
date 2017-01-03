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
using DAL;

namespace MovieManage
{

    public partial class UPDATEmovieForms : Form
    {
        private List<MovieType> mvs;
        public Movie mv;
      
        MovieDAL ml = new MovieDAL();
        public UPDATEmovieForms()
        {
            InitializeComponent();
        }

        public UPDATEmovieForms(List<MovieType> mvs,Movie mv)
            : this()
        {
            this.mvs = mvs;
            this.mv = mv;

            this.comboBox1.DisplayMember = "name";
            this.comboBox1.ValueMember = "id";
            MovieType mo = new MovieType()
            {
                Name = "全部"
            };
            mvs.RemoveAt(0);
            this.comboBox1.DataSource = mvs;
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
            mv.Name = textBox2.Text;
            mv.MovieTypeId =Convert.ToByte(comboBox1.SelectedValue);
            mv.Duration = Convert.ToByte(textBox1.Text);
            ml.Update(mv);
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;

                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
