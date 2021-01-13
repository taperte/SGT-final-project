using System;
using System.Collections.Generic;

namespace if_validations
{
    class Program
    {
        static void Main()
        {
            Console.Title = ("HangMan Game");
            List<string> listToChooseFrom = new List<string> { "sheep", "goat", "computer", "america", "watermelon", "icecream", "jasmine", "pineapple", "orange", "mango" };
            Random random = new Random();
            string secretword = listToChooseFrom[random.Next(0, listToChooseFrom.Count)];
            List<string> letterGuessed = new List<string>();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            CheIfItIsLetter(secretword, letterGuessed);
            bool isGameFinished = false;
            while (!isGameFinished)
            {
                Console.WriteLine("Please enter a guess!");
                Console.ForegroundColor = ConsoleColor.Green;
                string input = Console.ReadLine();
                if (letterGuessed.Contains(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You Entered Letter '{input}' already");
                    Console.ResetColor();
                    continue;
                }
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please don't input empty values!");
                    continue;
                }
                if (input.Length != 1 && input != secretword)
                {
                    Console.WriteLine("Nice try. You can only guess 1 letter at a time or whole word. Try again!");
                    continue;
                }
                letterGuessed.Add(input);
                if (CheckIfItIsWord(secretword, letterGuessed))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(secretword);
                    Console.WriteLine("Congratulations");
                    break;
                }
                else if (secretword.Contains(input))
                {
                    Console.WriteLine("Nice Entry");
                    string letters = CheIfItIsLetter(secretword, letterGuessed);
                    Console.Write(letters);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Letter is not in this word");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static bool CheckIfItIsWord(string secreword, List<string> letterGuessed)
        {
            bool word = false;
            for (int i = 0; i < secreword.Length; i++)
            {
                string c = Convert.ToString(secreword[i]);
                if (letterGuessed.Contains(c))
                {
                    word = true;
                }
                else
                {
                    return word = false;
                }
            }
            return word;
        }
        static string CheIfItIsLetter(string secretword, List<string> letterGuessed)
        {
            string correctletters = "";
            for (int i = 0; i < secretword.Length; i++)
            {
                string c = Convert.ToString(secretword[i]);
                if (letterGuessed.Contains(c))
                {
                    correctletters += c;
                }
                else
                {
                    correctletters += "_ ";
                }
            }
            return correctletters;
        }
    }
}
