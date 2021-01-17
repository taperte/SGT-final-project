using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using System.Text;

namespace Hangman_main
{
    class Program : HangmanMusic
    {
        static void Main(string[] args)
        {
            //Title in the console title bar is set to "Hangman".
            Console.Title = "Hangman";
            List<string> ENwords = File.ReadLines("C:\\Users\\''Dell''\\Desktop\\SGT_final_project\\WordListEN_cleaned.txt").ToList();
            List<string> LVwords = File.ReadLines("C:\\Users\\''Dell''\\Desktop\\SGT_final_project\\WordListLV_cleaned.txt").ToList();
            List<string> RUwords = File.ReadLines("C:\\Users\\''Dell''\\Desktop\\SGT_final_project\\WordListRU_cleaned.txt").ToList();
            List<Player> players = new List<Player>();
            List<string> previousGuesses = new List<string>();
            int language, level, playerCount;
            string english, latvian, russian;

            //Input and output encoding changed to Unicode, so that Latvian and Russian text
            //would be displayed correctly in the console.
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            while (true)
            {
                bool gameFinished = false;
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
                english = "Welcome to the Hangman game!" +
                          "\nHangman is a word guessing game. The program chooses a random word, and players try to guess it." +
                          "\nYou can play alone or in a group (the game allows up to 11 people)." +
                          "\nFirst of all, you choose level: 1st level — 4 or 5 letters," +
                          "\n2nd level — 6 or 7 letters, 3rd level — 8 letters and up." +
                          "\nThen you enter the number of players and their names." +
                          "\nPlayers enter their guesses in turns. A player can enter either a letter or a whole word." +
                          "\nIf the guess is incorrect, player's hangman image gets updated." +
                          "\nWhen the image is completed, the player looses.";
                latvian = "Laipni lūgti spēlē \"Karātavas\"!" +
                          "\n\"Karātavas\" ir vārdu minēšanas spēle. Programma izvēlas vārdu, un spēlētāji mēģina to uzminēt." +
                          "\nTu vari spēlēt viens pats vai ar draugiem (spēle atļauj līdz 11 dalībniekiem)." +
                          "\nVispirms ir jāizvēlas līmenis: 1. līmenis — 4 vai 5 burti;" +
                          "\n2. līmenis — 6 vai 7 burti; 3. līmenis — 8 burti un vairāk." +
                          "\nTad ir jāievada spēlētāju skaits un viņu vārdi." +
                          "\nSpēlētāji pēc kārtas ievada savu minējumu — vai nu vienu burtu, vai visu vārdu." +
                          "\nJa minējums ir nepareizs, spēlētāja karātavaas tiek papildinātas ar jaunu elementu." +
                          "\nKad karātavu zīmējums ir pabeigts, spēlētājs zaudē un izstājas no spēles.";
                russian = "Добро пожаловать в игру «Виселица»!" +
                          "\nЭто игра в слова: программа выбирает случайное слово, и задача игроков его отгадать." +
                          "\nВ неё можно играть одному или с друзьями (игра допускает до 11 участников)." +
                          "\nСначала нужно выбрать уровень: 1-й уровень — 4—5 букв," +
                          "\n2-й уровень — 6—7 букв, 3-й уровень — от 8 букв." +
                          "\nЗатем надо ввести количество игроков и их имена." +
                          "\nИгроки по очереди делают ход — можно отгадывать либо одну букву, либо всё слово." +
                          "\nЕсли догадка ошибочна, к виселице игрока дорисовывается элемент." +
                          "\nТот, чья виселица закончена, проигрывает и выходит из игры.";
                Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                Console.WriteLine();
                //The player(s) press(es) any key to proceed. 
                Proceed(language);

                //A player object is created to show how player's hangman image is updated in the course of the game.
                Player example = new Player();
                example.BuildHangmanImage(language);
                english = "The winner is the player who guesses the last letter or enters the secret word." +
                          "\nOnce the game has started, you can enter \"out\" to either exit the game or start a new one." +
                          "\nTo see the list of previous guesses, enter \"show guesses\"." +
                          "\nTo see your score, enter \"show hangman\"." +
                          "\nWhen the game is finished, you can either exit or start a new game.";
                latvian = "Uzvar spēlētājs, kurš ir uzminējis vārdu vai pareizi ievadījis vārda pēdējo burtu." +
                          "\nKad spēle ir sākusies, tu vari ievadīt \"iziet\", lai pamestu spēli pavisam vai sāktu jaunu spēli." +
                          "\nLai redzētu iepriekšējos minējumus, ievadi \"parādīt minējumus\"." +
                          "\nLai aplūkotu savu karātavu attēlu, ievadi \"parādīt karātavas\"." +
                          "\nKad spēle ir beigusies, tu vari iziet no spēles pavisam vai uzsākt jaunu.";
                russian = "Побеждает игрок, который правильно угадывает слово или последнюю букву." +
                          "\nПосле того как игра началась, ты можешь ввести «выйти», чтобы покинуть игру или начать новую." +
                          "\nЧтобы посмотреть предыдущие ходы, введи «показать ходы»." +
                          "\nЧтобы посмотреть свой счёт, введи «показать виселицу»." +
                          "\nПосле окончания игры ты сможешь выйти или начать новую игру." +
                          "\nВ игре используется буква «ё».";
                Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                Console.WriteLine();
                Proceed(language);


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
                Console.Clear();

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
                    if (playerCount < 1 || playerCount > 11)
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
                Console.Clear();

                //The program creates player objects and saves them to the list.
                AddPlayers(players, playerCount, language);

                //The program chooses secret word from one of the word lists and saves it to a variable.
                string secretWord = ChooseSecretWord(ENwords, LVwords, RUwords, language, level);
                secretWord = secretWord.ToLower();

                //Progress list is created.
                List<string> progress = CreateProgressList(secretWord);

                //The game begins.
                TheGameIsOn(language);
                Thread.Sleep(2000);
                Console.Clear();

                string exit = SwitchLanguage(language, "out", "iziet", "выйти");
                string showGuesses = SwitchLanguage(language, "show guesses", "parādīt minējumus", "показать ходы");
                string showScore = SwitchLanguage(language, "show hangman", "parādīt karātavas", "показать виселицу");

                //The program prints the contents of the progress list.
                ShowProgress(progress);
                while (!gameFinished)
                {
                    for (int current = 0; current < players.Count;)
                    {
                        Player currentPlayer = players[current];
                        //Current player enters their guess.
                        Console.ForegroundColor = currentPlayer.Color;
                        Console.Write(currentPlayer.Name);
                        Console.ResetColor();
                        english = ", your guess: ";
                        latvian = ", tavs minējums: ";
                        russian = ", твой ход: ";
                        Console.Write(SwitchLanguage(language, english, latvian, russian));
                        string guess = Console.ReadLine();
                        guess = guess.ToLower();
                        //If the player enters an empty string, an error message appears.
                        if (string.IsNullOrEmpty(guess))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            english = "Invalid input! Try again";
                            latvian = "Kļūda! Mēģini vēlreiz!";
                            russian = "Ошибка! Попробуй ещё раз!";
                            Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                            continue;
                        }
                        //If player's input is longer than one character, differs from the length 
                        //of the secret word, another error message appears.
                        if (guess.Length != 1 && guess.Length != secretWord.Length &&
                            guess != exit && guess != showGuesses && guess != showScore)
                        {
                            english = "You can only guess one letter at a time or the whole word. Try again!";
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
                        if (guess == showGuesses)
                        {
                            Console.WriteLine();
                            ShowPreviousGuesses(language, previousGuesses);
                            continue;
                        }
                        if (guess == showScore)
                        {
                            Console.WriteLine();
                            currentPlayer.PrintHangmanImage(currentPlayer.Color);
                            continue;
                        }
                        //If the guess is valid, it is added to the list of previous guesses.
                        if (guess != exit && guess != showGuesses && guess != showScore)
                        {
                            previousGuesses.Add(guess); 
                        }
                        //If the player enters the exit word, gameFinished is set to true.
                        if (guess == exit)
                        {
                            gameFinished = true;
                        }
                        //If the player guessed the word, they've won; the game is finished.
                        else if (guess == secretWord)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(secretWord);
                            Console.ResetColor();
                            Thread.Sleep(2000);
                            Console.Clear();
                            Victory(language);
                            Console.ForegroundColor = ConsoleColor.Green;
                            english = $"{currentPlayer.Name}, congrats, you've won the game!";
                            latvian = $"{currentPlayer.Name}, urrā, tu uzvarēji!";
                            russian = $"{currentPlayer.Name}, ура, ты победил!";
                            Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                            Console.ResetColor();
                            gameFinished = true;
                        }
                        //If the player inputted a letter, the program checks whether the secret word contains it. 
                        else if (secretWord.Contains(guess) && guess != exit)
                        {
                            //If the guess is correct, the progress list gets updated.
                            UpdateProgressList(guess, secretWord, progress);
                            //If the updated list still contains underscores, the program plays correct guess notification.
                            if (progress.Contains("_ ") || progress.Contains("_"))
                            {
                                Thread.Sleep(1000);
                                Console.Clear();
                                CorrectGuess(language);
                                Console.ForegroundColor = ConsoleColor.Green;
                                english = $"Congrats, \"{guess}\" is a correct guess!";
                                latvian = $"Jā, šajā vārdā ir burts \"{guess}\"!";
                                russian = $"Да, в этом слове есть буква «{guess}»!";
                                Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                            }
                            //If there are no underscores left, the player has won; the game is finished.
                            else
                            {
                                ShowProgress(progress);
                                Thread.Sleep(2000);
                                Console.Clear();
                                Victory(language);
                                Console.ForegroundColor = ConsoleColor.Green;
                                english = $"{currentPlayer.Name}, congrats, you've won the game!";
                                latvian = $"{currentPlayer.Name}, urrā, tu uzvarēji!";
                                russian = $"{currentPlayer.Name}, ура, ты победил!";
                                Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                                Console.ResetColor();
                                gameFinished = true;
                            }
                        }
                        //Otherwise player's incorrect guess counter and hangman image get updated.
                        else
                        {
                            currentPlayer.IncorrectGuessCount++;
                            currentPlayer.UpdateHangmanImage();
                            Thread.Sleep(1000);
                            Console.Clear();
                            //If incorrect guess count < 7, the program plays incorrect guess notification.
                            if (currentPlayer.IncorrectGuessCount < 7)
                            {
                                currentPlayer.IncorrectGuess();
                                Console.ForegroundColor = ConsoleColor.Red;
                                if (guess.Length == 1)
                                {
                                    english = $"There is no letter \"{guess}\" in this word!";
                                    latvian = $"Nē, šajā vārdā nav burta \"{guess}\"!";
                                    russian = $"Нет, в этом слове нет буквы «{guess}»!";
                                }
                                else
                                {
                                    english = $"No, it's not \"{guess}\"!";
                                    latvian = $"Nē, tas nav \"{guess}\"!";
                                    russian = $"Нет, это не «{guess}»!";
                                }
                                Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                            }
                            //If incorrect guess count == 7, the program plays loss notification.
                            else if (currentPlayer.IncorrectGuessCount == 7)
                            {
                                currentPlayer.Loss(language);
                                Console.ForegroundColor = ConsoleColor.Red;
                                //If there are more than 1 player, the program prints a message
                                //and removes the loser from the list of players; the game continues.
                                if (players.Count > 1)
                                {
                                    english = $"{currentPlayer.Name}, your hangman is completed. So sorry to see you go!";
                                    latvian = $"{currentPlayer.Name}, tavas karātavas ir pabeigtas. Cik žēl, ka tu mūs pamet!";
                                    russian = $"{currentPlayer.Name}, твоя виселица готова. Как жаль, что ты нас покидаешь!";
                                    Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                                    players.Remove(currentPlayer);
                                }
                                //Otherwise the game is finished.
                                else
                                {
                                    english = $"{currentPlayer.Name}, you've lost, the game is over!\nThe secret word was \"{secretWord}\".";
                                    latvian = $"{currentPlayer.Name}, tu zaudēji, spēle ir beigusies!\nTu neuzminēji vārdu \"{secretWord}\".";
                                    russian = $"{currentPlayer.Name}, ты проиграл, игра закончена!\nТы не отгадал слово «{secretWord}».";
                                    Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                                    Console.ResetColor();
                                    Thread.Sleep(2000);
                                    gameFinished = true;
                                }
                            }
                        }
                        Console.ResetColor();
                        Thread.Sleep(2000);
                        Console.Clear();
                        //If gameFinished == true, the program asks whether to exit the game or to start a new game.
                        if (gameFinished)
                        {
                            Console.Clear();
                            english = "To exit the game, press ESC.\nTo start another game, press any other key.";
                            latvian = "Lai izietu no spēles, spied ESC.\nLai sāktu jaunu spēli, spied jebkuru citu taustiņu.";
                            russian = "Чтобы выйти из игры, нажми ESC.\nЧтобы начать новую игру, нажми любую другую клавишу.";
                            Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                            ConsoleKey key = Console.ReadKey().Key;
                            Console.WriteLine();
                            //If ESC is pressed, the program ends.
                            if (key == ConsoleKey.Escape)
                            {
                                Environment.Exit(0);
                            }
                            //If any other key is pressed, the program clears all the lists, 
                            //breaks the loop and starts from the beginning.
                            else
                            {
                                players.Clear();
                                previousGuesses.Clear();
                                Console.Clear();
                                break;
                            }
                        }
                        //When the move is made the program prints current progress.
                        ShowProgress(progress);
                        current++;
                    }
                } 
            }
        }
    }
}
