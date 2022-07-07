using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main()
        {
            //var myCar = new SportCar(250, 50);
            //Console.WriteLine(myCar.FuelConsumption);
            //Console.WriteLine(myCar.Fuel);
            //myCar.Drive(100);
            //Console.WriteLine(myCar.Fuel);


            var car2 = new FamilyCar(90, 45);
            Console.WriteLine(car2.Fuel);
            car2.Drive(30);
            Console.WriteLine(car2.Fuel);

            var h = new CrossMotorcycle(80, 15);
            h.Drive(300);
            Console.WriteLine(h.Fuel);

            Console.WriteLine(h);
        }
    }
}
