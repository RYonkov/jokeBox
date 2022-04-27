using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E7.TruckTour
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			List<int> fuelStations = new List<int>();


			for (int i = 0; i < n; i++)
			{
				int[] station = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
				int current = station[0] - station[1];
				fuelStations.Add(current);
			}

			Queue<int> queue = new Queue<int>(fuelStations);

			for (int j = 0; j < n; j++)
			{
				bool hasNotFailed = true;
				long totalFuel = 0;

				foreach (int element in queue)
				{
					totalFuel += element;
					if (totalFuel < 0)
					{
						hasNotFailed = false;
						break;
					}
				}

				if (hasNotFailed)
				{
					Console.WriteLine(j);
					break;
				}
				else
				{
					queue.Enqueue(queue.Dequeue());
				}
			}
		}
	}
}
