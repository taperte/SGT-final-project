using System;
using System.Collections.Generic;

namespace calc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SomeMethod(67));
            Console.WriteLine((67.0 - 69.0) / 12.0);
        }

        //returns 440 * 2^((n - 69)/12)
        static int SomeMethod(int somenumber)
        {
            double exponent = (somenumber - 69.0) / 12.0;
            double someothernumber = 440 * Math.Pow(2, exponent);
            return (int)someothernumber;
        }
    }
}
