using System;
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex
using System.Linq;                          //For lambda expressions
using System.Collections.Generic;           //For Dictionaries
using System.Numerics;                      //For BigInteger
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics

namespace MidExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (IsTopNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        static bool IsTopNumber(int a)
        {
            string number = a.ToString();
            bool isSumDivisible = false;
            bool hasODDdigit = false;
            int digitSum = 0;
            for (int i = 1; i <= number.Length; i++)
            {
                int current = DigitPosition(a, i);
                if (current % 2 == 1)
                {
                    hasODDdigit = true;
                }
                digitSum += current;
            }

            if (digitSum % 8 == 0)
            {
                isSumDivisible = true;
            }
            return (isSumDivisible && hasODDdigit);
        }

        //Taking of a specific digit of integer - backwards
        static int DigitPosition(int number, int digitPosition)
        {
            int z = (int)Math.Pow(10, digitPosition);
            int digit = (number % z) / (z / 10);
            return digit;
        }
    }
}
