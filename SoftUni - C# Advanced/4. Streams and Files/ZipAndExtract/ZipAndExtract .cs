namespace ZipAndExtract
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
    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            using (var archive = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Create))
            {
                //1. взимаме файла, който ще zip-ваме
                string fileName = Path.GetFileName(inputFilePath);
                //2. съзадаваме zip на този файл
                //archive.CreateEntryFromFile(inputFilePath, fileName);
                archive.CreateEntryFromFile(inputFilePath, fileName);
            }
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
                ZipFile.OpenRead(zipArchiveFilePath).GetEntry(fileName).ExtractToFile(outputFilePath);
               
                //var archive = ZipFile.OpenRead(zipArchiveFilePath);
                //var fileForExtraction = archive.GetEntry(fileName);
                //fileForExtraction.ExtractToFile(outputFilePath);
        }
    }
}
