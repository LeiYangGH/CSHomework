using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSCircleSteps
{
    class Program
    {
        private static Walker walker = new Walker();
        private const int maxLayers = 50;//层数限制，可以试着改大，但注意所有步数溢出
        static void Main(string[] args)
        {
            int layer;
            //逐圈添加
            for (layer = 1; layer <= maxLayers; layer++)
            {
                walker.AddLayer(layer);
            }
            Console.WriteLine("总圈数:{0}\t总步数：{1}", layer, walker.HistoryLocations.Count);
            while (true)
            {
                int? step = PromptInputStep();
                if (step != null)
                {
                    Console.WriteLine("\t\t\t上\t右\t下\t左");
                    ShowOneStep(step.Value);
                }
            }
            Console.ReadLine();
        }

        private static int? PromptInputStep()
        {
            Console.Write("请输入要查询的步数，以回车结束：");
            string line = Console.ReadLine();
            int step;
            if (int.TryParse(line, out step))
                return step;
            else
                Console.Write("输入的步数不是整数。");
            return null;
        }

        private static void ShowOneStep(int step)
        {
            if (step > 0 && step < walker.HistoryLocations.Count)
            {
                Console.WriteLine(walker.HistoryMoves[step].MoveFromLastStepString());
                Console.WriteLine(walker.HistoryLocations[step].MoveFromStep0String());
            }
            else
                Console.WriteLine("输入的步数超出范围。");
        }
    }
}
