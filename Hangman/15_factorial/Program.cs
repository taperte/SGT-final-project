using System;
using System.Threading;

namespace factorial
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] randomnumbers = ArrayWithRandomNumbers(21);
            int j = 0;
            for (int i = 0; i < 40; i += 2)
            {
                Console.SetCursorPosition(i, j);
                Console.BackgroundColor = (ConsoleColor)randomnumbers[j];
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("The game is on!");
                Console.ResetColor();
                if (i % 4 == 0 || i == 38)
                {
                    Thread.Sleep(100);
                    Console.Clear();
                }
                j++;
            }
            Console.SetCursorPosition(2, 3);
            Console.ForegroundColor = (ConsoleColor)randomnumbers[10];
            CenterText("The game is on!");
            Console.ResetColor();
        }

        private static void CenterText(string text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }

        private static int[] ArrayWithRandomNumbers(int number)
        {
            int[] someArray = new int[number];
            for (int i = 0; i < someArray.Length;)
            {
                Random rand = new Random();
                int randomNumber = rand.Next(2, 15);
                if (randomNumber == 7 || randomNumber == 8)
                {
                    continue;
                }
                if (i == 0 || randomNumber != someArray[i - 1])
                {
                    someArray[i] = randomNumber;
                    i++;
                }
            }
            return someArray;
        }
    }
}
