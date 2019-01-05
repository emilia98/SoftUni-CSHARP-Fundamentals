using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class ArmorRepairKit : Item
    {
        private static int weight = 10;

        public ArmorRepairKit() : base(weight)
        {
        }

        // void AffectCharacter(Character character)
        // 1) For an item to affect a character, the character needs to be alive.
        // 2) The character’s armor restored up to the base armor value.
        // 3) Example: Armor: 10, Base Armor: 100  Armor: 100
        public override void AffectCharacter(Character character)
        {
            character.Armor = character.BaseArmor;
        }
    }
}
