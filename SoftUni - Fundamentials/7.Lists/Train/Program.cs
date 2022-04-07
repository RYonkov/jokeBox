using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;


namespace ArraysExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();
            int capacity = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            while (command != "end")
            {
                List<string> input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                if (input[0] == "Add")
                {
                    wagons.Add(int.Parse(input[1]));
                }
                else
                {
                    int newPassengers = int.Parse(input[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + newPassengers <= capacity)
                        {
                            wagons[i] += newPassengers;
                            break;
                        }
                    }

                }
                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", wagons));

        }
    }
}