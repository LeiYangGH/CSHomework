using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace CSFileManage
{
    class Program
    {
        static void Main(string[] args)
        {
            string d1 = Environment.CurrentDirectory;
            foreach (string d in GetD3Folders(d1))
                RenameJpgInFolder(d);
            Console.WriteLine("完成！");
            Console.ReadLine();
        }

        static void RenameJpgInFolder(string folder)
        {
            Console.WriteLine("--------------------{0}", folder);
            var oldFiles = Directory.GetFiles(folder, "*.jpg");
            int cnt = oldFiles.Length;
            string lastFolderName = Path.GetFileName(folder);

            for (int i = 0; i < cnt; i++)
            {
                string src = oldFiles[i];
                string des = Path.Combine(folder, lastFolderName + "_" + (i + 1).ToString() + ".jpg");
                File.Move(src, des);
                Console.WriteLine(Path.GetFileNameWithoutExtension(src));
            }
        }

        static IEnumerable<string> GetD3Folders(string d1)
        {
            return Directory.GetDirectories(d1)
                .SelectMany(x => Directory.GetDirectories(x));
        }
    }
}
