using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRead2DArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "chr12a.dat";
            var lines = File.ReadAllLines(fileName);
            int n = Convert.ToInt32(lines[0].Trim());
            int m = n + 1;
            Console.WriteLine($"n={n}");
            var ablines = lines.Skip(1).Where(x => x.Trim().Length > 5);
            var alines = ablines.Take(n).ToArray();
            var blines = ablines.Skip(n).ToArray();
            long[,] a = new long[m, m];
            long[,] b = new long[m, m];
            for (int ii = 1; ii <= n; ii++)
            {
                string[] ss = alines[ii - 1].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int jj = 1; jj <= n; jj++)
                {
                    a[ii, jj] = Convert.ToInt64(ss[jj - 1]);
                }
            }

            for (int ii = 1; ii <= n; ii++)
            {
                string[] ss = blines[ii - 1].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int jj = 1; jj <= n; jj++)
                {
                    b[ii, jj] = Convert.ToInt64(ss[jj - 1]);
                }
            }

            try
            {
                Console.WriteLine("数组读入结束！下面验证数组！");
                Console.WriteLine("请输入a[i,j]的i：");
                int i = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("请输入a[i,j]的j：");
                int j = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"a[{i},{j}]={a[i, j]}");

                Console.WriteLine("请输入b[i,j]的i：");
                i = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("请输入b[i,j]的j：");
                j = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"b[{i},{j}]={b[i, j]}");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
