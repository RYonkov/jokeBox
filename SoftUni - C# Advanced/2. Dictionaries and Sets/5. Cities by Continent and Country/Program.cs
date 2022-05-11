using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues, sets
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace _5.Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> places = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!places.ContainsKey(continent))
                {
                    places.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!places[continent].ContainsKey(country))
                {
                    places[continent].Add(country, new List<string>());
                }                
                places[continent][country].Add(city);                
            }
            
            
            

            foreach (var element in places)
            {
                Console.WriteLine($"{element.Key}:");

                foreach (var country in element.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {String.Join(", ", country.Value)}");
                }
            }


        }
    }
}