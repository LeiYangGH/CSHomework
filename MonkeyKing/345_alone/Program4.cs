using System;

namespace MonkeyKing
{
    static class Program4
    {
        static void Main4()
        {
            //4.
            Console.WriteLine("请输入n，并以回车结束");
            int n = Convert.ToInt32(Console.ReadLine());
            int sum = CalcSum(n);
            Console.WriteLine("1-2+3-4+5-6+7……+n = " + sum.ToString());
            Console.ReadLine();
        }

        static int CalcSum(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 1)
                {
                    sum += i;
                }
                else
                {
                    sum -= i;
                }
            }
            return sum;
        }
    }
}