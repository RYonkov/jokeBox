using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace _4._Matching_Brackets
{
	internal class Program
	{
		static void Main()
		{
			string input = Console.ReadLine();
			Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {				          
				if (input[i] =='(')
                {
					stack.Push(i);
                }
				else if (input[i] ==')')
                {
                    int startIndex = stack.Pop();
					int endIndex = i;
					Console.WriteLine(input.Substring(startIndex, endIndex-startIndex+1));
                }
            }
		}
	}
}
