using System;

namespace _02._Enter_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];
            int currentNumber = 1;

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    numbers[i] = ReadNumber(currentNumber, 100);
                    currentNumber = numbers[i];
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Your number is not in range {currentNumber} - 100!");
                    i--;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Number!");
                    i--;
                }


            }
            Console.WriteLine(String.Join(", ", numbers));

        }

        public static int ReadNumber(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());

            if (number <= start || number >= end)
            {
                throw new ArgumentOutOfRangeException();
            }           
            return number;
        }
    }
}
