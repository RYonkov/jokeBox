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
            string message = Console.ReadLine();
            string command = Console.ReadLine();

            while (command!="Decode")
            {
                string[] cmdArgs = command.Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string action = cmdArgs[0];

                if (action== "Move")
                {
                    int numberOfLetters = int.Parse(cmdArgs[1]);
                    string current = message.Substring(0, numberOfLetters);
                    message = message.Remove(0, numberOfLetters);
                    message = message + current;                    
                }
                else if (action== "Insert")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string value = cmdArgs[2];
                    message = message.Insert(index, value);
                }
                else if (action== "ChangeAll")
                {
                    string substring = cmdArgs[1];
                    string replacement = cmdArgs[2];
                    message = message.Replace(substring, replacement);
                }
                
                command = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
