using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues, sets
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace _7.ParkingLots
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] cmdArgs = input.Split(", ").ToArray();
                if (cmdArgs[0]=="IN")
                {
                    set.Add(cmdArgs[1]);
                }
                else if (cmdArgs[0]=="OUT")
                {
                    set.Remove(cmdArgs[1]);
                }
                input = Console.ReadLine();
            }

            if (set.Count >0)
            {
                foreach (string element in set)
                {
                    Console.WriteLine(element);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}