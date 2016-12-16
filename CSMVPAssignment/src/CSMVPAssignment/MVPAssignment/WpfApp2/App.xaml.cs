using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.Model;
using WpfApp2.Presenter;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnActivated(EventArgs e)
        {
            //model
            Collection collectionModel = new Collection();

            //view
            MainWindow mainView = Application.Current.MainWindow as MainWindow;

            //presenter
            MainViewPresenter presenter = new MainViewPresenter(mainView, collectionModel);
            base.OnActivated(e);
        }
    }
}
