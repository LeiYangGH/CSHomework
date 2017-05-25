using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDocxGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Open a doc file.
            string fn = Path.Combine(Environment.CurrentDirectory, "w.docx");
            Application application = new Application();
            Document document = application.Documents.Open(fn);

            // Loop through all words in the document.
            int count = document.Words.Count;
            for (int i = 1; i <= count; i++)
            {
                // Write the word.
                string text = document.Words[i].Text;
                Console.WriteLine("Word {0} = {1}", i, text);
            }
            // Close word.
            application.Quit();
            Console.ReadLine();
        }
    }
}
