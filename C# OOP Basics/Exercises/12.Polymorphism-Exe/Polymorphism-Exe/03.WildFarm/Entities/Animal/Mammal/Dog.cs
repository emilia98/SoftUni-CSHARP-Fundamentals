using System;

namespace _03.WildFarm
{
    public class Dog : Mammal
    {
        private static double WeightUp = 0.40;
        private static string Sound = "Woof!";

        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            Console.WriteLine(Dog.Sound);

            string foodType = food.GetType().Name;

            if (foodType == "Meat")
            {
                this.IncreaseWeight(Dog.WeightUp, food);
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {foodType}!");
            }
        }
    }
}