using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace CSRealTimeRedirect
{
    class Program
    {
        static void Main(string[] args)
        {
            string exedebug = @"..\..\..\TargetExe\bin\Debug\TargetExe.exe";
            string execur = Path.Combine(Environment.CurrentDirectory, "TargetExe.exe");
            string exe = File.Exists(execur) ? execur : exedebug;
            if (File.Exists(exe))
            {
                Console.WriteLine("准备调用exe");
                CallTarget(exe);
            }
            else
                Console.WriteLine("没有找到exe");
            Console.WriteLine("---Done---");
            Console.ReadLine();
        }

        static Process process;
        static void CallTarget(string exe)
        {
            Console.WriteLine("调用exe并获取实时输出");
            //要实现的代码在这里
            process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    FileName = exe,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    //WorkingDirectory = @"C:\Program Files\Application\php",
                }
            };
            if (process.Start())
            {
                Redirect(process.StandardOutput);
            }
        }

        private static void Redirect(StreamReader input)
        {
            new Thread(a =>
            {
                var buffer = new char[1];
                while (input.Read(buffer, 0, 1) > 0)
                {
                    string s = new string(buffer);
                    Console.Write(s);
                };
            }).Start();
        }
    }
}
