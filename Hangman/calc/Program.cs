using System;
using System.Collections.Generic;
using System.Threading;

namespace calc
{
    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter your name: ");
                string inputString = ""; ConsoleKey inputKey = ConsoleKey.UpArrow;
                if (KeyPressed(inputString, inputKey))
                {
                    Console.WriteLine($"Your name is {inputString}.");
                }
                else
                {
                    if (inputKey == ConsoleKey.Escape)
                    {
                        Console.WriteLine($"You pressed {inputKey}.");
                        break;
                    }
                    else if (inputKey == ConsoleKey.Spacebar)
                    {
                        Console.WriteLine($"You pressed {inputKey}.");
                    }
                    else
                    {
                        Console.WriteLine($"You pressed {inputKey}.");
                        continue;
                    }
                }
                Console.Write("Enter language: ");
                if (KeyPressed(inputString, inputKey))
                {
                    Console.WriteLine($"You entered {inputString}.");
                }
                else
                {
                    if (inputKey == ConsoleKey.Escape)
                    {
                        Console.WriteLine($"You pressed {inputKey}.");
                        break;
                    }
                    else if (inputKey == ConsoleKey.Spacebar)
                    {
                        Console.WriteLine($"You pressed {inputKey}.");
                    }
                    else
                    {
                        Console.WriteLine($"You pressed {inputKey}.");
                        continue;
                    }
                }
            }
        }

        static bool KeyPressed(string someString, ConsoleKey someKey)
        {
            while (true)
            {
                while (!Console.KeyAvailable)
                {
                    Thread.Sleep(1);
                }
                someKey = Console.ReadKey().Key;
                if (someKey == ConsoleKey.Escape || someKey == ConsoleKey.Spacebar || someKey == ConsoleKey.Tab)
                {
                    return true;
                }
                else
                {
                    someString = someKey.ToString() + Console.ReadLine();
                    return false;
                }
            }
            
        }

    }
}
