using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Hangman_main
{
    class Program
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
            //so that Latvian text would be displayed correctly in console.
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            //1) Player(s) choose(s) language.
            while (true)
            {
                Console.WriteLine("For English, enter 1.\nLai izvēlētos latviešu valodu, ievadiet 2.\nЧтобы выбрать русский язык, введите 3.");
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
            //2) Info about the game.
            english = "";
            latvian = "";
            russian = "";
            HangmanMethods.SwitchLanguage(language, english, latvian, russian);
            Console.WriteLine();

            //3) Player(s) choose(s) level.
            while (true)
            {
                english = "Please choose level (1, 2 or 3): ";
                latvian = "Izvēlieties līmeni (1, 2 vai 3): ";
                russian = "Выберите уровень (1, 2 или 3): ";
                HangmanMethods.SwitchLanguage(language, english, latvian, russian);
                string languageInput = Console.ReadLine();
                if (string.IsNullOrEmpty(languageInput) || !int.TryParse(languageInput, out level))
                {
                    english = "Invalid input! "; latvian = "Kļūda! "; russian = "Ошибка! ";
                    HangmanMethods.SwitchLanguage(language, english, latvian, russian);
                    continue;
                }
                if (level < 1 || level > 3)
                {
                    english = "Invalid number! "; latvian = "Nepareizs skaitlis! "; russian = "Неверное число! ";
                    HangmanMethods.SwitchLanguage(language, english, latvian, russian);
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
                english = "Please enter the number of players: ";
                latvian = "Ievadiet spēlētāju skaitu: ";
                russian = "Введите количество игроков: ";
                HangmanMethods.SwitchLanguage(language, english, latvian, russian);
                string playerCountInput = Console.ReadLine();
                if (string.IsNullOrEmpty(playerCountInput) || !int.TryParse(playerCountInput, out playerCount))
                {
                    english = "Invalid input! "; latvian = "Kļūda! "; russian = "Ошибка! ";
                    HangmanMethods.SwitchLanguage(language, english, latvian, russian);
                    continue;
                }
                if (playerCount < 1 || playerCount > 11)
                {
                    english = "Invalid number! "; latvian = "Nepareizs skaitlis! "; russian = "Неверное число! ";
                    HangmanMethods.SwitchLanguage(language, english, latvian, russian);
                    continue;
                }
                else
                {
                    break;
                }
            }
            //5) The program creates player objects and saves them to the list.
            HangmanMethods.CreatePlayers(players, playerCount, language);

            //Šo nevajadzēs, tas ir tikai testēšanai.
            foreach (Player player in players)
            {
                player.PrintPlayerInfo(language);
            }

            //6) The program chooses secret word from one of the word lists and saves it to a variable.
            //...
            string wordToGuess = HangmanMethods.ChooseWordToGuess(ENwords, LVwords, RUwords, language, level);
            english = "The game begins!"; latvian = "Spēle ir sākusies!"; russian = "Игра начинается!";
            HangmanMethods.SwitchLanguage(language, english, latvian, russian);
            Console.WriteLine();

            //7) Progress array is created.
            string[] progress = HangmanMethods.CreateProgressArray(wordToGuess);

            Player currentPlayer = players[0];

            //8) The game begins.
            while (!gameFinished)
            {
                //8.1) The program prints the progress array.
                HangmanMethods.ShowProgress(progress);
                //8.2) Spēlētājs ievada minējumu
                //8.3) Validācija(ievada empty string, ievada kaut ko, kas nav 1 burts un pēc garuma nesakrīt ar minamo vārdu-- programma paziņo par kļūdu)
                //8.4) Ja minējums derīgs, tas tiek saglabāts sarakstā
                //8.5) Pārbauda, vai minējums jau ir bijis, -- tas ir gatavs.
                //8.6) Ja spēlētājs ir ievadījis 1 burtu:
                //programma pārbauda, vai šāds burts ir vārdā. Ja ir, apdeito progress array un nodrukā paziņojumu.
                //Atkal piedāvā ievadīt minējumu. 
                //Ja šāda burta nav, tad pieskaita vienu punktu pie spēlētāja zaudējumu skaitītāja,
                //nodrukā paziņojumu un apdeito karātavas un nodrukā karātavas.
                //8.7) Ja skaitītājs == 7, spēlētājs ir zaudējis.gameFinished == true + paziņojums par zaudējumu,
                //!!! kaut kas foršs ar karātavām
                //8.8) Ja inputs sakrīt ar minamo vārdu, gameFinished == true, spēle ir beigusies,
                //paziņojums par uzvaru, !!!! kaut kas foršs ar karātavām
                //8.9) Ja spēlētajs nospiež Esc, iziet no spēles.
                //Programma jautā, vai sākt jaunu spēli vai iziet pavisam

            }
        }
    }
}
