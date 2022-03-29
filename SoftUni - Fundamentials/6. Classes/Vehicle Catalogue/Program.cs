using System;
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex
using System.Linq;                          //For lambda expressions
using System.Collections.Generic;           //For Dictionaries
using System.Numerics;                      //For BigInteger
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics


namespace NeedforSpeedIII

{
    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HP { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Vehicle> vehicles = new List<Vehicle>();

            while (input != "End")
            {
                string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = cmdArgs[0];
                if (type == "car")
                {
                    type = "Car";
                }
                if (type == "truck")
                {
                    type = "Truck";
                }
                string model = cmdArgs[1];
                string color = cmdArgs[2];
                int hp = int.Parse(cmdArgs[3]);
                Vehicle current = new Vehicle();
                current.Type = type;
                current.Model = model;
                current.Color = color;
                current.HP = hp;

                vehicles.Add(current);

                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "Close the Catalogue")
            {
                input = input.Trim();
                for (int i = 0; i < vehicles.Count; i++)
                {
                    if (vehicles[i].Model == input)
                    {
                        Console.WriteLine($"Type: {vehicles[i].Type}");
                        Console.WriteLine($"Model: {vehicles[i].Model}");
                        Console.WriteLine($"Color: {vehicles[i].Color}");
                        Console.WriteLine($"Horsepower: {vehicles[i].HP}");
                    }
                }
                input = Console.ReadLine();
            }

            List<Vehicle> cars = vehicles.Where(x => x.Type == "Car").ToList();
            double averageHP = 0;
            if (!(cars.Count == 0))
            {
                averageHP = cars.Average(x => x.HP);
            }

            Console.WriteLine($"Cars have average horsepower of: {averageHP:F2}.");

            List<Vehicle> trucks = vehicles.Where(x => x.Type == "Truck").ToList();

            double averageHP1 = 0;
            if (!(trucks.Count == 0))
            {
                averageHP1 = trucks.Average(x => x.HP);
            }
            Console.WriteLine($"Trucks have average horsepower of: {averageHP1:F2}.");
        }

    }
}
