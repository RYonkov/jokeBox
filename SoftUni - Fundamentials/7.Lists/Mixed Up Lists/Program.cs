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
            List<int> firstList = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int margin1 = 0;
            int margin2 = 0;
            List<int> result = new List<int>();

            if (firstList.Count<secondList.Count)
            {
                if (secondList[0]<secondList[1])
                {
                    margin1 = secondList[0];
                    margin2 = secondList[1];
                }
                else
                {
                    margin1 = secondList[1];
                    margin2 = secondList[0];
                }
                for (int i = 0; i < firstList.Count; i++)
                {
                    result.Add(firstList[i]);
                    result.Add(secondList[secondList.Count-1-i]);
                }                
            }
            else
            {
                if (firstList[firstList.Count-2]<firstList[firstList.Count-1])
                {
                    margin1 = firstList[firstList.Count-2];
                    margin2 = firstList[firstList.Count-1];
                }
                else
                {
                    margin1 = firstList[firstList.Count - 1];
                    margin2 = firstList[firstList.Count - 2];
                }
                for (int i = 0; i < secondList.Count; i++)
                {
                    result.Add(firstList[i]);
                    result.Add(secondList[secondList.Count-1-i]);
                }
            }
            result = result.Where(x => x>margin1 && x<margin2).OrderBy(x=>x).ToList();                    
            Console.WriteLine(String.Join(" ", result));                              
        }
    }
}