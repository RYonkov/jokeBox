using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E6._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Using nested Dictionaries - first key for the color, second key for the clothes, int as a counter
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());

            for (int j = 0; j < n; j++)
            {
                string input = Console.ReadLine();
                //using Regex for taking the colour (group 1) and for taking the array of clothes (group 2)
                string seekPattern = @"([A-Za-zА-Яа-я]+).?->.?([A-Za-z|-А-Яа-я|,|-|\x20]+)";

                MatchCollection matches = Regex.Matches(input, seekPattern);
                foreach (Match match in matches)
                {
                    string color = match.Groups[1].Value;

                    if (!wardrobe.ContainsKey(color))
                    {
                        wardrobe.Add(color, new Dictionary<string, int>());
                    }                    
                    string[] clothes = match.Groups[2].Value.Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    for (int i = 0; i < clothes.Length; i++)
                    {
                        if (wardrobe[color].ContainsKey(clothes[i]))
                        {
                            wardrobe[color][clothes[i]]++;
                        }
                        else
                        {
                            wardrobe[color].Add(clothes[i], 1);
                        }
                    }
                }
            }
            string[] seekCloth = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var element in wardrobe.Keys)
            {
                Console.WriteLine($"{element} clothes:");
                foreach (var item in wardrobe[element])
                {
                    if (element==seekCloth[0] && item.Key==seekCloth[1])
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }                  
                    
                }
            }
        }
    }
}
