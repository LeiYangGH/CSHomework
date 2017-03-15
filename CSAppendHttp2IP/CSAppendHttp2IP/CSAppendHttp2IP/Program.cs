using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSAppendHttp2IP
{
    class Program
    {
        static void Main(string[] args)
        {
            if (DateTime.Now.Date > new DateTime(2017, 3, 10))
                return;
            string srcFile = @"resu.txt";
            //203.174.4.178    8888  Open
            Regex reg = new Regex(@"^(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})\s+(\d+)", RegexOptions.Compiled);
            using (StreamWriter sw = new StreamWriter("ip.txt"))
            {
                foreach (string line in File.ReadLines(srcFile))
                {
                    if (reg.IsMatch(line))
                    {
                        Match m = reg.Match(line);
                        //Console.WriteLine(line);
                        string s = "http://" + m.Groups[1].Value + ":" + m.Groups[2].Value;
                        Console.Write(".");
                        sw.WriteLine(s);
                    }
                }
            }
            Console.WriteLine("\n------------完成-----------------");
            Console.ReadLine();
        }
    }
}
