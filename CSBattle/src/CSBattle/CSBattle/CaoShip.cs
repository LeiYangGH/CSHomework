using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBattle
{
    public class CaoShip : Ship
    {
        public CaoShip(int soldiersCount) : base(soldiersCount)
        {
        }

        public override int Strength
        {
            get
            {
                Random r = new Random();
                double d = CaoNavy.StrengthPerSoldier * this.SoldiersCount * (r.Next(7, 13) / 10.0d);
                return Convert.ToInt32(d);
            }
        }

        public override string ShowText()
        {
            return string.Format("<<曹军船|({0})", this.SoldiersCount);
        }
    }
}
