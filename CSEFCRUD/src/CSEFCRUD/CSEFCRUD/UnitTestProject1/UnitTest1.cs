using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System.Data.Entity;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// 测试添加示例数据到数据库
        /// 运行时可先手动删除数据库内所有记录
        /// </summary>
        [TestMethod]
        public void TestAddSampleDataToDataBase()
        {
            using (Model1 en = new Model1())
            {
                Assert.AreEqual(en.Students.Count(), 4);
                //foreach (Student stu in en.Students)
                //{
                //    Console.WriteLine(stu.Name);
                //}
            }
        }

        [TestMethod]
        public void TestAdd()
        {
            using (Model1 en = new Model1())
            {
                Student stu = new Student { Name = "LY", Sex = "M", Age = 28, Pwd = "L38" };
                StuDbAccessor.Add(stu);
                Assert.AreEqual(en.Students.Count(), 5);
            }
        }

        [TestMethod]
        public void TestDelete()
        {
            using (Model1 en = new Model1())
            {
                StuDbAccessor.Delete(2);
                Assert.AreEqual(en.Students.Count(), 4);
            }
        }

        [TestMethod]
        public void TestDelete()
        {
            using (Model1 en = new Model1())
            {
                StuDbAccessor.Delete(2);
                Assert.AreEqual(en.Students.Count(), 4);
            }
        }
    }
}
