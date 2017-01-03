using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace WCComTransfer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new CWCComTransfer() 
			};
            //开启Windows服务，可以推测这个程序是以服务的形式存在，而不是带界面的程序
            ServiceBase.Run(ServicesToRun);
        }
    }
}
