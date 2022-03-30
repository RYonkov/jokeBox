﻿using System;
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex
using System.Linq;                          //For lambda expressions
using System.Collections.Generic;           //For Dictionaries
using System.Numerics;                      //For BigInteger
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics

namespace Articles2
{
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

        //public string Edit(string content)
        //{
        //    return this.Content = content;
        //}

        //public string ChangeAuthor(string author)
        //{

        //    return this.Author = author;
        //}

        //public string Rename(string title)
        //{
        //    return this.Title = title;
        //}

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (input==String.Empty)
                {
                    continue;
                }
                string[] inputArgs = input.Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray();
                Article currentArticle = new Article(inputArgs[0].Trim(), inputArgs[1].Trim(), inputArgs[2].Trim());
                articles.Add(currentArticle);
            }
            string filter = Console.ReadLine();
            
            if (filter=="title")
            {
                articles = articles.OrderBy(x=>x.Title).ToList();

            } 
            else if (filter=="content")
            {
                articles = articles.OrderBy(x => x.Content).ToList();
 
            }
            else if (filter=="author")
            {
                articles = articles.OrderBy(x => x.Author).ToList();
         
            }
                        
            foreach (Article element in articles)
            {
                Console.WriteLine(element);
                
            }
            //Console.WriteLine(String.Join(Environment.NewLine, sortedList));
        }

       
    }
}
