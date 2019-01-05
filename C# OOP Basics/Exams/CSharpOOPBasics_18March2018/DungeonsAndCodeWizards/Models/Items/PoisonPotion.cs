using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class PoisonPotion : Item
    {
        private static int weight = 5;

        public PoisonPotion() : base(weight)
        {
        }

        // void AffectCharacter(Character character)
        // 1) For an item to affect a character, the character needs to be alive.
        // 2) The character’s health gets decreased by 20 points.
        //    If the character’s health drops to zero, the character dies (IsAlive  false).

        public override void AffectCharacter(Character character)
        {
            character.Health -= 20;
        }
    }
}