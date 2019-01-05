namespace DungeonsAndCodeWizards.Models.Contracts
{
    using DungeonsAndCodeWizards.Models.Bags;

    public interface ICharacter
    {
        Faction Faction { get; }

        string Name { get; }

        double BaseHealth { get; }

        double Health { get; }

        double BaseArmor { get; }

        double Armor { get; }

        double AbilityPoints { get; }

        Bag Bag { get; }

        bool IsAlive { get; }

        double RestHealMultiplier { get; }
    }
}