using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the game 'Hangman'!");
            string[] listwords = new string[10];
            listwords[0] = "sheep";
            listwords[1] = "goat";
            listwords[2] = "computer";
            listwords[3] = "america";
            listwords[4] = "watermelon";
            listwords[5] = "icecream";
            listwords[6] = "jasmine";
            listwords[7] = "pineapple";
            listwords[8] = "orange";
            listwords[9] = "mango";
            Random randGen = new Random();
            var word = randGen.Next(0, 9);
            string wordToGuess = listwords[word];
            char[] guess = new char[wordToGuess.Length];
            Console.Write("Please enter your guess: ");

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                guess[i] = '*';
            }


            while (true)
            {
                char playerGuess = char.Parse(Console.ReadLine());
                for (int j = 0; j < wordToGuess.Length; j++)
                {
                    if (playerGuess == wordToGuess[j])
                        guess[j] = playerGuess;
                }
                Console.WriteLine(guess);
            }
        }
    }
}
