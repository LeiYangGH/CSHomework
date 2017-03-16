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
        //static string curDir = @"C:\Users\yanglei2\Downloads\效果示例\H_SCANDATA（根目录）_效果前 - Copy\新PDF存放文件夹";
        static string curDir = Environment.CurrentDirectory;
        static string rangeGroupParentDir;

        static bool IsValidPdf(string fullName)
        {
            Regex reg = new Regex(@"H[0-9]{7}(?![0-9])");
            Console.WriteLine(fullName);
            bool b = reg.IsMatch(Path.GetFileNameWithoutExtension(fullName));
            Console.WriteLine(b);
            return b;
        }

        static List<PDFFile> GetAllPDFFiles()
        {
            var files = Directory.GetFiles(curDir, "*.pdf")
                 .Where(x => IsValidPdf(x))
                 .Select(x => new PDFFile(x));
            return files.ToList();
        }

        static void GroupMoveAllFiles()
        {
            var files = GetAllPDFFiles();
            foreach (var pdf in files)
                pdf.Move();
        }

        static string GetRangeGroupParentDir()
        {
            return Directory.GetParent(curDir).FullName;
        }

        static void Main(string[] args)
        {
            //int num = 256;
            //int d = num / 250;
            //int d1 = d * 250 + 1;
            //int d2 = d1 + 250;
            //Console.WriteLine(d1);
            //Console.WriteLine(d2 - 1);
            //Console.ReadLine();

            //return;
            Console.WriteLine("当前路径：{0}", curDir);
            rangeGroupParentDir = GetRangeGroupParentDir();
            PDFFile.curDir = curDir;
            PDFFile.rangeGroupParentDir = rangeGroupParentDir;


            Console.WriteLine("用法：把exe放在放新建pdf的文件夹里，运行，会在此文件夹内寻找符合格式的pdf，在上一层创建类似H3-00001_H3-00250/H300001的目录，动所属文件，并备份到pdf当前路径类似20170316的目录\n合法文件名判断依据：H开头，后面7位数字，如果后面还有则必须不能为数字\n，如果与已经分组的现有文件重名，则不移动\n如果与已备份文件重名，则先根据当前时间重命名再备份。\n任意键开始处理...");
            Console.ReadKey();

            GroupMoveAllFiles();

            Console.WriteLine("完成");

            Console.ReadLine();
        }
    }

    public class PDFFile
    {
        const int GroupRangeLength = 250;
        public string FullName;
        public string ShortName;
        public string ShortNameWithoutExt;
        public string GroupName;
        public string GroupRangeName;
        //public static int DupCount = 0;
        public static string curDir;
        public static string rangeGroupParentDir;
        //private static Random r = new Random();
        public PDFFile(string fullName)
        {
            this.FullName = fullName;

            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fullName);
            Regex reg = new Regex(@"(H[0-9]{6})[0-9]");
            string groupName = reg.Match(fileNameWithoutExtension).Groups[1].Value;
            //Console.WriteLine("groupName={0}", groupName);
            this.ShortName = Path.GetFileName(fullName);
            this.ShortNameWithoutExt = Path.GetFileNameWithoutExtension(fullName);
            this.GroupName = groupName;
            this.GroupRangeName = GetGroupRangeName(groupName);

        }
        private static string GetGroupRangeName(string groupName)
        {
            int num = Convert.ToInt32(groupName.Substring(2));
            int d = num / GroupRangeLength;
            int d1 = d * GroupRangeLength + 1;
            int d2 = d1 + GroupRangeLength;
            string groupRangeName = string.Format("H{0}-{1}_H{0}-{2}",
                groupName.Substring(1, 1),
                d1.ToString().PadLeft(5, '0'),
                d2.ToString().PadLeft(5, '0'));
            Console.WriteLine(groupRangeName);
            return groupRangeName;
        }

        private void Backup()
        {
            string backDir = Path.Combine(PDFFile.curDir, DateTime.Now.ToString("yyyyMMdd"));
            if (!Directory.Exists(backDir))
            {
                Directory.CreateDirectory(backDir);
                Console.WriteLine("创建备份文件夹---{0}---", this.GroupName);
            }
            string des = Path.Combine(backDir, this.ShortName);
            Console.WriteLine("备份文件{0}", this.ShortName);
            if (File.Exists(des))
            {
                Console.WriteLine("文件{0}已经存在，重命名...", this.ShortName);
                des = Path.Combine(backDir, this.ShortNameWithoutExt + "重命名" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf");
            }
            File.Copy(this.FullName, des, false);
        }

        public void Move()
        {
            string dir = Path.Combine(PDFFile.rangeGroupParentDir, this.GroupRangeName, this.GroupName);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                Console.WriteLine("创建文件夹---{0}---", this.GroupName);
            }
            string des = Path.Combine(dir, this.ShortName);
            Console.WriteLine("移动文件{0}", this.ShortName);
            this.Backup();
            if (File.Exists(des))
            {
                Console.WriteLine("文件{0}已经存在！", this.ShortName);
                File.Delete(this.FullName);
            }
            else
            {
                File.Move(this.FullName, des);
            }
        }

    }
}
