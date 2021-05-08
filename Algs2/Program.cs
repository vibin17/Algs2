using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algs2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Choose a task");

                try
                {
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1: LR1.Run(106732567, 152673836); break;
                        case 2: LR2.Task1.Run(); break;
                        case 3: LR2.Task2.Run(); break;
                        default: Console.WriteLine("wrong input"); break;
                    }
                }
                catch (FormatException)
                {

                }
                
            }
        }
    }
}
