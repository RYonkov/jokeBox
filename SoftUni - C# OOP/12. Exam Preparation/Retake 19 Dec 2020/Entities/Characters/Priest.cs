using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        public Priest(string name) : base(name, 50d, 25d, 40d, new Backpack()) { }
        
        public void Heal(Character character)
        {
            if (character.IsAlive && this.IsAlive)
            {                
                character.Health += this.AbilityPoints;
                if (character.Health>character.BaseHealth)
                {
                    character.Health = character.BaseHealth;
                }
            }
        }
    }
}
