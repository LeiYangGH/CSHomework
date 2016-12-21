using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStu
{
    public class Score
    {
        public Score(string stuno, string stuname, string major, int courseid, int mark)
        {
            this.StudentNo = stuno;
            this.StudentName = stuname;
            this.Major = major;
            this.CourseId = courseid;
            this.Mark = mark;
        }
        public string StudentNo { get; set; }
        public string StudentName { get; set; }
        public string Major { get; set; }
        public int CourseId { get; set; }
        public int Mark { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4}",
                this.StudentNo, this.StudentName, this.Major, this.CourseId, this.Mark);
        }
    }
}
