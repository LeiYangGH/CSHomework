using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStu
{
    public class AveCourse
    {
        public AveCourse(string n, string a)
        {
            this.CourseName = n;
            this.Ave = a;
        }
        public string CourseName { get; set; }
        public string Ave { get; set; }
    }
}
