using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCComTransfer
{
    public class RandPairs
    {
        public RandPairs(int min, int max)
        {
            this.Min = min;
            this.Max = max;
        }
        public int Min { get; set; }
        public int Max { get; set; }

        public decimal GetRandom(Random r)
        {
            return r.Next(this.Min, this.Max);
        }
    }
}
