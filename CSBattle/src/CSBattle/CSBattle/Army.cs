using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBattle
{
    public abstract class Army
    {
        public Army()
        {
            this.Create5Navys();
        }
        protected abstract void Create5Navys();
        public Navy[] NavyArray { get; set; }
        public int LivingSoldiersCount { get; set; }
        public bool AllDead
        {
            get
            {
                return this.NavyArray.All(x => x.LstShip.Count <= 0);
            }
        }
    }
}
