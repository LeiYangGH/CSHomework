using CalcLib;
using System;
namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorLib lib = new CalculatorLib();
            int sum = lib.Sum(2, 3);
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
