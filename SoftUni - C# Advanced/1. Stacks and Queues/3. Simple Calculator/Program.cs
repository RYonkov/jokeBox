using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace _3._Simple_Calculator
{
	internal class Program
	{
		static void Main()
		{
			string[] input = Console.ReadLine().Split (' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
			Queue<string> queue = new Queue<string>();

            for (int i = 0; i < input.Length; i++)
            {
				queue.Enqueue(input[i]);
            }
					
			int output = int.Parse(queue.Dequeue()); 
			while (queue.Count > 0)
            {
                char ch = queue.Dequeue()[0];
				int next = int.Parse(queue.Dequeue());
				
				if (ch =='+')
                {
					output += next;
                }
                else if (ch=='-')
                {
					output -= next;
                }
            }
			Console.WriteLine(output);
		}
	}
}
