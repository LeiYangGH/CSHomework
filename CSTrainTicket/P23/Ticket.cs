using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23
{
    [Serializable]
    public class Ticket
    {
        public Ticket(string n,DateTime d,int p)
        {
            this.No = n;
            this.Date = d;
            this.Price = p;
        }
        public string No { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
    }
}
