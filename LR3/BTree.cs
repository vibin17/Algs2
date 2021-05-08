using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR3
{
    public class BTree <T>
    {
        public class Node
        {
            public T Data { get; private set; }
            public Node Left { get; set; } = null;
            public Node Right { get; set; } = null;
            public Node(T data) => Data = data;
        }
        public Node AddNode (T data, Node parent = null)
        {
            if (parent == null)
            {
                Root = new Node(data);
                return Root;
            }
            if (parent.Left == null)
            {
                parent.Left = new Node(data);
                return parent.Left;
            }
            else
            {
                parent.Right = new Node(data);
                return parent.Right;
            }

        }
        public Node Root { get; set; } = null;
        public BTree() { }

    }
}
