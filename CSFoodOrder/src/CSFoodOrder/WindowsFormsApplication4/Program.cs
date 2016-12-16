using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if LYDEV
            Application.Run(new zck());
#else
            Application.Run(new yhdl());
#endif
        }
    }
}
