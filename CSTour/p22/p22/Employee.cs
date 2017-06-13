using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p22
{
    [Serializable]
    public class Employee
    {
        public Employee(string i, string n)
        {
            this.No = i;
            this.Name = n;
        }
        public string No { get; set; }
        public string Name { get; set; }
    }
}
