using System;
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex
using System.Linq;                          //For lambda expressions
using System.Collections.Generic;           //For Dictionaries
using System.Numerics;                      //For BigInteger
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Article> articles = new List<Article>();
            string[] inputArgs = input.Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray();

            Article currentArticle = new Article(inputArgs[0].Trim(), inputArgs[1].Trim(), inputArgs[2].Trim());
            articles.Add(currentArticle);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                string[] cmdArg = command.Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (cmdArg[0])
                {
                    case "Edit":
                        {
                            articles[0].Edit(cmdArg[1].Trim());
                            break;
                        }
                    case "ChangeAuthor":
                        {
                            articles[0].ChangeAuthor(cmdArg[1].Trim());
                            break;
                        }
                    case "Rename":
                        {
                            articles[0].Rename(cmdArg[1].Trim());
                            break;
                        }
                    default:
                        break;
                }




            }
            foreach (Article article in articles)
            {
                Console.WriteLine(article);
            }

        }

        class Article
        {
            public Article(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

            public string Edit(string content)
            {
                return this.Content = content;
            }

            public string ChangeAuthor(string author)
            {

                return this.Author = author;
            }

            public string Rename(string title)
            {
                return this.Title = title;
            }

            public override string ToString()
            {
                return $"{this.Title} - {this.Content}: {this.Author}";
            }
        }
    }
}
