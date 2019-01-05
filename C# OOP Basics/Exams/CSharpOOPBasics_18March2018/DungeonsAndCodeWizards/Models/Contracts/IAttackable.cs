namespace DungeonsAndCodeWizards.Models.Contracts
{
    using DungeonsAndCodeWizards.Models.Characters;

    public interface IAttackable
    {
        // A contract for any class that implements it, that includes an “Attack(Character character)” method
        void Attack(Character character);
    }
}