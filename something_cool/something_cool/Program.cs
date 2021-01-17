using System;
using System.Collections.Generic;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace something_cool
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                
                //int Width = Console.LargestWindowWidth;
                //int Height = Console.LargestWindowHeight;
                //for (int i = 1; i < 20; i++)
                //{
                //    Console.SetWindowSize(i, i);
                //    Thread.Sleep(10000);
                //}
                //Console.SetWindowSize(Width, Height);

                while (!Console.KeyAvailable) 

                {

                    Thread.Sleep(200);

                    Console.Write("a ");

                }




                Console.WriteLine();

                //parameter intercept (from method description):

                // Determines whether to display the pressed key in the console window. true to

                // not display the pressed key; otherwise, false.

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
                int Width1 = Console.LargestWindowWidth;
                int Height1 = Console.LargestWindowHeight;
                Console.SetWindowSize(Width1, Height1);
                for (int i = 1; i < 20; i--)
                {
                    Console.SetWindowSize(i, i);
                    Thread.Sleep(10000);
                }

            }
        }
                
    }
}
