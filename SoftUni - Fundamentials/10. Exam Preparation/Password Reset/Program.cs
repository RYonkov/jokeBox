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
            string[] commands = { "TakeOdd", "Cut", "Subscribe" };
                      
            string message = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string action = cmdArgs[0];

                if (action == commands[1])
                {
                    string output = String.Empty;
                    for (int i = 1; i < message.Length; i=i+2)
                    {
                        output+=message[i];
                    }
                    message = output;
                }
                else if (action == commands[2])
                {
                    int index = int.Parse(cmdArgs[1]);
                    int lenght = int.Parse(cmdArgs[2]);
                    message = message.Remove(index, lenght);
                }
                else if (action == commands[3])
                {
                    string substring = cmdArgs[1];
                    string replacement = cmdArgs[2];

                    bool hasReplacement = false;
                    while (message.Contains(substring))
                    {
                        message = message.Replace(substring, replacement);
                        hasReplacement = true;
                    }
                    
                    if (!hasReplacement)
                    {
                        Console.WriteLine("Nothing to replace!");
                        command = Console.ReadLine();
                        continue;
                    }                 
                }
                Console.WriteLine(message);
                command = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {message}");
        }
    }
}
