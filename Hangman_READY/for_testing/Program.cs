using System;
using System.Collections.Generic;
using System.Threading;

namespace for_testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 1; i < 40; i++)
            //{
            //    Console.SetWindowSize(i, i);
            //    System.Threading.Thread.Sleep(50);
            //}

            //LOOSING ANNOUCMENT
            int j = 0;
            for (int i = 35; i > 0; i -= 2)
            {

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(i, j);
                j++;
                Console.WriteLine("YOU LOST!");
                Thread.Sleep(100);
                Console.ResetColor();
                if (i % 1 == 0 || i == 70)
                {
                    Thread.Sleep(200);
                    Console.Clear();
                }
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, j);
                i++; j++;
                Console.WriteLine("MuHahaHaahaHa");
                Thread.Sleep(100);
                Console.ResetColor();
                if (i % 1 == 0 || i == 70)
                {
                    Thread.Sleep(100);
                    Console.Clear();
                }
                Console.WriteLine();
            }

        }
    }
}
