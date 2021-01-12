using System;
using System.Collections.Generic;

namespace Hangman_main
{
    class HangmanMethods
    {
        //This method switches between languages.
        public static string SwitchLanguage(int number, string message1, string message2, string message3)
        {
            return number switch
            {
                1 => message1,
                2 => message2,
                _ => message3,
            };
        }

        //This method creates an initial hangman image. 
        public static string[,] CreateHangmanImage()
        {
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
                    else if ((column == 2 || column == 8) && row != 0 && row != 1 && row != hangman.GetLength(0))
                    {
                        hangman[row, column] = "|";
                    }
                    else if (row == hangman.GetLength(0) - 2 && (column == 1 || column == 7))
                    {
                        hangman[row, column] = "/";
                    }
                    else if (row == hangman.GetLength(0) - 2 && (column == 3 || column == 9))
                    {
                        hangman[row, column] = "\\";
                    }
                    else
                    {
                        hangman[row, column] = " ";
                    }
                }
            }
            return hangman;
        }

        //This method chooses the secret word from the word lists.
        public static string ChooseWordToGuess(List<string> list1, List<string> list2, List<string> list3, int number1, int number2)
        {
            //The program selects the list to choose from according to player's choice of language.
            List<string> listToChooseFrom = new List<string>();
            if (number1 == 1)
            {
                listToChooseFrom = list1;
            }
            else if (number1 == 2)
            {
                listToChooseFrom = list2;
            }
            else if (number1 == 3)
            {
                listToChooseFrom = list3;
            }
            //Then selects a word according to player's choice of level.
            while (true)
            {
                Random random = new Random();
                string wordToGuess = listToChooseFrom[random.Next(listToChooseFrom.Count)];
                if (number2 == 1)
                {
                    if (wordToGuess.Length <= 5)
                    {
                        return wordToGuess;
                    }
                }
                else if (number2 == 2)
                {
                    if (5 < wordToGuess.Length && wordToGuess.Length <= 7)
                    {
                        return wordToGuess;
                    }
                }
                else if (number2 == 3)
                {
                    if (wordToGuess.Length > 7)
                    {
                        return wordToGuess;
                    }
                }
            }
        }

        //This method receives a string value, creates a string array with the size == string.Length
        //and fills it with "_ ". If there is a hyphen in the string value, the spot in the array 
        //with the corresponding index is filled with a hyphen, too.
        public static string[] CreateProgressArray(string someString)
        {
            string[] someArray = new string[someString.Length];
            for (int i = 0; i < someString.Length; i++)
            {
                if (someString.Substring(i, 1) == "-")
                {
                    if (i != 0)
                    {
                        someArray[i - 1] = "_";
                    }
                    someArray[i] = "-";
                }
                else
                {
                    someArray[i] = "_ ";
                }
            }
            return someArray;
        }

        //This method prints the progress array.
        public static void ShowProgress(string[] someArray)
        {
            for (int i = 0; i < someArray.Length; i++)
            {
                if (someArray[i] == "_ " || someArray[i] == "_" || someArray[i] == "-")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(someArray[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(someArray[i]);
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        //This method creates an integer array of a given size 
        //and fills it with random numbers from 2 to 14;
        //the same number can be generated more than once, but not in a row.
        public static int[] ArrayWithRandomNumbers(int number)
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

        //This method prints centered text in a random color on a certain line.
        public static void CenteredTextInColor(string message, int number1, int number2)
        {
            Random rand = new Random();
            Console.SetCursorPosition(0, number1);
            Console.ForegroundColor = (ConsoleColor)ArrayWithRandomNumbers(number2)[rand.Next(number2)];
            CenterText(message);
            Console.ResetColor();
        }

        public static void CenterText(string text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }
    }
}
