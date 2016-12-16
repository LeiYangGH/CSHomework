using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBattle
{
    public class SunLiuNavy : Navy
    {
        public SunLiuNavy(int arrayIndex, Army belongingArmy) : base(arrayIndex, belongingArmy)
        {

        }

        public override Ship CreateShip()
        {
            int living = this.belongingArmy.LivingSoldiersCount;
            if (living <= 0)
                return null;
            else if (living < SunLiuNavy.SoldiersPerShip)
            {
                this.belongingArmy.LivingSoldiersCount = 0;
                return new SunLiuShip(living);
            }
            else
            {
                this.belongingArmy.LivingSoldiersCount -= SunLiuNavy.SoldiersPerShip;
                return new SunLiuShip(SunLiuNavy.SoldiersPerShip);
            }
        }

        public override string ShowText(int shipCount)
        {
            return string.Join("  ", this.LstShip.Take(shipCount).Reverse().Select(x => x.ShowText()));
        }

        public override void CreateInitShips()
        {
            this.LstShip = Enumerable.Range(1, 5).Select(x => (Ship)new SunLiuShip(SunLiuNavy.SoldiersPerShip)).ToList();

        }

        public override void SetEnemyNavy()
        {
            this.EnemyNavy = Program.caoArmy.NavyArray[this.ArrayIndex];
        }

        public static int SoldiersPerShip = 200;

        public static double StrengthPerSoldier = 0.2;


    }
}
