using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Hangman_main
{
    class HangmanMusic
    {
        public static void CorrectGuess()
        {
            Console.Beep(NoteFrequency(55), NoteDuration(8));
            Console.Beep(NoteFrequency(55), NoteDuration(8));
            Console.Beep(NoteFrequency(55), NoteDuration(8));
            Console.Beep(NoteFrequency(60), NoteDuration(2));
            Console.Beep(NoteFrequency(67), NoteDuration(2));
            Console.Beep(NoteFrequency(65), NoteDuration(8));
            Console.Beep(NoteFrequency(64), NoteDuration(8));
            Console.Beep(NoteFrequency(62), NoteDuration(8));
            Console.Beep(NoteFrequency(72), NoteDuration(2));
            Thread.Sleep(NoteDuration(2));
            Console.Beep(NoteFrequency(67), NoteDuration(4));
            Console.Beep(NoteFrequency(65), NoteDuration(8));
            Console.Beep(NoteFrequency(64), NoteDuration(8));
            Console.Beep(NoteFrequency(62), NoteDuration(8));
            Console.Beep(NoteFrequency(72), NoteDuration(2));
            Console.Beep(NoteFrequency(67), NoteDuration(4));
            Console.Beep(NoteFrequency(65), NoteDuration(8));
            Console.Beep(NoteFrequency(64), NoteDuration(8));
            Console.Beep(NoteFrequency(65), NoteDuration(8));
            Console.Beep(NoteFrequency(62), NoteDuration());
        }

        public static void IncorrectGuess()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Beep(NoteFrequency(67), NoteDuration(8));
            }
            Console.Beep(NoteFrequency(64), NoteDuration(2));
            Thread.Sleep(NoteDuration(8));
            for (int i = 0; i < 3; i++)
            {
                Console.Beep(NoteFrequency(65), NoteDuration(8));
            }
            Console.Beep(NoteFrequency(62), NoteDuration(2));
        }

        public static void Loss()
        {
            Console.Beep(NoteFrequency(58), NoteDuration(4));
            Console.Beep(NoteFrequency(58), NoteDuration(8, 1));
            Console.Beep(NoteFrequency(58), NoteDuration(16));
            Console.Beep(NoteFrequency(58), NoteDuration(4));
            Console.Beep(NoteFrequency(61), NoteDuration(8, 1));
            Console.Beep(NoteFrequency(60), NoteDuration(16));
            Console.Beep(NoteFrequency(60), NoteDuration(8, 1));
            Console.Beep(NoteFrequency(58), NoteDuration(16));
            Console.Beep(NoteFrequency(58), NoteDuration(8, 1));
            Console.Beep(NoteFrequency(58), NoteDuration(16));
            Console.Beep(NoteFrequency(58), NoteDuration(2));
        }

        public static void Victory()
        {
            Console.Beep(NoteFrequency(67), NoteDuration(4));
            Console.Beep(NoteFrequency(72), NoteDuration(2));
            Console.Beep(NoteFrequency(74), NoteDuration(4, 1));
            Console.Beep(NoteFrequency(75), NoteDuration(16));
            Console.Beep(NoteFrequency(77), NoteDuration(16));
            Console.Beep(NoteFrequency(75), NoteDuration(2));
            Console.Beep(NoteFrequency(67), NoteDuration(4, 1));
            Thread.Sleep(NoteDuration(4));
            Console.Beep(NoteFrequency(67), NoteDuration(8));
            Console.Beep(NoteFrequency(72), NoteDuration(4, 1));
            Console.Beep(NoteFrequency(74), NoteDuration(8));
            Console.Beep(NoteFrequency(75), NoteDuration(8));
            Console.Beep(NoteFrequency(67), NoteDuration(8));
            Console.Beep(NoteFrequency(75), NoteDuration(8));
            Console.Beep(NoteFrequency(72), NoteDuration(8));
            Console.Beep(NoteFrequency(79), NoteDuration(8));
            Console.Beep(NoteFrequency(77), NoteDuration(2, 1));
            Thread.Sleep(NoteDuration(8) * 5);
            Thread.Sleep(NoteDuration(4));

            Console.Beep(NoteFrequency(67), NoteDuration(4));
            Console.Beep(NoteFrequency(72), NoteDuration(4, 1));
            Thread.Sleep(NoteDuration(8) * 2);
            Console.Beep(NoteFrequency(74), NoteDuration(8));
            Console.Beep(NoteFrequency(75), NoteDuration(8, 1));
            Console.Beep(NoteFrequency(72), NoteDuration(16));
            Console.Beep(NoteFrequency(79), NoteDuration(8, 1));
            Console.Beep(NoteFrequency(75), NoteDuration(16));
            Console.Beep(NoteFrequency(84), NoteDuration(2));
            Thread.Sleep(NoteDuration(8) * 4);
            Console.Beep(NoteFrequency(72), NoteDuration(4));
            Console.Beep(NoteFrequency(75), NoteDuration(8));
            Console.Beep(NoteFrequency(74), NoteDuration(8));
            Console.Beep(NoteFrequency(72), NoteDuration(8));
            Console.Beep(NoteFrequency(79), NoteDuration(4, 1));
            Thread.Sleep(NoteDuration(8));
            Thread.Sleep(NoteDuration(4));
            Console.Beep(NoteFrequency(75), NoteDuration(16));
            Console.Beep(NoteFrequency(72), NoteDuration(16));
            Console.Beep(NoteFrequency(67), NoteDuration(4));
            Thread.Sleep(NoteDuration(8));
            Console.Beep(NoteFrequency(67), NoteDuration(8, 1));
            Console.Beep(NoteFrequency(67), NoteDuration(16));
            Console.Beep(NoteFrequency(72), NoteDuration(2, 1));
        }

        //This method calculates note frequecy;
        //parameter: note number in MIDI standard (from 0 to 127).
        //f(n) = 440 * 2^((n - 69)/12)
        private static int NoteFrequency(int midiNoteNumber)
        {
            double exponent = (midiNoteNumber - 69.0) / 12.0;
            double frequency = 440 * Math.Pow(2, exponent);
            return (int)frequency;
        }

        //This method calculates note duration;
        //parameters: note value denominator (e.g. note value is 1/8, the parameter is 8),
        //dot modifier, multiplier (for double whole note, longa or maxima).
        private static int NoteDuration(int denominator = 1, int dot = 0, int multiplier = 1)
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
