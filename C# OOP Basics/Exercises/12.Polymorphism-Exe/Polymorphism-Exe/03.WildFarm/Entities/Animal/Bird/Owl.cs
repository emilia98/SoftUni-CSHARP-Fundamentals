using System;

namespace _03.WildFarm
{
    public class Owl : Bird
    {
        private static double WeightUp = 0.25;
        private static string Sound = "Hoot Hoot";

        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            Console.WriteLine(Owl.Sound);

            string foodType = food.GetType().Name;

            if (foodType == "Meat")
            {
                this.IncreaseWeight(Owl.WeightUp, food);
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {foodType}!");
            }
        }
    }
}