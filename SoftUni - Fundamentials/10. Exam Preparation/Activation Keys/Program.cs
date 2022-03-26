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
            string[] commands = { "Contains", "Flip", "Slice" };

            string message = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Generate")
            {
                string[] cmdArgs = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string action = cmdArgs[0];

                if (action == commands[0])
                {
                    string substring = cmdArgs[1];
                    if (message.Contains(substring))
                    {
                        Console.WriteLine($"{message} contains {substring}");

                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");                        
                    }
                    command = Console.ReadLine();
                    continue;
                }
                else if (action == commands[1])
                {
                    string direction = cmdArgs[1];                                     
                    int index = int.Parse(cmdArgs[2]);
                    int endIndex = int.Parse(cmdArgs[3]);
                    if (index>endIndex)
                    {
                        int higher = index;
                        index=endIndex;
                        endIndex=higher;
                    }
                    string current = message.Substring(index, endIndex - index);
                    
                    if (!(index < 0 || index >= message.Length || endIndex < 0 || endIndex >= message.Length))
                    {
                        if (direction=="Upper")
                        {
                            current=current.ToUpper();
                        }
                        else if (direction=="Lower")
                        {
                            current = current.ToLower();
                        }
                    }
                    message = message.Remove(index, endIndex-index);
                    message = message.Insert(index, current);

                }
                else if (action == commands[2])
                {
                    int index = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    message = message.Remove(index, endIndex-index);                  
                }
                Console.WriteLine(message);
                command = Console.ReadLine();
            }
            Console.WriteLine($"Your activation key is: {message}");
        }
    }
}
