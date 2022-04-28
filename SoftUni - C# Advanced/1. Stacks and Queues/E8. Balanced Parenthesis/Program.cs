using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E8.BalancedParenthesis
{
	internal class Program
	{
		static void Main(string[] args)
		{
			char[] brackets = Console.ReadLine().ToArray();
			Stack<char> stack = new Stack<char>();

			foreach (var element in brackets)
			{
				if (element == '(' || element == '[' || element == '{')
				{
					stack.Push(element);
					continue;
				}

				if ((element == ')' && stack.Count > 0 && stack.Peek() == '(') || (element == ']' && stack.Count > 0 && stack.Peek() == '[') || (element == '}' && stack.Count > 0 && stack.Peek() == '{'))
				{
					stack.Pop();
					continue;
				}

				if (element != '(' || element != '[' || element != '{' || element != ')' || element != ']' || element != '}')
				{
					stack.Push(element);
					break;
				}
			}

			if (stack.Count == 0)
			{
				Console.WriteLine("YES");
			}
			else
			{
				Console.WriteLine("NO");
			}
		}
	}
}
