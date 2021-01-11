using System;
using System.Threading;

namespace Hangman_music
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pilnais karātavu zīmējums
            string[,] hangman = CreateHangman();

            //Incorrect guess
            Console.Write("Enter anything: ");
            Console.ReadLine();
            Console.Clear();
            int[] colornumbers = ArrayWithRandomNumbers(8);
            for (int i = 0; i < 3; i++)
            {
                Console.ForegroundColor = (ConsoleColor)colornumbers[i];
                PrintHangman(hangman);
                Console.ResetColor();
                Console.Beep(NoteFrequency(Note.G4), NoteDuration(8));
                Console.Clear();
            }
            Console.ForegroundColor = (ConsoleColor)colornumbers[3];
            PrintHangman(hangman);
            Console.ResetColor();
            Console.Beep(NoteFrequency(Note.E4), NoteDuration(2));
            Thread.Sleep(NoteDuration(8));
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Console.ForegroundColor = (ConsoleColor)colornumbers[i + 4];
                PrintHangman(hangman);
                Console.ResetColor();
                Console.Beep(NoteFrequency(Note.F4), NoteDuration(8));
                Console.Clear();
            }
            Console.ForegroundColor = (ConsoleColor)colornumbers[7];
            PrintHangman(hangman);
            Console.ResetColor();
            Console.Beep(NoteFrequency(Note.D4), NoteDuration(2));

            //This method calculates note frequecy; parameter: note enum value.
            //f(n) = 440 * 2^((n - 69)/12), where n is note's number in MIDI standard.
            static int NoteFrequency(Note note)
            {
                //The note enum starts with A0, its MIDI number is 21,
                //so in order to get note's MIDI number, its enum index has to be increased by 21. 
                int midiNoteNumber = (int)note + 21;
                double exponent = (midiNoteNumber - 69.0) / 12.0;
                double frequency = 440 * Math.Pow(2, exponent);
                return (int)frequency;
            }

            //This method calculates note duration;
            //parameters: note value denominator (e.g. note value is 1/8, the parameter is 8),
            //dot modifier, multiplier (for double whole note, longa or maxima).
            static int NoteDuration(int denominator = 1, int dot = 0, int multiplier = 1)
            {
                int wholeNote = 2000;
                int duration = multiplier * wholeNote / denominator;
                if (dot != 0)
                {
                    int modifier = 2;
                    for (int i = 0; i < dot; i++)
                    {
                        modifier *= 2;
                    }
                    duration += duration * ((modifier - 1) / 2);
                }
                return duration;
            }

            static string[,] CreateHangman()
            {
                string[,] hangman = new string[10, 11];
                for (int row = 0; row < hangman.GetLength(0); row++)
                {
                    for (int column = 0; column < hangman.GetLength(1); column++)
                    {
                        if (((row == 0 || row == hangman.GetLength(0) - 1) && column % 2 == 0) ||
                            column == 0 || column == hangman.GetLength(1) - 1)
                        {
                            hangman[row, column] = "*";
                        }
                        else if (row == 1 && column != 0 && column != 1 &&
                                 column != hangman.GetLength(1) - 2 && column != hangman.GetLength(1) - 1)
                        {
                            hangman[row, column] = "—";
                        }
                        else if (((column == 2 || column == 8) && row != 0 && row != 1 && row != hangman.GetLength(0)) ||
                                  (column == 5 && (row == 2 || row == 4 || row == 5)))
                        {
                            hangman[row, column] = "|";
                        }
                        else if (row == 3 && column == 5)
                        {
                            hangman[row, column] = "O";
                        }
                        else if ((column == 4 && (row == 4 || row == 6)) || (row == hangman.GetLength(0) - 2 && (column == 1 || column == 7)))
                        {
                            hangman[row, column] = "/";
                        }
                        else if ((column == 6 && (row == 4 || row == 6)) || (row == hangman.GetLength(0) - 2 && (column == 3 || column == 9)))
                        {
                            hangman[row, column] = "\\";
                        }
                        else
                        {
                            hangman[row, column] = " ";
                        }
                    }
                }
                return hangman;
            }

            static void PrintHangman(string[,] somearray)
            {
                //Nodrukā karātavas
                for (int row = 0; row < somearray.GetLength(0); row++)
                {
                    for (int column = 0; column < somearray.GetLength(1); column++)
                    {
                        Console.Write(somearray[row, column]);
                    }
                    Console.WriteLine();
                }
            }

            //This method creates an integer array of a given size 
            //and fills it with random numbers from 2 to 14;
            //the same number can be generated more than once, but not in a row.
            static int[] ArrayWithRandomNumbers(int number)
            {
                int[] someArray = new int[number];
                for (int i = 0; i < someArray.Length;)
                {
                    Random rand = new Random();
                    int randomNumber = rand.Next(2, 15);
                    if (randomNumber == 7 || randomNumber == 8)
                    {
                        continue;
                    }
                    if (i == 0 || randomNumber != someArray[i - 1])
                    {
                        someArray[i] = randomNumber;
                        i++;
                    }
                }
                return someArray;
            }
        }
    }
}
