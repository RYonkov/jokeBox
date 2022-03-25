using System;
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex
using System.Linq;                          //For lambda expressions
using System.Collections.Generic;           //For Dictionaries
using System.Numerics;                      //For BigInteger
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics


namespace ExamPreparation
{
    internal class Program
    {
        class Product
        {
            public Product(string name, string date, int calories)
            {
                this.Name = name;
                this.ExpirationDate = date;
                this.Calories = calories;
            }
            public string Name { get; set; }
            public string ExpirationDate { get; set; }
            public int Calories { get; set; }
        }
        
        static void Main(string[] args)
        {
            string seekPattern = @"([#|\|])([A-Za-zА-Яа-я\s]+)\1(\d{2}\/\d{2}\/\d{2})\1(\d{1,5})\1";
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, seekPattern);
            List<Product> products = new List<Product>();
            int totalSum = 0;

            foreach (Match match in matches)
            {
                string product = match.Groups[2].Value;
                string date = match.Groups[3].Value;
                int calories = int.Parse(match.Groups[4].Value);
                Product current = new Product(product, date, calories);
                products.Add(current);
                totalSum += calories;
            }
            

            Console.WriteLine($"You have food to last you for: {totalSum/2000} days!");
            foreach (Product element in products)
            {
                Console.WriteLine($"Item: {element.Name}, Best before: {element.ExpirationDate}, Nutrition: {element.Calories}");
            }

        }
    }
}
