using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E7._Predicate_for_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1st solution - using Predicate
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            Predicate<string> isCorrect = x => x.Length <= n;

            foreach (string element in names)
                if (isCorrect(element))
                    Console.WriteLine(element);



            ////2nd solution - input only names meeting the criteria
            //int n = int.Parse(Console.ReadLine());
            //List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(x=>x.Length<=n).ToList();
            //foreach (string element in names)
            //     Console.WriteLine(element);




            ////3rd solution - on two lines
            //int n = int.Parse(Console.ReadLine());
            //Console.WriteLine(String.Join("\n\r", Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Where(x => x.Length <= n).ToList()));

        }
    }
}
