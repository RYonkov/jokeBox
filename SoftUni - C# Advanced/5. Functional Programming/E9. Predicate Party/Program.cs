using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E9._Predicate_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine();



            while (input != "Party!")
            {
                string command = input.Split()[0];
                Predicate<string> predicate = GetPredicate(input);

                if (command == "Remove")
                {
                    people.RemoveAll(predicate);
                }
                else if (command == "Double")
                {                    
                    for (int i = 0; i < people.Count; i++)
                    {
                        string person = people[i];

                        if (predicate(person))
                        {
                            people.Insert(i + 1, person);
                            i++;
                        }                       
                    }
                }               
                input = Console.ReadLine();
            }

            if (people.Count>0)
            {
                Console.Write(String.Join(", ", people));
                Console.WriteLine(" are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string input)
        {                    
            string condition = input.Split()[1];
            string arg = input.Split()[2];

            Predicate<string> predicate = null;

            if (condition == "StartsWith")
            {
                predicate = x => x.StartsWith(arg);
            }
            else if (condition == "EndsWith")
            {
                predicate = x => x.EndsWith(arg);
            }
            else if (condition == "Length")
            {
                predicate = x => x.Length == int.Parse(arg);
            }
            return predicate;

        }
    }
}
