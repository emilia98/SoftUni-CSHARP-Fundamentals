﻿namespace _03.WildFarm
{
    public abstract class Feline : Mammal
    {
        public string Breed { get; }

        protected Feline(string name, double weight, 
                       string livingRegion,
                      string breed
            ) : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}