using System;
using System.Collections.Generic;

namespace LR3
{
    static class Program
    {
        static public readonly Dictionary<string, int> ops = new Dictionary<string, int>()
            {
                { "+", 1 },
                { "-", 1 },
                { "*", 2 },
                { "/", 2 },
            };

        static void Main(string[] args)
        {
            string example = "(12+13)*14/(74+2)";
            var tree = new BTree<string>();
            
            formTree(tree, null, example);
            var res = calculate(tree.Root);
            return;
        }
        static void PrintTree(BTree<string> tree)
        {

        }
        static double calculate(BTree<string>.Node node)
        {
            if (ops.ContainsKey(node.Data))
            {
                double left = calculate(node.Left);
                double right = calculate(node.Right);
                switch(node.Data)
                {
                    case "+": return left + right;
                    case "-": return left - right;
                    case "*": return left * right;
                    case "/": return left / right;
                }
            }
            return Convert.ToDouble(node.Data);
        }

        static string deleteOuterBrackets(string str)
        {
            bool correct = false;
            if (!str.Contains('('))
            {
                return str;
            }
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    count++;
                }
                if (str[i] == ')')
                {
                    count--;
                }
                if (count == 0 && i != str.Length - 1)
                {
                    correct = true;
                }
            }
            return correct ? str : str.Substring(1, str.Length - 2);
        }
        static void formTree(BTree<string> tree, BTree<string>.Node parent, string str)
        {
            int brackets = 0;
            str = deleteOuterBrackets(str);
            var operations = new List<(string, int)>();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    brackets++;
                }
                if (str[i] == ')')
                {
                    brackets--;
                }
                if (brackets == 0)
                {
                    if (ops.ContainsKey(str[i].ToString()))
                    {
                        operations.Add((str[i].ToString(), i));
                    }
                }
            }
            if (operations.Count > 0)
            {
                var minPrior = operations[0];

                foreach (var op in operations)
                {
                    if (ops[op.Item1] < ops[minPrior.Item1])
                    {
                        minPrior = op;
                    }
                    else
                    {
                        if (op.Item2 > minPrior.Item2)
                        {
                            minPrior = op;
                        }
                    }
                }
                var first = str.Substring(0, minPrior.Item2);
                var second = str.Substring(minPrior.Item2 + 1);
                var node = tree.AddNode(str[minPrior.Item2].ToString(), parent);
                formTree(tree, node, first);
                formTree(tree, node, second);
            }
            else
            {
                tree.AddNode(str, parent);
            }
        }
    }
}
