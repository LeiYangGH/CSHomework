using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
using WpfApp2.Model;
using WpfApp2.Presenter;
using System.Collections.Generic;
using System.Windows.Controls;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for CreateNewTutorial.xaml
    /// </summary>
    public partial class CreateNewTutorial : Window
    {
        public CreateViewPresenter Presenter { get; set; }

        public CreateNewTutorial()
        {
            InitializeComponent();

        }

        public void FillIdStringComboBoxes(List<IdNamePair> items, int comboBoxId)
        {
            ComboBox[] cbs = new ComboBox[] { comboBox, comboBox1 };
            ComboBox cbo = cbs[comboBoxId];
            cbo.Items.Clear();
            cbo.DisplayMemberPath = "Name";
            cbo.SelectedValuePath = "Id";
            cbo.ItemsSource = items;
        }

        public void FillIntComboBoxes()
        {
            ////set semester
            comboBox2.Items.Add("1");
            comboBox2.Items.Add("2");
            //set years
            comboBox3.Items.Add("2015");
            comboBox3.Items.Add("2016");
            comboBox3.Items.Add("2017");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Presenter.OnMainLoad();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //convert the value from combobox to sting, then parse it to integer for further use
            int teacherId = int.Parse(comboBox.SelectedValue.ToString());
            int subjectId = int.Parse(comboBox1.SelectedValue.ToString());
            int year = int.Parse(comboBox3.SelectedItem.ToString());
            int semester = int.Parse(comboBox2.SelectedItem.ToString());
            this.Presenter.OnOKClicked(teacherId, subjectId, year, semester);
        }
    }
}