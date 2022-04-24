using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E4_FastFood
{
	internal class Program
	{
		static void Main()
		{
			int totalFood = int.Parse(Console.ReadLine());
			int[] orders = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();            
			Queue<int> queue = new Queue<int>(orders);
			List<int> ordersList = new List<int>(queue);
			int biggest = ordersList.Max();
			Console.WriteLine(biggest);

            while (queue.Count>0)
            {
                if (queue.Peek()<=totalFood)
                {					
					totalFood -= queue.Dequeue();                    
                }
                else
                {
					break;
                }
            }

            if (queue.Count==0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.Write($"Orders left: ");
                Console.Write(String.Join(' ', queue));
            }
		}
	}
}
