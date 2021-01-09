using System;

namespace Hangman_main
{
    class Player : HangmanMethods
    {
        public int IDnumber { get; set; }
        public string Name { get; set; }
        public int IncorrectGuessCount { get; set; }
        public string[,] Hangman { get; set; }
        public ConsoleColor Color { get; set; }


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
        }

        public void PrintPlayerInfo(int number)
        {
            string message1 = "Player's info:";
            string message2 = "Informācija par spēlētāju:";
            string message3 = "Информация об игроке:";
            SwitchLanguage(number, message1, message2, message3);
            Console.WriteLine();

            message1 = "Name: "; message2 = "Vārds: "; message3 = "Имя: ";
            SwitchLanguage(number, message1, message2, message3);
            Console.Write(Name);
            Console.WriteLine();

            message1 = "The number of incorrect guesses: ";
            message2 = "Nepareizu minējumu skaits: ";
            message3 = "Количество неверных догадок: ";
            SwitchLanguage(number, message1, message2, message3);
            Console.Write(IncorrectGuessCount);
            Console.WriteLine();

            PrintHangmanImage();
            Console.WriteLine();
        }
    }
}
