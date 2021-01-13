using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;

namespace Hangman_main
{
    class Program : HangmanMusic
    {
        static void Main(string[] args)
        {
            //Title in the console title bar set to "Hangman".
            Console.Title = "Hangman";
            List<string> ENwords = File.ReadLines("C:\\Users\\''Dell''\\Desktop\\SGT_final_project\\WordListEN_cleaned.txt").ToList();
            List<string> LVwords = File.ReadLines("C:\\Users\\''Dell''\\Desktop\\SGT_final_project\\WordListLV_cleaned.txt").ToList();
            List<string> RUwords = File.ReadLines("C:\\Users\\''Dell''\\Desktop\\SGT_final_project\\WordListRU_cleaned.txt").ToList();
            List<Player> players = new List<Player>();
            List<string> previousGuesses = new List<string>();
            int language, level, playerCount;
            string english, latvian, russian;
            bool gameFinished = false;

            //Change default output encoding to Unicode,
            //so that Latvian and Russian text would be displayed correctly in console.
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            //Player(s) choose(s) language.
            while (true)
            {
                Console.WriteLine("For English, enter 1.\nLai izvēlētos latviešu valodu, ievadi 2.\nЧтобы выбрать русский язык, введи 3.");
                string languageInput = Console.ReadLine();
                if (string.IsNullOrEmpty(languageInput) || !int.TryParse(languageInput, out language))
                {
                    Console.WriteLine("Invalid input! / Kļūda! / Ошибка!");
                    continue;
                }
                if (language < 1 || language > 3)
                {
                    Console.WriteLine("Invalid number! / Nepareizs skaitlis! / Неверное число!");
                    continue;
                }
                else
                {
                    break;
                }
            }
            //When language is chosen the title changes accordingly.
            Console.Title = SwitchLanguage(language, "Hangman", "Karātavas", "Виселица");
            Console.Clear();
            //Info about the game.
            english = "";
            latvian = "";
            russian = "";
            Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
            //The player(s) press(es) enter to proceed. 
            PressEnter(language);
            Player example = new Player();
            example.BuildHangmanImage(language);

            //Player(s) choose(s) level.
            while (true)
            {
                english = "Please choose level (1, 2 or 3): ";
                latvian = "Izvēlies līmeni (1, 2 vai 3): ";
                russian = "Выбери уровень (1, 2 или 3): ";
                Console.Write(SwitchLanguage(language, english, latvian, russian));
                string languageInput = Console.ReadLine();
                if (string.IsNullOrEmpty(languageInput) || !int.TryParse(languageInput, out level))
                {
                    english = "Invalid input! "; latvian = "Kļūda! "; russian = "Ошибка! ";
                    Console.Write(SwitchLanguage(language, english, latvian, russian));
                    continue;
                }
                if (level < 1 || level > 3)
                {
                    english = "Invalid number! "; latvian = "Nepareizs skaitlis! "; russian = "Неверное число! ";
                    Console.Write(SwitchLanguage(language, english, latvian, russian));
                    continue;
                }
                else
                {
                    break;
                }
            }
            //Number of players.
            while (true)
            {
                english = "The number of players: ";
                latvian = "Spēlētāju skaits: ";
                russian = "Количество игроков: ";
                Console.Write(SwitchLanguage(language, english, latvian, russian));
                string playerCountInput = Console.ReadLine();
                if (string.IsNullOrEmpty(playerCountInput) || !int.TryParse(playerCountInput, out playerCount))
                {
                    english = "Invalid input! "; latvian = "Kļūda! "; russian = "Ошибка! ";
                    Console.Write(SwitchLanguage(language, english, latvian, russian));
                    continue;
                }
                if (playerCount < 1 || playerCount > 9)
                {
                    english = "Invalid number! "; latvian = "Nepareizs skaitlis! "; russian = "Неверное число! ";
                    Console.Write(SwitchLanguage(language, english, latvian, russian));
                    continue;
                }
                else
                {
                    break;
                }
            }
            //The program creates player objects and saves them to the list.
            AddPlayers(players, playerCount, language);

            //The program chooses secret word from one of the word lists and saves it to a variable.
            string secretWord = ChooseWordToGuess(ENwords, LVwords, RUwords, language, level);

            //Progress list is created.
            List<string> progress = CreateProgressList(secretWord);

            //The player(s) press(es) enter to proceed. 
            PressEnter(language);

            //The game begins.
            TheGameIsOn(language);
            Thread.Sleep(1500);
            Console.Clear();

            //The program prints the contents of the progress list.
            ShowProgress(progress);

            Player currentPlayer = players[0];
            while (!gameFinished)
            {
                //Current player enters their guess.
                english = $"{currentPlayer.Name}, your guess: ";
                latvian = $"{currentPlayer.Name}, tavs minējums: ";
                russian = $"{currentPlayer.Name}, твой ход: ";
                Console.ResetColor();
                Console.Write(SwitchLanguage(language, english, latvian, russian));
                string guess = Console.ReadLine().ToLower();

                //If the player enters an empty string, an error message appears.
                if (string.IsNullOrEmpty(guess))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    english = "Invalid input! "; latvian = "Kļūda! "; russian = "Ошибка! ";
                    Console.Write(SwitchLanguage(language, english, latvian, russian));
                    continue;
                }
                //If player's input is longer than one character and differs 
                //from of the the length of the secret word, another error message appears.
                if (guess.Length != 1 && guess.Length != secretWord.Length)
                {
                    english = "You can only guess 1 letter at a time or the whole word. Try again!";
                    latvian = "Tu vari minēt vai nu vienu burtu, vai visu vārdu. Mēģini vēlreiz!";
                    russian = "Ты можешь ввести либо одну букву, либо всё слово. Попробуй ещё раз!";
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                    continue;
                }
                //If the guess is valid, it is added to the list of previous guesses.
                previousGuesses.Add(guess);
                //If the list of previous guesses contains current plyer's guess, an error message appears.
                if (previousGuesses.Contains(guess))
                {
                    english = "This guess was entered already. Try another one!";
                    latvian = "Šis minējums jau ir bijis. Mēģini vēlreiz!";
                    russian = "Повтор — попробуй ещё раз!";
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                    continue;
                }
                //If the player inputted a letter, the program checks whether the secret word contains it. 
                if (guess.Length == 1 && secretWord.Contains(guess))
                {
                    for (int i = 0; i < secretWord.Length; i++)
                    {
                        //If the guess is correct, the progress list gets updated.
                        if (guess == secretWord.Substring(i, 1))
                        {
                            progress[i] = guess;
                        }
                    }
                    CorrectGuessMusic();
                }
                else
                {
                    currentPlayer.IncorrectGuessCount++;
                    currentPlayer.UpdateHangmanImage();
                    currentPlayer.IncorrectGuess();
                    Console.ForegroundColor = ConsoleColor.Red;
                    english = "Incorrect guess!"; latvian = "Šāda burta nav!"; russian = "Такой буквы нет!";
                    Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                }
                //Ja šāda burta nav, tad pieskaita vienu punktu pie spēlētāja zaudējumu skaitītāja,
                //nodrukā paziņojumu un apdeito karātavas un nodrukā karātavas.

                Console.ResetColor();
                //9.6) Kad gājiens izdarīts, nodrukā apdeitotu progress array.
                ShowProgress(progress);
                //9.7) Ja skaitītājs == 7, spēlētājs ir zaudējis.gameFinished == true + paziņojums par zaudējumu,
                //!!! kaut kas foršs ar karātavām
                //9.8) Ja inputs sakrīt ar minamo vārdu, gameFinished == true, spēle ir beigusies,
                //paziņojums par uzvaru, !!!! kaut kas foršs ar karātavām
                //9.9) Ja spēlētajs nospiež Esc, iziet no spēles.
                if (guess == SwitchLanguage(language, "out", "iziet", "выйти"))
                {

                }

             
            }
        }
    }
}
