using System;
using System.Collections.Generic;

namespace Hangman_main
{
    class Player : HangmanMethods
    {
        public int IDnumber { get; set; }
        public string Name { get; set; }
        public int IncorrectGuessCount { get; set; }
        public string[,] Hangman { get; set; }
        public ConsoleColor Color { get; set; }

        //This method creates a certain number of player objects and saves them to a list.
        public static void AddPlayers(List<Player> players, int number1, int number2)
        {
            string message1, message2, message3;
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
                    message2 = $"{i + 1}. spēlētājs, lūdzu, ievadiet savu vārdu: ";
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
                };
                //A color is assigned to the player.
                player.ChooseColor(players);
                //The program prints greeting for the player and adds them to the list.
                player.PrintGreeting(number1);
                players.Add(player);
            }
        }

        public void PrintGreeting(int number)
        {
            string message1 = $"Good luck, {Name}!";
            string message2 = $"Veiksmi spēlē, {Name}!";
            string message3 = $"Удачи в игре, {Name}!";
            SwitchLanguage(number, message1, message2, message3);
            Console.WriteLine();
        }

        //This method chooses a random color from the ConsoleColor enum
        //to assign to a player object property.
        private ConsoleColor ChooseColor(List<Player> players)
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
                    Color = (ConsoleColor)randomNumber;
                    return Color;
                }
                //At the end of iteration, the repitition counter value is restored to 0.
                repititions = 0;
            }
        }

        //This methods adds elements to player's hangman image
        //depending on their incorrect guess score.
        public void UpdateHangmanImage()
        {
            switch (IncorrectGuessCount)
            {
                case 1:
                    Hangman[2, 5] = "|";
                    break;
                case 2:
                    Hangman[3, 5] = "O";
                    break;
                case 3:
                    Hangman[4, 5] = "|";
                    Hangman[5, 5] = "|";
                    break;
                case 4:
                    Hangman[4, 4] = "/";
                    break;
                case 5:
                    Hangman[4, 6] = "\\";
                    break;
                case 6:
                    Hangman[6, 4] = "/";
                    break;
                case 7:
                    Hangman[6, 6] = "\\";
                    break;
                default:
                    break;
            }
        }

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
            Console.WriteLine();
        }
    }
}
