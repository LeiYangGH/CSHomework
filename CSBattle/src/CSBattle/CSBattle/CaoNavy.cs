using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBattle
{
    public class CaoNavy : Navy
    {
        public CaoNavy(int arrayIndex, Army belongingArmy) : base(arrayIndex, belongingArmy)
        {

        }

        public override Ship CreateShip()
        {
            int living = this.belongingArmy.LivingSoldiersCount;
            if (living <= 0)
                return null;
            else if (living < CaoNavy.SoldiersPerShip)
            {
                this.belongingArmy.LivingSoldiersCount = 0;
                return new CaoShip(living);
            }
            else
            {
                this.belongingArmy.LivingSoldiersCount -= CaoNavy.SoldiersPerShip;
                return new CaoShip(CaoNavy.SoldiersPerShip);
            }
        }

        public override string ShowText(int shipCount)
        {
            return string.Join("  ", this.LstShip.Take(shipCount).Select(x => x.ShowText()));
        }

        public override void CreateInitShips()
        {
            this.LstShip = Enumerable.Range(1, 5).Select(x => (Ship)new CaoShip(CaoNavy.SoldiersPerShip)).ToList();
        }

        public override void SetEnemyNavy()
        {
            this.EnemyNavy = Program.sunLiuArmy.NavyArray[this.ArrayIndex];
        }

        public static int SoldiersPerShip = 100;
        public static double StrengthPerSoldier = 0.16;

    }
}
