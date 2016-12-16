using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace CSBattle
{
    public class Program
    {
        public static CaoArmy caoArmy = new CaoArmy();
        public static SunLiuArmy sunLiuArmy = new SunLiuArmy();

        static void SetEnamy()
        {
            Console.WriteLine("SetEnamy");
            foreach (var navy in caoArmy.NavyArray)
                navy.SetEnemyNavy();
            foreach (var navy in sunLiuArmy.NavyArray)
                navy.SetEnemyNavy();
        }

        static void ShowLivingSoldiers()
        {
            Console.WriteLine("剩余士兵： 孙刘军: {0} \t 曹军: {1}",
                sunLiuArmy.LivingSoldiersCount, caoArmy.LivingSoldiersCount);
        }

        static bool IsBattleEnd()
        {
            bool bCao = caoArmy.AllDead;
            bool bSunLiu = sunLiuArmy.AllDead;
            if (bCao)
            {
                Console.WriteLine("孙刘军胜！");
                return true;
            }
            else if (bSunLiu)
            {
                Console.WriteLine("曹军胜！");
                return true;
            }
            else
                return false;
        }

        static void ShowBattle(int shipCount)
        {
            Console.Clear();
            ShowLivingSoldiers();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("{0}\t{1}",
                    sunLiuArmy.NavyArray[i].ShowText(shipCount),
                    caoArmy.NavyArray[i].ShowText(shipCount));
            }
        }

        static void Main(string[] args)
        {
            SetEnamy();
            while (!IsBattleEnd())
            {
                ShowBattle(2);
                Thread.Sleep(1000);
            }
            Console.ReadLine();
        }
    }
}
