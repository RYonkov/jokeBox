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

            char[,] matrix = new char[length, width];
            
            PopulateMatrix(matrix, length, width);

            string input = Console.ReadLine();
            char seekChar = input[0];
            bool isFound = false;
            int x=-1, y=-1; 

            for (int row = 0; row < length; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    if (matrix[row, col] == seekChar) 
                    {
                        isFound = true;
                        x = row;
                        y = col;
                        break;
                    }                    
                }
                if (isFound)
                {
                    break;
                }
            }
            if (isFound)
            {
                Console.WriteLine($"({x}, {y})");
            }
            else
            {
                Console.WriteLine($"{seekChar} does not occur in the matrix");
            }
            
           
        }

        static char[,] PopulateMatrix(char[,] matrix, int lenght, int width)
        {
            for (int rows = 0; rows < lenght; rows++)
            {
                char[] inputRow = Console.ReadLine().ToArray();

                for (int cols = 0; cols < width; cols++)
                {
                    matrix[rows, cols] = inputRow[cols];
                }
            }
            return matrix;
        }
    }
}
