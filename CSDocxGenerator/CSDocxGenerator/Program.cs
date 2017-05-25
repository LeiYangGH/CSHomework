using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
namespace CSDocxGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入生成的序号从多少数字开始：");
            int from = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入生成的序号从多少数字结束：");
            int to = Convert.ToInt32(Console.ReadLine());

            for (int i = from; i <= to; i++)
            {
                CreateDocx(i);

            }
            Console.WriteLine("结束！");
            Console.ReadLine();
        }

        static void CreateDocx(int n)
        {
            string fn = Path.Combine(Environment.CurrentDirectory, $"{n}.docx");


            object oMissing = System.Reflection.Missing.Value;
            //object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

            //Start Word and create a new document.
            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();
            //oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);

            //Insert a paragraph at the beginning of the document.
            Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara1.Range.Text = $"2017年度部卫片{n}号";
            oPara1.Range.Font.Bold = 1;
            oPara1.Range.Font.Size = 36;
            //oPara1.Format.SpaceAfter = 36;    //24 pt spacing after paragraph.
            oPara1.Format.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;    //24 pt spacing after paragraph.
            oPara1.Range.InsertParagraphAfter();


            oDoc.SaveAs2(fn);
            oWord.Quit();
            Console.WriteLine(fn);
        }
    }
}
