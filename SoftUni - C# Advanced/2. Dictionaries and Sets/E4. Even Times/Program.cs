using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E4.EvenTimes
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
				int input = int.Parse(Console.ReadLine());
                if (numbers.ContainsKey(input))
                {
					numbers[input]++;
                }
                else
                {
					numbers.Add(input, 1);
                }                
			}
			
			foreach (var elelement in numbers)
            {
                if (elelement.Value%2==0)
                {
					Console.WriteLine(elelement.Key);
				}				
            }
		}
	}
}
