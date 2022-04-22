using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E3_MaximumAndMinimumElement
{
	internal class Program
	{
		static void Main()
		{
			Stack<int> numbers = new Stack<int>();
			List<int> numbers2 = new List<int>();
			int n = int.Parse(Console.ReadLine()); 


			int minN = int.MaxValue;
			int maxN = int.MinValue;

			for (int i = 0; i < n; i++)
			{
				int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
				if (input[0] == 1)
				{
					numbers.Push(input[1]);
				}
				else if (input[0] == 2 && numbers.Count!=0)
				{
					numbers.Pop();
				}
				else if (input[0] == 3)
				{
					if (numbers.Count == 0)
					{
						continue;
					}
					else
					{
						numbers2 = numbers.ToList();
						maxN = numbers2.Max();
                        Console.WriteLine(maxN);					
					}
				}
				else if (input[0] == 4)
				{
					if (numbers.Count == 0)
					{
						continue;
					}
					else
					{
						numbers2 = numbers.ToList();
						minN = numbers2.Min();
                        Console.WriteLine(minN);
					}
				}
			}
			Console.WriteLine(String.Join(", ", numbers));
		}
	}
}
