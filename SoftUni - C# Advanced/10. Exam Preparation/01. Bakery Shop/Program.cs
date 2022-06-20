using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace _01._Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Using queue for the water
            double[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Queue<double> water = new Queue<double>(input);
            SortedList<string, int> bakedProducts = new SortedList<string, int>();

            //Using stack for the flour
            double[] input1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Stack<double> flour = new Stack<double>(input1);

            while (water.Count > 0 && flour.Count > 0)
            {
                //Initializing of major variables to process before each iteration
                double currentWater = water.Dequeue();
                double currentFlour = flour.Pop();               
                double currentWaterPercentage = Math.Round((currentWater / (currentWater + currentFlour)), 7);                

                //Processing the mixture and baking products
                if (currentWaterPercentage == 0.5)
                {
                    AddProduct(bakedProducts, "Croissant");
                }
                else if (currentWaterPercentage == 0.4)
                {
                    AddProduct(bakedProducts, "Muffin");
                }
                else if (currentWaterPercentage == 0.3)
                {
                    AddProduct(bakedProducts, "Baguette");
                }
                else if (currentWaterPercentage == 0.2)
                {
                    AddProduct(bakedProducts, "Bagel");
                }
                else
                {
                    currentFlour -= currentWater;
                    flour.Push(currentFlour);
                    AddProduct(bakedProducts, "Croissant");
                }       
            }

            //Printing the correct result depending on the input
            foreach (var element in bakedProducts.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                 Console.WriteLine($"{element.Key}: {element.Value}");
            
            if (water.Count == 0)
                Console.WriteLine("Water left: None");            
            else
               Console.WriteLine($"Water left: {String.Join(", ", water)}");
            

            if (flour.Count == 0)
               Console.WriteLine("Flour left: None");
            else
               Console.WriteLine($"Flour left: {String.Join(", ", flour)}");                             
        }

        public static void AddProduct(SortedList<string, int> bakedProducts, string product)
        {
            if (!bakedProducts.ContainsKey(product))
               bakedProducts.Add(product, 1);
            else
               bakedProducts[product] += 1;            
        }
    }    
}
