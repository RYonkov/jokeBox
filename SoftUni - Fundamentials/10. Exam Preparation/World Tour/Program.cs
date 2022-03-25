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
            string[] commands = { "Add Stop", "Remove Stop", "Switch" };

            string message = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Travel")
            {
                string[] cmdArgs = command.Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string action = cmdArgs[0];

                if (action == commands[0])
                {
                    int index = int.Parse(cmdArgs[1]);
                    string lenght = cmdArgs[2];
                    message = message.Insert(index, lenght);
                }
                else if (action == commands[1])
                {
                    int index = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    if (!(index<0 || index>=message.Length || endIndex<0 || endIndex>=message.Length))
                    {
                        message = message.Remove(index, endIndex-index+1);
                    }

                }
                else if (action == commands[2])
                {
                    string substring = cmdArgs[1];
                    string replacement = cmdArgs[2];

                    StringBuilder sb = new StringBuilder();
                    sb.Append(message);
                    sb.Replace(substring, replacement);
                    message = sb.ToString();

                    

                    //bool hasReplacement = false;

                    //int index = message.IndexOf(substring);
                    //while (index!=-1)
                    //{
                    //    message = message.Replace(substring, replacement);
                    //    index = message.IndexOf(substring);
                    //}                                      
                } 
                Console.WriteLine(message);
                command = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {message}");
        }
    }
}
