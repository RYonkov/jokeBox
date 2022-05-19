using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex


namespace _7._Pascal_Triangle_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimension = int.Parse(Console.ReadLine());   
            List<long> row = new List<long>() {1};                   

            while (dimension > 0)
            {                
                Console.WriteLine(String.Join(' ', row));  
                List<long> newRow = new List<long>();
                newRow.Add(1);
                for (int i = 0; i < row.Count-1; i++)
                {
                    newRow.Add(row[i] + row[i + 1]);
                }                
                newRow.Add(1);
                dimension--;                
                row = newRow;
            }        
        }
    }
}
