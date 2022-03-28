using System;
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex
using System.Linq;                          //For lambda expressions
using System.Collections.Generic;           //For Dictionaries
using System.Numerics;                      //For BigInteger
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics


namespace Pirates
{
    class City
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> cities = new Dictionary<string, List<int>>();

            string input = Console.ReadLine();
            while (input != "Sail")
            {
                PopulateDictionary(input, cities);


                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                string[] cmdArgs = input.Split("=>").ToArray();
                string action = cmdArgs[0];
                string city = cmdArgs[1];
                int people = 0;
                int gold = 0;

                if (action == "Plunder" && cities.ContainsKey(city))
                {
                    people = int.Parse(cmdArgs[2]);
                    gold = int.Parse(cmdArgs[3]);
                    cities[city][0] -= people;
                    cities[city][1] -= gold;
                    Console.WriteLine($"{city} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (cities[city][0] <= 0 || cities[city][1] <= 0)
                    {
                        Console.WriteLine($"{city} has been wiped off the map!");
                        cities.Remove(city);
                    }                  
                }

                if (action == "Prosper" && cities.ContainsKey(city))
                {
                    gold = int.Parse(cmdArgs[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        input = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        cities[city][1] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {city} now has {cities[city][1]} gold.");
                    }
                }
                input = Console.ReadLine();
            }

            if (cities.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                foreach (var city in cities)
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value[0]} citizens, Gold: {city.Value[1]} kg");
                }

            }
        }

        static Dictionary<string, List<int>> PopulateDictionary(string input, Dictionary<string, List<int>> dict)
        {
            string[] cmdArgs = input.Split("||", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string key = cmdArgs[0].Trim();
            int uniqueValue = int.Parse(cmdArgs[1].Trim());
            int uniqueValue2 = int.Parse(cmdArgs[2].Trim());

            if (!dict.ContainsKey(key))
            {
                dict.Add(key, new List<int>());
                dict[key].Add(uniqueValue);
                dict[key].Add(uniqueValue2);
            }
            else
            {
                //if (!dict[key].Contains(uniqueValue))
                {
                    dict[key][0] += uniqueValue;
                    dict[key][1] += uniqueValue2;
                }
            }
            return dict;
        }

    }
}
