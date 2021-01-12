using System;
using System.Collections.Generic;
using System.Threading;

namespace calc
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list1 = new List<string> { "skapis", "putra", "lielveikals", "pīle" };
            List<string> list2 = new List<string> { "приговор", "язык", "машина" };
            List<string> list3 = new List<string> { "sheep", "goat", "computer", "america", "chase", "paste", "programming" };
            Random rand = new Random();
            string randomWord = list3[rand.Next(list3.Count)];

        }
    }
}
