using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues, sets
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace _1.Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] values = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Dictionary<double, int> result = new Dictionary<double, int>();

            for (int i = 0; i < values.Length; i++)
            {
                if (result.ContainsKey(values[i]))
                {
                    result[values[i]]++;
                }
                else
                {
                    result.Add(values[i], 1);
                }
            }

            foreach (var element in result)
            {
                Console.WriteLine($"{element.Key} - {element.Value} times");
            }
        }
    }
}