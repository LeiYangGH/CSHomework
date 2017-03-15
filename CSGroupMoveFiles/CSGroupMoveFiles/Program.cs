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
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;

            Console.WriteLine("用法：把exe放在放pdf的文件夹里，运行，会在此文件夹的同一层次创建分组目录并复制所属文件。目前只支持文件名1～倒数第2位为分组标准。\n解决了第二次运行报错（原因是复制文件没设置覆盖选项）\n任意键开始处理...");
            Console.ReadKey();
            Regex reg = new Regex(@"H[0-9H_]+");
            string curDir = Environment.CurrentDirectory;
            var files = Directory.GetFiles(curDir, "*.pdf")
                .Where(x => reg.IsMatch(x))
                .Select(x => new
                {
                    full = x,
                    shortName = Path.GetFileName(x),
                    groupName = Path.GetFileNameWithoutExtension(x).Substring(0, Path.GetFileNameWithoutExtension(x).Length - 1)
                }
                );
            //foreach (var f in files)
            //    Console.WriteLine("{0}\t{1}\t{2}", f.full, f.shortName, f.groupName);
            string parentDir = Directory.GetParent(curDir).FullName;
            //Console.WriteLine(parentDir);
            foreach (var g in files.GroupBy(x => x.groupName))
            {
                string dir = Path.Combine(parentDir, g.Key);
                Directory.CreateDirectory(dir);
                Console.WriteLine("---{0}---", g.Key);
                foreach (var src in g.ToList())
                {
                    string des = Path.Combine(dir, src.shortName);
                    Console.WriteLine(src.shortName);
                    File.Copy(src.full, des, true);
                }
            }
            Console.WriteLine("处理结束!");
            Console.ReadLine();
        }
    }
}
