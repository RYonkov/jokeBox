using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex


namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());         //number of rows to be printed   
            List<long> numbers = new List<long>() { 1 };   //using List of long numbers and populatitng the first element                                
            PascalTrianglePrint(numbers, n);          
        }

        static int PascalTrianglePrint(List<long> numbers, int n)
        {          
            while (n>0)
            {
                Console.WriteLine(String.Join(' ', numbers));       //Printing the current row
                List<long> nextRow = new List<long>();              //Initializing new list for the next row
                
                //Processing the next row to be printed
                nextRow.Add(1);
                for (int i = 0; i < numbers.Count-1; i++)
                {
                    nextRow.Add(numbers[i] + numbers[i + 1]);    
                }
                nextRow.Add(1);

                //Decreasing the rows to be printed and invoiking the Recursive Method again with new paramenters - new row to be printed and decreased number
                n--;
                int k = PascalTrianglePrint(nextRow, n);  
                
                //Used to break the recursive cycle
                if (k==0)
                {
                    return 0;
                }
            }            
            return 0;
        }
    }
}
