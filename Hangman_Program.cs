using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangmen_draft
{


    class Program
    {
        static string[] listWordsLV = {"skapis", "putra", "lielveikals" };
        static string[] listWordsRU = { "приговор", "язык", "машина" };
        static string[] listWordsENG = { "sheep", "goat", "computer", "america", "watermelon", "icecream", "jasmine", "pineapple", "orange", "mango" };
        static void Main(string[] args)
        {

            string response = "";
            Console.WriteLine("Please choose a language: 1:ENG 2:RU 3:LV 4:Exit");
            response = Console.ReadLine();
            ChooseWordToGuess(response);



        }
        static void PlayENG()
        {
            int lives = 5;
            bool won = false;
            int lettersRevealed = 0;
            while (!won && lives > 0)
            {
                Console.WriteLine("Welcome to the game 'Hangman'!");
                Random randGen = new Random();
                var word = randGen.Next(0, 9);
                string wordToGuess = listWordsENG[word];
                char[] guess = new char[wordToGuess.Length];
                Console.Write("Please enter your guess: ");

                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    guess[i] = '*';
                }
            }

        }
        static void PlayRU()
        {
            int lives = 5;
            bool won = false;
            int lettersRevealed = 0;
            while (!won && lives > 0)
            {
                Console.WriteLine("Добро пожаловать в игру 'Вешалки!'");
                Random randGen = new Random();
                var word = randGen.Next(0, 9);
                string wordToGuess = listWordsRU[word];
                char[] guess = new char[wordToGuess.Length];
                Console.Write("Ваше предположение: ");

                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    guess[i] = '*';
                }
            }

        }
        static void PlayLV()
        {
            int lives = 5;
            bool won = false;
            int lettersRevealed = 0;
            while (!won && lives > 0)
            {
                Console.WriteLine("Laipni lūdzu spēlē 'Karātavas'!");
                Random randGen = new Random();
                var word = randGen.Next(0, 9);
                string wordToGuess = listWordsLV[word];
                char[] guess = new char[wordToGuess.Length];
                Console.Write("Tavs minējums: ");

                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    guess[i] = '*';
                }
            }

        }
        private static void ChooseWordToGuess(string response)
        {

            
            do
            {
                switch (response)
                {
                    case "1":
                        PlayENG();
                        break;
                    case "2":
                        PlayRU();
                        break;
                    case "3":
                        PlayLV();
                        break;
                    case "4":
                        break;
                } 
            } while (response != "4");
        }
    }
}
