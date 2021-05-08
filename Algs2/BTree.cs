using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algs2
{
    public class BTree <T>
    {
        public class Node
        {
            public Int64 Item1 { get; private set; }
            public T Item2 { get; private set; }
            public Node Left { get; set; } = null;
            public Node Right { get; set; } = null;
            public Node(Int64 item1, T item2)
            {
                Item1 = item1;
                Item2 = item2;
            }
        }
        public Node Root { get; private set; } = null;
        public BTree() { }
        public void AddNode(Int64 item1, T item2)
        {
            if (Root == null)
            {
                Root = new Node(item1, item2);
                return;
            }
            Search(Root, item1, item2);
        }
        public void Search(Node node, Int64 item1, T item2)
        {
            if (item1 < node.Item1)
            {
                if (node.Left == null)
                {
                    node.Left = new Node(item1, item2);
                }
                else
                {
                    Search(node.Left, item1, item2);
                }
            }
            else if (node.Right == null)
            {
                node.Right = new Node(item1, item2);
            }
            else
            {
                Search(node.Right, item1, item2);
            }
        }
    }
}
