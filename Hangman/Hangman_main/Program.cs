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

            //1) Player(s) choose(s) language.
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
            Console.Clear();
            //2) Info about the game.
            english = "";
            latvian = "";
            russian = "";
            Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
            //The player(s) press(es) enter to proceed. 
            PressEnter(language);
            Player example = new Player();
            example.BuildHangmanImage(language);

            //3) Player(s) choose(s) level.
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
            //4) Number of players.
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
            //5) The program creates player objects and saves them to the list.
            AddPlayers(players, playerCount, language);

            //6) The program chooses secret word from one of the word lists and saves it to a variable.
            string wordToGuess = ChooseWordToGuess(ENwords, LVwords, RUwords, language, level);

            //7) Progress array is created.
            string[] progress = CreateProgressArray(wordToGuess);

            //The player(s) press(es) enter to proceed. 
            PressEnter(language);

            //The game begins.
            TheGameIsOn(language);
            Thread.Sleep(1500);
            Console.Clear();

            //8) The program prints the progress array.
            ShowProgress(progress);

            Player currentPlayer = players[0];

            //9) The game begins.
            while (!gameFinished)
            {
                //9.1) Current player enters their guess.
                english = $"{currentPlayer.Name}, your guess: ";
                latvian = $"{currentPlayer.Name}, tavs minējums: ";
                russian = $"{currentPlayer.Name}, твой ход: ";
                Console.Write(SwitchLanguage(language, english, latvian, russian));
                string guess = Console.ReadLine().ToLower();
                //9.2) Validācija(ievada empty string, ievada kaut ko, kas nav 1 burts un pēc garuma nesakrīt ar minamo vārdu-- programma paziņo par kļūdu)
                //9.3) Ja minējums derīgs, tas tiek saglabāts sarakstā
                //9.4) Pārbauda, vai minējums jau ir bijis, -- tas ir gatavs.
                if (previousGuesses.Contains(guess))
                {
                    english = "This guess was entered already, try another one!";
                    latvian = "Šis minējums jau ir bijis, mēģini vēlreiz!";
                    russian = "Повтор — попробуй ещё раз!";
                    Console.WriteLine(SwitchLanguage(language, english, latvian, russian));
                    continue;
                }
                //9.5) Ja spēlētājs ir ievadījis 1 burtu:
                //programma pārbauda, vai šāds burts ir vārdā. Ja ir, apdeito progress array un nodrukā paziņojumu.
                //Atkal piedāvā ievadīt minējumu. 
                //Ja šāda burta nav, tad pieskaita vienu punktu pie spēlētāja zaudējumu skaitītāja,
                //nodrukā paziņojumu un apdeito karātavas un nodrukā karātavas.
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
