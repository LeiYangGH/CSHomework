using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSchenyi96225
{
    class Program1
    {
        static void Main(string[] args)
        {
            int num = 1000;
            while (true)
            {
                if (IsPrime(num--))
                {
                    Console.WriteLine("1000以内的最大素数:{0}", num);
                    break;
                }
            }
            Console.ReadLine();
        }

        static bool IsPrime(int num)
        {
            if (num == 1) return false;
            if (num == 2) return true;
            int b = (int)Math.Floor(Math.Sqrt(num));
            for (int i = 2; i <= b; ++i)
                if (num % i == 0)
                    return false;
            return true;
        }
    }
}
