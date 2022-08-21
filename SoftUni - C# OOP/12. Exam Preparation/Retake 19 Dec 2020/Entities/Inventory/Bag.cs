using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity;
        private readonly List<Item> items;
        protected Bag(int capacity)
        {
            this.capacity = capacity;     
            items = new List<Item>();
        }

        public int Capacity { get => capacity; set {; } }

        public int Load => Items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items { get => items.AsReadOnly();  }

        public void AddItem(Item item)
        {
            if (item.Weight+this.Load> this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }            
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count==0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            if (!this.items.Any(x=>x.GetType().Name == name))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }
            
            Item seeked = this.items.FirstOrDefault(x => x.GetType().Name == name);
            items.Remove(seeked);
            return seeked;
        }
    }
}
