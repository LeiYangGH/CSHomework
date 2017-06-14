using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p22
{
    [Serializable]
    public class Activity
    {
        public Activity(string n, DateTime d, string s)
        {
            this.Name = n;
            this.Date = d;
            this.State = s;
        }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string State { get; set; }
    }
}
