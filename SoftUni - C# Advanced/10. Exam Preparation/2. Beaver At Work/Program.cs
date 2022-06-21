using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex


namespace _2._Beaver_At_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var pond = new char[n, n];
            int[] position = new int[3];

            //Finding the position of the beaver and Populationg the matrix
            position = PopulateMatrix(pond);
            int x = position[0];
            int y = position[1];
            int remainingBranches = position[2];
            //PrintMatrix(pond, " ");
            //Console.WriteLine(x + " / " + y);
            //Console.WriteLine(position[2]);

            //using stack for collected of branches
            Stack<char> branches = new Stack<char>();
            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "up" && x - 1 >= 0)
                {
                    pond[x, y] = '-';
                    if (pond[x - 1, y] == 'F')
                    {
                        pond[x - 1, y] = '-';
                        if (x - 1 > 0)
                        {
                            x = 0;
                        }
                        else
                        {
                            x = pond.GetLength(0) - 1;
                        }


                        if (Char.IsLower(pond[x, y]))
                        {
                            remainingBranches--;
                            branches.Push(pond[x, y]);
                            if (remainingBranches == 0)
                            {
                                pond[x, y] = 'B';
                                break;
                            }
                        }
                        pond[x, y] = 'B';
                        //PrintMatrix(pond, " ");
                        command = Console.ReadLine();
                        continue;
                    }
                    if (Char.IsLower(pond[x - 1, y]))
                    {
                        branches.Push(pond[x - 1, y]);
                        remainingBranches--;
                    }
                    pond[x - 1, y] = 'B';
                    x -= 1;
                }
                else if (command == "up" && x - 1 < 0 && branches.Count > 0)
                {
                    branches.Pop();
                }
                else if (command == "down" && x + 1 < pond.GetLength(0))
                {
                    pond[x, y] = '-';
                    if (pond[x + 1, y] == 'F')
                    {
                        pond[x + 1, y] = '-';
                        if (x + 1 < pond.GetLength(0) - 1)
                        {
                            x = pond.GetLength(0) - 1;
                        }
                        else
                        {
                            x = 0;
                        }

                        pond[x, y] = 'B';
                        //PrintMatrix(pond, " ");

                        if (Char.IsLower(pond[x, y]))
                        {
                            remainingBranches--;
                            branches.Push(pond[x, y]);
                            if (remainingBranches == 0)
                            {

                                pond[x, y] = 'B';
                                break;
                            }
                        }
                        command = Console.ReadLine();
                        continue;
                    }
                    if (Char.IsLower(pond[x + 1, y]))
                    {
                        branches.Push(pond[x + 1, y]);
                        remainingBranches--;
                    }
                    pond[x + 1, y] = 'B';
                    x += 1;
                }
                else if (command == "down" && x + 1 == pond.GetLength(0) && branches.Count > 0)
                {
                    branches.Pop();
                }
                else if (command == "left" && y - 1 >= 0)
                {
                    pond[x, y] = '-';

                    if (pond[x, y - 1] == 'F')
                    {
                        pond[x, y - 1] = '-';
                        if (y - 1 > 0)
                        {
                            y = 0;
                        }
                        else
                        {
                            y = pond.GetLength(1) - 1;
                        }


                        if (Char.IsLower(pond[x, y]))
                        {
                            remainingBranches--;
                            branches.Push(pond[x, y]);
                            if (remainingBranches == 0)
                            {
                                pond[x, y] = 'B';
                                break;
                            }
                        }
                        pond[x, y] = 'B';
                        //PrintMatrix(pond, " ");
                        command = Console.ReadLine();
                        continue;
                    }
                    if (Char.IsLower(pond[x, y - 1]))
                    {
                        branches.Push(pond[x, y - 1]);
                        remainingBranches--;
                    }
                    pond[x, y - 1] = 'B';
                    y -= 1;
                }
                else if (command == "left" && y - 1 < 0 && branches.Count > 0)
                {
                    branches.Pop();
                }
                else if (command == "right" && y + 1 < pond.GetLength(1))
                {
                    pond[x, y] = '-';
                    if (pond[x, y + 1] == 'F')
                    {
                        pond[x, y + 1] = '-';
                        if (y + 1 < pond.GetLength(1) - 1)
                        {
                            y = pond.GetLength(1) - 1;
                        }
                        else
                        {
                            y = 0;
                        }


                        if (Char.IsLower(pond[x, y]))
                        {
                            remainingBranches--;
                            branches.Push(pond[x, y]);
                            if (remainingBranches == 0)
                            {
                                pond[x, y] = 'B';
                                break;
                            }
                        }
                        pond[x, y] = 'B';
                        //PrintMatrix(pond, " ");
                        command = Console.ReadLine();
                        continue;
                    }
                    if (Char.IsLower(pond[x, y + 1]))
                    {
                        branches.Push(pond[x, y + 1]);
                        remainingBranches--;
                    }
                    pond[x, y + 1] = 'B';
                    y += 1;
                }
                else if (command == "right" && y + 1 == pond.GetLength(1) && branches.Count > 0)
                {
                    branches.Pop();
                }
                //PrintMatrix(pond, " ");
                if (remainingBranches == 0)
                {
                    break;
                }
                command = Console.ReadLine();
            }

            if (remainingBranches == 0)
            {                
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {String.Join(", ", branches.Reverse())}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {remainingBranches} branches left.");
            }
            PrintMatrix(pond, " ");




        }
        static int[] PopulateMatrix(char[,] matrix)
        {
            var pos = new int[3];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                string[] inputRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = inputRow[cols][0];
                    if (inputRow[cols][0] == 'B')
                    {
                        pos[0] = rows;
                        pos[1] = cols;
                    }
                    else if (Char.IsLower(inputRow[cols][0]))
                    {
                        pos[2]++;
                    }
                }
            }
            return pos;
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

