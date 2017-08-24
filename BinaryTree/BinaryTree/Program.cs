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
            int[] nums = { 6, 2, 1, 4, 3 };
            foreach (int n in nums)
                root.Insert(n);
            PrintTree(root);
            Console.ReadKey();
        }

        static void PrintTree(Node nd)
        {
            Console.WriteLine(nd.Value);
            if (nd.Left != null)
                PrintTree(nd.Left);
            if (nd.Right != null)
                PrintTree(nd.Right);
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
