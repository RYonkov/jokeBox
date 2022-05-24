using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues, sets
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E4.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int length = dimensions[0];
            int width = dimensions[1];

            string[,] matrix = new string[length, width];
            PopulateMatrix(matrix);

            string command = Console.ReadLine();

            while (command!="END")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                if (action!="swap" || cmdArgs.Length!=5)
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }

                int row1 = int.Parse(cmdArgs[1]);
                int col1 = int.Parse(cmdArgs[2]);
                int row2 = int.Parse(cmdArgs[3]);
                int col2 = int.Parse(cmdArgs[4]);


                if ( row1<0 || row2<0 || col1<0 || col2<0 || row1>=length || row2>=length || col1>=width || col2>=width)
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }
                else
                {
                    string current = matrix[row1, col1];
                    matrix[row1, col1]=matrix[row2, col2];
                    matrix[row2++, col2]=current;
                    PrintMatrix(matrix, " ");
                }
                
                command = Console.ReadLine();
            }
            

        }

        static string[,] PopulateMatrix(string[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                string[] inputRow = Console.ReadLine().Split(' ').ToArray();

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
