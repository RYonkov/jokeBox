using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex


namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimension = int.Parse(Console.ReadLine());
            int length = dimension;
            int width = dimension;

            int[,] matrix = new int[length, width];
            PopulateMatrix(matrix, length, width);

            string command = Console.ReadLine();

            while (command!="END")
            {
                string[] cmdArgs = command.Split(' ').ToArray();
                string action = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);

                if (row<0 || row>=length || col<0 || col>=width)
                {
                    Console.WriteLine("Invalid coordinates");
                    command = Console.ReadLine();
                    continue;
                }
                else if (action=="Add")
                {
                    matrix[row, col] += int.Parse(cmdArgs[3]);
                }
                else if (action=="Subtract")
                {
                    matrix[row, col] -= int.Parse(cmdArgs[3]);
                }                            
                command = Console.ReadLine();
            }
            PrintMatrix(matrix, " ");
        }

        static int[,] PopulateMatrix(int[,] matrix, int length, int width)
        {
            for (int rows = 0; rows < length; rows++)
            {
                int[] inputRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int cols = 0; cols < width; cols++)
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
