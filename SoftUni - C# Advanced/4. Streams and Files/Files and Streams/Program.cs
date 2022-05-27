using System;


namespace OddLines
{
    using System;
    using System.IO;
    public class OddLines
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputPath, outputPath);
        }

        public static void ExtractOddLines(string inputPath, string outputPath)
        {
            using (StreamReader reader = new StreamReader(inputPath))
            {
                string input = reader.ReadLine();
                int counter = 0;
                StreamWriter writer = new StreamWriter(outputPath);
                while (input != null)
                {
                    if (counter % 2 == 1)
                    {
                        Console.WriteLine(input);
                        writer.WriteLine(input);
                    }
                    input = reader.ReadLine();
                    counter++;
                }
                writer.Close();
            }
        }
    }
}

