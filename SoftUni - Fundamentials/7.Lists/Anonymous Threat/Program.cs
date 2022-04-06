using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;


namespace AnonimousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                                        .Split(' ')
                                        .ToList();

            string command;
            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] cmdArgs = command.Split(' ').ToArray();

                if (cmdArgs[0] == "merge")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    else if (startIndex > input.Count - 1)
                    {
                        startIndex = input.Count - 1;
                    }

                    if (endIndex < 0)
                    {
                        endIndex = 0;
                    }
                    else if (endIndex > input.Count - 1)
                    {
                        endIndex = input.Count - 1;
                    }

                    string mergedString = "";

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        mergedString += input[i];
                    }
                    input[startIndex] = mergedString;
                    input.RemoveRange(startIndex + 1, (endIndex - startIndex));

                }
                else if (cmdArgs[0] == "divide")
                {
                    int divideIndex = int.Parse(cmdArgs[1]);
                    int numberOfPartitions = int.Parse((cmdArgs[2]));
                    DivideElement(input, divideIndex, numberOfPartitions);
                }
            }
            Console.WriteLine(String.Join(" ", input));
        }

        static void DivideElement(List<string> input, int divideIndex, int numberOfPartitions)
        {
            List<char> currentElement = input[divideIndex].ToList();
            int currentElementLength = currentElement.Count;
            int lengthOfPartition = currentElementLength / numberOfPartitions;
            int remainingLength = currentElementLength % numberOfPartitions;
            input.RemoveAt(divideIndex);
            string currentPartition = "";

            for (int j = 1; j <= numberOfPartitions; j++)
            {
                currentPartition = "";
                if (j == numberOfPartitions)
                {
                    lengthOfPartition += remainingLength;
                }
                for (int i = 0; i < lengthOfPartition; i++)
                {
                    currentPartition += currentElement[0].ToString();
                    currentElement.RemoveAt(0);
                }
                input.Insert(divideIndex + j - 1, currentPartition);
            }
        }
    }
}