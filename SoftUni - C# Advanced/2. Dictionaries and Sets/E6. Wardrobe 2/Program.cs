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
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] clothes = input[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobe.ContainsKey(color))
                {
                        wardrobe.Add(color, new Dictionary<string, int>());
                }
                
                    
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
            string[] seekCloth = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var element in wardrobe.Keys)
            {
                Console.WriteLine($"{element} clothes:");
                foreach (var item in wardrobe[element])
                {
                    if (element == seekCloth[0] && item.Key == seekCloth[1])
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
