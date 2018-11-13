namespace _03.WildFarm
{
    public abstract class Animal
    {
        public string Name { get; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public void IncreaseWeight(double weight, Food food)
        {
            this.Weight += (weight * food.Quantity);
            this.IncreaseEatenFood(food);
        }

        private void IncreaseEatenFood(Food food)
        {
            this.FoodEaten += food.Quantity;
        }

        public virtual void Eat(Food food)
        {
        }
    }
}