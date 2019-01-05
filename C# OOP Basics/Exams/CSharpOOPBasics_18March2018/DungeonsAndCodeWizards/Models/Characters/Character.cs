namespace DungeonsAndCodeWizards.Models.Characters
{
    using DungeonsAndCodeWizards.Models.Bags;
    using DungeonsAndCodeWizards.Models.Contracts;
    using DungeonsAndCodeWizards.Models.Items;
    using System;
    
    public abstract class Character : ICharacter
    {
        /*
•	Health – a floating-point number (current health).
o	Health maxes out at BaseHealth and mins out at 0. 
•	Armor – a floating-point number (current armor)
o	Armor maxes out at BaseArmor and mins out at 0.
•	Faction – a constant value with 2 possible values: CSharp and Java
         */
        private string name;
        private double health;
        private double armor;

        // ERROR: WHAT TO DO HERE
        public Faction Faction { get; }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health
        {
            get { return this.health; }
            set
            {
                if (value <= 0)
                {
                    this.health = 0;
                    this.IsAlive = false;
                }

                if (value >= this.BaseHealth)
                {
                    this.health = this.BaseHealth;
                }

                this.health = value;
            }
        }

        public double BaseArmor { get; }

        public double Armor
        {
            get { return this.armor; }
            set
            {
                if (value <= 0)
                {
                    this.armor = 0;
                }

                if (value >= this.BaseArmor)
                {
                    this.armor = this.BaseArmor;
                }

                this.armor = value;
            }
        }

        public double AbilityPoints { get; }

        public Bag Bag { get; }

        public bool IsAlive { get; private set; }

        public double RestHealMultiplier { get;  set; }
        

        protected Character(string name, double health, double armor,
                            double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.Bag = bag;
            this.AbilityPoints = abilityPoints;
            this.IsAlive = true;
            this.RestHealMultiplier = 0.2;
            this.Faction = faction;
            this.BaseHealth = health;
            this.BaseArmor = armor;

            // ERROR: INIT VALUES???
            this.Health = this.BaseHealth;
            this.Armor = this.BaseArmor;
        }

        // void TakeDamage(double hitPoints)
        // 1) For a character to take damage, they need to be alive.
        // 2) The character takes damage equal to the hit points. Taking damage works like so:
        // 3) The character’s armor is reduced by the hit point amount, 
        //    then if there are still hit points left, they take that amount of health damage.
        // 4) If the character’s health drops to zero, the character dies (IsAlive become false)
        // 5) Example: Health: 100, Armor: 30, Hit Points: 40  Health: 90, Armor: 0
        public void TakeDamage(double hitPoints)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (this.Armor < hitPoints)
            {
                this.Health -= (hitPoints - this.Armor);
            }

            this.Armor -= hitPoints;

            // ERROR: BELOW ZERO OR EQUAL
            /* if (this.Health <= 0)
            {
                this.IsAlive = false;

            }
            */
        }

        // void Rest()
        // 1) For a character to rest, they need to be alive.
        // 2) The character’s health increases by their BaseHealth, multiplied by their RestHealMultiplier
        // 3) Example: Health: 50, BaseHealth: 100, RestHealMultiplier: 0.2  Health: 50 + (100 * 0.2)  70
        public void Rest()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            this.Health += (this.BaseHealth * 0.2);
        }
        

        // void ReceiveItem(Item item)
        // 1) For a character to receive an item, they need to be alive.
        // 2) The character puts the item into their bag.
        public void ReceiveItem(Item item)
        {
            if(!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            this.Bag.AddItem(item);
        }

        // void GiveCharacterItem(Item item, Character character)
        // 1) For a character to give another character an item, both of them need to be alive.
        // 2) The targeted character receives the item.
        public void GiveCharacterItem(Item item, Character character)
        {
            if(!this.IsAlive || !character.IsAlive)
            {
                // ERROR: SHOULD THROW THIS EXCEPTION
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            // ERROR: SHOULD I REMOVE THE ITEM FROM BAG
            //  this.Bag.
            character.ReceiveItem(item);
        }

        // void UseItem(Item item)
        // 1) For a character to use an item, they need to be alive.
        // 2) The item affects the character with the item effect.
        public void UseItem(Item item)
        {
            if(!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            item.AffectCharacter(this);
        }

        // void UseItemOn(Item item, Character character)
        // 1) For a character to use an item on another character, both of them need to be alive.
        // 2) The item affects the targeted character with the item effect.
        public void UseItemOn(Item item, Character character)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            character.UseItem(item);
        }
    }
}
