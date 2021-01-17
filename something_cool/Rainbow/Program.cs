using System;
using System.Collections.Generic;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Rainbow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = ("HangMan Game");
            List<string> listToChooseFrom = new List<string> { "sheep", "goat", "computer", "america", "watermelon", "icecream", "jasmine", "pineapple", "orange", "mango" };
            Random random = new Random();
            string secretword = listToChooseFrom[random.Next(0, listToChooseFrom.Count)];
            List<string> previousGuesses = new List<string>();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            CheckIfItIsLetter(secretword, previousGuesses);
            bool isGameFinished = false;
            string usedLetters = string.Empty;
            while (!isGameFinished)
            {
                Console.WriteLine("Please enter a guess!");
                Console.ForegroundColor = ConsoleColor.Green;
                string input = Console.ReadLine();
                if (previousGuesses.Contains(input))
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
                if (input.Length != 1/* && input != secretword*/)
                {
                    Console.WriteLine("Nice try. You can only guess 1 letter at a time or whole word. Try again!");
                    continue;
                }
                previousGuesses.Add(input);
                //Jāsalīdzina spēlētāja inputs ar minamo vārdu, nevis minamais vārds ar sarakstu, kurā glabājas iepriekšējie minējumi.
                //Šim nav vajadzīga īpaša metode. if input == secretword — tas arī viss, kas ir vajadzīgs.
                if (CheckIfItIsWord(secretword, previousGuesses))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(secretword);
                    Console.WriteLine("Congratulations");
                    break;
                }
                else if (secretword.Contains(input))
                {
                    Console.WriteLine("Nice Entry");
                    string letters = CheckIfItIsLetter(secretword, previousGuesses);
                    Console.Write(letters);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Letter is not in this word");
                    Console.ResetColor();
                }
                Console.WriteLine();

                ShowAllGuesses(previousGuesses);
            }
            Console.ReadKey();
            
        }
        static bool CheckIfItIsWord(string someWord, List<string> someList)
        {
            bool word = false;
            for (int i = 0; i < someWord.Length; i++)
            {
                string c = Convert.ToString(someWord[i]);
                if (someList.Contains(c))
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

        static string CheckIfItIsLetter(string secretword, List<string> letterGuessed)
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
        public static void ShowAllGuesses(List<string> previousGuesses)
        {
            Console.Write("Letters: ");
            for (int i = 0; i < previousGuesses.Count; i++)
            {
                if (previousGuesses[i].Length == 1)
                {
                    Console.Write(previousGuesses[i] + " ");
                }
            }
            Console.WriteLine();
            Console.Write("Words: ");
            for (int i = 0; i < previousGuesses.Count; i++)
            {
                if (previousGuesses[i].Length > 1)
                {
                    Console.Write(previousGuesses[i] + " ");
                }
            }
            Console.WriteLine();
            
            
        }

    }
    
}
