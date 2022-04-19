using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace HotPotato
{
	internal class Program
	{
		static void Main()
		{
			string[] names = Console.ReadLine().Split(' ').ToArray();

			Queue<string> kids = new Queue<string>(names);
			int n = int.Parse(Console.ReadLine());

			while (kids.Count() > 1)
			{
				for (int i = 0; i < n - 1; i++)
				{
					string current = kids.Dequeue();
					kids.Enqueue(current);
				}
				Console.WriteLine($"Removed {kids.Dequeue()}");
			}
			Console.WriteLine($"Last is {kids.Dequeue()}");
		}
	}
}
