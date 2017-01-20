using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLargeLogAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            string fn = @"denglu.txt";
            Console.WriteLine("开始读文件...");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            string[] words;
            string id;
            string date;
            dic.Add("20170101", new List<string>());
            foreach (string line in File.ReadLines(fn))
            {
                //157455732,20170102,7,0
                words = line.Split(new char[] { ',' });
                id = words[0];
                date = words[1];
                if (!dic.ContainsKey(date))
                {
                    dic.Add(date, new List<string>());
                }
                dic[date].Add(id);
            }
            Console.WriteLine(dic.Keys.Count());
            Console.WriteLine("读文件完成");
            string[] dates = dic.Keys.ToArray();
            string[] ids = { };

            for (int i = 1; i <= 5; i++)
            {
                ids = ids.Union(dic[dates[i]]).ToArray();
            }
            for (int i = 6; i < dates.Length; i++)
            {
                Console.WriteLine("key=" + dates[i]);
                Console.WriteLine("Except" + dates[i - 6]);
                ids = ids.Except(dic[dates[i - 6]]).ToArray();
                Console.WriteLine("Union" + dates[i - 1]);
                ids = ids.Union(dic[dates[i - 1]]).ToArray();
                var firstlogins = dic[dates[i]].Except(ids).Distinct();
                Console.WriteLine("firstlogins" + dates[i]);
                Console.WriteLine(firstlogins.Count());
                File.WriteAllLines(dates[i] + ".txt", firstlogins);
            }
            sw.Stop();
            Console.WriteLine("完成！");
            Console.WriteLine(sw.ElapsedMilliseconds / 1000);
            Console.ReadLine();
        }
    }
}
//0   1 2 3 4 5. 6 7 8