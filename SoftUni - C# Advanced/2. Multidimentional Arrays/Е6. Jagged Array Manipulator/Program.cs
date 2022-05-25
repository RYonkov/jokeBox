using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues, sets
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E6.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jagged = new int[n][];


            for (int i = 0; i < n; i++)
            {
                int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jagged[i] = new int[line.Length];
                for (int j = 0; j < line.Length; j++)
                {
                    jagged[i][j] = line[j];
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                if (jagged[i].Length == jagged[i + 1].Length)
                {
                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        jagged[i][j] *= 2;
                        jagged[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        jagged[i][j] /= 2;                        
                    }
                    for (int j = 0; j < jagged[i+1].Length; j++)
                    {                        
                        jagged[i + 1][j] /= 2;
                    }
                }


            }
            string input = Console.ReadLine();
            while (input != "End")
            {             
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int val = int.Parse(tokens[3]);

                if (tokens[0] == "Add")
                {
                    if (row >= 0 && row < n && col >= 0 && col < jagged[row].Length)
                    {
                        jagged[row][col] += val;
                    }
                }
                else if (tokens[0] == "Subtract")
                {
                    if (row >= 0 && row < n && col >= 0 && col < jagged[row].Length)
                    {
                        jagged[row][col] -= val;
                    }
                }
                input = Console.ReadLine();
            }
            foreach (int[] row in jagged)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }        
    }
}



