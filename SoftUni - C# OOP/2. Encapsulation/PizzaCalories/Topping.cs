using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double meat = 1.2;
        private const double veggies = 0.8;
        private const double cheese = 1.1;
        private const double sauce = 0.9;
        private const double grams = 2;

        private double toppingGrams;//
        private string toppingType;//
        private double weightGrams;//
        public Topping(string toppingType, double grams)
        {
            this.ToppingType = toppingType;
            this.WeightGrams = grams;
        }

        public string ToppingType
        {
            get { return toppingType; }
            set
            {
                if (value.ToLower() == "Meat".ToLower())
                {
                    toppingGrams = meat;
                }
                else if (value.ToLower() == "Veggies".ToLower())
                {
                    toppingGrams = veggies;
                }
                else if (value.ToLower() == "Cheese".ToLower())
                {
                    toppingGrams = cheese;
                }
                else if (value.ToLower() == "Sauce".ToLower())
                {
                    toppingGrams = sauce;
                }
                else
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value;
            }
        }
        public double WeightGrams
        {
            get { return weightGrams; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{this.ToppingType} weight should be in the range [1..50].");
                }
                weightGrams = value;
            }
        }
        public double toppingCalories => grams * this.WeightGrams * this.toppingGrams;














        //private string toppingType;        
        //private double toppinghWeight;
        //private double toppingCaloriesPerGram = 2;
        //private double modifier;
        //public double totalCalories;

        //public Topping(string toppingType, double toppinghWeight, double toppingCaloriesPerGram)
        //{
        //    this.toppingType = toppingType;
        //    this.toppinghWeight = toppinghWeight;
        //    this.toppingCaloriesPerGram = toppingCaloriesPerGram;
        //    this.modifier = modifier;
        //    this.totalCalories = totalCalories;
        //}

        //public string ToppingType
        //{
        //    get
        //    {
        //        return this.toppingType;
        //    }
        //    set
        //    {
        //        if (value == "Meat" || value == "Veggies" || value == "Cheese" || value == "Sauce")
        //        {
        //            this.toppingType = value;
        //        }
        //        else
        //        {
        //            throw new ArgumentException($"Cannot place {value} on top of your pizza.");
        //        }
        //    }
        //}

        //private double ToppingWeight
        //{
        //    get
        //    {
        //        return this.toppinghWeight;
        //    }
        //    set
        //    {
        //        if (value > 0 && value <= 50)
        //        {
        //            this.toppinghWeight = value;                    
        //        }
        //        else
        //        {
        //            throw new ArgumentException($"{value} weight should be in the range [1..50].");
        //        }

        //    }
        //}

        //private double Modifier
        //{
        //    get
        //    {
        //        return modifier;
        //    }
        //    set
        //    {
        //        modifier = 1;
        //        if (this.toppingType == "Meat")
        //        {
        //            modifier *= 1.2;
        //        }
        //        else if (this.toppingType == "Veggies")
        //        {
        //            modifier *= 0.8;
        //        }
        //        else if (this.toppingType == "Chesse")
        //        {
        //            modifier *= 1.1;
        //        }
        //        else if (this.toppingType == "Sauce")
        //        {
        //            modifier *= 0.9;
        //        }                
        //    }
        //}
    }
}
