using System.Linq;
using System.Windows;
using System.IO;
using System.Collections.Generic;
using WpfApp2.Model;
using WpfApp2.Presenter;
namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewPresenter Presenter { get; set; }
        public CreateViewPresenter CntPresenter { get; set; }
        public SearchViewPresenter svPresenter { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.OnCreateClicked();
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            int lineCount;
            lineCount = File.ReadAllLines(@"Tutorial.csv").Count();
            MessageBox.Show((lineCount - 1).ToString(), "The tutorial that you have.",
                         MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow SW = new SearchWindow();
            SW.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Presenter.OnMainLoad();
        }

        public void UpdateView(List<string> items)
        {
            this.listBox.Items.Clear();
            foreach (string item in items)
            {
                this.listBox.Items.Add(item);
            }
        }
    }
}








