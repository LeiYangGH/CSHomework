using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStu
{
    public class Repository
    {
        public Repository()
        {
            this.AllStudents = new Student[]
                {
                    new Student("20160001","Miller"),
                    new Student("20160002","Jim"),
                    new Student("20160003","Mike"),
                    new Student("20160004","Lucy")
                };
        }
        public Student[] AllStudents;
    }
}
