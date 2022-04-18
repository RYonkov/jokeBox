using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace Supermarket
{
	internal class Program
	{
		static void Main()
		{
			Queue<string> supermarketQueue = new Queue<string>();
			string input = Console.ReadLine();
			while (input != "End")
			{
				if (input == "Paid")
				{
					foreach (string element in supermarketQueue)
					{
						Console.WriteLine(element);
					}
					supermarketQueue.Clear();
				}
				else
				{
					supermarketQueue.Enqueue(input);
				}
				input = Console.ReadLine();
			}
			Console.WriteLine($"{supermarketQueue.Count} people remaining.");
		}
	}
}
