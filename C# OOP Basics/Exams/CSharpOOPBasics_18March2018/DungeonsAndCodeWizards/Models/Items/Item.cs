namespace DungeonsAndCodeWizards.Models.Items
{
    using DungeonsAndCodeWizards.Models.Characters;
    using DungeonsAndCodeWizards.Models.Contracts;

    public abstract class Item : IItem
    {
        public int Weight { get; private set; }

        protected Item(int weight)
        {
            this.Weight = weight;
        }

        // void AffectCharacter(Character character)
        // 1) For an item to affect a character, the character needs to be alive.
        // 2) If not, throw an InvalidOperationException with the message 
        //    “Must be alive to perform this action!”.
        // 3) Throw this exception everywhere a character needs to be alive to perform the action.

        public virtual void AffectCharacter(Character character)
        {
        }
    }
}
