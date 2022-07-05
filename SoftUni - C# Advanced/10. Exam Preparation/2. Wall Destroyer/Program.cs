using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace _2._Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var wall = new char[n, n];

            int[] positions = new int[2];

            //Finding the position of the pawns and Populationg the matrix
            positions = PopulateMatrix(wall);
            int x = positions[0];
            int y = positions[1];
           

            //PopulateMatrix(wall);
            //PrintMatrix(wall, " ");
            int holesCounter = 1;
            int hittedRods = 0;
            bool isElectrocuted = false;

            string command = Console.ReadLine();

            while (command != "End")
            {
                //If we have valid command up
                if (command == "up" && x - 1 >= 0)
                {
                    wall[x, y] = '*';
                    x -= 1;
                    if (wall[x, y] == 'C')
                    {
                        wall[x, y] = 'E';
                        holesCounter++;
                        isElectrocuted = true;
                        break;
                    }
                    else if (wall[x, y] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{x}, {y}]!");
                        wall[x, y] = 'V';
                    }
                    else if (wall[x, y] == 'R')
                    {
                        hittedRods++;
                        x += 1;
                        wall[x, y] = 'V';
                        Console.WriteLine("Vanko hit a rod!");
                    }
                    else if (wall[x, y] == '-')
                    {
                        wall[x, y] = 'V';
                        holesCounter++;
                    }            
                }

                //If we have valid command down
                if (command == "down" && x + 1 <= wall.GetLength(0)-1)
                {
                    wall[x, y] = '*';
                    x += 1;
                    if (wall[x, y] == 'C')
                    {
                        wall[x, y] = 'E';
                        holesCounter++;
                        isElectrocuted = true;
                        break;
                    }
                    else if (wall[x, y] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{x}, {y}]!");
                        wall[x, y] = 'V';
                    }
                    else if (wall[x, y] == 'R')
                    {
                        hittedRods++;
                        x -= 1;
                        wall[x, y] = 'V';
                        Console.WriteLine("Vanko hit a rod!");
                    }
                    else if (wall[x, y] == '-')
                    {
                        wall[x, y] = 'V';
                        holesCounter++;
                    }
                }

                //If we have valid command right
                if (command == "right" && y + 1 <= wall.GetLength(1) - 1)
                {
                    wall[x, y] = '*';
                    y += 1;
                    if (wall[x, y] == 'C')
                    {
                        wall[x, y] = 'E';
                        holesCounter++;
                        isElectrocuted = true;
                        break;
                    }
                    else if (wall[x, y] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{x}, {y}]!");
                        wall[x, y] = 'V';
                    }
                    else if (wall[x, y] == 'R')
                    {
                        hittedRods++;
                        y -= 1;
                        wall[x, y] = 'V';
                        Console.WriteLine("Vanko hit a rod!");
                    }
                    else if (wall[x, y] == '-')
                    {
                        wall[x, y] = 'V';
                        holesCounter++;
                    }
                }

                //If we have valid command left
                if (command == "left" && y - 1 >= 0)
                {
                    wall[x, y] = '*';
                    y -= 1;
                    if (wall[x, y] == 'C')
                    {
                        wall[x, y] = 'E';
                        holesCounter++;
                        isElectrocuted = true;
                        break;
                    }
                    else if (wall[x, y] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{x}, {y}]!");
                        wall[x, y] = 'V';
                    }
                    else if (wall[x, y] == 'R')
                    {
                        hittedRods++;
                        y += 1;
                        wall[x, y] = 'V';
                        Console.WriteLine("Vanko hit a rod!");
                    }
                    else if (wall[x, y] == '-')
                    {
                        wall[x, y] = 'V';
                        holesCounter++;
                    }
                }


                //PrintMatrix(wall, " ");
                command = Console.ReadLine();

            }
           
            //Printing the output depending on the data
            if (isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCounter} hole(s).");                
            }
            else if (true)
            {
                Console.WriteLine($"Vanko managed to make {holesCounter} hole(s) and he hit only {hittedRods} rod(s).");
            }
            PrintMatrix(wall, "");


            static int[] PopulateMatrix(char[,] matrix)
            {
                var pos = new int[2];
                for (int rows = 0; rows < matrix.GetLength(0); rows++)
                {
                    string inputRow = Console.ReadLine();

                    for (int cols = 0; cols < matrix.GetLength(1); cols++)
                    {
                        matrix[rows, cols] = inputRow[cols];
                        if (inputRow[cols] == 'V' || inputRow[cols] == 'v')
                        {
                            pos[0] = rows;
                            pos[1] = cols;
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
}

