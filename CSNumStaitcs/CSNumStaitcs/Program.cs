using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CSNumStaitcs
{
    static class Program
    {
#if win
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
#else
        [STAThread]
        static void Main()
        {
            NumGenerator gen = new NumGenerator(new int[] { 6, 5, 4, 3, 7, 6 });
            object o = gen.Get34Seeds();
            Console.WriteLine(o);
            Console.WriteLine(gen.GetTxt4Lines());
            Console.ReadLine();
        }
#endif
    }
}
