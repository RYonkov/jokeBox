using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> race = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

            int middleIndex = (race.Count-1) / 2;
            double sumLeft = 0;
            double sumRight = 0;
            for (int i = 0; i < middleIndex; i++)
            {
                   sumLeft += race[i];
                    if (race[i] == 0)
                    {
                        sumLeft = sumLeft * 0.8;
                    }               
            }
            for (int i = race.Count-1; i > middleIndex; i--)
            {                                      
                    sumRight+=race[i];
                    if (race[i] == 0)
                    {
                        sumRight *= 0.8;
                    }                
            }
            if (sumLeft<sumRight)
            {
                Console.WriteLine($"The winner is left with total time: {Math.Round(sumLeft,1)}");
            } 
            if (sumRight<sumLeft)
            {
                Console.WriteLine($"The winner is right with total time: {Math.Round(sumRight,1)}");
            }
        }
    }
}
