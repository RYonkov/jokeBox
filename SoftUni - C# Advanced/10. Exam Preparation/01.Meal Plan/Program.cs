using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex

namespace _01.Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Using queue for the meals
            
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            Queue <string> queue = new Queue<string>(input);
            Queue<int> meals = new Queue<int>();

            //Using additional queue with number in order to peform arithmetic operations
            foreach (var element in queue)
            {
                if (element == "salad")
                {
                    meals.Enqueue(350);
                }
                else if (element == "soup")
                {
                    meals.Enqueue(490);
                }
                else if (element == "pasta")
                {
                    meals.Enqueue(680);
                }
                else if (element == "steak")
                {
                    meals.Enqueue(790);
                }
            }
            //Console.WriteLine(String.Join(", ", meals));

            //Using stack for the calories
            int[] input1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(input1);
            //Console.WriteLine(String.Join(", ", stack));

            int currentMeal = 0;
            int counter = 0;
            int currentCalories = 0;

            while (meals.Count>0 && stack.Count>0)
            {
                //Initializing of major variables to process before each iteration
                if (currentMeal==0 && meals.Count>0)
                {
                    currentMeal += meals.Peek();
                }
                
                if (currentCalories==0 && stack.Count>0)
                {
                    currentCalories += stack.Peek();
                }

                //Checking which is bigger and processing the queue and stack
                if (currentMeal<currentCalories)
                {
                    currentCalories -= currentMeal;   
                    stack.Pop();
                    stack.Push(currentCalories);
                    currentMeal = 0;
                    meals.Dequeue();                     
                    counter++; 
                }
                else
                {
                    currentMeal -= currentCalories;
                    currentCalories = 0;  
                    stack.Pop();                    
                }

            }

            //Printing the correct result depending on the input
            if (meals.Count<=0)
            {                
                
                Console.WriteLine($"John had {counter} meals.");
                Console.WriteLine($"For the next few days, he can eat {String.Join(", ", stack)} calories.");
            }
            else
            {
                meals.Dequeue();
                counter++;

                //Removing of eaten dishes in order to print the names, not the calories
                for (int i = 0; i < counter; i++)
                {
                    queue.Dequeue();
                }
                Console.WriteLine($"John ate enough, he had {counter} meals.");
                Console.WriteLine($"Meals left: {String.Join(", ", queue)}.");
            }
        }
    }
}
