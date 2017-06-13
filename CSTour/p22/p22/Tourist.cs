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
        public Tourist(string i, string n, string g, string t)
        {
            this.Id = i;
            this.Name = n;
            this.Gender = g;
            this.Tel = t;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Tel { get; set; }
    }
}
