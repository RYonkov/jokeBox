using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace _5._Filter_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());            
            List<ValueTuple<string, int>> myValueTuple = new List<ValueTuple<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                myValueTuple.Add(ValueTuple.Create(input[0], int.Parse(input[1])));
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();          
            
            if (condition=="older")
            {
                myValueTuple = myValueTuple.Where(x => x.Item2 >= age).ToList();
            }
            else if (condition=="younger")
            {
                myValueTuple = myValueTuple.Where(x => x.Item2 < age).ToList();
            }

            if (format == "name")
            {
                foreach (var tuple in myValueTuple)
                {
                    Console.WriteLine(tuple.Item1);
                }
            }
            else if (format == "age")
            {
                foreach (var tuple in myValueTuple)
                {
                    Console.WriteLine(tuple.Item2);
                }
            } else if (format == "name age")
            {
                foreach (var tuple in myValueTuple)
                {
                    Console.WriteLine(tuple.Item1+" - "+tuple.Item2);
                }
            }          
        }
    }
}
