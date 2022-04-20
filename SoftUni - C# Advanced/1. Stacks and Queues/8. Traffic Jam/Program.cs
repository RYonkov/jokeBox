using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace TrafficJam
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			string input = Console.ReadLine();
			int count = 0;
			Queue<string> queue = new Queue<string>();

			while (input != "end")
			{
				if (input == "green")
				{
					for (int i = 0; i < n && queue.Count!=0; i++)
					{
						if (queue.Count > 0)
						{
							Console.WriteLine($"{queue.Dequeue()} passed!");
							count++;
						}
					}
				}
				else
				{
					queue.Enqueue(input);
				}
				input = Console.ReadLine();
			}
			Console.WriteLine($"{count} cars passed the crossroads.");
		}
	}
}
