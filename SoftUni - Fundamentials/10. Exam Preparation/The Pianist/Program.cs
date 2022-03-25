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
    class Pieces
    {
        public Pieces(string name, string author, string gamma)
        {
            this.Name = name;
            this.Author = author;
            this.Gamma = gamma;
        }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Gamma { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           

            Dictionary<string, List<string>> pieces = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine(); 
                PopulateDictionary(input, pieces);

            }          

            string command = Console.ReadLine();
            while (command!= "Stop")
            {
                string[] cmdArgs = command.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                
                if (action == "Add")
                {
                    string piece = cmdArgs[1];
                    string author = cmdArgs[2];
                    string gamma = cmdArgs[3];
                    if (!pieces.ContainsKey(piece))
                    {
                        pieces.Add(piece, new List<string>() {author, gamma});
                        Console.WriteLine($"{piece} by {author} in {gamma} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }
                else if (action == "Remove")
                {
                    string piece = cmdArgs[1];
                    if (pieces.ContainsKey(piece))
                    {
                        pieces.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (action == "ChangeKey")
                {
                    string piece = cmdArgs[1];
                    string gamma = cmdArgs[2];
                    if (pieces.ContainsKey(piece))
                    {
                        pieces[piece][1] = gamma;
                        Console.WriteLine($"Changed the key of {piece} to {gamma}!");                        
                    } else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }                         
                command = Console.ReadLine();
            }
            foreach (var element in pieces)
            {
                Console.WriteLine($"{element.Key} -> Composer: {element.Value[0]}, Key: {element.Value[1]}");
            }                      
        }

        static Dictionary<string, List<string>> PopulateDictionary(string input, Dictionary<string, List<string>> dict)
        {
            string[] cmdArgs = input.Split("|", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string key = cmdArgs[0].Trim();
            string uniqueValue = cmdArgs[1].Trim();
            string uniqueValue2 = cmdArgs[2].Trim();

            if (!dict.ContainsKey(key))
            {
                dict.Add(key, new List<string>());
                dict[key].Add(uniqueValue);
                dict[key].Add(uniqueValue2);
            }
            else
            {
                if (!dict[key].Contains(uniqueValue))
                {
                    dict[key].Add(uniqueValue);
                    dict[key].Add(uniqueValue2);
                }
            }
            return dict;
        }

    }
}
