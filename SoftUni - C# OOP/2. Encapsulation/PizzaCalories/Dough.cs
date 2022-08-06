using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double doughWeight;
        private double calPerGram = 2;
        private double modifier; 
        public double totalCalories;
        public Dough(string flourType, string bakingTechnique, double doughWeigth)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.DoughWeight = doughWeigth;
            this.Modifier = modifier;
            this.TotalCalories = totalCalories;
        }
        private string FlourType
        {
            get
            {
                return this.flourType;
            }
            set
            {
                if (value.ToLower() == "White".ToLower() || value.ToLower()=="Wholegrain".ToLower())
                {
                    this.flourType = value;                    
                }          
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        private string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            set
            {
                if (value.ToLower() == "Crispy".ToLower() || value.ToLower() =="Chewy".ToLower() || value.ToLower() == "Homemade".ToLower())
                {
                    this.bakingTechnique = value;                   
                }              
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
               
            }
        }
        private double DoughWeight
        {
            get
            {
                return this.doughWeight;
            }
            set
            {
                if (value > 0 && value <= 200)
                {
                    this.doughWeight = value;                    
                }
                else
                {
                    throw new ArgumentException("Dough weight should be in the range[1..200].");
                }

            }
        }       

        private double Modifier
        {
            get
            {
                return modifier;
            }
            set
            {
                modifier = 1;                 
                if (this.flourType.ToLower() == "White".ToLower())
                {
                    modifier *= 1.5;
                }
                else if (this.flourType.ToLower() == "Wholegrain".ToLower())
                {
                    modifier *= 1;
                }

                if (bakingTechnique.ToLower() == "Crispy".ToLower())
                {
                    modifier *= 0.9;
                }
                else if (bakingTechnique.ToLower() == "Chewy".ToLower())
                {
                    modifier *= 1.1;
                }
                else if (bakingTechnique.ToLower() == "Homemade".ToLower())
                {
                    modifier *= 1;
                }                
            }
        }

        //public double calories => caloriesPerGram * this.DoughWeight * this.FlourType * this.bakingTechnique;
        public double TotalCalories
        {
            get
            {
                return this.totalCalories;
            }
            set
            {
                this.totalCalories = this.doughWeight * this.calPerGram * this.modifier;
            }
        }        
    }
}
