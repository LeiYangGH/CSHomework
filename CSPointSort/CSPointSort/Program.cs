using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPointSort
{
    class Program
    {
        const string a0FileName = "A0.txt";
        const string datFileName = "Elist.dat";

        static List<string> ReadListFromA0()
        {
            return File.ReadAllLines(a0FileName)
                .Select(x => x.Trim()).ToList();
        }

        static void Main(string[] args)
        {
            foreach (string line in ReadListFromA0())
            {
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }
    }
}
