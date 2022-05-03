using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E3.PeriodicTable
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());


			HashSet<string> elements = new HashSet<string>();


			for (int i = 0; i < n; i++)
			{
				string[] input = Console.ReadLine().Split(' ').ToArray();
				for (int j = 0; j < input.Length; j++)
				{
					elements.Add(input[j]);
				}
			}
			elements = elements.OrderBy(x => x).ToHashSet();

			Console.Write(String.Join(' ', elements));
		}
	}
}
