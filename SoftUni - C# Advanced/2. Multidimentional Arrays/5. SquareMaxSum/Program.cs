using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace P5.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int length = dimensions[0];
            int width = dimensions[1];

            int[,] matrix = new int[length, width];
            PopulateMatrix(matrix, length, width);

            int[,] matrixSum = new int[length - 1, width - 1];
            int maxSum = int.MinValue;
            int x = -1;
            int y = -1;

            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < width - 1; j++)
                {
                    matrixSum[i, j] = matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1];
                    if (maxSum < matrixSum[i, j])
                    {
                        maxSum = matrixSum[i, j];
                        x = i;
                        y = j;
                    }
                }
            }

            Console.WriteLine($"{matrix[x, y]} {matrix[x, y + 1]}");
            Console.WriteLine($"{matrix[x + 1, y]} {matrix[x + 1, y + 1]}");
            Console.WriteLine($"{matrixSum[x, y]}");         
        }

        static int[,] PopulateMatrix(int[,] matrix, int length, int width)
        {
            for (int rows = 0; rows < length; rows++)
            {
                int[] inputRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int cols = 0; cols < width; cols++)
                {
                    matrix[rows, cols] = inputRow[cols];
                }
            }
            return matrix;
        }

        static void PrintMatrix <T>(T[,] matrix, string delimeter = "\t")
        {
            StringBuilder s = new StringBuilder();
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j==(matrix.GetLength(1)-1))
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
