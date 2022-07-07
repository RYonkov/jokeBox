using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public abstract class Vehicle
    {
        public const double DEFAULT_FUEL_CONSUMPTION = 1.25;
        public virtual double FuelConsumption => DEFAULT_FUEL_CONSUMPTION;                    
        
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public Vehicle(int horsepower, double fuel)
        {
            HorsePower = horsepower;
            Fuel = fuel;            
        }
        public virtual void Drive(double kilometers)
        {
            if (this.Fuel >= kilometers * FuelConsumption)
            {
                this.Fuel -= kilometers * FuelConsumption;
            }

        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}\nHorse power: {this.HorsePower}\nFuel: {this.Fuel}\nFuel consumption: {this.FuelConsumption}";
        }
    }
}
