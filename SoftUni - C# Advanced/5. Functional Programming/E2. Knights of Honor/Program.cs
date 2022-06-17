using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E2._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> knights = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            //1st way
            //Action<string> print = x => Console.WriteLine("Sir " + x);
            //knights.ForEach(print);

            //2nd way
            Func<string, string> addSir = delegate (string x) { return "Sir " + x; };
            //Func<string, string> addSir = name => "Sir " + name;
            foreach (string knight in knights)
            {
                Console.WriteLine(addSir(knight));
            }
        }
    }
}
