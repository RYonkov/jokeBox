using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace _3._Count_Upper_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> predicate = x =>Char.IsUpper(x[0]);
            string[] output = input.Where(predicate).ToArray();

            foreach (string s in output)
            {
                Console.WriteLine(s);
            }

            
        }
    }
}
