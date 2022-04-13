using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex


namespace ReverseStrings
{
	class Program
	{
		static void Main()
		{
			string input = Console.ReadLine();
			Stack<char> stack = new Stack<char>(input);				
			
					
			while (stack.Count > 0)
			{
				Console.Write(stack.Pop());
			}
		}
        
    }
}