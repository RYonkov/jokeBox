using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E6._Reverse_and_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            ////With Lambda Function
            //foreach (var element in nums.Where(x => x % n != 0).OrderByDescending(x => x))
            //{
            //    Console.Write(element + " ");
            //}

            //With Predicate
            Predicate<int> isDivisible = num => num % n == 0;
            nums = nums.Reverse().ToArray();

            foreach (var element in nums)
                 if (!isDivisible(element))              
                    Console.Write(element + " ");
                
            
          
        }
    }
}
