using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Cleric : Character, IHealable
    {
        // The Cleric class always has 50 Base Health, 25 Base Armor, 40 Ability Points, and a Backpack as a bag.
        // The cleric’s RestHealMultiplier is 0.5.

        private static double baseHealth = 50;
        private static double baseArmor = 25;
        private static int abilityPoints = 40;
        private static Bag bag = new Backpack();

        public Cleric(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction) : base(name, health, armor, abilityPoints, bag, faction)
        {
            this.RestHealMultiplier = 0.5;
        }

        // void Heal(Character character)
        // 1)  For a character to heal another character, both of them need to be alive.
        // 2) If the character the character is healing is from a different faction, 
        // throw an InvalidOperationException with the message “Cannot heal enemy character!”
        // 3) If both of those checks pass, the receiving character’s health increases by the healer’s ability points.

        public void Heal(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                // ERROR: SHOULD THROW THIS EXCEPTION
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (this.Faction == character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            // ERROR: HOW HEALS
            character.Health += this.AbilityPoints;
        }
    }
}
