namespace EvenLines
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
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            int counter = 0;
            
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line = reader.ReadLine();
                while (line!=null)
                {
                    if (counter % 2 == 0)
                    {
                        ////{ '-', ', ', '. ', '! ', '? '}
                        //HashSet<char> set = new HashSet<char>() { '-', ',', '.', '!', '?' };
                        //for (int i = 0; i < line.Length; i++)
                        //{
                        //    if (set.Contains(line[i]))
                        //    {

                        //    }
                        //}
                        line = line.Replace('-', '@').Replace(',', '@').Replace('.', '@').Replace(',', '@').Replace('!', '@').Replace('?', '@');
                        string[] words = line.Split().Reverse().ToArray();
                        Console.WriteLine(String.Join(" ",words));
                        line = String.Join(" ", words);
                        //line = line.Split().Reverse(); 
                        //words[] string = line.Split().Reverse().ToArray();                        
                    }
                    counter++;
                    line = reader.ReadLine();
                }
                return line;


            }
        }
    }
}
