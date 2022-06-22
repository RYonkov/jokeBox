using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace _01._Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Using queue for the steel

            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> steel = new Queue<int>(input);
            SortedList<string, int> swords = new SortedList<string, int>();


            //Using stack for the carbon
            int[] input1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> carbon = new Stack<int>(input1);            
      

            while (steel.Count > 0 && carbon.Count > 0)
            {
                //Initializing of major variables to process before each iteration
                int currentSteel = steel.Dequeue();
                int currentCarbon = carbon.Pop();            

                //Adding sword or not depending on the exact amount
                switch (currentSteel + currentCarbon)
                {
                    case 70:
                        {                            
                            AddSword(swords, "Gladius");                                                        
                            break;
                        }
                    case 80:
                        {                            
                            AddSword(swords, "Shamshir");                                                                               
                            break;
                        }
                    case 90:
                        {
                            AddSword(swords, "Katana");                                                                                                              
                            break;
                        }
                    case 110:
                        {                            
                            AddSword(swords, "Sabre");                                                                                    
                            break;
                        }
                    case 150:
                        {                           
                            AddSword(swords, "Broadsword");                                                                               
                            break;
                        }
                    default:
                        {                                                   
                            carbon.Push(currentCarbon + 5);
                            break;
                        }
                }
            }

            //Printing the correct result depending on the input
            if (swords.Count <= 0)
            {
                Console.WriteLine($"You did not have enough resources to forge a sword.");
            }
            else
            {
                Console.WriteLine($"You have forged {swords.Values.Sum()} swords.");
            }

            if (steel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {String.Join(", ", steel)}");
            }

            if (carbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {String.Join(", ", carbon)}");
            }

            foreach (var element in swords.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{element.Key}: {element.Value}");
            }
        }

        public static void AddSword(SortedList<string, int> swords, string sword)
        {
            if (!swords.ContainsKey(sword))
            {
                swords.Add(sword, 1);
            }
            else
            {
                swords[sword] += 1;
            }            
        }
    }
}
