using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues, sets
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace E5.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int length = dimensions[0];
            int width = dimensions[1];

            char[,] matrix = new char[length, width];
            string snake = Console.ReadLine();

            //Using queue for the string, each used symbol is enqueued again
            Queue<char> queue = new Queue<char>();
            for (int i = 0; i < snake.Length; i++)
            {
                queue.Enqueue(snake[i]);
            }

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                //Checking the row number - even -> from left to right ; odd -> from right to left
                if (rows % 2 == 0)
                {
                    for (int cols = 0; cols < matrix.GetLength(1); cols++)
                    {
                        matrix[rows, cols] = queue.Dequeue();
                        queue.Enqueue(matrix[rows, cols]);
                    }
                }
                else
                {
                    for (int cols = matrix.GetLength(1) - 1; cols >= 0; cols--)
                    {
                        matrix[rows, cols] = queue.Dequeue();
                        queue.Enqueue(matrix[rows, cols]);
                    }
                }
            }
            PrintMatrix(matrix);

        }




        static void PrintMatrix<T>(T[,] matrix, string delimeter = "")
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



