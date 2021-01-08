using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            int language, level, playerCount;
            string english, latvian, russian;

            //Change default output encoding to Unicode,
            //so that Latvian text would be displayed correctly in console.
            Console.OutputEncoding = Encoding.Unicode;

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
                latvian = "Lūdzu, ievadiet spēlētāju skaitu: ";
                russian = "Пожалуйста, введите количество игроков: ";
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
            Player currentPlayer = players[0];

            //Šo nevajadzēs, tas ir tikai testēšanai.
            foreach (Player player in players)
            {
                player.PrintPlayerInfo(language);
            }
        }
    }
}
