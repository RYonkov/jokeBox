using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E1.UniqueUsernames
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			HashSet<string> usernames = new HashSet<string>();
			for (int i = 0; i < n; i++)
			{
				string input = Console.ReadLine();
				usernames.Add(input);
			}

			foreach (string element in usernames)
			{
				Console.WriteLine(element);
			}
		}
	}
}
