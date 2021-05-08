using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algs2
{
    class LR1
    {
        static public void Run(int a, int b)
        {
            Stopwatch timer = Stopwatch.StartNew();
            for (int i = a; i <= b; i++) // b - a
            {
                var numb = i;
                double Pow1 = Math.Sqrt(Math.Sqrt(numb));
                if (Convert.ToInt64(Pow1) == Pow1)
                {
                    if (Prime(Convert.ToInt32(Pow1)))

                    {
                        Console.WriteLine($"{numb} {Math.Pow(Pow1, 3)}");
                    }
                }
            }
            timer.Stop();
            Console.WriteLine($"{timer.ElapsedMilliseconds / 1000} s {timer.ElapsedMilliseconds % 1000} ms");
        }
        static bool Prime(int a) // sqrt(n)
        {
            for (int i = 2; i <= Math.Sqrt(a) + 1; i++)
            {
                if (a % i == 0) return false;
            }
            return true;
        }
    }
}
