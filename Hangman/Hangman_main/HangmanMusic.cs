using System;
using System.Threading;

namespace Hangman_main
{
    class HangmanMusic : HangmanMethods
    {
        public static void TheGameIsOn(int number)
        {
            int[] randomNumbers = ArrayWithRandomNumbers(21);
            int j = 0;
            string message1 = "The game is on!", message2 = "Sākam spēli!", message3 = "Начинаем игру!";
            string text = SwitchLanguage(number, message1, message2, message3);
            for (int i = 0; i < 40; i += 2)
            {
                Console.SetCursorPosition(i, j);
                Console.BackgroundColor = (ConsoleColor)randomNumbers[j];
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(text);
                Console.ResetColor();
                if (i % 4 == 0 || i == 38)
                {
                    Thread.Sleep(100);
                    Console.Clear();
                }
                j++;
            }
            Console.Beep(NoteFrequency(Note.G4), NoteDuration(4, 1));
            CenteredTextInColor(text, 3, randomNumbers.Length);
            Console.Beep(NoteFrequency(Note.D5), NoteDuration(4) + NoteDuration(4) / 2);
            CenteredTextInColor(text, 3, randomNumbers.Length);
            Console.Beep(NoteFrequency(Note.C5), NoteDuration(8, 1));
            CenteredTextInColor(text, 3, randomNumbers.Length);
            Console.Beep(NoteFrequency(Note.A4sh_B4fl), NoteDuration(16, 1));
            CenteredTextInColor(text, 3, randomNumbers.Length);
            Console.Beep(NoteFrequency(Note.A4sh_B4fl), NoteDuration(4) + NoteDuration(4) / 2);
            CenteredTextInColor(text, 3, randomNumbers.Length);
            Console.Beep(NoteFrequency(Note.C5), NoteDuration(8, 1));
            CenteredTextInColor(text, 3, randomNumbers.Length);
            Console.Beep(NoteFrequency(Note.D5), NoteDuration(16));
            CenteredTextInColor(text, 3, randomNumbers.Length);
            Console.Beep(NoteFrequency(Note.D5), NoteDuration(4) + NoteDuration(4) / 2);
            CenteredTextInColor(text, 3, randomNumbers.Length);
            Console.Beep(NoteFrequency(Note.G4), NoteDuration(2));
            Thread.Sleep(NoteDuration(4));
            CenteredTextInColor(text, 3, randomNumbers.Length);
            Console.Beep(NoteFrequency(Note.D5), NoteDuration(4));
            CenteredTextInColor(text, 3, randomNumbers.Length);
            Console.Beep(NoteFrequency(Note.C5), NoteDuration(4));
            CenteredTextInColor(text, 3, randomNumbers.Length);
            Console.Beep(NoteFrequency(Note.A4sh_B4fl), NoteDuration(8));
            CenteredTextInColor(text, 3, randomNumbers.Length);
            Console.Beep(NoteFrequency(Note.A4sh_B4fl), NoteDuration(8, 1));
            CenteredTextInColor(text, 3, randomNumbers.Length);
            Console.Beep(NoteFrequency(Note.A4), NoteDuration(4) + NoteDuration(4) / 2);
            CenteredTextInColor(text, 3, randomNumbers.Length);
            Console.Beep(NoteFrequency(Note.G4), NoteDuration(2));
            CenteredTextInColor(text, 3, randomNumbers.Length);
        }

        public static void CorrectGuessMusic()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Beep(NoteFrequency(Note.G3), NoteDuration(8));
            }
            Console.Beep(NoteFrequency(Note.C4), NoteDuration(2));
            Console.Beep(NoteFrequency(Note.G4), NoteDuration(2));
            Console.Beep(NoteFrequency(Note.F4), NoteDuration(8));
            Console.Beep(NoteFrequency(Note.E4), NoteDuration(8));
            Console.Beep(NoteFrequency(Note.D4), NoteDuration(8));
            Console.Beep(NoteFrequency(Note.C5), NoteDuration(2));
            Thread.Sleep(NoteDuration(2));
            Console.Beep(NoteFrequency(Note.G4), NoteDuration(4));
            Console.Beep(NoteFrequency(Note.F4), NoteDuration(8));
            Console.Beep(NoteFrequency(Note.E4), NoteDuration(8));
            Console.Beep(NoteFrequency(Note.D4), NoteDuration(8));
            Console.Beep(NoteFrequency(Note.C5), NoteDuration(2));
            Console.Beep(NoteFrequency(Note.G4), NoteDuration(4));
            Console.Beep(NoteFrequency(Note.F4), NoteDuration(8));
            Console.Beep(NoteFrequency(Note.E4), NoteDuration(8));
            Console.Beep(NoteFrequency(Note.F4), NoteDuration(8));
            Console.Beep(NoteFrequency(Note.D4), NoteDuration());
        }

        public static void IncorrectGuessMusic()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Beep(NoteFrequency(Note.G4), NoteDuration(8));
            }
            Console.Beep(NoteFrequency(Note.E4), NoteDuration(2));
            Thread.Sleep(NoteDuration(8));
            for (int i = 0; i < 3; i++)
            {
                Console.Beep(NoteFrequency(Note.F4), NoteDuration(8));
            }
            Console.Beep(NoteFrequency(Note.D4), NoteDuration(2));
        }

        public static void LossMusic()
        {
            Console.Beep(NoteFrequency(Note.A3sh_B3fl), NoteDuration(4));
            Console.Beep(NoteFrequency(Note.A3sh_B3fl), NoteDuration(8, 1));
            Console.Beep(NoteFrequency(Note.A3sh_B3fl), NoteDuration(16));
            Console.Beep(NoteFrequency(Note.A3sh_B3fl), NoteDuration(4));
            Console.Beep(NoteFrequency(Note.C4sh_D4fl), NoteDuration(8, 1));
            Console.Beep(NoteFrequency(Note.C4), NoteDuration(16));
            Console.Beep(NoteFrequency(Note.C4), NoteDuration(8, 1));
            Console.Beep(NoteFrequency(Note.A3sh_B3fl), NoteDuration(16));
            Console.Beep(NoteFrequency(Note.A3sh_B3fl), NoteDuration(8, 1));
            Console.Beep(NoteFrequency(Note.A3sh_B3fl), NoteDuration(16));
            Console.Beep(NoteFrequency(Note.A3sh_B3fl), NoteDuration(2));
        }

        public static void VictoryMusic()
        {
            Console.Beep(NoteFrequency(Note.G4), NoteDuration(4));
            Console.Beep(NoteFrequency(Note.C5), NoteDuration(2));
            Console.Beep(NoteFrequency(Note.D5), NoteDuration(4, 1));
            Console.Beep(NoteFrequency(Note.D5sh_E5fl), NoteDuration(16));
            Console.Beep(NoteFrequency(Note.F5), NoteDuration(16));
            Console.Beep(NoteFrequency(Note.D5sh_E5fl), NoteDuration(2));
            Console.Beep(NoteFrequency(Note.G4), NoteDuration(4, 1));
            Thread.Sleep(NoteDuration(4));
            Console.Beep(NoteFrequency(Note.G4), NoteDuration(8));
            Console.Beep(NoteFrequency(Note.C5), NoteDuration(4, 1));
            Console.Beep(NoteFrequency(Note.D5), NoteDuration(8));
            Console.Beep(NoteFrequency(Note.D5sh_E5fl), NoteDuration(8));
            Console.Beep(NoteFrequency(Note.G4), NoteDuration(8));
            Console.Beep(NoteFrequency(Note.D5sh_E5fl), NoteDuration(8));
            Console.Beep(NoteFrequency(Note.C5), NoteDuration(8));
            Console.Beep(NoteFrequency(Note.G5), NoteDuration(8));
            Console.Beep(NoteFrequency(Note.F5), NoteDuration(2, 1));
            Thread.Sleep(NoteDuration(8) * 5);
            Thread.Sleep(NoteDuration(4));

            Console.Beep(NoteFrequency(Note.G4), NoteDuration(4));
            Console.Beep(NoteFrequency(Note.C5), NoteDuration(4, 1));
            Thread.Sleep(NoteDuration(8) * 2);
            Console.Beep(NoteFrequency(Note.D5), NoteDuration(8));
            Console.Beep(NoteFrequency(Note.D5sh_E5fl), NoteDuration(8, 1));
            Console.Beep(NoteFrequency(Note.C5), NoteDuration(16));
            Console.Beep(NoteFrequency(Note.G5), NoteDuration(8, 1));
            Console.Beep(NoteFrequency(Note.D5sh_E5fl), NoteDuration(16));
            Console.Beep(NoteFrequency(Note.C6), NoteDuration(2));
            Thread.Sleep(NoteDuration(8) * 4);
            Console.Beep(NoteFrequency(Note.C5), NoteDuration(4));
            Console.Beep(NoteFrequency(Note.D5sh_E5fl), NoteDuration(8));
            Console.Beep(NoteFrequency(Note.D5), NoteDuration(8));
            Console.Beep(NoteFrequency(Note.C5), NoteDuration(8));
            Console.Beep(NoteFrequency(Note.G5), NoteDuration(4, 1));
            Thread.Sleep(NoteDuration(8));
            Thread.Sleep(NoteDuration(4));
            Console.Beep(NoteFrequency(Note.D5sh_E5fl), NoteDuration(16));
            Console.Beep(NoteFrequency(Note.C5), NoteDuration(16));
            Console.Beep(NoteFrequency(Note.G4), NoteDuration(4));
            Thread.Sleep(NoteDuration(8));
            Console.Beep(NoteFrequency(Note.G4), NoteDuration(8, 1));
            Console.Beep(NoteFrequency(Note.G4), NoteDuration(16));
            Console.Beep(NoteFrequency(Note.C5), NoteDuration(2, 1));
        }

        //This method calculates note frequecy; parameter: note enum value.
        //f(n) = 440 * 2^((n - 69)/12), where n is note's number
        //in MIDI (Musical Instrument Digital Interface) standard.
        public static int NoteFrequency(Note note)
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
        public static int NoteDuration(int denominator = 1, int dot = 0, int multiplier = 1)
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
    }
}
