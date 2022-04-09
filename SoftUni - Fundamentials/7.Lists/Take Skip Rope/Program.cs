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

            string message = Console.ReadLine();
            List<int> digits = new List<int>();
            List<char> chars = new List<char>();

            for (int i = 0; i < message.Length; i++)
            {
                if (Char.IsDigit(message[i]))
                {
                    int current = (char)message[i] - '0';
                    digits.Add(current);
                    message = message.Remove(i, 1);
                    i--;
                }
                else
                {
                    chars.Add(message[i]);
                }
            }
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int i = 0; i < digits.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(digits[i]);                    
                }
                else
                {
                    skipList.Add(digits[i]);
                }
            }
            int position=0;
            string output = "";
            for (int i = 0; i < takeList.Count; i++)
            {
                position += takeList[i];

                while (skipList[i] > 0)
                {
                    if (position < message.Length)
                    {
                        message = message.Remove(position, 1);
                        skipList[i]--;
                    }
                    else
                    {
                        break;
                    }                   
                }              
            }
            if (position <= message.Length)
            {
                message=message.Remove(position, message.Length-position);
            }
            
            Console.WriteLine(message);

            // My First and better solution

            //string message = Console.ReadLine();
            //List<int> digits = new List<int>();
            //List<char> chars = new List<char>();

            //for (int i = 0; i < message.Length; i++)
            //{
            //    if (Char.IsDigit(message[i]))
            //    {
            //        int current = (char)message[i] - '0';
            //        digits.Add(current);
            //    }
            //    else
            //    {
            //        chars.Add(message[i]);
            //    }
            //}
            //List<int> takeList = new List<int>();
            //List<int> skipList = new List<int>();

            //for (int i = 0; i < digits.Count; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        takeList.Add(digits[i]);
            //    }
            //    else
            //    {
            //        skipList.Add(digits[i]);
            //    }
            //}
            //string output = "";
            //int position = 0;
            //for (int i = 0; i < takeList.Count; i++)
            //{
            //    for (int j = 0; j < takeList[i]; j++)
            //    {
            //        if (j + position < chars.Count)
            //        {
            //            output += chars[j + position];
            //        }
            //    }
            //    position += takeList[i];
            //    position += skipList[i];
            //}

            //Console.WriteLine(output);
        }
    }
}