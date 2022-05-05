using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E5._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input  = Console.ReadLine();
            SortedDictionary<char, int> output = new SortedDictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];
                if (output.ContainsKey(current))
                {
                    output[current]++;
                }
                else
                {
                    output.Add(current, 1);
                }
            }
            foreach (var element in output)
            {
                Console.WriteLine($"{element.Key}: {element.Value} time/s");
               
            }
          

        }
    }
}
