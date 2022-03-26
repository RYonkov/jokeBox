using System;
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex
using System.Linq;                          //For lambda expressions
using System.Collections.Generic;           //For Dictionaries
using System.Numerics;                      //For BigInteger
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics


namespace ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string seekPattern = @"([=\/])([A-Z][a-z]{2,})\1";
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, seekPattern);
            List<string> destinations = new List<string>();
            int totalSum = 0;
          
            foreach (Match match in matches)
            {
                string destination = match.Groups[2].Value;    
                destinations.Add(destination);
                totalSum += destination.Length;
            }                    
            Console.WriteLine($"Destinations: {String.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {totalSum}");
        }
    }
}
