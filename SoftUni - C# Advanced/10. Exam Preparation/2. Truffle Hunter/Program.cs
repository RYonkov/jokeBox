using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace _2._Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var forest = new char[n, n];
            PopulateMatrix(forest);
            //using array for counting of colletected truffles. Positions: 0 - summer truffle; 1 - black truffle; 2 - white truffle; 3 - eaten by the wild boar
            int[] counters = new int[4];
            string command = Console.ReadLine();

            while (command != "Stop the hunt")
            {

                string action = command.Split()[0];
                int x = int.Parse(command.Split()[1]);
                int y = int.Parse(command.Split()[2]);

                if (x >= 0 && x <= forest.GetLength(0) && y >= 0 && y <= forest.GetLength(1) && action == "Collect")
                {
                    if (forest[x, y] == 'S')
                    {
                        counters[0]++;
                        forest[x, y] = '-';
                    }
                    if (forest[x, y] == 'B')
                    {
                        counters[1]++;
                        forest[x, y] = '-';
                    }
                    if (forest[x, y] == 'W')
                    {
                        counters[2]++;
                        forest[x, y] = '-';
                    }
                }

                if (action == "Wild_Boar")
                {
                    string direction = command.Split()[3];

                    while (x >= 0 && x < forest.GetLength(0) && y >= 0 && y < forest.GetLength(1))
                    {
                        if (forest[x, y] == 'S' || forest[x, y] == 'B' || forest[x, y] == 'W')
                        {
                            counters[3]++;
                        }

                        if (direction == "up")
                        {

                            forest[x, y] = '-';
                            x -= 2;
                        }
                        else if (direction == "down")
                        {
                            forest[x, y] = '-';
                            x += 2;
                        }
                        else if (direction == "right")
                        {
                            forest[x, y] = '-';
                            y += 2;
                        }
                        else if (direction == "left")
                        {
                            forest[x, y] = '-';
                            y -= 2;
                        }
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"Peter manages to harvest {counters[1]} black, {counters[0]} summer, and {counters[2]} white truffles.");
            Console.WriteLine($"The wild boar has eaten {counters[3]} truffles.");
            PrintMatrix(forest, " ");
        }



        static void PopulateMatrix(char[,] matrix)
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                string[] inputRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = inputRow[cols][0];
                }
            }
        }
        static void PrintMatrix(char[,] matrix, string delimeter)
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
