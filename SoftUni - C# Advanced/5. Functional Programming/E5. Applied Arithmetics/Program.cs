using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E5._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string action = Console.ReadLine();
            while (action != "end")
            {

                Func<int, int> add = (x) => x=x+1;
                //Func<List<int>, List<int>> add1 = list => list.Select(x => x = x+1).ToList();
                Func<int, int> multi = (x) => x *= 2;
                Func<int, int> subtract = (x) => x=x-1;
                Action<int> print = (int x) => Console.Write(x+" ");

                switch (action)
                {
                    case "add":
                        {
                            nums = nums.Select(add).ToArray();                            
                            break;
                        }
                    case "multiply":
                        {
                            nums = nums.Select(multi).ToArray();
                            break;
                        }
                    case "subtract":
                        {
                            nums = nums.Select(subtract).ToArray();
                            break;
                        }
                    case "print":
                        {
                            foreach (var element in nums)
                            {
                                print(element);                                
                            }
                            Console.WriteLine();
                            break;
                        }
                    default:
                        break;

                }
                action = Console.ReadLine();
            }

        }
    }
}
