using System;
using System.Collections.Generic;
using System.Threading;

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
                Thread.Sleep(2000);
                Console.Clear();
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
        public static string ChooseSecretWord(List<string> list1, List<string> list2, List<string> list3, int number1, int number2)
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
        //If there is a hyphen in the string, the spot in the list 
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

        //This method updates the progress list.
        public static void UpdateProgressList(string someString1, string someString2, List<string> someList)
        {
            for (int i = 0; i < someString2.Length; i++)
            {
                if (someString1 == someString2.Substring(i, 1))
                {
                    someList[i] = someString1;
                    if (i != 0 && someList[i - 1] == "_ ")
                    {
                        someList[i - 1] = "_";
                    }
                }
            }
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
            Console.ForegroundColor = (ConsoleColor)ArrayWithRandomNumbers(number2)[rand.Next(number2)];
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, number1);
            Console.WriteLine(text);
            Console.ResetColor();
        }

        //This method asks user to input any key and then clears console.
        public static void Proceed(int number)
        {
            string message1 = "Press any key to proceed.";
            string message2 = "Lai turpinātu, spied jebkuru taustiņu.";
            string message3 = "Чтобы продолжить, нажми любую клавишу.";
            Console.WriteLine(SwitchLanguage(number, message1, message2, message3));
            while (true)
            {
                if (!Console.KeyAvailable)
                {
                    Thread.Sleep(1);
                    continue;
                }
                else
                {
                    var key = Console.ReadKey(true);
                    break;
                } 
            }
            Console.Clear();
        }

        //This methods prints the contents of the list with previous guesses.
        public static void ShowPreviousGuesses(int number, List<string> someList)
        {
            int letters = 0;
            int words = 0;
            //The program counts letters and words in the list.
            foreach (var item in someList)
            {
                if (item.Length == 1)
                {
                    letters++;
                }
                if (item.Length > 1)
                {
                    words++;
                }
            }
            //If there are any letters, prints them.
            if (letters != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(SwitchLanguage(number, "Letters: ", "Burti: ", "Буквы: "));
                Console.ResetColor();
                for (int i = 0; i < someList.Count; i++)
                {
                    if (someList[i].Length == 1)
                    {
                        Console.Write(someList[i] + " ");
                    }
                }
                Console.WriteLine(); 
            }
            //If there are any words, prints them.
            if (words != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(SwitchLanguage(number, "Words: ", "Vārdi: ", "Слова: "));
                Console.ResetColor();
                for (int i = 0; i < someList.Count; i++)
                {
                    if (someList[i].Length > 1)
                    {
                        Console.Write(someList[i] + " ");
                    }
                }
                Console.WriteLine(); 
            }
            //If the list is empty, prints a message.
            if (someList.Count == 0)
            {
                string message1 = "The list of previous guesses is empty.";
                string message2 = "Minējumu saraksts ir tukšs.";
                string message3 = "Список предыдущих ходов пуст.";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(SwitchLanguage(number, message1, message2, message3));
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        //This method displays the list of keywords for extra functionality.
        public static void ShowKeywords(int number, string someString1, string someString2, string someString3)
        {
            string message1 = "Useful keywords:";
            string message2 = "Noderīgi atslēgvārdi:";
            string message3 = "Полезные фразы:";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(SwitchLanguage(number, message1, message2, message3));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(someString1 + " ");
            Console.ResetColor();
            message1 = "— exit the game;";
            message2 = "— iziet no spēles;";
            message3 = "— выйти из игры;";
            Console.Write(SwitchLanguage(number, message1, message2, message3));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(someString2 + " ");
            Console.ResetColor();
            message1 = "— see previous guesses;";
            message2 = "— apskatīties iepriekšējos minējumus;";
            message3 = "— посмотреть предыдущие ходы;";
            Console.Write(SwitchLanguage(number, message1, message2, message3));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(someString3 + " ");
            Console.ResetColor();
            message1 = "— see current player's score.";
            message2 = "— apskatīties pašreizējā spēlētāja karātavas.";
            message3 = "— посмотреть счёт действующего игрока.";
            Console.Write(SwitchLanguage(number, message1, message2, message3));
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
