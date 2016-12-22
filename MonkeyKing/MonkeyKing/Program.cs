using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonkeyKing
{
    static class Program
    {
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new frmPyramid());
        //}

        static void Main()
        {
            CalcFirstAndLastDay();
            Console.ReadLine();
        }

        static void CalcFirstAndLastDay()
        {
            Console.WriteLine("注：你可以通过修改电脑年份，运行后可以看到不同结果");
            DateTime now = DateTime.Now;
            int year = now.Year;
            DateTime firstDay = new DateTime(year, 1, 1).Date;
            DateTime lastDay = new DateTime(year, 12, 31).Date;
            Console.WriteLine("今年第一天" + firstDay.ToShortDateString());
            Console.WriteLine("今年最后一天" + lastDay.ToShortDateString());
        }

    }
}
