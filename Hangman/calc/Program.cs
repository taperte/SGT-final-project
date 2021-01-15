using System;
using System.Collections.Generic;
using System.Threading;

namespace calc
{
    class Program
    {
        static void Main(string[] args)
        {
            int Width = Console.LargestWindowWidth;
            int Height = Console.LargestWindowHeight;
            for (int i = 1; i < 20; i++)
            {
                Console.SetWindowSize(i, i);
                Thread.Sleep(100);
            }
            Console.SetWindowSize(Width, Height);
        }
        
    }
}
