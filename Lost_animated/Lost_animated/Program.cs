using System;
using System.Threading;

namespace Lost_animated
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
            //Pilnais karātavu zīmējums
            string[,] hangman = new string[10, 11];
            int j = 0;
            for (int i = 0; i < 30; i++)
            {
                for (int row = 0; row < hangman.GetLength(0); row++)
                {
                    for (int column = 0; column < hangman.GetLength(1); column++)
                    {
                        if (((row == 0 || row == hangman.GetLength(0) - 1) && column % 2 == 0) ||
                            column == 0 || column == hangman.GetLength(1) - 1)
                        {
                            hangman[row, column] = "*";
                        }
                        else if (row == 1 && column != 0 && column != 1 &&
                                 column != hangman.GetLength(1) - 2 && column != hangman.GetLength(1) - 1)
                        {
                            hangman[row, column] = "—";
                        }
                        else if (((column == 2 || column == 8) && row != 0 && row != 1 && row != hangman.GetLength(0)) ||
                                  (column == 5 && (row == 2 || row == 4 || row == 5)))
                        {
                            hangman[row, column] = "|";
                        }
                        else if (row == 3 && column == 5)
                        {
                            hangman[row, column] = "O";
                        }
                        else if ((column == 4 && (row == 4 || row == 6)) || (row == hangman.GetLength(0) - 2 && (column == 1 || column == 7)))
                        {
                            hangman[row, column] = "/";
                        }
                        else if ((column == 6 && (row == 4 || row == 6)) || (row == hangman.GetLength(0) - 2 && (column == 3 || column == 9)))
                        {
                            hangman[row, column] = "\\";
                        }
                        else
                        {
                            hangman[row, column] = " ";
                        }
                    }
                }
            }
            //LOOSING ANNOUCMENT
            for (int row = 0; row < hangman.GetLength(0); row++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                for (int column = 0; column < hangman.GetLength(1); column++)
                {
                    Console.Write(hangman[row, column]);
                    Thread.Sleep(10);
                }
                Console.ResetColor();
                Console.WriteLine();
            }
            Console.Clear();

            for (int i = 0; i < 35; i++)
            {

                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(i, j);
                i++; j++;
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
