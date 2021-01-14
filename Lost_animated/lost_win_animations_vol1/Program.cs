using System;
using System.Threading;

namespace lost_win_animations_vol1
{
    class Program
    {
        static void Main(string[] args)
        {

            //WINNING ANNOUCMENT
            int j = 0;

            for (int i = 0; i < 40; i++)
            {

                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(i, j);
                i++; j++;
                Console.WriteLine("YOU WON!");
                Thread.Sleep(100);
                Console.ResetColor();
                if (i % 1 == 0 || i == 70)
                {
                    Thread.Sleep(200);
                    Console.Clear();
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(i, j);
                i++; j++;
                Console.WriteLine("CONGRATULATIONS!");
                Thread.Sleep(100);
                Console.ResetColor();
                if (i % 1 == 0 || i == 70)
                {
                    Thread.Sleep(100);
                    Console.Clear();
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.Clear();

        }
    }
}
