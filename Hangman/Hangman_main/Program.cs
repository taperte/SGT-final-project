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

            while (!gameFinished)
            {
                for (int current = 0; current < players.Count;)
                {
                    Player currentPlayer = players[current];
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
                        english = "Invalid input! Try again";
                        latvian = "Kļūda! Mēģini vēlreiz!";
                        russian = "Ошибка! Попробуй ещё раз";
                        Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                        continue;
                    }
                    //If player's input is longer than one character and differs 
                    //from the length of the secret word, another error message appears.
                    if (guess.Length != 1 && guess.Length != secretWord.Length)
                    {
                        english = "You can only guess 1 letter at a time or the whole word. Try again!";
                        latvian = "Tu vari minēt vai nu vienu burtu, vai visu vārdu. Mēģini vēlreiz!";
                        russian = "Ты можешь ввести либо одну букву, либо всё слово. Попробуй ещё раз!";
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                        continue;
                    }
                    //If the list of previous guesses contains current player's guess, an error message appears.
                    if (previousGuesses.Contains(guess))
                    {
                        english = "This guess was entered already. Try another one!";
                        latvian = "Šis minējums jau ir bijis. Mēģini vēlreiz!";
                        russian = "Повтор — попробуй ещё раз!";
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                        continue;
                    }
                    //If the guess is valid, it is added to the list of previous guesses.
                    previousGuesses.Add(guess);
                    //If the player guessed the word, they've won; the game is finished.
                    if (guess == secretWord)
                    {
                        VictoryMusic();
                        Console.ForegroundColor = ConsoleColor.Green;
                        english = $"{currentPlayer.Name}, congrats, you've won the game!";
                        latvian = $"{currentPlayer.Name}, urrā, tu uzvarēji!";
                        russian = $"{currentPlayer.Name}, ура, это победа!";
                        Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                        Console.ResetColor();
                        gameFinished = true;
                        break;
                    }
                    //If the player inputted a letter, the program checks whether the secret word contains it. 
                    else if (secretWord.Contains(guess))
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
                        Console.ForegroundColor = ConsoleColor.Green;
                        english = $"Congrats, \"{guess}\" is a correct guess!";
                        latvian = $"Jā, šajā vārdā ir burts \"{guess}\"!";
                        russian = $"Да, в этом слове есть буква «{guess}»!";
                        Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                    }
                    //Otherwise player's incorrect guess counter and hangman image get updated.
                    else
                    {
                        currentPlayer.IncorrectGuessCount++;
                        currentPlayer.UpdateHangmanImage();
                        //If incorrect guess count < 7, the program plays incorrect guess notification.
                        if (currentPlayer.IncorrectGuessCount < 7)
                        {
                            currentPlayer.IncorrectGuess();
                            Console.ForegroundColor = ConsoleColor.Red;
                            if (guess.Length == 1)
                            {
                                english = $"The word contains no letters \"{guess}\"!";
                                latvian = $"Nē, šajā vārdā nav burta \"{guess}\"!";
                                russian = $"Нет, в этом слове нет буквы «{guess}»!";
                            }
                            else
                            {
                                english = $"No, it's not \"{guess}\"!"; latvian = $"Nē, tas nav \"{guess}\"!";
                                russian = $"Нет, это не «{guess}»!";
                            }
                            Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                        }
                        //If incorrect guess count == 7, the program plays loss notification.
                        else if (currentPlayer.IncorrectGuessCount == 7)
                        {
                            LossMusic();
                            Console.ForegroundColor = ConsoleColor.Red;
                            //If there are more than 1 player, the program prints a message
                            //and removes the loser from the list of players; the game continues.
                            if (players.Count > 1)
                            {
                                english = $"{currentPlayer.Name}, your hangman is completed, so sorry to see you go!";
                                latvian = $"{currentPlayer.Name}, tavas karātavas ir pabeigtas. Cik žēl, ka tu mūs pamet!";
                                russian = $"{currentPlayer.Name}, твоя виселица готова. Как жаль, что ты нас покидаешь!";
                                Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                                players.Remove(currentPlayer);
                            }
                            //Otherwise the game is finished.
                            else
                            {
                                english = $"{currentPlayer.Name}, you've lost, the game is over!";
                                latvian = $"{currentPlayer.Name}, tu zaudēji, spēle ir beigusies!";
                                russian = $"{currentPlayer.Name}, ты проиграл, игра закончена!";
                                Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                                Console.ResetColor();
                                gameFinished = true;
                                break;
                            }
                        }
                    }
                    Console.ResetColor();
                    //When the move is made the program prints current progress.
                    ShowProgress(progress);
                    //Exit
                    //if (guess == SwitchLanguage(language, "out", "iziet", "выйти"))
                    //{

                    //}
                    current++;
                }
            }
        }
    }
}
