using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStu
{
    public class Repository
    {
        public static Repository Default;
        public Repository()
        {
            Repository.Default = this;
            this.AllStudents = new List<Student>
                {
                    new Student("20160001","Miller"),
                    new Student("20160002","Jim"),
                    new Student("20160003","Mike"),
                    new Student("20160004","Lucy")
                };
            this.AllCourses = new List<Course>();
        }
        public List<Student> AllStudents;
        public List<Course> AllCourses;
    }
}
