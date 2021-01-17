using System;
using System.Collections.Generic;
using System.Threading;

namespace calc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter smth: ");
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(1);
            }
            Console.WriteLine();
            //parameter intercept (from method description):
            //Determines whether to display the pressed key in the console window. true to
            //not display the pressed key; otherwise, false.
            var key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.Escape)
            {
                Console.Write(key.KeyChar);
                string newText = Console.ReadLine();
                string textCombined = key.KeyChar.ToString() + newText;
                Console.WriteLine($"You just input: '{textCombined}'");
            }
            else
            {
                string aa = "You pressed ESC";
                Console.WriteLine(aa);
            }

            int[] randomnumbers = ArrayWithRandomNumbers(40);
            int j = 20;
            for (int i = 40; i > 0; i -= 2)
            {
                Console.SetCursorPosition(i, j);
                Console.BackgroundColor = (ConsoleColor)randomnumbers[j];
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("The game is on!");
                Console.ResetColor();
                if (i % 4 == 0 || i == 2)
                {
                    Thread.Sleep(100);
                    Console.Clear();
                }
                j--;
            }
        }
    }
}
