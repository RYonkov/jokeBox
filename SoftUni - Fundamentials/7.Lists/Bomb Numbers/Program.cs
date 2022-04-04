using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;


namespace BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

            int[] bombNumbers = Console.ReadLine()
                              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToArray();

            int bomb = bombNumbers[0];
            int bombPower = bombNumbers[1];
            int indexBomb = numbers.IndexOf(bomb);

            while (indexBomb != -1)
            {
                int range = indexBomb - bombPower;
                int leftMargin;
                int correction = 0;

                if (range < 0)
                {
                    leftMargin = 0;
                    correction = Math.Abs(range);
                }
                else
                {
                    leftMargin = range;
                }

                if (indexBomb + bombPower >= numbers.Count)
                {
                    correction = (indexBomb + 1 + bombPower) - numbers.Count;
                }
                DetonateBomb(numbers, leftMargin, bombPower, correction);
                indexBomb = numbers.IndexOf(bomb);
            }
            Console.WriteLine(numbers.Sum());
        }


        static void DetonateBomb(List<int> numbers, int leftMargin, int bombPower, int correction)
        {
            numbers.RemoveRange(leftMargin, (2 * bombPower + 1 - correction));
        }
    }
}