using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CSGroupMoveFiles
{
    class Program
    {
        public const string RM = "_rm";
#if DEBUG
        public static string curDir = @"C:\G\CSHomework\CSGroupMoveFiles\CSGroupMoveFiles\bin\Debug\效果示例\H_SCANDATA（根目录）_效果前 - Copy\新PDF存放文件夹";
#else
        public static string curDir = Environment.CurrentDirectory;
#endif
        private static Regex regValidFile = new Regex(@"H[0-9]{7}(?![0-9])", RegexOptions.Compiled);

        public static string rangeGroupParentDir;

        static bool IsValidPdf(string fullName)
        {
            return regValidFile.IsMatch(Path.GetFileNameWithoutExtension(fullName));
        }

        static List<PDFFile> GetAllPDFFiles()
        {
            var allfiles = Directory.GetFiles(curDir, "*.pdf");

            var pdfFileNames = allfiles.Where(x => IsValidPdf(x));
            var badFileNames = allfiles.Except(pdfFileNames);
            if (badFileNames.Any())
            {
                Console.WriteLine("下列文件名不合法：");
                Console.WriteLine("--------------------");
                foreach (string badFile in badFileNames)
                {
                    Console.WriteLine(Path.GetFileName(badFile));
                }
                Console.WriteLine("--------------------");
            }
            return pdfFileNames.Select(x => new PDFFile(x)).ToList();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("当前路径：{0}", curDir);
            Program.rangeGroupParentDir = Directory.GetParent(curDir).FullName;
#if DEBUG

#else
            Console.WriteLine("用法：把exe放在放新建pdf的文件夹里，运行，会在此文件夹内寻找符合格式的pdf，在上一层创建类似H3-00001_H3-00250/H300001的目录，并移动所属文件，并备份到pdf当前路径类似20170316的目录\n合法文件名判断依据：H开头，后面7位数字，如果后面还有则必须不能为数字\n，如果与已经分组的现有文件重名(前8位相同)，且不以_rm结尾则不移动\n如果目标范围文件夹不存在则不移动\n如果与已备份文件完全重名，则不移动\n任意键开始处理...");
            Console.ReadKey();
#endif
            Task.Run(() =>
            {
                var files = GetAllPDFFiles();
                foreach (var pdf in files
                    .OrderBy(x => x.GroupRangeName)
                    .ThenBy(x => x.GroupName))
                {
                    pdf.Process();
                    Thread.Sleep(1000);
                }

                Console.WriteLine("完成");
            });

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
        private static Regex regGroupName = new Regex(@"(H[0-9]{6})[0-9]", RegexOptions.Compiled);
        public PDFFile(string fullName)
        {
            this.FullName = fullName;

            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fullName);

            string groupName = regGroupName.Match(fileNameWithoutExtension).Groups[1].Value;
            //Console.WriteLine("groupName={0}", groupName);
            this.ShortName = Path.GetFileName(fullName);
            this.ShortNameWithoutExt = Path.GetFileNameWithoutExtension(fullName);
            this.GroupName = groupName;
            this.GroupRangeName = GetGroupRangeName(groupName);

        }
        private static string GetGroupRangeName(string groupName)
        {
            int num = Convert.ToInt32(groupName.Substring(2));
            if (num % 250 == 0)
                num -= 1;
            int d = num / GroupRangeLength;
            int d1 = d * GroupRangeLength + 1;
            int d2 = d1 + GroupRangeLength - 1;
            string groupRangeName = string.Format("H{0}-{1}_H{0}-{2}",
                groupName.Substring(1, 1),
                d1.ToString().PadLeft(5, '0'),
                d2.ToString().PadLeft(5, '0'));
            //Console.WriteLine(groupRangeName);
            return groupRangeName;
        }

        private void Backup()
        {
            string backDir = Path.Combine(Program.curDir, DateTime.Now.ToString("yyyyMMdd"));
            if (!Directory.Exists(backDir))
            {
                Directory.CreateDirectory(backDir);
                Console.WriteLine("创建备份文件夹---{0}---", this.GroupName);
            }
            string des = Path.Combine(backDir, this.ShortName);
            Console.WriteLine("备份文件{0}", this.ShortName);
            if (File.Exists(des))
            {
                Console.WriteLine("文件{0}已经存在，备份失败", this.ShortName);
            }
            else
            {
                try
                {
                    File.Copy(this.FullName, des, false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private bool ExistGrouped8FileName(string dir)
        {
            string group8Name = this.ShortNameWithoutExt.Substring(0, 8);
            return (Directory.GetFiles(dir, "*.pdf").Select(x => Path.GetFileNameWithoutExtension(x))
                .Any(x => x.StartsWith(group8Name) && !x.EndsWith(Program.RM)));
        }

        public void Process()
        {
            string rangeDir = Path.Combine(Program.rangeGroupParentDir, this.GroupRangeName);
            if (!Directory.Exists(rangeDir))
            {
                Console.WriteLine("文件无法移动，因为二级范围文件夹不存在:\n{0}\n{1}\n", this.ShortNameWithoutExt, this.GroupRangeName);
                return;
            }

            string desDir = Path.Combine(rangeDir, this.GroupName);
            if (!Directory.Exists(desDir))
            {
                Console.WriteLine("创建三级分组文件夹---{0}---", this.GroupName);
                Directory.CreateDirectory(desDir);
            }
            string desFullName = Path.Combine(desDir, this.ShortName);



            if (!this.ShortNameWithoutExt.EndsWith(Program.RM) && ExistGrouped8FileName(desDir))
            {
                Console.WriteLine("目标文件夹内已存在相同前8位文件名的文件，未移动，重命名:\n{0}\n{1}\n", this.ShortName, this.GroupName);
                string renameFullName = Path.Combine(Program.curDir, this.ShortNameWithoutExt + "_重命名" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf");
                if (File.Exists(renameFullName))
                {
                    Console.WriteLine("文件已存在{0}，所以重命名取消", renameFullName);
                }
                else
                {
                    try
                    {
                        File.Move(this.FullName, renameFullName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                return;
            }
            Console.WriteLine("备份并移动文件{0}...", this.ShortName);
            this.Backup();
            try
            {
                File.Move(this.FullName, desFullName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
