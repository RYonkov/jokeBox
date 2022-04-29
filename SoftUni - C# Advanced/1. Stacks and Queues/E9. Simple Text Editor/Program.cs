using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E9.SimpleTextEditor
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			string current = "";
			Stack<string> output = new Stack<string>();
			output.Push(current);

			for (int i = 0; i < n; i++)
			{
				string[] input = Console.ReadLine().Split(' ').ToArray();
				if (input[0][0] == '1')
				{
					current = string.Concat(output.Peek(), input[1]);
					output.Push(current);
				}
				else if (input[0][0] == '2' && output.Count > 0)
				{
					current = output.Peek();
					int count = int.Parse(input[1]);
					current = current.Remove(current.Length - count, count);
					output.Push(current);
				}
				else if (input[0][0] == '3')
				{
					int count = int.Parse(input[1]);
					Console.WriteLine(output.Peek()[count - 1]);
				}
				else if (input[0][0] == '4')
				{
					output.Pop();
				}
			}

		}
	}
}
