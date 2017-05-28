using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAddLineNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input the file name:");
            string inFile = Console.ReadLine();
            string outFile = Path.Combine(Environment.CurrentDirectory, "print.txt");
            Console.WriteLine("the file name is :" + inFile);
            try
            {
                File.WriteAllLines(outFile,
                File.ReadAllLines(inFile, Encoding.Default)
                .Select((x, i) => i.ToString() + x));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("OK!, please check output file:" + outFile);
            Console.ReadLine();
        }
    }
}
