using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBattle
{
    public class CaoArmy : Army
    {

        public CaoArmy()
        {
#if DEVTEST
            this.LivingSoldiersCount = 100 * 10 * 5;
#else
            this.LivingSoldiersCount = 200000;
#endif
        }

        protected override void Create5Navys()
        {
            this.NavyArray = new CaoNavy[5];
            for (int i = 0; i < 5; i++)
            {
                this.NavyArray[i] = new CaoNavy(i, this);
            }
        }
    }
}
