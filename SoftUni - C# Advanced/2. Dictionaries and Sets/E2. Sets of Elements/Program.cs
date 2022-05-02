using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E2.SetsOflements
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

			HashSet<int> set1 = new HashSet<int>();
			HashSet<int> set2 = new HashSet<int>();


			for (int i = 0; i < size[0]; i++)
			{
				string input = Console.ReadLine();
				set1.Add(int.Parse(input));
			}

			for (int i = 0; i < size[1]; i++)
			{
				string input = Console.ReadLine();
				set2.Add(int.Parse(input));
			}


			set1.IntersectWith(set2);

			//foreach (int element in set1)
			{
				Console.Write(String.Join(' ', set1));
			}
		}
	}
}
