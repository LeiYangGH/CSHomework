using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBattle
{
    public class SunLiuArmy : Army
    {

        public SunLiuArmy()
        {
#if DEVTEST
            this.LivingSoldiersCount = 200 * 5 * 5;
#else
            this.LivingSoldiersCount = 50000;
#endif
        }

        protected override void Create5Navys()
        {
            this.NavyArray = new SunLiuNavy[5];
            for (int i = 0; i < 5; i++)
            {
                this.NavyArray[i] = new SunLiuNavy(i, this);
            }
        }
    }
}
