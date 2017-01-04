using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace WCComTransfer
{
    static class Program
    {
        static CWCComTransfer v = new CWCComTransfer();

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            v.OnStart();
        }
        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            v.OnStop();
            Console.WriteLine("程序退出。");
        }
    }
}
