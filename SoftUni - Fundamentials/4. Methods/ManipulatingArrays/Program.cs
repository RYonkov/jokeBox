using System;
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex
using System.Linq;                          //For lambda expressions
using System.Collections.Generic;           //For Dictionaries
using System.Numerics;                      //For BigInteger
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics



namespace ManipulatingArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] cmdArgs = command.Split(' ');
                command = cmdArgs[0];

                if (command == "exchange")
                {
                    int index = int.Parse(cmdArgs[1]);
                    numbers = ExchangeIndex(numbers, index);
                    //Console.WriteLine(String.Join(" ", numbers));
                }
                else if (command == "max")
                {
                    string type = cmdArgs[1];
                    Console.WriteLine(MaxNumber(numbers, type));
                }
                else if (command == "min")
                {
                    string type = cmdArgs[1];
                    if (MinNumber(numbers, type) == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(MinNumber(numbers, type));
                    }

                }
                else if (command == "first")
                {
                    int count = int.Parse(cmdArgs[1]);
                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                        command = Console.ReadLine();
                        continue;
                    }
                    string type = cmdArgs[2];
                    List<int> current = FirstElements(numbers, count, type);
                    Console.Write($"[" + String.Join(", ", current));
                    Console.WriteLine("]");
                }
                else if (command == "last")
                {
                    int count = int.Parse(cmdArgs[1]);
                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                        command = Console.ReadLine();
                        continue;
                    }
                    string type = cmdArgs[2];
                    List<int> current = LastElements(numbers, count, type);

                    Console.Write($"[" + String.Join(", ", current));
                    Console.WriteLine("]");


                }


                command = Console.ReadLine();
            }

            Console.Write($"[" + String.Join(", ", numbers));
            Console.WriteLine("]");



        }

        private static List<int> FirstElements(int[] numbers, int count, string type)
        {
            List<int> current = new List<int>();
            if (type == "odd")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 == 1)
                    {
                        current.Add(numbers[i]);
                        count--;
                    }
                    if (count == 0)
                    {
                        break;
                    }
                }
            }
            if (type == "even")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 == 0)
                    {
                        current.Add(numbers[i]);
                        count--;
                    }
                    if (count == 0)
                    {
                        break;
                    }
                }
            }

            return current;

        }

        private static List<int> LastElements(int[] numbers, int count, string type)
        {
            List<int> current = new List<int>();
            if (type == "odd")
            {
                for (int i = numbers.Length - 1; i >= 0; i--)
                {
                    if (numbers[i] % 2 == 1)
                    {
                        current.Add(numbers[i]);
                        count--;
                    }
                    if (count == 0)
                    {
                        break;
                    }
                }
            }
            if (type == "even")
            {
                for (int i = numbers.Length - 1; i >= 0; i--)
                {
                    if (numbers[i] % 2 == 0)
                    {
                        current.Add(numbers[i]);
                        count--;
                    }
                    if (count == 0)
                    {
                        break;
                    }
                }
            }
            current.Reverse();
            return current;

        }

        private static int MaxNumber(int[] numbers, string type)
        {
            int max = int.MinValue;
            int indexMaxValue = -1;
            if (type == "odd")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] >= max && numbers[i] % 2 == 1)
                    {
                        max = numbers[i];
                        indexMaxValue = i;
                    }
                }
            }
            else if (type == "even")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] >= max && numbers[i] % 2 == 0)
                    {
                        max = numbers[i];
                        indexMaxValue = i;
                    }
                }
            }
            return indexMaxValue;
        }

        private static int MinNumber(int[] numbers, string type)
        {
            int min = int.MaxValue;
            int indexMinValue = -1;
            if (type == "odd")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] <= min && numbers[i] % 2 == 1)
                    {
                        min = numbers[i];
                        indexMinValue = i;
                    }
                }
            }
            else if (type == "even")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] <= min && numbers[i] % 2 == 0)
                    {
                        min = numbers[i];
                        indexMinValue = i;
                    }
                }
            }
            return indexMinValue;
        }

        private static int[] ExchangeIndex(int[] numbers, int index)
        {
            int[] current = new int[numbers.Length];
            if (index < 0 || index >= numbers.Length)
            {
                Console.WriteLine("Invalid index");
                return numbers;
            }
            else
            {
                int count = 0;
                for (int i = index + 1; i < numbers.Length; i++)
                {
                    current[i - index - 1] = numbers[i];
                    count++;
                }

                for (int i = 0; i <= index; i++)
                {
                    current[count + i] = numbers[i];
                }
            }

            return current;
        }
    }
}