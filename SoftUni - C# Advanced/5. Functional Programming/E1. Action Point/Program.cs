using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E1._Action_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ').ToList();
            Action<string> print = x => Console.WriteLine(x);
             input.ForEach(print);

            //2st way - with for loop
            //for (int i = 0; i < input.Count; i++)
            //{
            //    print(input[i]);
            //}

            //3nd way - with Lambda 
            //input.ForEach(x => Console.WriteLine(x));         
           
        }
    }
}
