using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Sale
    {
        public Sale(string mName, string cusName, float price, List<Position> soldPositions)
        {
            this.MovieName = mName;
            this.CustomerTypeName = cusName;
            this.Price = price;
            this.SoldPositions = soldPositions;
        }
        public string MovieName { get; set; }
        public string CustomerTypeName { get; set; }
        public float Price { get; set; }
        public List<Position> SoldPositions;
    }
}
