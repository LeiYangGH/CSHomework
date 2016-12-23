using System;
using System.Collections.Generic;

namespace CSchenyi96225
{
    class Program5
    {
        static void Main(string[] args)
        {
            Console.Write("请输入n:");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n >= 12)
                Console.Write("输入的数太大，你不怕把电脑撑爆吗？！");
            else
                Console.WriteLine("1!+2!+3!+…+n! = {0}", FactSum(n));
            Console.ReadLine();
        }

        static long FactSum(int n)
        {
            List<long> fact = new List<long>();
            fact.Add(0);//占个下标
            fact.Add(1);
            long sum = 1;
            for (int i = 2; i <= n; i++)
            {
                long fi = i * fact[i - 1];
                fact.Add(fi);
                sum += fi;
            }
            return sum;
        }
    }


}
