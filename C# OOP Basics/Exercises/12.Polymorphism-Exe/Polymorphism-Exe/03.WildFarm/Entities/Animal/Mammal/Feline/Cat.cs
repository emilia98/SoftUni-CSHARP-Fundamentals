using System;

namespace _03.WildFarm
{
    public class Cat : Feline
    {
        private static double WeightUp = 0.30;
        private static string Sound = "Meow";

        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            string foodType = food.GetType().Name;

            Console.WriteLine(Cat.Sound);

            if (foodType == "Vegetable" || foodType == "Meat")
            {
                this.IncreaseWeight(Cat.WeightUp, food);
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {foodType}!");
            }
        }
    }
}