namespace DungeonsAndCodeWizards.Models.Contracts
{
    using DungeonsAndCodeWizards.Models.Items;
    using System.Collections.Generic;

    public interface IBag
    {
        int Capacity { get; }

        IReadOnlyCollection<Item> Items { get; }

        int Load { get; }
        
        void AddItem(Item item);

        Item GetItem(string name);
    }
}