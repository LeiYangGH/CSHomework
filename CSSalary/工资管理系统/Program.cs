using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 工资管理系统
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
            Application.Run (new frmLogin());
            //Application.Run(new first());//加不加效果一样？！

          
        }
    }
}
