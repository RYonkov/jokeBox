namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;       //For Regex
    public class WordCount
    {
        static void Main(string[] args)
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamReader wordReader = new StreamReader(wordsFilePath))
            {
                using (StreamReader textReader = new StreamReader(textFilePath))
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        string wholeText = textReader.ReadToEnd().ToLower();
                        

                        string seekPattern = @"[A-Za-zА-Яа-я|']+";
                        //Regex matches = new Regex(seekPattern);
                        var matches = Regex.Matches(wholeText, seekPattern);
                        List<string> text = new List<string>();

                        foreach (Match match in matches)
                        {
                            text.Add(match.ToString());
                        }

                        string[] words = wordReader.ReadLine().ToLower().Split().ToArray();
                        Dictionary<string, int> output = new Dictionary<string, int>();
                        for (int i = 0; i < words.Length; i++)
                        {
                            output.Add(words[i], 0);

                            for (int j = 0; j < text.Count; j++)
                            {
                                if (words[i] == text[j])
                                {
                                    output[words[i]]++;
                                }                           
                            }
                        }

                        //output.OrderBy(x => x.Value);
                        foreach (var element in output.OrderByDescending(x=>x.Value))
                        {
                            writer.WriteLine($"{element.Key} - {element.Value} ");
                        }
                        
                    }
                }
            }

        }
    }
}
