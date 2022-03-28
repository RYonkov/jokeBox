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
    class Car
    {
        public Car(string name, int mileage, int fuel)
        {
            this.Name = name;
            this.Mileage = mileage;
            this.Fuel = fuel;
        }
        public string Name { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //Dictionary<string, List<string>> pieces = new Dictionary<string, List<string>>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                PopulateList(input, cars);              
            }

            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] cmdArgs = command.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0].Trim();
                string name = cmdArgs[1].Trim();

                if (action == "Drive")
                {
                    int distance = int.Parse(cmdArgs[2].Trim());
                    int fuel = int.Parse(cmdArgs[3].Trim());

                    foreach (Car element in cars)
                    {
                        if (element.Name == name && element.Fuel < fuel)
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        } else if (element.Name == name && element.Fuel >= fuel)
                        {
                            element.Fuel -= fuel;
                            element.Mileage += distance;
                            Console.WriteLine($"{name} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        }
                        if (element.Mileage >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {element.Name}!");
                            cars.Remove(element);
                            break;
                        }
                    }
                }
                else if (action == "Refuel")
                {
                    int fuel = int.Parse(cmdArgs[2].Trim());

                    foreach(Car element in cars)
                    {
                        if (element.Name==name)
                        {
                            int correction = 0;                       
                            element.Fuel += fuel;
                            if (element.Fuel>75)
                            {
                                correction = element.Fuel - 75;
                                element.Fuel = 75;
                            }
                            Console.WriteLine($"{element.Name} refueled with {fuel-correction} liters");
                        }
                    }
                }
                else if (action=="Revert")
                {
                    int distance = int.Parse(cmdArgs[2].Trim());
                    foreach (Car element in cars)
                    {
                        if (element.Name == name)
                        {
                            element.Mileage -= distance;
                            Console.WriteLine($"{element.Name} mileage decreased by {distance} kilometers");
                            if (element.Mileage < 10000)
                            {
                                element.Mileage = 10000;
                            }
                        }
                    }
                    
                }                                      
                command = Console.ReadLine();
            }
            foreach (Car element in cars)
            {
                Console.WriteLine($"{element.Name} -> Mileage: {element.Mileage} kms, Fuel in the tank: {element.Fuel} lt.");
            }
        }
                        
        static List<Car> PopulateList(string input, List<Car> cars)
        {
            string[] cmdArg = input.Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string name = cmdArg[0].Trim();
            int mileage = int.Parse(cmdArg[1].Trim());
            int fuel = int.Parse(cmdArg[2].Trim());
            Car current = new Car(name, mileage, fuel);
            cars.Add(current);
            return cars;
        }

    }
}
