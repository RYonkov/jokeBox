using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;


namespace ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                List<string> input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                if (input[0] == "Delete")
                {
                    int num = int.Parse(input[1]);
                    numbers.RemoveAll(x => x == num);                    
                }
                else if (input[0] == "Insert")
                {
                    int element = int.Parse(input[1]);
                    int index = int.Parse(input[2]);
                    numbers.Insert(index, element);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
