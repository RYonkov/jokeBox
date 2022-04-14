using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main()
        {
			int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
			Stack<int> stack = new Stack<int>(input);

			string action = Console.ReadLine().ToLower();

			while (action != "end") 
			{
				string[] cmdArgs = action.Split(' ').ToArray();

				if (cmdArgs[0] == "add")
				{
					stack.Push(int.Parse(cmdArgs[1]));
					stack.Push(int.Parse(cmdArgs[2]));
				}
				else if (cmdArgs[0] == "remove")
				{
					if (stack.Count >= int.Parse(cmdArgs[1]))
					{
						for (int i = 0; i < int.Parse(cmdArgs[1]); i++)
						{
							stack.Pop();
						}
					}
				}

				action = Console.ReadLine().ToLower();
			}

			int sum = 0;
            while (stack.Count > 0)
            {
                sum += stack.Pop();
            }

			//Option with using Method in LINQ
			//int sum = stack.Sum(); 

            Console.WriteLine($"Sum: {sum}");
		}
    }
}
