using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p22
{
    [Serializable]
    public class Route
    {
        public Route(string de, DateTime d, int p)
        {
            this.Descriptions = de;
            this.Date = d;
            this.Price = p;
        }
        public string Descriptions { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
    }
}
