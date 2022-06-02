namespace FolderSize
{
    using System;
    using System.IO; 
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            double sum = 0;
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] data = dir.GetFiles();
           
            foreach (var element in data)
                  sum += element.Length;
            
            DirectoryInfo[] dataDir = dir.GetDirectories();
            foreach (var element in dataDir)
            {
               FileInfo[] data1 = element.GetFiles();
                foreach (var item in data1)
                {
                    sum += item.Length;
                }
            }                

            sum = sum/(1024);
            File.WriteAllText(outputFilePath, sum.ToString()+" KB");
        }
    }
}
