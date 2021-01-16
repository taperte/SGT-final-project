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
        }
    }
}
