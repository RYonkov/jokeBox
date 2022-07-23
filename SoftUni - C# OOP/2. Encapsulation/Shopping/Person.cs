using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping
{
    public class Person
    {
        private string name;
        private double money;
        private List<string> bag;
        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.Bag = new List<string>();
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public double Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public List<string> Bag
        {
            get { return bag; }
            set { bag = value; }
        }
    }
}
