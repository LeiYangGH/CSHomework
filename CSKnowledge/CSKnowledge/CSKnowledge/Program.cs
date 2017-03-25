using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSKnowledge
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
            //#if DEBUG
            //            //Application.Run(new frmAdd());
            //            Application.Run(new frmView());
            //#else
            //            Application.Run(new frmMain());
            //#endif
            Application.Run(new frmMain());

        }
    }
}
