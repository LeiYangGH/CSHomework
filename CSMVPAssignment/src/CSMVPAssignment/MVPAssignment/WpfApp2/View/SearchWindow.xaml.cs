using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {

        public Presenter.MainViewPresenter Presenter { get; set; }
        public Presenter.CreateViewPresenter CntPresenter { get; set; }
        public Presenter.SearchViewPresenter svPresenter { get; set; }

        public SearchWindow()
        {
            InitializeComponent();

            //display and select value in combobox by using entity framework
            var s = (from a in Model.Collection.Teachers
                     select new { id = a._TeacherID, fn = a._FirstName, ln = a._LastName }).ToList();
            cb1.ItemsSource = s;
            cb1.DisplayMemberPath = "id";
            cb1.SelectedValuePath = "id";

        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //cast combobox value to integer and store it 
                int id = (int)this.cb1.SelectedValue;

                //past parameter and run it
                Task.Run(() => this.Search(id));
            }
            catch
            {
                //catch error
                MessageBox.Show("Please Select Values", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
        //use async to implement the method

        //Task Search(int id);

        private async Task Search(int id)
        {
            await Task.Run(() =>
            {
                //declare name as Fullname and pass id parameter
                string name = Model.Collection.Teachers.First(x => x._TeacherID == id).FullName;

                //show name
                MessageBox.Show(name, "This teacher ID will be",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            });
        }
    }
}

