using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace _5._Filter_by_Age_2
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    internal class Program
    {


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person { Name = input[0], Age = int.Parse(input[1])} );
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            if (condition == "older")
            {
                people = people.Where(x => x.Age >= age).ToList();
            }
            else if (condition == "younger")
            {
                people = people.Where(x => x.Age < age).ToList();
            }

            if (format == "name")
            {
                foreach (var element in people)
                {
                    Console.WriteLine(element.Name);
                }
            }
            else if (format == "age")
            {
                foreach (var element in people)
                {
                    Console.WriteLine(element.Age);
                }
            }
            else if (format == "name age")
            {
                foreach (var element in people)
                {
                    Console.WriteLine(element.Name + " - " + element.Age);
                }
            }
        }
    }
}
