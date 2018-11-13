using System;

namespace _03.WildFarm
{
    public class Tiger : Feline
    {
        private static double WeightUp = 1.00;
        private static string Sound = "ROAR!!!";

        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            Console.WriteLine(Tiger.Sound);

            string foodType = food.GetType().Name;

            if (foodType == "Meat")
            {
                this.IncreaseWeight(Tiger.WeightUp, food);
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {foodType}!");
            }
        }
    }
}