using System;
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex
using System.Linq;                          //For lambda expressions
using System.Collections.Generic;           //For Dictionaries
using System.Numerics;                      //For BigInteger
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics


namespace The_Pianist
{
    //class Pieces
    //{
    //    public Pieces(string name, string author, string gamma)
    //    {
    //        this.Name = name;
    //        this.Author = author;
    //        this.Gamma = gamma;
    //    }
    //    public string Name { get; set; }
    //    public string Author { get; set; }
    //    public string Gamma { get; set; }

    //}
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            Dictionary<string, int> plants = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                PopulateDictionary(input, plants);
            }

            Dictionary < string, List<double>> ratings = new Dictionary<string, List<double>>();

            foreach (string element in plants.Keys)
            {
                ratings.Add(element, new List<double>());
            }

            string command = Console.ReadLine();
            while (command != "Exhibition")
            {
                string[] cmdArgs = command.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                string[] parameters = cmdArgs[1].Split('-', StringSplitOptions.RemoveEmptyEntries);
                string plant = parameters[0].Trim();

                if (!plants.ContainsKey(plant))
                {
                    Console.WriteLine("error");
                    command = Console.ReadLine();
                    continue;
                }

                if (action == "Rate" && ratings.ContainsKey(plant))
                {                   
                    ratings[plant].Add(double.Parse(parameters[1].Trim()));                                   
                }
                else if (action == "Update" && plants.ContainsKey(plant))
                {
                    plants[plant] = int.Parse(parameters[1].Trim());                     
                }
                else if (action == "Reset" && plants.ContainsKey(plant))
                {                    
                    ratings[plant].Clear();
                }
              
                command = Console.ReadLine();
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var element in plants)
            {
                double average = 0;
                if (ratings.ContainsKey(element.Key) && ratings[element.Key].Count > 0)
                {
                   average = ratings[element.Key].Average();
                }
                Console.WriteLine($"- {element.Key}; Rarity: {element.Value}; Rating: {average:f2}");
            }
        }

        static Dictionary<string, int> PopulateDictionary(string input, Dictionary<string, int> dict)
        {
            string[] cmdArgs = input.Split("<->", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string key = cmdArgs[0].Trim();
            int uniqueValue = int.Parse(cmdArgs[1].Trim());
            

            if (!dict.ContainsKey(key))
            {
                dict.Add(key, uniqueValue);              
            }
            else
            {
                dict[key]=uniqueValue;                
            }
            return dict;
        }

    }
}
