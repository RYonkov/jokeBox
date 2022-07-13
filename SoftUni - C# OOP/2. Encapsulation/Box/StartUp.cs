using System;

namespace Box
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double l = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            try
            {
                Box myBox = new Box(l, w, h);
                Console.WriteLine($"Surface Area - {myBox.SurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {myBox.LateralSurfaceArea():F2}");
                Console.WriteLine($"Volume - {myBox.Volume():F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);               
            }
        }
    }
}
