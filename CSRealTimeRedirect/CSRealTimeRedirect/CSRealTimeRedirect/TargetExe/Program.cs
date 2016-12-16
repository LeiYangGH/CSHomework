using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TargetExe
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 10000; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }
    }
}
