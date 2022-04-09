using System;
using System.Collections.Generic;           //For Dictionaries
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex


namespace AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrays = Console.ReadLine()
                                     .Split('|')
                                     .ToArray();

            List<int> output = new List<int>();

            for (int i = arrays.Length - 1; i > -1; i--)
            {
                int[] currentArray = arrays[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                output.AddRange(currentArray);                
            }
            Console.WriteLine(String.Join(" ", output));           
        }
    }
}