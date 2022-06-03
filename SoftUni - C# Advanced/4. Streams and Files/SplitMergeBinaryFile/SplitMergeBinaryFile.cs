namespace SplitMergeBinaryFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main(string[] args)
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (var source = new FileStream(sourceFilePath, FileMode.Open))
            {
                using (FileStream part1 = new FileStream(partOneFilePath, FileMode.OpenOrCreate))
                {
                    using (var part2 = new FileStream(partTwoFilePath, FileMode.OpenOrCreate))
                    {
                        var fileInfo = new FileInfo(sourceFilePath);
                        int correction = 0;
                        Console.WriteLine(fileInfo.Length);
                        if (fileInfo.Length % 2 == 1)
                        {
                            correction = 1;
                        }

                        List<byte> bytesToWritePart1 = new List<byte>();

                        for (int i = 0; i < (fileInfo.Length / 2 + correction); i++)
                        {
                            bytesToWritePart1.Add((byte)source.ReadByte());
                        }
                        part1.Write(bytesToWritePart1.ToArray(), 0, (int)fileInfo.Length / 2 + correction);

                        List<byte> bytesToWritePart2 = new List<byte>();

                        for (int i = (int)(fileInfo.Length / 2 + correction); i < fileInfo.Length; i++)
                        {
                            bytesToWritePart2.Add((byte)source.ReadByte());
                        }
                        part2.Write(bytesToWritePart2.ToArray(), 0, (int)fileInfo.Length / 2);
                    }
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (var joined = new FileStream(joinedFilePath, FileMode.OpenOrCreate))
            {
                using (FileStream part1 = new FileStream(partOneFilePath, FileMode.OpenOrCreate))
                {
                    using (var part2 = new FileStream(partTwoFilePath, FileMode.OpenOrCreate))
                    {
                        part1.CopyTo(joined);
                        part2.CopyTo(joined);
                    }
                }
            }
        }
    }
}