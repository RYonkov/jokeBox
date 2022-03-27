using System;
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex
using System.Linq;                          //For lambda expressions
using System.Collections.Generic;           //For Dictionaries
using System.Numerics;                      //For BigInteger
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics


namespace ExercisingRegex
{
    internal class Program
    {
        static string ReversedString(string input)
        {
            string output = "";
            for (int i = input.Length - 1; i >= 0; i--)
            {
                output += input[i];
            }
            return output;
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string seekPattern = @"([@|#]){1}[A-Za-zА-Яа-я]{3,}\1\1[A-Za-zА-Яа-я]{3,}\1";

            MatchCollection matches = Regex.Matches(input, seekPattern);
            string[] words = new string[matches.Count];
            List<string> mirrorWords = new List<string>();

            int i = 0;
            foreach (Match match in matches)
            {
                words[i] = match.Value;
                i++;
            }

            if (words.Length == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else if (true)
            {

                Console.WriteLine($"{words.Length} word pairs found!");
            }

            for (int j = 0; j < words.Length; j++)
            {
                string current = ReversedString(words[j]);

                if (words[j] == current)
                {
                    string singleWord = words[j].Substring(1, (words[j].Length / 2 - 2));
                    mirrorWords.Add(ReversedString(singleWord));
                    mirrorWords.Add(singleWord);
                }
            }


            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                PrintListOnOneLine(mirrorWords);
            }
        }

        static void PrintListOnOneLine(List<string> myList)
        {
            string output = "";
            for (int n = 0; n < myList.Count - 2; n = n + 2)
            {
                output += $"{myList[n + 1]} <=> {myList[n]}" + ", ";
            }
            output += $"{myList[myList.Count - 1]} <=> {myList[myList.Count - 2]}";
            Console.WriteLine(output);
        }
    }
}