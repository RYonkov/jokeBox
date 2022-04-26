using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E6._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string[] input = Console.ReadLine().Split(", ").ToArray();
           Queue<string> songs = new Queue<string>(input);
            
            string command=Console.ReadLine();
            while (songs.Count>0)
            {
                int index = command.IndexOf(' ');
                string action = String.Empty;
                string song = String.Empty;
                if (index!=-1)
                {
                    action = command.Substring(0, index);
                    song = command.Remove(0, action.Length+1);
                }
                else
                {
                    action=command;
                }
                

                if (action=="Play")
                {
                    songs.Dequeue();
                }
                else if (action == "Add")
                {
                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }
                }
                else if (action == "Show")
                {
                    Console.WriteLine(String.Join(", ", songs));
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("No more songs!");
        }
    }
}
