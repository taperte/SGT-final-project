using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace method_for_hangman
{
    class Program
    {

        static void Main(string[] args)
        {
            List<string> list1 = new List<string> { "skapis", "putra", "lielveikals", "pīle" };
            List<string> list2 = new List<string> { "приговор", "язык", "машина" };
            List<string> list3 = new List<string> { "sheep", "goat", "computer", "america", "chase", "paste" };
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            string word = ChooseWordToGuess(list1, list2, list3, 3, 3);
            Console.WriteLine(word);


            static string ChooseWordToGuess(List<string> list1, List<string> list2, List<string> list3, int number1, int number2)
            {
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
                while (true)
                {
                    Random random = new Random();
                    string wordToGuess = listToChooseFrom[random.Next(0, listToChooseFrom.Count)];
                    if (number2 == 1)
                    {
                        if (wordToGuess.Length <= 5)
                        {
                            return wordToGuess;
                        }
                    }
                    if (number2 == 2)
                    {
                        if (5 < wordToGuess.Length && wordToGuess.Length <= 7)
                        {
                            return wordToGuess;
                        }
                    }
                    if (number2 == 3)
                    {
                        if (wordToGuess.Length < 7)
                        {
                            return wordToGuess;
                        }
                    }
                }
            }
        }


    }
}