using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.ServiceReference1;
using TestConsole.ServiceReference2;
namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestDAL();

            //TestWCF();
            TestWebService();

            Console.ReadLine();
        }

        static void TestWCF()
        {
            Service1Client client = new Service1Client();
            bool b = client.CheckStudent("name", "pwd");
            Console.WriteLine("用WCF验证不合法用户名： {0}", b);
            b = client.CheckStudent("Jim", "123");
            Console.WriteLine("用WCF验证合法用户名： {0}", b);
        }

        static void TestWebService()
        {
            WebService1SoapClient client = new WebService1SoapClient();
            bool b = client.CheckStudent("name", "pwd");
            Console.WriteLine("用WebService验证不合法用户名： {0}", b);
            b = client.CheckStudent("Jim", "123");
            Console.WriteLine("用WebService验证合法用户名： {0}", b);
        }

        static void TestDAL()
        {
            using (Model1 en = new Model1())
            {
                Console.WriteLine("默认记录数量：{0}", en.Students.Count());

                Student stu = new Student { Name = "LY", Sex = "M", Age = 28, Pwd = "L38" };
                StuDbAccessor.Add(stu);
                Console.WriteLine("添加了一条记录后记录数量：{0}", en.Students.Count());

                StuDbAccessor.Delete(2);
                Console.WriteLine("删除了一条记录后记录数量：{0}", en.Students.Count());

                Student stuUpdate = new Student { Name = "name1", Sex = "M", Age = 1, Pwd = "pwd1" };
                StuDbAccessor.Update(1, stuUpdate);
                Console.WriteLine("更新了第一条记录，下面是更新后的属性");
                Student updated1 = StuDbAccessor.SelectById(1);
                Console.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}",
                   updated1.Name, updated1.Pwd, updated1.Sex, updated1.Pwd));
            }
        }

    }
}
