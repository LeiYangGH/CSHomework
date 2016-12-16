using System.Windows;
using CSMVPAssignment.ViewModel;

namespace CSMVPAssignment.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = MainViewModel.Instance;
        }

        private void btnCnt_Click(object sender, RoutedEventArgs e)
        {
            int cnt = 0;
            MainViewModel.Instance.GetTutorialsCount(ref cnt);
            MessageBox.Show(cnt.ToString());
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow createWin = new SearchWindow();
            createWin.ShowDialog();
        }
    }

}

