using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues, sets
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace _2.Average_Student_Grade
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> studentGrades  = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (!studentGrades.ContainsKey(input[0]))
                {
                    studentGrades.Add(input[0], new List<decimal>());
                }
                studentGrades[input[0]].Add(decimal.Parse(input[1]));                             
            }

            foreach (var element in studentGrades)
            {
                string grades = String.Join(' ', element.Value);
                Console.Write($"{element.Key} -> ");
                foreach (var grade in element.Value)
                {
                    Console.Write($"{grade:F2} ");
                }                
                Console.WriteLine($"(avg: {element.Value.Average():F2})");
            }
        }
    }
}