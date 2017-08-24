using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node();
            root.Value = 5;
            //6  2  1  4  3  8  7  9
            int[] nums = { 6, 2, 1, 4, 3, 8, 7, 9 };
            foreach (int n in nums)
                root.Insert(n);
            PrintValues(root);
            Console.WriteLine("==========");
            PrintLevels(root);
            Console.ReadKey();
        }

        static void PrintLevels(Node nd)
        {
            List<Node> level = new List<Node>() { nd };
            List<List<Node>> levels = new List<List<Node>>() { level };

            while (level.Count() > 0)
            {
                List<Node> tlevel = new List<Node>();
                tlevel.AddRange(level.Select(x => x.Left).Where(x => x != null));
                tlevel.AddRange(level.Select(x => x.Right).Where(x => x != null));
                if (tlevel.Count > 0)
                    levels.Add(tlevel);
                level = tlevel;
            }
            Dictionary<Node, int> dicNodeX = new Dictionary<Node, int>();
            int ndWidth = 5;
            int totalWidth = ndWidth * levels.Max(x => x.Count);

            nd.ColCount = levels.Count;

            //foreach (List<Node> alevel in levels)
            for (int lindex = 0; lindex < levels.Count; lindex++)
            {
                int currentC = 0;
                string spaces = new string(' ', (levels.Count - lindex) * ndWidth);
                string space = new string(' ', 2 * ndWidth);
                Console.Write(spaces);
                //foreach (Node n in alevel)
                foreach (Node n in levels[lindex])
                {
                    int ndiff = n.ColCount * ndWidth - currentC - 1;
                    string diff = new string(' ', ndiff);
                    Console.Write(diff);
                    Console.Write(n.Value);
                    if (n.Left != null)
                    {
                        n.Left.ColCount = n.ColCount - 1;
                    }
                    if (n.Right != null)
                    {
                        n.Right.ColCount = n.ColCount + 1;
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static void PrintValues(Node nd)
        {
            Console.WriteLine(nd.Value);
            if (nd.Left != null)
                PrintValues(nd.Left);
            if (nd.Right != null)
                PrintValues(nd.Right);
        }
    }



    class Node
    {
        public Node()
        {
        }
        public int Value
        {
            get; set;
        }

        //public Node Parent { get; set; }

        public int ColCount { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public void Insert(int value)
        {
            if (value < this.Value)
            {
                if (this.Left == null)
                {
                    Node nd = new Node();
                    nd.Value = value;
                    this.Left = nd;
                    //nd.Parent = this;
                }
                else
                    this.Left.Insert(value);
            }
            else if (value > this.Value)
            {
                if (this.Right == null)
                {
                    Node nd = new Node();
                    nd.Value = value;
                    this.Right = nd;
                    //nd.Parent = this;
                }
                else
                    this.Right.Insert(value);
            }

        }

    }
}
