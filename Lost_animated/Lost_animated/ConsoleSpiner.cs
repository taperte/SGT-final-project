using System;

namespace Lost_animated
{
    internal class ConsoleSpiner
    {

        int counter;
        public ConsoleSpiner()
        {
            counter = 0;
        }
        public void Turn()
        {
            counter++;
            for (int i = 0; i < 40; i++)
            {
                Console.WriteLine();
            }
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);

        }
    }
}