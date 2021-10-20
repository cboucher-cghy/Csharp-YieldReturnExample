using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace YieldReturnExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            IEnumerable<string> values = GetStrings().Take(10);
            Console.WriteLine("Starting...");
            foreach (string value in values)
            {
                Console.WriteLine($"Writing #{i++,3} : {value}");
            }
            Console.WriteLine("Terminated...");
            Console.ReadLine();
        }

        static IEnumerable<string> GetStrings()
        {
            Console.WriteLine("Getting values of Strings");
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Getting values #{i}");
                Thread.Sleep(1000);
                yield return GetString();
            }
        }

        static string GetString()
        {
            Thread.Sleep(1000);
            string value = new Random().Next().ToString();
            Console.WriteLine($"Value is {value}");

            return value;
        }
    }
}
