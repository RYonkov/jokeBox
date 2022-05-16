using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace P3.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int length = n;
            int width = n;

            int[,] matrix = new int[length, width];
            int sum = 0;

            PopulateMatrix(matrix, length, width);

            for (int cols = 0; cols < width; cols++)
            {
                sum += matrix[cols, cols];
            }
            Console.WriteLine(sum);
        }

        static int[,] PopulateMatrix(int[,] matrix, int lenght, int width)
        {
            for (int rows = 0; rows < lenght; rows++)
            {
                int[] inputRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int cols = 0; cols < width; cols++)
                {
                    matrix[rows, cols] = inputRow[cols];
                }
            }
            return matrix;
        }
    }
}
