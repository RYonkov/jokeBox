using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues, sets
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.IO;
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace _8.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> people = new HashSet<string>();
            HashSet<string> VIP = new HashSet<string>();

            string input = Console.ReadLine();

            while (input!="PARTY" && input!="END")
            {
                if (input.Length!=8)
                {
                    input = Console.ReadLine();
                    continue;
                }   
                
                if (Char.IsDigit(input[0]))
                {
                    VIP.Add(input);
                }
                else
                {
                    people.Add(input);
                }                
                input = Console.ReadLine();
            }

            while (input != "END")
            {
                input = Console.ReadLine();
                people.Remove(input);
                VIP.Remove(input);
            }

            Console.WriteLine(people.Count + VIP.Count);
            if (people.Count > 0 || VIP.Count>0)
            {                     
                //VIP = VIP.OrderBy(x => x).ToHashSet();
                //people = people.OrderBy(x => x).ToHashSet();
                  
                    foreach (string element in VIP)
                    {
                        Console.WriteLine(element);
                    }
                    foreach (string element in people)
                    {
                        Console.WriteLine(element);
                    }
            }                                
        }
    }
}