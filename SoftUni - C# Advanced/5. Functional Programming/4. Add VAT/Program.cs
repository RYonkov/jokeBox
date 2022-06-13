using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace _4._Add_VAT
{           
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //Reading the sequence of numbers in array of doubles
            double[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            //Defining function - for each x to be returned the value multiplied by 1.2
            Func<double, double> withVAT = delegate (double x) { return x * 1.2; };
            Func<decimal, decimal> withVAT2 = x => x * 1.2m; 

            //Printing of each element of the array formatted by 2 positions
            for (int i = 0; i < input.Length; i++)
            {
                //Console.WriteLine($"{withVAT(input[i]):F2}");
                Console.WriteLine($"{0:F2}, input[i]");
            }           
        }
    }
}
