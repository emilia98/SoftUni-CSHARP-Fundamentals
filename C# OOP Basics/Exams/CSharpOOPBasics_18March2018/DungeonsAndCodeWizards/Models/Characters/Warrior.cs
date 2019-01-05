namespace DungeonsAndCodeWizards.Models.Characters
{
    using DungeonsAndCodeWizards.Models.Bags;
    using DungeonsAndCodeWizards.Models.Contracts;
    using System;

    public class Warrior : Character, IAttackable
    {
        private static double baseHealth = 100;
        private static double baseArmor = 50;
        private static int abilityPoints = 40;
        private static Bag bag = new Satchel();

        // The Warrior class always has 100 Base Health, 50 Base Armor, 40 Ability Points, and a Satchel as a bag.
        public Warrior(string name, Faction faction)
            : base(name, baseHealth, baseArmor, abilityPoints, bag, faction)
        {
        }


        // void Attack(Character character)
        // 1) For a character to attack another character, both of them need to be alive.
        // 2) If the character they are trying to attack is the same character, 
        //    throw an InvalidOperationException with the message “Cannot attack self!”
        // 3) If the character the character is attacking is from the same faction, 
        //    throw an ArgumentException with the message 
        //    “Friendly fire! Both characters are from { faction }
        //    faction!”
        // 4) If all of those checks pass, the receiving character takes damage with hit points equal to the attacking character’s ability points.

        public void Attack(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                // ERROR: SHOULD THROW THIS EXCEPTION
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if(this == character)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if(this.Faction == character.Faction)
            {
                throw new InvalidOperationException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }

            // ERROR: HOW ATTACKS
            character.TakeDamage(this.AbilityPoints);
        }
    }
}
