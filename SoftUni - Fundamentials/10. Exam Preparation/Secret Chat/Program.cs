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
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Reveal")
            {
                string[] cmdArgs = command.Split(":|:").ToArray();

                if (cmdArgs[0] == "InsertSpace")
                {
                    message = message.Insert(int.Parse(cmdArgs[1]), ' '.ToString());
                    Console.WriteLine(message);
                }

                if (cmdArgs[0] == "Reverse")
                {
                    string substring = ReversedString(cmdArgs[1]);
                    if (message.Contains(cmdArgs[1]))
                    {
                        int index = message.IndexOf(cmdArgs[1]);
                        message = message.Remove(index, cmdArgs[1].Length);
                        message = message + substring;                                        
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                        command = Console.ReadLine();
                        continue;
                    }
                }

                if (cmdArgs[0] == "ChangeAll")
                {
                    string substring = cmdArgs[1];
                    string newSubstring = cmdArgs[2];
                    message = message.Replace(substring, newSubstring);
                    Console.WriteLine(message);
                    ;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {message}");
        }

        static string ReversedString(string input)
        {
            string output = "";
            for (int i = input.Length - 1; i >= 0; i--)
            {
                output += input[i];
            }
            return output;
        }
    }
}