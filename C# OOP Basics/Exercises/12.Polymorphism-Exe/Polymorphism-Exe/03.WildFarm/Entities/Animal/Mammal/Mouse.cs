using System;

namespace _03.WildFarm
{
    public class Mouse : Mammal
    {
        private static double WeightUp = 0.10;
        private static string Sound = "Squeak";

        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            Console.WriteLine(Mouse.Sound);

            string foodType = food.GetType().Name;

            if (foodType == "Vegetable" || foodType == "Fruit")
            {
                this.IncreaseWeight(Mouse.WeightUp, food);

            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {foodType}!");
            }

        }
    }
}