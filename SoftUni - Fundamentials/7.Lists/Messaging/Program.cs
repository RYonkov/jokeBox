using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;


namespace Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

            string message = Console.ReadLine();
            string output=string.Empty;

            for (int i = 0; i < numbers.Count; i++)
            {
                int sum = 0;
                

                string stringLenght = numbers[i].ToString();
                for (int j = 1; j <= stringLenght.Length; j++)
                {
                    int current = DigitPosition(numbers[i], j);
                    sum += current;
                }
                while (sum>=message.Length)
                {
                    sum -= message.Length;
                }
                output+=message.ElementAt(sum);
                message = message.Remove(sum, 1);
            }
            Console.WriteLine(output);
           
        }
        static int DigitPosition(int number, int digitPosition)
        {
            int z = (int)Math.Pow(10, digitPosition);
            int digit = (number % z) / (z / 10);
            return digit;
        }

    }
}