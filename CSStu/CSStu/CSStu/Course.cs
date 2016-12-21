using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSStu
{
    public class Course
    {
        private static int id = 1;
        private const string dateFormatString = @"yyyy-MM-dd";
        public Course()
        {
            this.Id = Course.id++;
        }

        public Course(int id, string name, DateTime date, int duration)
        {
            this.Id = id;
            if (Course.id <= id)
                Course.id = id + 1;
            this.Name = name;
            this.StartDate = date;
            this.Duration = duration;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }

        /// <summary>
        /// 从各个字段组合成一行
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}",
                this.Id, this.Name, this.StartDate.ToString(dateFormatString), this.Duration);
        }
    }
}
