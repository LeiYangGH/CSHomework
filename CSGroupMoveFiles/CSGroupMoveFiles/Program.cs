using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSGroupMoveFiles
{
    class Program
    {
        const string groupDirsFileName = "groupnames.txt";
        static List<string> lstGroupDirs = new List<string>();
        static string curDir = @"C:\G\CSHomework\CSGroupMoveFiles\CSGroupMoveFiles\bin\Debug";// Environment.CurrentDirectory;

        static void LoadDirsList()
        {

        }

        static PDFFile ConvertToPdf(string fullName)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fullName);
            return new PDFFile(
                fullName,
                Path.GetFileName(fullName),
               fileNameWithoutExtension.Substring(0, fileNameWithoutExtension.Length - 1));
        }

        static void MoveOnePDF(PDFFile pdf)
        {
            string dir = Path.Combine(curDir, pdf.GroupName);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                Console.WriteLine("创建文件夹---{0}---", pdf.GroupName);
            }
            string des = Path.Combine(dir, pdf.ShortName);
            Console.WriteLine(pdf.ShortName);
            File.Move(pdf.FullName, des);
        }

        static List<PDFFile> GetAllPDFFiles()
        {
            Regex reg = new Regex(@"H[0-9H_]+");
            var files = Directory.GetFiles(curDir, "*.pdf")
                 .Where(x => reg.IsMatch(x))
                 .Select(x => ConvertToPdf(x));
            return files.ToList();
        }

        static void GroupAllFilesAtStart()
        {
            var files = GetAllPDFFiles();
            foreach (var pdf in files)
                MoveOnePDF(pdf);
        }

        static void Main(string[] args)
        {

            Console.WriteLine("用法：把exe放在放pdf的文件夹里，运行，会在此文件夹内创建分组目录并移动所属文件。目前只支持文件名1～倒数第2位为分组标准。\n然后启动监控，有pdf文件创建则进行处理。任意键开始处理...");
            Console.ReadKey();

            GroupAllFilesAtStart();


            Console.WriteLine("现有文件处理结束!下面开始监控新建pdf...");
            FileSystemWatcher fw = new FileSystemWatcher(curDir, "*.pdf");
            fw.Created += Fw_Created;
            fw.EnableRaisingEvents = true;
            Console.ReadLine();
        }

        private static void Fw_Created(object sender, FileSystemEventArgs e)
        {
            string fileName = e.FullPath;
            Console.WriteLine(fileName);
            MoveOnePDF(ConvertToPdf(fileName));
        }
    }

    public class PDFFile
    {
        public PDFFile(string fullName, string shortName, string groupName)
        {
            this.FullName = fullName;
            this.ShortName = shortName;
            this.GroupName = groupName;
        }
        public string FullName;
        public string ShortName;
        public string GroupName;
    }
}
