using System;
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex
using System.Linq;                          //For lambda expressions
using System.Collections.Generic;           //For Dictionaries
using System.Numerics;                      //For BigInteger
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics

namespace ExercisingRegex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string seekPattern = @"(@#)[#]*(?<product>[A-ZА-Я][A-Za-zА-Яа-я0-9]{4,}[A-ZА-Я])\1";
                Match myMatch = Regex.Match(input, seekPattern);
                string sb = "";

                if (!myMatch.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                string product = myMatch.Groups["product"].Value;

                for (int j = 0; j < product.Length; j++)
                {
                    if (Char.IsDigit(product[j]))
                    {
                        sb += product[j].ToString();
                    }

                }

                if (sb != "")
                {
                    Console.WriteLine($"Product group: " + sb);
                }
                else
                {
                    Console.WriteLine("Product group: 00");
                }
            }
        }

    }
}
