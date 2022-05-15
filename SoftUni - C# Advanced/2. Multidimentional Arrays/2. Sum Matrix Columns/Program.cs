using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace P2.SumMatrixColumns
{    internal class Program
    {        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = new int[dimentions[0], dimentions[1]];
            int sum = 0;

            for (int i = 0; i < dimentions[0]; i++)
            {
                int[] inputRow = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < dimentions[1]; j++)
                {
                    matrix[i, j] = inputRow[j];
                    sum += matrix[i, j];
                }
            }
            int length = matrix.GetLength(0);
            Console.WriteLine(length);
            int width = matrix.GetLength(1);
            Console.WriteLine(width);

            Console.WriteLine(sum);
        }
    }
}
