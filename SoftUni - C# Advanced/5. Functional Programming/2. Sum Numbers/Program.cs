using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace _2._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                
            string input = Console.ReadLine();
            Func<string, int> parsing = x => int.Parse(x);
            Func<string, int> parsing2 = (x) => { return int.Parse(x); };
            int[] numbers = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(parsing2).ToArray();
            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }
    }
}
