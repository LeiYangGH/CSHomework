using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplicationxxx
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private peifang2DataSet.peifang2DataTable peifang2DataTable;
        private System.Windows.Forms.BindingSource peifang2BindingSource;
        private peifang2DataSetTableAdapters.peifang2TableAdapter peifang2TableAdapter;

        public MainWindow()
        {
            InitializeComponent();
            this.peifang2DataTable = new peifang2DataSet.peifang2DataTable();
            this.peifang2BindingSource = new System.Windows.Forms.BindingSource();
            this.peifang2TableAdapter = new peifang2DataSetTableAdapters.peifang2TableAdapter();
            this.peifang2TableAdapter.Fill(this.peifang2DataTable);
            this.peifang2BindingSource.DataSource = this.peifang2DataTable;
            this.dg1.ItemsSource = this.peifang2BindingSource;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var r = this.peifang2DataTable.NewRow();


            this.peifang2DataTable.Rows.Add(r);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var v = this.peifang2BindingSource.Current as DataRowView;
            this.peifang2DataTable.Rows.OfType<peifang2DataSet.peifang2Row>()
                .First(x=>x.ID==Convert.ToInt32( v[0])).Delete();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.peifang2TableAdapter.Update(this.peifang2DataTable);
                MessageBox.Show("ok");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
