using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.
        private string name;
        private double health;
        private double baseHealth;
        private double baseArmor;
        private double abilityPoints;
        private Bag bag;
        public bool IsAlive { get; set; } = true;
        public string Name
        {
            get => name;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            }
        }
        public double BaseHealth
        {
            get => baseHealth;
            private set
            {
                baseHealth = value;
            }
        }
        public double Health
        {
            get => health; 
            set
            {
                if (value>this.BaseHealth)
                {
                    health = this.BaseHealth;
                }
                if (value<0)
                {
                    throw new InvalidOperationException("Health could not be below 0.");
                }
                health = value; 
            } 
        }
        public double BaseArmor
        {
            get => baseArmor;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Armor cannot be 0.");
                }
                baseArmor = value;
            }
        }
        public double AbilityPoints { get; set; }
        public Bag Bag { get => bag; }

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.AbilityPoints = abilityPoints;

            if (bag.GetType().Name == "Backpack")
            {
                this.bag = new Backpack();
            }
            else if (bag.GetType().Name == "Satchel")
            {
                this.bag = new Satchel();
            }

        }      
        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Character is already DEAD!!!");
            }

            if (hitPoints>this.BaseArmor)
            {
                hitPoints -= this.BaseArmor;
                this.BaseArmor = 0;            
                this.Health -= hitPoints;
            }
            else
            {
                this.BaseArmor-=hitPoints;
            }

            if (this.Health<=0)
            {
                this.IsAlive = false;
                this.Health = 0;
            }
        }

        public void UseItem(Item item)
        {
            if (this.IsAlive)
            {               
                item.AffectCharacter(this);
            }
        }
    }
}