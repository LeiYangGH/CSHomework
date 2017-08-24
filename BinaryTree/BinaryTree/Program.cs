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

            while (level.Any())
            {
                List<Node> tlevel = new List<Node>();
                tlevel.AddRange(level.Select(x => x.Left).Where(x => x != null));
                tlevel.AddRange(level.Select(x => x.Right).Where(x => x != null));
                if (tlevel.Count > 0)
                    levels.Add(tlevel);
                level = tlevel;
            }


            nd.X = 40;

            for (int lindex = 0; lindex < levels.Count; lindex++)
            {
                int currentC = 0;
                 

                foreach (Node n in levels[lindex])
                {
                    int xdiff = n.X   - currentC ;
                    if(xdiff>0)
                    {
                    string sdiff = new string(' ', xdiff);
                    Console.Write(sdiff);
                    Console.Write(n.Value);
                    currentC+=xdiff+1;
                    }
                    if (n.Left != null)
                    {
                    	n.Left.X = n.X - 2*(int)Math.Pow(2,levels.Count-lindex);
                    }
                    if (n.Right != null)
                    {
                        n.Right.X = n.X + 2*(int)Math.Pow(2,levels.Count-lindex);
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


        public int X { get; set; }
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
                }
                else
                    this.Right.Insert(value);
            }

        }

    }
}
