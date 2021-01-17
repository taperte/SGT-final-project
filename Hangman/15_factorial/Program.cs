using System;
using System.Threading;

namespace factorial
{
    class Program
    {
        static void Main(string[] args)
        {
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
            string[,] sadFace = new string[12, 12];
            for (int row = 0; row < sadFace.GetLength(0); row++)
            {
                for (int column = 0; column < sadFace.GetLength(1); column++)
                {
                    if (((row == column || column - row == 8) && row < 5 && column < 5) ||
                        (row == 0 && (column == 4 || column == 12)) || 
                        (row == 1 && (column == 3 || column == 11)) ||
                        (row == 3 && (column == 1 || column == 9)) ||
                        (row == 4 && (column == 0 || column == 8)) ||
                        (row == 8 && column > 3 && column < 9) ||
                        (row == 9 && column > 1 && column < 11) ||
                        (row == 10 && (column == 1 || column == 2 || column == 10 || column == 11)) ||
                        (row == 11 && column == 0) || (row == 12 && column == 0) || (row == 11 && column == 12) ||
                        (row == 12 && column == 12))
                    {
                        sadFace[row, column] = "@";

                    }
                    else
                    {
                        sadFace[row, column] = " ";
                    }
                }
            }
            for (int row = 0; row < sadFace.GetLength(0); row++)
            {
                for (int column = 0; column < sadFace.GetLength(1); column++)
                {
                    Console.Write(sadFace[row, column]);
                }
                Console.WriteLine();
            }
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
