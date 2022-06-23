using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace _2._Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var board = new char[8, 8];
            int[] positions = new int[4];

            //Finding the position of the pawns and Populationg the matrix
            positions = PopulateMatrix(board);
            int x = positions[0];
            int y = positions[1];
            int x1 = positions[2];
            int y1 = positions[3];
            
            //PrintMatrix(board, " ");
            //Console.WriteLine(x + " / " + y);
            //Console.WriteLine(x1 + " / " + y1);

            bool isBlackTaken = false;
            bool isWhiteTaken = false;            
            string turn = "white";

            while (!(x==0 || x1==7 || isBlackTaken || isWhiteTaken))
            {
                //Checking for black pawn on the diagonals
                if (((x-1==x1 && y-1==y1) || (x-1==x1 && y+1==y1)) && turn=="white")
                {
                    isBlackTaken = true;
                    break;
                }
                else if (turn=="white")
                {
                    x -= 1;                    
                    turn = "black";
                    continue;
                }

                //Checking for white pawn on the diagonals
                if (((x1 + 1 == x && y1 - 1 == y) || (x1 + 1 == x && y1 + 1 == y)) && turn=="black")
                {
                    isWhiteTaken = true;
                    break;
                }
                else if (turn=="black")
                {
                    x1 += 1;                    
                    turn = "white";
                    continue;
                }
            }

            if (isBlackTaken)
            {
                Console.WriteLine($"Game over! White capture on {(char)(y1+97)}{8-x1}.");
            }

            if (isWhiteTaken)
            {
                Console.WriteLine($"Game over! Black capture on {(char)(y + 97)}{8 - x}.");
            }

            if (x==0)
            {
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(y + 97)}{8- x}.");
            }

            if (x1 == 7)
            {
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(y1 + 97)}{8 - x1}.");
            }

        }

        static int[] PopulateMatrix(char[,] matrix)
        {
            var pos = new int[4];
            for (int rows = 0; rows < 8; rows++)
            {                
                string inputRow = Console.ReadLine();                              

                for (int cols = 0; cols < 8; cols++)
                {
                    matrix[rows, cols] = inputRow[cols];
                    if (inputRow[cols] == 'w' || inputRow[cols]=='W')
                    {
                        pos[0] = rows;
                        pos[1] = cols;
                    }
                    
                    if (inputRow[cols] == 'b' || inputRow[cols]=='B')
                    {
                        pos[2] = rows;
                        pos[3] = cols;
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


