namespace DirectoryTraversal
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
    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath);
            Dictionary<string, List<FileInfo>> extInfo = new Dictionary<string, List<FileInfo>>();
            StringBuilder sb = new StringBuilder();

            //For each file, we need the extension
            foreach (var element in files)
            {
                FileInfo current = new FileInfo(element);
                string currExt = current.Extension;

                if (!extInfo.ContainsKey(currExt))
                {
                    extInfo.Add(currExt, new List<FileInfo>());
                }
                extInfo[currExt].Add(current);
            }

            extInfo = extInfo.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x=>x.Key, y=>y.Value);


            foreach (var element in extInfo)
            {                
                Console.WriteLine($"{element.Key}");                
                sb.AppendLine(element.Key.ToString());
                var fI = element.Value.OrderByDescending(x=>x.Length);

                foreach (var fileInfo in fI)
                {
                    Console.WriteLine($"--{fileInfo.Name} - {fileInfo.Length / 1024:F3}kB");
                    sb.AppendLine($"--{fileInfo.Name} - {fileInfo.Length / 1024:F3}kB");
                }
            }
            return sb.ToString();

        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            //Getting the path of Desktop and adding the fileName
            string pathReport = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;

            //writing all the content in the file with the specific path
            File.WriteAllText(pathReport, textContent);
        }
    }
}
