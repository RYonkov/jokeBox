using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Truffle_Hunter
{
    public class Matrix<T> where T : IComparable<T>
    {
        public string[,] matrix;

        public Matrix(int length, int width)
        {
            this.matrix = new string[length, width];
        }    

        public void PopulateMatrix()
        {
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                string[] inputRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    this.matrix[rows, cols] = inputRow[cols];
                }
            }            
        }
        public void PrintMatrix<T>(string delimeter = "\t")
        {
            StringBuilder s = new StringBuilder();
            for (var i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (var j = 0; j < this.matrix.GetLength(1); j++)
                {
                    if (j == (this.matrix.GetLength(1) - 1))
                    {
                        s.Append(this.matrix[i, j]);
                    }
                    else
                    {
                        s.Append(this.matrix[i, j] + delimeter);
                    }
                }
                Console.WriteLine(s.ToString());
                s = s.Clear();
            }
        }        
    }
}
