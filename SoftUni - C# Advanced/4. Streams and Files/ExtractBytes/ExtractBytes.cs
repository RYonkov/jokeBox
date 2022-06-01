namespace ExtractBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ExtractBytes
    {
        static void Main(string[] args)
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using (var fs = new FileStream(binaryFilePath, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(bytesFilePath))
                {
                    using (var output = new FileStream(outputPath, FileMode.OpenOrCreate))
                    {
                        List<byte> seekedBytes = new List<byte>();
                        while (true)
                        {
                            string line = reader.ReadLine();
                            if (line!=null)
                            {
                                seekedBytes.Add(byte.Parse(line));
                            }
                            else
                            {
                                break;
                            }                            
                        }


                        byte[] buffer = new byte[4096];
                        List<byte> bytesToWrite = new List<byte>();

                        while (true)
                        {
                            int readBytes = fs.Read(buffer);
                            if (readBytes==0)
                            {
                                break;
                            }
                            for (int i = 0; i < readBytes; i++)
                            {
                                if (seekedBytes.Contains(buffer[i]))
                                {
                                    bytesToWrite.Add(buffer[i]);
                                }
                            }
                        }
                        output.Write(bytesToWrite.ToArray());
                    }
                }
            }
            
        }
    }
}
