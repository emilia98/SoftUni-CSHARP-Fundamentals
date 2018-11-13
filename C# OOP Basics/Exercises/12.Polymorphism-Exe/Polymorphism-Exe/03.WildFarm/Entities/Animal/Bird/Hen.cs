using System;

namespace _03.WildFarm
{
    public class Hen : Bird
    {
        private static double WeightUp = 0.35;
        private static string Sound = "Cluck";

        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            Console.WriteLine(Hen.Sound);
            this.IncreaseWeight(Hen.WeightUp, food);
        }
    }
}