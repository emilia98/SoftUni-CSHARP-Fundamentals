using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class HealthPotion : Item
    {
        private static int weight = 5;

        public HealthPotion() : base(weight)
        {
        }

        // void AffectCharacter(Character character)
        // 1) For an item to affect a character, the character needs to be alive.
        // 2) The character’s health gets increased by 20 points.
        public override void AffectCharacter(Character character)
        {
            character.Health += 20;
        }
    }
}
