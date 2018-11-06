namespace _07.FoodShortage
{
    public abstract class Member : IBuyer, IMember
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public int Food { get; }

        protected Member(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            // this.Food = 0;
        }

        public abstract void BuyFood();
    }
}