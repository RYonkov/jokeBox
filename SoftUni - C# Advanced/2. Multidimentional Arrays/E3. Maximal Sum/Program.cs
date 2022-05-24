using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues, sets
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E3.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            //Console.WriteLine(String.Join(",", dimensions));

            string input = Console.ReadLine();
            int[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int length = data[0];
            int width = data[1];

            int[,] matrix = new int[length, width];
            PopulateMatrix(matrix);

            //long[,] matrixSum = new long[length - 2, width - 2];
            long maxSum = long.MinValue;
            int x = -1;
            int y = -1;

            for (int i = 0; i < length - 2; i++)
            {
                for (int j = 0; j < width - 2; j++)
                {
                    long currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] + matrix[i + 1, j] + matrix[i + 1, j + 1] +
                                      matrix[i + 1, j + 2] + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                    if (maxSum < currentSum)
                    {
                        maxSum = currentSum;
                        x = i;
                        y = j;
                    }
                }
            }
            if (x != -1 || y != -1)
            {
                Console.WriteLine($"Sum = {maxSum}");
                Console.WriteLine($"{matrix[x, y]} {matrix[x, y + 1]} {matrix[x, y + 2]}");
                Console.WriteLine($"{matrix[x + 1, y]} {matrix[x + 1, y + 1]} {matrix[x + 1, y + 2]}");
                Console.WriteLine($"{matrix[x + 2, y]} {matrix[x + 2, y + 1]} {matrix[x + 2, y + 2]}");
            }

        }

        static int[,] PopulateMatrix(int[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] inputRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = inputRow[cols];
                }
            }
            return matrix;
        }

        static void PrintMatrix<T>(T[,] matrix, string delimeter = "\t")
        {
            StringBuilder s = new StringBuilder();
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == (matrix.GetLength(1) - 1))
                    {
                        s.Append(matrix[i, j]);
                    }
                    else
                    {
                        s.Append(matrix[i, j] + delimeter);
                    }
                }
                Console.WriteLine(s.ToString());
                s = s.Clear();
            }
        }


    }
}
