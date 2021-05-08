using System;
using Shared;
using System.Collections.Generic;
using System.IO;

namespace LR2_2
{
    class Program
    {
        public enum Rate
        {
            ЛучшаяЦена, Выгодный, Оптимальный, ВсеВключено
        }
        public static void Main()
        {
            BTree<(string, Rate)> tree = new BTree<(string, Rate)>();
            Dictionary<string, int> rates = new Dictionary<string, int>();
            using (StreamReader stream = new StreamReader("LR2Input.txt"))
            {
                string input = string.Empty;
                while ((input = stream.ReadLine()) != null)
                {
                    var nodeData = input.Split(' ');
                    tree.AddNode(Convert.ToInt64(nodeData[0]), (nodeData[1], (Rate)Enum.Parse(typeof(Rate), nodeData[2], true)));
                    if (rates.ContainsKey(nodeData[2]))
                    {
                        rates[nodeData[2]] += 1;
                    }
                    else
                    {
                        rates[nodeData[2]] = 1;
                    }
                }
            }
            return;
        }
        public static BTree<(string, Rate)>.Node Work(BTree<(string, Rate)>.Node node, Int64 numb)
        {
            if (node?.Item1 == numb)
            {
                return node;
            }
            if (Work(node.Left, numb) == null)
            {
                return Work(node.Right, numb);
            }
            else return Work(node.Left, numb);
        }
    }
}
