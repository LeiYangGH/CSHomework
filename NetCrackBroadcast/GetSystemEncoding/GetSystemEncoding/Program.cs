using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace GetSystemEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Encoding.Default.BodyName);
            Console.WriteLine(Console.OutputEncoding.CodePage);
            Console.WriteLine(Thread.CurrentThread.CurrentCulture);
            Console.WriteLine(Thread.CurrentThread.CurrentUICulture);
            CultureInfo ci = CultureInfo.InstalledUICulture;
            Console.WriteLine("Default Language Info:");
            Console.WriteLine("* Name: {0}", ci.Name);
            Console.WriteLine("* Display Name: {0}", ci.DisplayName);
            Console.WriteLine("* English Name: {0}", ci.EnglishName);
            Console.WriteLine("* 2-letter ISO Name: {0}", ci.TwoLetterISOLanguageName);
            Console.WriteLine("* 3-letter ISO Name: {0}", ci.ThreeLetterISOLanguageName);
            Console.WriteLine("* 3-letter Win32 API Name: {0}", ci.ThreeLetterWindowsLanguageName);
            Console.ReadLine();
        }

        static Encoding BestEncodingForCurrentSystem()
        {
            CultureInfo ci = CultureInfo.InstalledUICulture;
            string cultureEngName = ci.EnglishName;
            if (cultureEngName.Contains("Simplif"))
                return Encoding.Default;
            else if (cultureEngName.Contains("Traditional"))
                return Encoding.GetEncoding("Big5");
            return Encoding.UTF8;
        }
    }
}
