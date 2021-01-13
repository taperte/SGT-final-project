using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pilnais karātavu zīmējums
            string[,] hangman = new string[10, 11];
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


            //Nodrukā karātavas
            for (int row = 0; row < hangman.GetLength(0); row++)
            {
                for (int column = 0; column < hangman.GetLength(1); column++)
                {
                    Console.Write(hangman[row, column]);
                }
                Console.WriteLine();
            }
        }
    }
}
