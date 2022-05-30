namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main(string[] args)
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader first = new StreamReader(firstInputFilePath))
            {
                using (StreamReader second = new StreamReader(secondInputFilePath))
                {
                    using (StreamWriter output = new StreamWriter(outputFilePath))
                    {
                        string line;
                        string line1="";

                        while (true)
                        {
                            if ((line = first.ReadLine())!=null)
                            {
                                output.WriteLine(line);
                            }
                            if ((line1 = second.ReadLine()) != null)
                            {
                                output.WriteLine(line1);
                            }

                            if (line==null && line1==null)
                            {
                                break;
                            }

                        }
                    }
                }
            }
        }
    }
}
