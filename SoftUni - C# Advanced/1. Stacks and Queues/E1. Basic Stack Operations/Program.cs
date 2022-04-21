using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E1_BasicStackOperations
{
	internal class Program
	{
		static void Main()
		{
			int[] parameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
			int n = parameters[0];
			int s = parameters[1];
			int x = parameters[2];

			int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

			Stack<int> numbers = new Stack<int>();
			int minN = int.MaxValue;
			for (int i = 0; i < (n - s); i++)
			{
				numbers.Push(input[i]);
			}

			if (numbers.Count == 0)
			{
				Console.WriteLine(0);
				return;
			}

			if (numbers.Contains(x))
			{
				Console.WriteLine("true");
			}
			else
			{
				for (int j = 0; j < (n - s); j++)
				{
					int current = numbers.Pop();
					if (minN > current)
					{
						minN = current;
					}
				}
				Console.WriteLine(minN);
			}
		}
	}
}
