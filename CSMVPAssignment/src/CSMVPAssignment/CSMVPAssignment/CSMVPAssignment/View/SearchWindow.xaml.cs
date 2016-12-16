using CSMVPAssignment.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CSMVPAssignment.View
{

    public partial class SearchWindow : Window
    {
        public SearchWindow()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)this.cboTeachers.SelectedValue;
            Task.Run(() => this.Search(id));
        }

        private async Task Search(int id)
        {
            await Task.Run(() =>
            {
                string name = Repository.AllTeachers.First(x => x.TeacherID == id)
                .FullName;
                MessageBox.Show(name);
            });
        }
    }
}
