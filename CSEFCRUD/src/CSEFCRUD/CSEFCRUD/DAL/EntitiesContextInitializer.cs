using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 添加示例记录到数据库
    /// </summary>
    //public class EntitiesContextInitializer : DropCreateDatabaseIfModelChanges<Model1>
    public class EntitiesContextInitializer : DropCreateDatabaseAlways<Model1>
    {
        protected override void Seed(Model1 context)
        {
            List<Student> stus = new List<Student>
        {
            new Student {Name="Jim",Sex="M",Age=35,Pwd="123"},
            new Student {Name="Walter",Sex="M",Age=38,Pwd="pwd"},
            new Student {Name="Tracy",Sex="F",Age=32,Pwd="asdfg"},
            new Student {Name="Ivy",Sex="F",Age=27,Pwd="qwert"}
        };

            // add data into context and save to db
            foreach (Student stu in stus)
            {
                context.Students.Add(stu);
            }
            context.SaveChanges();
        }
    }
}
