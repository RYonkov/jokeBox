using System;
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex
using System.Linq;                          //For lambda expressions
using System.Collections.Generic;           //For Dictionaries
using System.Numerics;                      //For BigInteger
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics


namespace StringGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string command = Console.ReadLine();

            while (command!="Done")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string action = cmdArgs[0];

                if (action== "Change")
                {
                        char seek = cmdArgs[1][0];
                        char replacement = cmdArgs[2][0];
                        message = message.Replace(seek, replacement);
                        Console.WriteLine(message);                 
                }
                else if (action== "Includes")
                {
                    string substring = cmdArgs[1];
                    Console.WriteLine(message.Contains(substring));                                      
                }
                else if (action== "End")
                {
                    string substring = cmdArgs[1];
                    Console.WriteLine(message.EndsWith(substring));
                    
                }
                else if (action == "Uppercase")
                {
                    message = message.ToUpper();
                    Console.WriteLine(message);
                }
                else if (action == "FindIndex")
                {
                    char seek = cmdArgs[1][0];
                    Console.WriteLine( message.IndexOf(seek));

                }
                else if (action == "Cut")
                {
                    int index = int.Parse(cmdArgs[1]);
                    int count = int.Parse(cmdArgs[2]);
                    string output = message.Substring(index, count);
                    Console.WriteLine(output);
                }
                command = Console.ReadLine();
            }           
        }
    }
}

