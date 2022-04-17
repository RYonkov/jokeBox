using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace _5._Print_Even_Numbers
{
	internal class Program
	{
		static void Main()
		{
            Queue<int> queue = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            while (queue.Count>0)
            {
                if (queue.Peek()%2==0)
                {
                    Console.Write(queue.Dequeue());
                    if (queue.Count>0)
                    {
                        Console.Write(", ");
                    }
                }
                else
                {
                    queue.Dequeue();
                }

                //Solution with LINQ
                //Queue<int> queue = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
                //Queue<int> evenQueue = new Queue<int>(queue.Where(x => x % 2 == 0).ToList());
                //Console.WriteLine(String.Join(", ", evenQueue));
            }            		
		}
	}
}
