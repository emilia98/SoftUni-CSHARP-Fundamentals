namespace DungeonsAndCodeWizards.Models.Contracts
{
    using DungeonsAndCodeWizards.Models.Characters;

    public interface IHealable
    {
        // A contract for any class that implements it, that includes a “Heal(Character character)” method
        void Heal(Character character);
    }
}