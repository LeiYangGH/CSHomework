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
        public Course()
        {
            this.Id = id++;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }

        //public static int NewId()
        //{
        //    return id++;
        //}

    }
}
