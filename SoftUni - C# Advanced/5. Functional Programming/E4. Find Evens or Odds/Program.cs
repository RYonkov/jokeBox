using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E4._FindEvenOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> output = new List<int>(); 
            int start = nums[0];
            int end = nums[1];
            if (start>end)
            {
                return;
            }
            for (int i = start; i <= end; i++)
            {
                output.Add(i);
            }

            string seeked = Console.ReadLine().ToLower();

            //Predicate<int> isEven = x => x % 2 == 0;
            //Predicate<int> isOdd = x => x % 2 == 1;

            //if (seeked == "even")
            //{
            //    for (int i = start; i <= end; i++)
            //    {
            //        if (isEven(i))
            //        {
            //            Console.Write(i + " ");
            //        }
            //    }
            //}
            //else if (seeked == "odd")
            //{
            //    for (int i = start; i <= end; i++)
            //    {
            //        if (isOdd(i))
            //        {
            //            Console.Write(i + " ");
            //        }
            //    }
            //}

            Predicate<int> predicate = null;
            if (seeked=="even")
            {
                predicate = x => x % 2 == 0;
            }
            else if (seeked=="odd")
            {
                predicate = x => x % 2 != 0;                
            }

            Console.WriteLine(String.Join(" ", output.FindAll(predicate)));
        }
    }
}
