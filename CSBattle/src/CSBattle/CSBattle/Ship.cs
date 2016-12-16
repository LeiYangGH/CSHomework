using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBattle
{
    public abstract class Ship
    {
        public Ship(int soldiersCount)
        {
            this.SoldiersCount = soldiersCount;
        }
        public abstract int Strength { get; }

        public int SoldiersCount { get; set; }
        public abstract string ShowText();
    }
}
