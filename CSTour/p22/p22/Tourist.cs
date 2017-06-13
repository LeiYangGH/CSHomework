using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p22
{
    [Serializable]
    public class Tourist
    {
        public Tourist(string n, string g, string i,  string t)
        {
            this.Name = n;
            this.Gender = g;
            this.Id = i;
            this.Tel = t;
        }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Id { get; set; }
        public string Tel { get; set; }
    }
}
