using System;
using System.Collections.Generic;
using System.Diagnostics;
using Shared;

namespace LR2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Int64> data = new List<Int64>();
            string input;
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
}
