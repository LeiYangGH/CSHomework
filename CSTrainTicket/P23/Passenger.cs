using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23
{
    [Serializable]
    public class Passenger
    {
        public Passenger(string i, string n, string g, int a)
        {
            this.Id = i;
            this.Name = n;
            this.Gender = g;
            this.Age = a;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
    }
}
