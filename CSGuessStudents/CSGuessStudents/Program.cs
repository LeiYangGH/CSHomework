using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGuessStudents
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int x = 0; x <= 30; x++)
                for (int y = 0; y <= 40; y++)
                {
                    double z1 = (10 - x / 3.0d - y / 4.0d) * 5.0d;
                    double z2 = (100 - 2 * x - 3 * y) / (double)4;
                    if (z1 > 0 && z2 > 0 && z1 == z2 &&
                        Math.Round(z1) == z1 && Math.Round(z2) == z2)
                    {
                        Console.WriteLine("大、中、小班各有小朋友:{0}人、{1}人、{2}人",
                            x, y, z1);
                    }
                }
            Console.ReadLine();
        }
    }
}
