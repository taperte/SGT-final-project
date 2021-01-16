using System;
using System.Collections.Generic;

namespace for_testing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string> { "a", "b", "kdjhkdj", "f", "kjcks", "jha", "jhbsxjh" };
            Console.Write("Letters: ");
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Length == 1)
                {
                    Console.Write(list[i] + " ");
                }
            }
            Console.WriteLine();
            Console.Write("Words: ");
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Length > 1)
                {
                    Console.Write(list[i] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
