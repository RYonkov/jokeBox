using System;
using System.Collections.Generic;           //For Dictionaries
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex


namespace TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());

            List<int> drumsInitial = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> drums = new List<int>(drumsInitial);

            string input = Console.ReadLine();
            while (input!= "Hit it again, Gabsy!")
            {
                int current = int.Parse(input);
                for (int i = 0; i < drums.Count; i++)
                {
                    drums[i] -= current;
                    if (drums[i]<=0 && drumsInitial[i]*3<=savings)
                    {
                        drums[i] = drumsInitial[i];
                        savings -= drumsInitial[i] * 3;                        
                    }
                    else if (drums[i]<=0 && drumsInitial[i]*3>savings)
                    {                                            
                        drums.RemoveAt(i);
                        drumsInitial.RemoveAt(i);
                        i--;
                    }
                }                
                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", drums));
            Console.WriteLine($"Gabsy has {savings:F2}lv.");
        }
    }
}