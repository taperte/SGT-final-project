using System;
using System.Collections.Generic;

namespace calc
{
    class Program
    {

        static void Main(string[] args)
        {
            List<string> list1 = new List<string> { "skapis", "putra", "lielveikals", "pīle" };
            List<string> list2 = new List<string> { "приговор", "язык", "машина" };
            List<string> list3 = new List<string> { "sheep", "goat", "computer", "america", "chase", "paste" };
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            string word = ChooseWordToGuess(list1, list2, list3, 2, 1);
            Console.WriteLine(word);

            //This method chooses the secret word from the word lists.
            static string ChooseWordToGuess(List<string> list1, List<string> list2, List<string> list3, int number1, int number2)
            {
                //The program selects the list to choose from according to player's choice of language.
                List<string> listToChooseFrom = new List<string>();
                if (number1 == 1)
                {
                    listToChooseFrom = list1;
                }
                else if (number1 == 2)
                {
                    listToChooseFrom = list2;
                }
                else if (number1 == 3)
                {
                    listToChooseFrom = list3;
                }
                //Then selects a word according to player's choice of level.
                while (true)
                {
                    Random random = new Random();
                    string wordToGuess = listToChooseFrom[random.Next(listToChooseFrom.Count)];
                    if (number2 == 1)
                    {
                        if (wordToGuess.Length <= 5)
                        {
                            return wordToGuess;
                        }
                    }
                    else if (number2 == 2)
                    {
                        if (5 < wordToGuess.Length && wordToGuess.Length <= 7)
                        {
                            return wordToGuess;
                        }
                    }
                    else if (number2 == 3)
                    {
                        if (wordToGuess.Length > 7)
                        {
                            return wordToGuess;
                        }
                    }
                }
            }
        }

    }
}
