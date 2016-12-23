using System;

namespace CSchenyi96225
{
    class Program2
    {
        static void Main2(string[] args)
        {
            int num = 1000;
            int need = 10;
            int cnt = 0;
            Console.WriteLine("1000以内的最大素数:");
            while (true)
            {
                if (IsPrime(num--))
                {
                    Console.WriteLine(num);
                    if (++cnt == need)
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
