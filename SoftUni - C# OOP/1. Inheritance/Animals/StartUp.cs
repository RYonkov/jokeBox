using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main()
        {
            List<Animal> animals = new List<Animal>();
            Animal animal; 
            string input = Console.ReadLine();

            while (input != "Beast!")
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                //Validation of the animal data
                if (String.IsNullOrEmpty(data[0]) || String.IsNullOrEmpty(data[1]) || int.Parse(data[1]) < 0)
                {
                    throw new Exception("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }

                //Creating instances of different animals depending on the type
                if (input == "Cat")
                {
                    animal = new Cat(data[0], int.Parse(data[1]), data[2]);
                    animals.Add(animal);                    
                }
                else if (input == "Dog")
                {
                    animal = new Dog(data[0], int.Parse(data[1]), data[2]);
                    animals.Add(animal);
                }
                else if (input == "Frog")
                {
                    animal = new Frog(data[0], int.Parse(data[1]), data[2]);
                    animals.Add(animal);
                }
                else if (input == "Kitten")
                {
                    animal = new Kitten(data[0], int.Parse(data[1]));
                    animals.Add(animal);
                }
                else if (input == "Tomcat")
                {                    
                    animals.Add(new Tomcat(data[0], int.Parse(data[1])));
                }              
                input = Console.ReadLine();
            }

            

            foreach (var element in animals)
            {
                Console.WriteLine($"{element.GetType().Name}");
                Console.WriteLine($"{element.Name} {element.Age} {element.Gender}");
                Console.WriteLine(element.ProduceSound());
            }
        }
    }
}
