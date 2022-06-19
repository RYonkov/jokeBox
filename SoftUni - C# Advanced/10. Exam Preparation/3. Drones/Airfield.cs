using System;
using System.Collections.Generic;           //For Dictionaries, stacks and queues
using System.Diagnostics;                   //For clock, stopwatch
using System.Globalization;                 //For regional specifics
using System.Linq;                          //For lambda expressions
using System.Numerics;                      //For BigInteger
using System.Text;                          //For StringBuilder
using System.Text.RegularExpressions;       //For Regex


namespace Drones
{
    public class Airfield
    {
        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count { get { return this.Drones.Count; } private set {; } }   
        public Airfield(string name, int capacity, double landingStrip)
        {           
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.Drones = new List<Drone>(); 
        }

        public string AddDrone(Drone drone)
        {
            if (String.IsNullOrEmpty(drone.Name) || String.IsNullOrEmpty(drone.Brand) || drone.Range<5 || drone.Range>15)
            {
                return $"Invalid drone.";
            }
            else if (this.Count>=Capacity)
            {
                return $"Airfield is full."; 
            }
            else
            {
                this.Drones.Add(drone);
                this.Count++;
                return $"Successfully added {drone.Name} to the airfield.";
            }
            
            
            return null; 
        }
        public bool RemoveDrone(string name)
        {
            int count = this.Drones.RemoveAll(x => x.Name == name);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int RemoveDroneByBrand(string brand)
        {
            int count = this.Drones.RemoveAll(x => x.Brand == brand);
            return count;
        }
        public Drone FlyDrone(string name)
        {
            foreach (var elelement in Drones)
            {
                if (elelement.Name==name)
                {
                    elelement.Available = false;                    
                    return elelement;
                }
            } 
            return null;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> matchingDrones = new List<Drone>();

            foreach (var element in Drones)
            {
                if (element.Range>=range)
                {
                    element.Available = false;
                    matchingDrones.Add(element);
                }
            }            
            return matchingDrones;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");
            foreach (var element in Drones)
            {
                if (element.Available)
                {
                    sb.AppendLine($"{element.ToString()}");
                }
            }     
            return sb.ToString().TrimEnd();
        }
    }
}
