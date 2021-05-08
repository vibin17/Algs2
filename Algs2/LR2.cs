using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;


namespace Algs2
{
    public static class LR2
    {
        public static class Task1
        {
            public static void Run()
            {
                string input = string.Empty;
                List<Int64> data = new List<Int64>();
                while ((input = Console.ReadLine()) != "0")
                {
                    data.Add(Convert.ToInt32(input));
                }
                Stopwatch timer = Stopwatch.StartNew();
                Dictionary<Int64, int> nodes = new Dictionary<Int64, int>();
                foreach (var item in data)
                {
                    nodes[item] = 0;
                }
                foreach (var item in data)
                {
                    nodes[item] += 1;
                }
                HashSet<Int64> values = new HashSet<Int64>();
                foreach (var item in nodes.Keys)
                {
                    values.Add(item);
                }
                BTree<int> tree = new BTree<int>();
                foreach (var item in values)
                {
                    tree.AddNode(item, nodes[item]);
                }
                timer.Stop();
                Console.WriteLine($"{timer.ElapsedMilliseconds / 1000} s {timer.ElapsedMilliseconds % 1000} ms");
                return;
            }
        }
        public static class Task2
        {
            public enum Rate
            {
                ЛучшаяЦена, Выгодный, Оптимальный, ВсеВключено
            }
            public static void Run()
            {
                BTree<(string, Rate)> bTree = new BTree<(string, Rate)>();
                Dictionary<string, int> rates = new Dictionary<string, int>();
                using (StreamReader stream = new StreamReader("LR2Input.txt"))
                {
                    string input = string.Empty;
                    while ((input = stream.ReadLine()) != null)
                    {
                        var nodeData = input.Split(' ');
                        bTree.AddNode(Convert.ToInt64(nodeData[0]), (nodeData[1], (Rate)Enum.Parse(typeof(Rate), nodeData[2], true)));
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
}

