using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSTreeGrid.DAL;

namespace CSTreeGrid
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
            //注释这行是默认的
            //Application.Run(new frmMain());
            //下面这行是加的
            Application.Run(new frmMain(new MSSqlGoodsRepository()));
        }
    }
}
