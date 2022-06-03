namespace CopyBinaryFile
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
    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream fs = new FileStream(inputFilePath, FileMode.Open))
            {
                using (FileStream output = new FileStream(outputFilePath, FileMode.Create))
                {
                    if (fs.CanRead && output.CanWrite)
                    {
                        byte[] buffer = new byte[4096];
                        
                        while (true)
                        {
                            int counter = fs.Read(buffer, 0, buffer.Length);                            
                            if (counter == 0)
                                break;
                            output.Write(buffer, 0, buffer.Length);
                        }

                        //fs.CopyTo(output);
                    }
                }
            }
        }
    }
}
