namespace LineNumbers
{
    using System;
    using System.Collections.Generic;           //For Dictionaries, stacks and queues
    using System.Diagnostics;                   //For clock, stopwatch
    using System.Globalization;                 //For regional specifics
    using System.IO;                            //For IO operations; 
    using System.Linq;                          //For lambda expressions
    using System.Numerics;                      //For BigInteger
    using System.Text;                          //For StringBuilder
    using System.Text.RegularExpressions;       //For Regex 
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    int counter = 1; 
                    string line = reader.ReadLine();
                    while (line!=null)
                    {

                        int counterLetter = line.Count(Char.IsLetter);
                        int counterSigns = line.Count(Char.IsPunctuation);

                        //for (int i = 0; i < line.Length; i++)
                        //{
                        //    if (Char.IsLetter(line[i]))
                        //    {
                        //        counterLetter++;
                        //    }
                        //    if (Char.IsPunctuation(line[i]))
                        //    {
                        //        counterSigns++;
                        //    }
                        //}
                        writer.WriteLine($"Line {counter}: {line} ({counterLetter})({counterSigns})");
                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
