using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman_main
{
    class Hangman_methods
    {
        //This method switches between languages.
        public static void SwitchLanguage(int number, string message1, string message2, string message3)
        {
            switch (number)
            {
                case 1:
                    Console.Write(message1);
                    break;
                case 2:
                    Console.Write(message2);
                    break;
                default:
                    Console.Write(message3);
                    break;
            }
        }

        //This method creates a certain number of player objects and saves them to a list.
        public static void CreatePlayers(List<Player> players, int number1, int number2, string message1, string message2, string message3)
        {
            for (int i = 0; i < number1; i++)
            {
                //A player enters their name.
                if (number1 == 1)
                {
                    message1 = "Please enter your name: ";
                    message2 = "Lūdzu, ievadiet savu vārdu: ";
                    message3 = "Пожалуйста, введите своё имя: ";
                }
                else
                {
                    message1 = $"Player {i + 1}, please enter your name: ";
                    message2 = $"{i + 1}. spēlētāj, lūdzu, ievadiet savu vārdu: ";
                    message3 = $"Игрок №{i + 1}, пожалуйста, введите своё имя: ";
                }
                SwitchLanguage(number2, message1, message2, message3);
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.Write("Invalid input! ");
                    continue;
                }
                //A player class object is created.
                Player player = new Player()
                {
                    IDnumber = i + 1,
                    Name = input,
                    IncorrectGuessCount = 0,
                    Hangman = CreateHangmanImage(),
                    Color = ChooseColor(players)
                };
                //The object is added to a list.
                players.Add(player);
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

        //This method chooses a random color from the ConsoleColor enum
        //to assign to a player object property.
        public static ConsoleColor ChooseColor(List<Player> players)
        {
            int repititions = 0;
            while (true)
            {
                //The program generates a random number from 0 to 14 (no white color).
                Random rand = new Random();
                int randomNumber = rand.Next(15);
                //If it equals the index of black, dark blue, gray or dark gray,
                //the program exits current loop iteration.
                if (randomNumber == 0 || randomNumber == 1 || randomNumber == 7 || randomNumber == 8)
                {
                    continue;
                }
                //When a proper number is generated, the program checks
                //whether the corresponding color was assiged to a previous player already.
                for (int i = 0; i < players.Count; i++)
                {
                    //If random number equals the index of an existing color from players' list,
                    if (randomNumber == (int)players[i].Color)
                    {
                        //the counter adds 1.
                        repititions++;
                    }
                }
                //If there are no matches,
                if (repititions == 0)
                {
                    //the new color is assigned and the program exits the loop.
                    ConsoleColor color = (ConsoleColor)randomNumber;
                    return color;
                }
                //At the end of iteration, the repitition counter value is restored to 0.
                repititions = 0;
            }
        }
    }
}
