using MVPDemo.Model;
using MVPDemo.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVPDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //model
            DemoModel model = new DemoModel();

            //view
            Demoview view = new Demoview();

            //presenter
            DemoPresenter presenter = new DemoPresenter(model, view);

            Application.Run(view);


           // Application.Run(new Demoview());
        }
    }
}
