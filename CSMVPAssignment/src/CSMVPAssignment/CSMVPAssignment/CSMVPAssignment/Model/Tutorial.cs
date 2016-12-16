using CSMVPAssignment.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMVPAssignment.Model
{
    public class Tutorial
    {
        public Tutorial(Teacher teacher,
            Subject subject,
            int year,
            int semester)
        {
            this.Teacher = teacher;
            this.Subject = subject;
            this.Year = year;
            this.Semester = semester;
        }

        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }
    }
}
