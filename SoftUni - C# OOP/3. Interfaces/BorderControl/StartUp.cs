using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<ISubject> subjects = new List<ISubject>();
            List<IBirthday> celebrators = new List<IBirthday>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = input.Split(' ');

                if (cmdArgs.Length == 3 && cmdArgs[0]=="Robot")
                {
                    ISubject current = new Robot(cmdArgs[0], cmdArgs[1]);
                    subjects.Add(current);
                }
                else if (cmdArgs.Length == 3 && cmdArgs[0] == "Pet")
                {
                    IBirthday current = new Pet(cmdArgs[1], cmdArgs[2]);
                    celebrators.Add(current);
                }
                else if (cmdArgs.Length == 5)
                {
                    ISubject current = new Citizen(cmdArgs[1], int.Parse(cmdArgs[2]), cmdArgs[3], cmdArgs[4]);                    
                    subjects.Add(current);                    
                    celebrators.Add(new Citizen(cmdArgs[1], int.Parse(cmdArgs[2]), cmdArgs[3], cmdArgs[4]));
                }
            }
            input = Console.ReadLine();

            //foreach (ISubject element in subjects.Where(x => x.Id.EndsWith(input)))
            //{
            //    Console.WriteLine(element.Id);
            //}

            foreach (IBirthday element in celebrators.Where(x => x.BirthDate.EndsWith(input)))
            {
                Console.WriteLine(element.BirthDate);
            }
        }
    }
}
