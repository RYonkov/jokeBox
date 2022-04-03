using System;
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex
using System.Linq;                          //For lambda expressions
using System.Collections.Generic;           //For Dictionaries
using System.Numerics;                      //For BigInteger
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics


namespace HeroRecruitment

{
    class Program
    {
        static void Main(string[] args)
        {                        
            Dictionary<string, List<string>> heroes = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0].Trim();
                string name = cmdArgs[1].Trim();

                if (action == "Enroll")
                {
                    if (heroes.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} is already enrolled.");
                    }
                    else
                    {
                        heroes.Add(name, new List<string>());
                    }
                }
                else if (action == "Learn")
                {
                    string spell = cmdArgs[2].Trim();
                    if (!heroes.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} doesn't exist.");
                    }
                    else if (heroes[name].Contains(spell))
                    {
                        Console.WriteLine($"{name} has already learnt {spell}");
                    }
                    else
                    {
                        heroes[name].Add(spell);
                    }
                }
                else if (action == "Unlearn")
                {
                    string spell = cmdArgs[2].Trim();
                    if (!heroes.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} doesn't exist.");
                    }
                    else if (!heroes[name].Contains(spell))
                    {
                        Console.WriteLine($"{name} doesn't know {spell}");
                    }
                    else
                    {
                        heroes[name].Remove(spell);
                    }
                }                
                command = Console.ReadLine();
            }

            Console.WriteLine("Heroes:");
            foreach (KeyValuePair<string, List<string>> element in heroes)
            {
                Console.WriteLine($"== {element.Key}: {String.Join(", ", element.Value)}");
            }

        }
    }
}
