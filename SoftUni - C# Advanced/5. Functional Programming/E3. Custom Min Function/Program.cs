using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E3._CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();                       
            Func<List<int>, int> takeMin = delegate (List<int> x) { return x.Min(); };
            Console.WriteLine(takeMin(nums));

            //Func<List<int>, int> takeMax = x => x.Max();                 
            //Console.WriteLine(takeMax(nums));
        }
    }
}
