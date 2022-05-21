using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E3.DiagonalDifference
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
            int sum2 = 0;

            PopulateMatrix(matrix, " ");

            for (int row = 0; row < length; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if (row==col)
                    {
                        sum += matrix[row, col];
                    }                   
                   
                    if (row+col == (length-1))
                    {
                        sum2+=matrix[row, col];
                    }
                }
            }
            Console.WriteLine(Math.Abs(sum-sum2));
        }

        static int[,] PopulateMatrix(int[,] matrix, string separator)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] inputRow = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = inputRow[cols];
                }
            }
            return matrix;
        }
    }
}
