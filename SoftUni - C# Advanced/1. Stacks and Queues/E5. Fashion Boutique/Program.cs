using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E5._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> clothes = new Stack<int>(input);
            int initialCapacity = int.Parse(Console.ReadLine());
            int capacity = initialCapacity;

            int count = 1; 
            while (clothes.Count > 0)
            {
                if (clothes.Peek()<=capacity)
                {                    
                    capacity -= clothes.Pop();
                }
                else
                {
                    count++;
                    capacity = initialCapacity;
                    capacity -= clothes.Pop();
                }
            }
            Console.WriteLine(count);
        }
    }
}
