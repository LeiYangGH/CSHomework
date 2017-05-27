using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            CreateDocx(from, to);
            //CreateDocx(1, 3);
            Console.WriteLine("结束！");
            Console.ReadLine();
        }

        static void CreateDocx(int from, int to)
        {
            string fn = Path.Combine(Environment.CurrentDirectory, "test.docx");


            object oMissing = System.Reflection.Missing.Value;

            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();

            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);
            Word.Paragraph oPara1;
            //oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            //oPara1.Range.Text = $"2017年度部卫片";
            //oPara1.Range.Font.Bold = 1;
            //oPara1.Range.Font.Size = 36;
            //oPara1.Format.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            //oPara1.Range.InsertParagraphAfter();
            for (int i = from; i <= to; i++)
            {
                if (i > from)
                    oDoc.Words.Last.InsertBreak(Word.WdBreakType.wdPageBreak);

                oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara1.Range.Text = $"2017年度部卫片{i}号";
                oPara1.Range.Font.Bold = 1;
                oPara1.Range.Font.Size = 55;
                oPara1.Format.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                oPara1.Range.InsertParagraphAfter();
            }

            oDoc.SaveAs2(fn);
            oWord.Quit();
            Console.WriteLine(fn);
        }
    }
}
