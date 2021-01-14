﻿using System;
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

        //This method creates a certain number of player objects and saves them to a list.
        public static void AddPlayers(List<Player> players, int number1, int number2)
        {
            string message1, message2, message3;
            for (int i = 0; i < number1;)
            {
                //A player enters their name.
                if (number1 == 1)
                {
                    message1 = "Please enter your name: ";
                    message2 = "Lūdzu, ievadi savu vārdu: ";
                    message3 = "Пожалуйста, введи своё имя: ";
                }
                else
                {
                    message1 = $"Player {i + 1}, please enter your name: ";
                    message2 = $"{i + 1}. spēlētājs, lūdzu, ievadi savu vārdu: ";
                    message3 = $"Игрок №{i + 1}, пожалуйста, введи своё имя: ";
                }
                Console.Write(SwitchLanguage(number2, message1, message2, message3));
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    message1 = "Invalid input! ";
                    message2 = "Kļūda! ";
                    message3 = "Ошибка! ";
                    Console.Write(SwitchLanguage(number2, message1, message2, message3));
                    continue;
                }
                //A player class object is created.
                Player player = new Player()
                {
                    IDnumber = i + 1,
                    Name = input,
                    IncorrectGuessCount = 0,
                    Hangman = CreateHangmanImage(),
                };
                //A color is assigned to the player.
                player.ChooseColor(players);
                //The program prints greeting for the player and adds them to the list.
                player.PrintGreeting(number2);
                players.Add(player);
                i++;
            }
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
                string word = listToChooseFrom[random.Next(listToChooseFrom.Count)];
                if (number2 == 1)
                {
                    if (word.Length <= 5)
                    {
                        return word;
                    }
                }
                else if (number2 == 2)
                {
                    if (5 < word.Length && word.Length <= 7)
                    {
                        return word;
                    }
                }
                else if (number2 == 3)
                {
                    if (word.Length > 7)
                    {
                        return word;
                    }
                }
            }
        }

        //This method receives a string value, creates a string list and fills it with "_ ".
        //If there is a hyphen in the string value, the spot in the list 
        //with the corresponding index is filled with a hyphen, too.
        public static List<string> CreateProgressList(string someString)
        {
            List<string> someList = new List<string>();
            for (int i = 0; i < someString.Length; i++)
            {
                if (someString.Substring(i, 1) == "-")
                {
                    if (i != 0)
                    {
                        someList[i - 1] = "_";
                    }
                    someList.Add("-");
                }
                else
                {
                    someList.Add("_ ");
                }
            }
            return someList;
        }

        //This method prints the progress list.
        public static void ShowProgress(List<string> someList)
        {
            for (int i = 0; i < someList.Count; i++)
            {
                if (someList[i] == "_ " || someList[i] == "_" || someList[i] == "-")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(someList[i]);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(someList[i]);
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
        public static void CenteredTextInColor(string text, int number1, int number2)
        {
            Random rand = new Random();
            Console.SetCursorPosition(0, number1);
            Console.ForegroundColor = (ConsoleColor)ArrayWithRandomNumbers(number2)[rand.Next(number2)];
            CenterText(text);
            Console.ResetColor();
        }

        //This method prints centered text.
        public static void CenterText(string text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }

        //This method asks user to input ENTER and then clears console.
        public static void PressEnter(int number)
        {
            while (true)
            {
                string message1 = "Press ENTER to proceed: ";
                string message2 = "Lai turpinātu, spied ENTER: ";
                string message3 = "Чтобы продолжить, нажми ENTER: ";
                Console.WriteLine(SwitchLanguage(number, message1, message2, message3));
                if (!string.IsNullOrEmpty(Console.ReadLine()))
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            Console.Clear();
        }
    }
}
