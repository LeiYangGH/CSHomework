using DesignPatterns.ChainOfResponsibility;
using DesignPatterns.Command;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //ChainOfResponsibility();
            Command();
            Console.ReadLine();

        }

        public static void ChainOfResponsibility()
        {
            using (FileStream tempFileStream = File.Create(Path.GetTempFileName()))
            {
                ILogger consoleLogger = new ConsoleLogger(LogLevel.Info | LogLevel.Warning | LogLevel.Error);
                ILogger memoryLogger = new MemoryQueueLogger(LogLevel.Warning | LogLevel.Error);

                ILogger fileLogger = new FileLogger(LogLevel.Error, tempFileStream);

                ILogger logger = consoleLogger;
                consoleLogger.SetNext(memoryLogger);
                memoryLogger.SetNext(fileLogger);

                logger.Log("This entry arrives only to ConsoleLogger.", LogLevel.Info);
                logger.Log("This entry arrives to ConsoleLogger and MemoryQueueLogger.", LogLevel.Warning);
                logger.Log("This entry arrives to ConsoleLogger, MemoryQueueLogger and FileLogger.", LogLevel.Error);
            }
        }

        public static void Command()
        {
            //IFileOperator fileOperator = new FileSystemOperator(Path.GetTempPath());
            IFileOperator fileOperator = new FileSystemOperator(@"C:\test");

            //IFileOperator fileOperator = new FtpFileOperator(new Uri("ftp://tepuri.org"));

            var invoker = new FileOperationInvoker();
            ICommand command;

            command = new CreateFileCommand(fileOperator, "HelloWorld.txt");
            invoker.Enqueue(command);

            command = new RenameFileCommand(fileOperator, "HelloWorld.txt", "GoodbyeWorld.txt");
            invoker.Enqueue(command);

            command = new DeleteFileCommand(fileOperator, "GoodbyeWorld.txt");
            invoker.Enqueue(command);

            invoker.InvokeAll();
        }
    }
}
