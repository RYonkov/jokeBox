using System;

namespace Shopping
{
    public class Product
    {
        private string name;
        private double cost;
        public Product(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;            
        }

        public string Name
        {
            get 
            {              
               return name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public double Cost
        {
            get { return cost; }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                cost = value;
            }
        }
    }
}
