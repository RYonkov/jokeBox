using System;
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex
using System.Linq;                          //For lambda expressions
using System.Collections.Generic;           //For Dictionaries
using System.Numerics;                      //For BigInteger
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics


namespace OrderByAge

{
    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HP { get; set; }
    }
    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;          
        }
        public string Name { get; set; }
        public int Age { get; set; }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            //List<Person> persons = new List<Person>();
            Dictionary<int, Person> persons = new Dictionary<int, Person>();

            while (input != "End")
            {
                string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = cmdArgs[0];
                int idNumber = int.Parse(cmdArgs[1]);
                int age = int.Parse(cmdArgs[2]);

                if (!persons.ContainsKey(idNumber))
                {
                    persons.Add(idNumber, new Person(name, age));
                }
                else if (true)
                {
                    persons[idNumber].Name = name;
                    persons[idNumber].Age = age;
                }
                input = Console.ReadLine(); 
            }

            var persons2 = persons.OrderBy(x=>x.Value.Age).ToList();

            foreach (var element in persons2)
            {
                Console.WriteLine($"{element.Value.Name} with ID: {element.Key} is {element.Value.Age} years old.");
            }
        }

    }
}
