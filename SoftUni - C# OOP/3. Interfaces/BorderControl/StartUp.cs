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
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = input.Split(' ');

                if (cmdArgs.Length == 2)
                {
                    ISubject current = new Robot(cmdArgs[0], cmdArgs[1]);
                    subjects.Add(current);
                }
                else if (cmdArgs.Length == 3)
                {
                    ISubject current = new Citizen(cmdArgs[0], int.Parse(cmdArgs[1]), cmdArgs[2]);
                    subjects.Add(current);
                }
            }
            input = Console.ReadLine();

            foreach (ISubject element in subjects.Where(x => x.Id.EndsWith(input)))
            {
                Console.WriteLine(element.Id);
            }
        }
    }
}
