using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonkeyKing
{
    static class Program5
    {
        static void Main()
        {
            //5.
            Cat cat = new Cat();
            Mouse m1 = new Mouse("Micky");
            Mouse m2 = new Mouse("Kathy");
            Mouse m3 = new Mouse("Jim");
            Man man = new Man();
            cat.EvCatMiao += (s, e) =>
              {
                  m1.Run();
                  m1.Run();
                  m1.Run();
                  man.Wakeup();
              };
            cat.Miao();

            Console.ReadLine();
        }
    }

    public class Cat
    {
        public event EventHandler EvCatMiao;

        public void Miao()
        {
            Console.WriteLine("猫在叫！");
            if (this.EvCatMiao != null)
            {
                this.EvCatMiao(this, null);
            }
        }
    }

    public class Mouse
    {
        public Mouse(string name)
        {
            this.Name = name;
        }
        public void Run()
        {
            Console.WriteLine("鼠{0}逃跑...", this.Name);
        }

        public string Name { get; set; }
    }

    public class Man
    {
        public void Wakeup()
        {
            Console.WriteLine("主人醒来...");
        }
    }
}