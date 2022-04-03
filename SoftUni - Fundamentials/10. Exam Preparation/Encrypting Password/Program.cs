using System;
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex
using System.Linq;                          //For lambda expressions
using System.Collections.Generic;           //For Dictionaries
using System.Numerics;                      //For BigInteger
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics


namespace EncryptingPassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string seekPattern = @"^(.*)>(\d{3})\|([a-zа-я]{3})\|([A-ZА-Я]{3})\|([^><]{3})<\1$";
           
            for (int i = 0; i < n; i++)
            {
                string current = string.Empty;
                string output = string.Empty;
                string input = Console.ReadLine();
                Match match = Regex.Match(input, seekPattern);
                current = match.ToString();

                if (current.Length == 0)
                {
                    Console.WriteLine("Try another password!");
                }
                else
                {
                    for (int j = 2; j < 6; j++)
                    {
                        output += match.Groups[j].Value;
                    }
                    Console.WriteLine($"Password: {output}");
                }             
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