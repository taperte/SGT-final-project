using System;
using System.Collections.Generic;
using System.Threading;

namespace Hangman_main
{
    class Player : HangmanMusic
    {
        public int IDnumber { get; set; }
        public string Name { get; set; }
        public int IncorrectGuessCount { get; set; }
        public string[,] Hangman { get; set; }
        public ConsoleColor Color { get; set; }


        //This method prints a greeting for a player before adding them to the player list.
        public void PrintGreeting(int number)
        {
            string message1 = $"Good luck, {Name}!";
            string message2 = $"Veiksmi spēlē, {Name}!";
            string message3 = $"Удачи в игре, {Name}!";
            Console.ForegroundColor = Color;
            Console.WriteLine(SwitchLanguage(number, message1, message2, message3));
            Console.ResetColor();
            Greeting();
        }

        //This method chooses a random color from the ConsoleColor enum
        //to assign to a player object property.
        public ConsoleColor ChooseColor(List<Player> players)
        {
            int repititions = 0;
            while (true)
            {
                //The program generates a random number from 2 to 14 (no black, dark blue or white color).
                Random rand = new Random();
                int randomNumber = rand.Next(2, 15);
                //If it equals the index of gray or dark gray the program exits current loop iteration.
                if (randomNumber == 7 || randomNumber == 8)
                {
                    continue;
                }
                //When a proper number is generated, the program checks
                //whether the corresponding color was assiged to previous players already.
                for (int i = 0; i < players.Count; i++)
                {
                    //If random number equals the index of an existing color from player list,
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

        //This method prints player's hangman image in a given color.
        public void PrintHangmanImage(ConsoleColor color)
        {
            Console.ForegroundColor = color;
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

        //This method prints player's hangman image update after incorrect guess.
        public void IncorrectGuess()
        {
            //An integer array is created; the integers in the array will be used
            //as ConsoleColor value indices.
            int[] colorNumbers = ArrayWithRandomNumbers(7);
            for (int i = 0; i < 3; i++)
            {
                PrintHangmanImage((ConsoleColor)colorNumbers[i]);
                Console.ResetColor();
                Console.Beep(NoteFrequency(Note.G4), NoteDuration(8));
                Console.Clear();
            }
            PrintHangmanImage((ConsoleColor)colorNumbers[3]);
            Console.ResetColor();
            Console.Beep(NoteFrequency(Note.E4), NoteDuration(2));
            Thread.Sleep(NoteDuration(8));
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                PrintHangmanImage((ConsoleColor)colorNumbers[i + 4]);
                Console.ResetColor();
                Console.Beep(NoteFrequency(Note.F4), NoteDuration(8));
                Console.Clear();
            }
            //The last image is printed in player's color.
            PrintHangmanImage(Color);
            Console.Beep(NoteFrequency(Note.D4), NoteDuration(2));
        }

        public void Loss(int number)
        {
            string message1 = "YOU'VE LOST!", message2 = "TU ZAUDĒJI!", message3 = "ТЫ ПРОИГРАЛ!";
            string text = SwitchLanguage(number, message1, message2, message3);
            int[] colorNumbers = ArrayWithRandomNumbers(41);
            int j = 20;
            for (int i = 40; i > 0; i -= 2)
            {
                Console.SetCursorPosition(i, j);
                Console.BackgroundColor = (ConsoleColor)colorNumbers[j];
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(text);
                Console.ResetColor();
                if (i % 4 == 0 || i == 2)
                {
                    Thread.Sleep(100);
                    Console.Clear();
                }
                j--;
            }
            Console.BackgroundColor = (ConsoleColor)colorNumbers[0];
            PrintHangmanImage(ConsoleColor.Black);
            Console.Beep(NoteFrequency(Note.A3sh_B3fl), NoteDuration(4));
            Console.Clear();
            Console.BackgroundColor = (ConsoleColor)colorNumbers[1];
            PrintHangmanImage(ConsoleColor.Black);
            Console.Beep(NoteFrequency(Note.A3sh_B3fl), NoteDuration(8, 1));
            Console.Clear();
            Console.BackgroundColor = (ConsoleColor)colorNumbers[2];
            PrintHangmanImage(ConsoleColor.Black);
            Console.Beep(NoteFrequency(Note.A3sh_B3fl), NoteDuration(16));
            Console.Clear();
            Console.BackgroundColor = (ConsoleColor)colorNumbers[3];
            PrintHangmanImage(ConsoleColor.Black);
            Console.Beep(NoteFrequency(Note.A3sh_B3fl), NoteDuration(4));
            Console.Clear();
            Console.BackgroundColor = (ConsoleColor)colorNumbers[4];
            PrintHangmanImage(ConsoleColor.Black);
            Console.Beep(NoteFrequency(Note.C4sh_D4fl), NoteDuration(8, 1));
            Console.Clear();
            Console.BackgroundColor = (ConsoleColor)colorNumbers[5];
            PrintHangmanImage(ConsoleColor.Black);
            Console.Beep(NoteFrequency(Note.C4), NoteDuration(16));
            Console.Clear();
            Console.BackgroundColor = (ConsoleColor)colorNumbers[6];
            PrintHangmanImage(ConsoleColor.Black);
            Console.Beep(NoteFrequency(Note.C4), NoteDuration(8, 1));
            Console.Clear();
            Console.BackgroundColor = (ConsoleColor)colorNumbers[7];
            PrintHangmanImage(ConsoleColor.Black);
            Console.Beep(NoteFrequency(Note.A3sh_B3fl), NoteDuration(16));
            Console.Clear();
            Console.BackgroundColor = (ConsoleColor)colorNumbers[8];
            PrintHangmanImage(ConsoleColor.Black);
            Console.Beep(NoteFrequency(Note.A3sh_B3fl), NoteDuration(8, 1));
            Console.Clear();
            Console.BackgroundColor = (ConsoleColor)colorNumbers[9];
            PrintHangmanImage(ConsoleColor.Black);
            Console.Beep(NoteFrequency(Note.A3sh_B3fl), NoteDuration(16));
            Console.Clear();
            //The last image is printed in player's color.
            Console.BackgroundColor = Color;
            PrintHangmanImage(ConsoleColor.Black);
            Console.Beep(NoteFrequency(Note.A3sh_B3fl), NoteDuration(2));
            Console.ResetColor();
        }

        //This method shows how a hangman image gets updated in the course of the game.
        public void BuildHangmanImage(int number)
        {
            for (IncorrectGuessCount = 0; IncorrectGuessCount < 8; IncorrectGuessCount++)
            {
                string message1, message2, message3;
                if (IncorrectGuessCount == 0)
                {
                    message1 = "0 incorrect guesses:";
                    message2 = "0 nepareizu minējumu:";
                    message3 = "0 неверных догадок:";
                    Console.WriteLine(SwitchLanguage(number, message1, message2, message3));
                    Hangman = CreateHangmanImage();
                }
                else
                {
                    if (IncorrectGuessCount == 1)
                    {
                        message1 = "1 incorrect guess:";
                        message2 = "1 nepareizs minējums:";
                        message3 = "1 неверная догадка:";
                        Console.WriteLine(SwitchLanguage(number, message1, message2, message3));
                    }
                    else if (IncorrectGuessCount != 7)
                    {
                        message1 = $"{IncorrectGuessCount} incorrect guesses:";
                        message2 = $"{IncorrectGuessCount} nepareizi minējumi:";
                        if (IncorrectGuessCount > 1 && IncorrectGuessCount <= 4)
                        {
                            message3 = $"{IncorrectGuessCount} неверные догадки:";
                        }
                        else
                        {
                            message3 = $"{IncorrectGuessCount} неверных догадок:";
                        }
                        Console.WriteLine(SwitchLanguage(number, message1, message2, message3));
                    }
                    else
                    {
                        message1 = $"{IncorrectGuessCount} incorrect guesses — you've lost!";
                        message2 = $"{IncorrectGuessCount} nepareizi minējumi — spēle ir zaudēta!";
                        message3 = $"{IncorrectGuessCount} неверных догадок — игра проиграна!";
                        Console.WriteLine(SwitchLanguage(number, message1, message2, message3));
                    }
                    UpdateHangmanImage();
                }
                PrintHangmanImage(ConsoleColor.Red);
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
    }
}
