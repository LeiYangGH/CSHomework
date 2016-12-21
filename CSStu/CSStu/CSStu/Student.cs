using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStu
{
    public class Student
    {
        public Student(string no, string name)
        {
            this.No = no;
            this.Name = name;
        }
        public string No { get; set; }
        public string Name { get; set; }
    }
}
