using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman_main
{
    class Player
    {
        public int IDnumber { get; set; }
        public string Name { get; set; }
        public int IncorrectGuessCount { get; set; }
        public string[,] Hangman { get; set; }
        public ConsoleColor Color { get; set; }


        //This method prints a hangman image.
        public void PrintHangmanImage()
        {
            Console.ForegroundColor = Color;
            for (int row = 0; row < Hangman.GetLength(0); row++)
            {
                for (int column = 0; column < Hangman.GetLength(1); column++)
                {
                    Console.Write(Hangman[row, column]);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        public void PrintPlayerInfo()
        {
            Console.WriteLine("Player's info: ");
            Console.WriteLine($"Name: {Name}.");
            Console.WriteLine($"The number of incorrect guesses: {IncorrectGuessCount}.");
            Console.WriteLine($"Player's color: {Color.ToString().ToLower()}.");
            Console.WriteLine("Hangman image:");
            PrintHangmanImage();
            Console.WriteLine();
        }
    }
}
