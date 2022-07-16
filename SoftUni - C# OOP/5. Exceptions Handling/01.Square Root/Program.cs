using System;

namespace _01.Square_Root
{
    internal class Program
    {
        static void Main()
        {
            double input = double.Parse(Console.ReadLine());
            try
            {
                if (input<0)
                {
                    throw new ArgumentException("Invalid number.");
                }
                
                double output = Math.Sqrt(input);
                Console.WriteLine(output);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
