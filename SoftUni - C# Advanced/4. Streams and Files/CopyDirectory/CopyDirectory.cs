namespace CopyDirectory
{
    using System;
    using System.Collections.Generic;           //For Dictionaries, stacks and queues
    using System.Diagnostics;                   //For clock, stopwatch
    using System.Globalization;                 //For regional specifics
    using System.IO;                            //For IO operations; 
    using System.IO.Compression;                //For Archives
    using System.Linq;                          //For lambda expressions
    using System.Numerics;                      //For BigInteger
    using System.Text;                          //For StringBuilder
    using System.Text.RegularExpressions;       //For Regex 
   
    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath =  @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            //Check whether the directory already exists. If yes - it is deleted.
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }
            
            //Creating new directory on the submitted path
            Directory.CreateDirectory(outputPath);

            //Taking all files in the Directory -> array of strings
            string[] files = Directory.GetFiles(inputPath);


            //Copy each file in the new directory
            foreach (var element in files)
            {
                //Taking the name of each file in the collection
                string currentFile = Path.GetFileName(element);
                //Old path
                string oldPath = Path.Combine(inputPath, currentFile);
                //New path 
                string newPath = Path.Combine(outputPath, currentFile);
                //Copying the current file in the new directory
                File.Copy(oldPath, newPath);                
            }
        }
    }
}
