using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();

            for (int i = 0; i < input.Length; i++)
            {
                string[] data = input[i].Split('=');
                try
                {
                    Person currentPerson = new Person(data[0], double.Parse(data[1]));
                    people.Add(currentPerson);
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }

            }
            string[] inputProducts = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            List<Product> assortiment = new List<Product>();

            for (int i = 0; i < inputProducts.Length; i++)
            {
                string[] data = inputProducts[i].Split('=');
                try
                {
                    Product currentProduct = new Product(data[0], double.Parse(data[1]));
                    assortiment.Add(currentProduct);
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string buyer = command.Split()[0];
                string productToBuy = command.Split()[1];

                var targetPerson = people.FirstOrDefault(p => p.Name == buyer);
                var targetProduct = assortiment.FirstOrDefault(p => p.Name == productToBuy);
                if (targetPerson!=null && targetProduct!=null)
                {
                    if (targetPerson.Money >= targetProduct.Cost)
                    {
                        Console.WriteLine($"{targetPerson.Name} bought {targetProduct.Name}");
                        targetPerson.Money -= targetProduct.Cost;
                        targetPerson.Bag.Add(targetProduct.Name);
                    }
                    else
                    {
                        Console.WriteLine($"{targetPerson.Name} can't afford {targetProduct.Name}");
                    }
                }
                
            }

            foreach (var buyer in people)
            {
                if (buyer.Bag.Count != 0)
                {
                    Console.WriteLine($"{buyer.Name} - {String.Join(", ", buyer.Bag)}");
                }
                else
                {
                    Console.WriteLine($"{buyer.Name} - Nothing bought");
                }
            }
        }
    }
}
