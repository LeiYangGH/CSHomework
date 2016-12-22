using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonkeyKing
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmShape());
        }

        //把Main改成其他名字为了防止与Winform的冲突
        //如果需要控制台程序则要反过来改
        static void Main1()
        {
            //3.
            CalcFirstAndLastDay();


            //4.
            Console.WriteLine("请输入n，并以回车结束");
            int n = Convert.ToInt32(Console.ReadLine());
            int sum = CalcSum(n);
            Console.WriteLine("1-2+3-4+5-6+7……+n = " + sum.ToString());



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

        static void CalcFirstAndLastDay()
        {
            Console.WriteLine("注：你可以通过修改电脑年份，运行后可以看到不同结果");
            DateTime now = DateTime.Now;
            int year = now.Year;
            DateTime firstDay = new DateTime(year, 1, 1).Date;
            DateTime lastDay = new DateTime(year, 12, 31).Date;
            Console.WriteLine("今年第一天" + firstDay.ToShortDateString());
            Console.WriteLine("今年最后一天" + lastDay.ToShortDateString());
        }

        static int CalcSum(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 1)
                {
                    sum += i;
                }
                else
                {
                    sum -= i;
                }
            }
            return sum;
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
