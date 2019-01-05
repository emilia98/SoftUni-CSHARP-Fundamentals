using DungeonsAndCodeWizards.Models.Contracts;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag : IBag
    {

        private List<Item> items;
        private int capacity;
        // Capacity – an integer number.Default value: 100

        //  public int Capacity { get; }
        public int Capacity => this.capacity;

        public IReadOnlyCollection<Item> Items
        {
            get { return this.items; }
        }

        public int Load => this.Items.Sum(x => x.Weight);

        protected Bag(int capacity)
        {
            // this.capacity = 100;
            this.capacity = capacity;
            this.items = new List<Item>();
            // this.Capacity = 100;
        }


        // void AddItem(Item item)
        // If the current load + the weight of the item attempted to be added
        // is greater than the bag’s capacity,
        // throw an InvalidOperationException with the message “Bag is full!”
        // If the check passes, the item is added to the bag.
        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        //Item GetItem(string name)
        // 1. If no items exist in the bag, throw an InvalidOperationException 
        //    with the message “Bag is empty!”
        // 2. If an item with that name doesn’t exist in the bag, 
        //    throw an ArgumentException with the message “No item with name { name } in bag!”
        //If both checks pass, the item is removed from the bag and returned to the caller.
        public Item GetItem(string name)
        {
            if(this.Items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            var item = this.items.FirstOrDefault(x => x.GetType().Name == name);

            if(item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            this.items.Remove(item);
            return item;
        }
    }
}
