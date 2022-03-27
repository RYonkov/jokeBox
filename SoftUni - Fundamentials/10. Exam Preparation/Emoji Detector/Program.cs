using System;
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex
using System.Linq;                          //For lambda expressions
using System.Collections.Generic;           //For Dictionaries
using System.Numerics;                      //For BigInteger
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics


namespace ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string seekPattern = @"(:|\*)\1([A-Z][a-z]{2,})\1\1";
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, seekPattern);
            List<string> emojis = new List<string>();
            long coolTreshold = 1; 

            StringBuilder sb = new StringBuilder();

            //Extracting each digit, store in StringBuilder and calculation of Cool Treshold
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    sb.Append(input[i]);
                    int current = (input[i])-48;
                    coolTreshold *= current;                  
                }
            }
            Console.WriteLine($"Cool threshold: {coolTreshold}");

            //Populating the list of emojis
            foreach (Match match in matches)
            {
                string emoji = match.Groups[0].Value;                        
                emojis.Add(emoji);                
            }

            Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");
            foreach (string element in emojis)
            {
                int coolness = 0;
                for (int i = 2; i < element.Length-2; i++)
                {
                    coolness += element[i];
                }
                if (coolness>coolTreshold)
                {
                    Console.WriteLine($"{element}");
                }                
            }

        }
    }
}
