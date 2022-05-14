using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues, sets
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace _3.Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine(String.Join(' ', Console.ReadLine().Split(' ').Select(int.Parse).ToArray().OrderByDescending(x => x).Take(3)));
        }
    }
}