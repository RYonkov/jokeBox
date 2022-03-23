using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Text;

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
                    string singleWord = words[j].Substring(1, (words[j].Length / 2-2));
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

        static void PrintListOnOneLine (List<string> myList)
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


            
            


            


























//            string message = Console.ReadLine();
//            string command = Console.ReadLine();

            //            while (command!="Reveal")
            //            {
            //                string[] cmdArgs = command.Split(":|:").ToArray();



            //                if (cmdArgs[0]=="InsertSpace")
            //                {
            //                    message = message.Insert(int.Parse(cmdArgs[1]), ' '.ToString());
            //                    Console.WriteLine(message);
            //                }

            //                if (cmdArgs[0]=="Reverse")
            //                {
            //                    string substring = ReversedString(cmdArgs[1]);
            //                    if (message.Contains(cmdArgs[1]))
            //                    {
            //                        int index = message.IndexOf(cmdArgs[1]);
            //                        message = message.Remove(index, cmdArgs[1].Length);
            //                        message = message + substring;
            //                       /* message = message.Replace(cmdArgs[1], substring)*/;

            //                        Console.WriteLine(message);
            //                    }
            //                    else
            //                    {
            //                        Console.WriteLine("error");
            //                        command = Console.ReadLine();
            //                        continue;
            //                    }

            //                }

            //                if (cmdArgs[0]=="ChangeAll")
            //                {
            //                    string substring = cmdArgs[1];
            //                    string newSubstring = cmdArgs[2];
            //                    message = message.Replace(substring, newSubstring);
            //                    Console.WriteLine(message);
            //;               }


            //                command = Console.ReadLine();
            //            }

            //            Console.WriteLine($"You have a new text message: {message}");















            //int n = int.Parse(Console.ReadLine());


            //for (int i = 0; i < n; i++)
            //{
            //    string input = Console.ReadLine();
            //    string seekPattern = @"(@#)[#]*(?<product>[A-ZА-Я][A-Za-zА-Яа-я0-9]{4,}[A-ZА-Я])\1";
            //    Match myMatch = Regex.Match(input, seekPattern);
            //    string sb = "";

            //    if (!myMatch.Success)
            //    {
            //        Console.WriteLine("Invalid barcode");
            //        continue;
            //    }

            //    string product = myMatch.Groups["product"].Value;

            //    for (int j = 0; j < product.Length; j++)
            //    {
            //        if (Char.IsDigit(product[j]))
            //        {
            //            sb += product[j].ToString();
            //        }

            //    }

            //    if (sb!="")
            //    {
            //        Console.WriteLine($"Product group: " + sb);
            //    }
            //    else
            //    {
            //        Console.WriteLine("Product group: 00");
            //    }


            //}












            //    int n = int.Parse(Console.ReadLine());
            //    List<string> attackedPlanets = new List<string>();
            //    List<string> destroyedPlanets = new List<string>();
            //    for (int i = 0; i < n; i++)
            //    {
            //        string input = Console.ReadLine();
            //        input = AdjustedInput(input);
            //        string seekPattern = @".*@(?<planet>[A-Za-z]+)[^\@\-\!\,\:\>]*:(?<population>[\+\-]?\d+)[^\@\-\!\,\:\>]*!(?<type>[AD])![^\@\-\!\,\:\>]*->(?<bodycount>\d+)";
            //        Match myMatch = Regex.Match(input, seekPattern);


            //        if (myMatch.Groups["type"].Value.Contains('A'))
            //        {
            //            attackedPlanets.Add(myMatch.Groups["planet"].Value);
            //        }
            //        else if (myMatch.Groups["type"].Value.Contains('D'))
            //        {
            //            destroyedPlanets.Add(myMatch.Groups["planet"].Value);
            //        }

            //    }

            //    attackedPlanets.Sort();
            //    destroyedPlanets.Sort();

            //    Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");


            //     for (int j = 0; j < attackedPlanets.Count; j++)
            //        {
            //        Console.WriteLine($"-> {attackedPlanets[j]}");
            //        }

            //    Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");


            //    for (int j = 0; j < destroyedPlanets.Count; j++)
            //    {
            //        Console.WriteLine($"-> {destroyedPlanets[j]}");
            //    }


        

     



        //static string AdjustedInput (string input)
        //{
        //    string seekPattern = @"[STARstar]";
        //    MatchCollection matches = Regex.Matches(input, seekPattern);
        //    int count = matches.Count;
        //    //Console.WriteLine(count);
        //    string output = "";

        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        output += (char)(input[i] - (char)count);   
        //    }
        //    return output;             
        //}
