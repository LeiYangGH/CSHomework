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
        public Activity(string t, string r)
        {
            this.TouristName = t;
            this.RouteDescriptions = r;
        }
        public string TouristName { get; set; }
        public string RouteDescriptions { get; set; }
    }
}
