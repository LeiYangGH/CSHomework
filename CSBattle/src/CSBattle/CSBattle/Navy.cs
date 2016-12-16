using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
namespace CSBattle
{
    public abstract class Navy
    {
#if DEVTEST
        Timer timer = new Timer(200);//
#else
        Timer timer = new Timer(1000);//
#endif

        public Navy(int arrayIndex, Army belongingArmy)
        {
            this.ArrayIndex = arrayIndex;
            this.belongingArmy = belongingArmy;
            this.LstShip = new List<Ship>();
            this.CreateInitShips();
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

        }

        public abstract void SetEnemyNavy();

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (this.LstShip.Count == 0)//
                this.timer.Dispose();
            else
                this.Attack();
        }

        public virtual void CreateInitShips()
        {
            for (int i = 0; i < 5; i++)
            {
                var newShip = this.CreateShip();
                if (newShip == null)
                    break;
                else
                {
                    this.LstShip.Add(newShip);
                }
            }
        }

        protected Army belongingArmy { get; set; }
        protected Navy EnemyNavy { get; set; }

        public Ship HeadShip
        {
            get
            {
                return this.LstShip.FirstOrDefault();
            }
        }

        public int ArrayIndex { get; private set; }
        public abstract Ship CreateShip();
        public virtual List<Ship> LstShip { get; set; }
        public virtual void Attack()
        {
            if (this.LstShip.Count > 0
                && this.EnemyNavy != null)//?
                this.EnemyNavy.AcceptAttack(this.HeadShip.Strength);
        }
        public virtual void AcceptAttack(int strength)
        {
            if (this.HeadShip == null)
                return;//
            this.HeadShip.SoldiersCount -= Convert.ToInt32(strength);

            if (this.HeadShip.Strength <= 0)
            {
                this.LstShip.Remove(HeadShip);
                var newShip = this.CreateShip();
                if (newShip != null)
                    this.LstShip.Add(newShip);
            }
        }
        public abstract string ShowText(int shipCount);
    }
}
