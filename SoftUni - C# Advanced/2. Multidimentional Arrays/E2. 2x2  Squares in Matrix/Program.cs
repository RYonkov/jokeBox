using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E2.SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int length = dimensions[0];
            int width = dimensions[1];

            char[,] matrix = new char[length, width];
            PopulateMatrix(matrix);
            int count = 0;

            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < width - 1; j++)
                {
                    if (matrix[i,j]==matrix[i+1,j] && matrix[i,j]==matrix[i,j+1] && matrix[i,j]==matrix[i+1,j+1])
                    {
                        count++;
                    }                                    
                }
            }
            Console.WriteLine(count);
        }

        static char[,] PopulateMatrix(char[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                string[] inputRow = Console.ReadLine().Split(' ').ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = inputRow[cols][0];
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
