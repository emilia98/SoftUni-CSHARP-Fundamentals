namespace _07.FoodShortage
{
    public class Rebel : Member, IBuyer
    {
        public string Group { get; private set; }

        public int Food { get; private set; }

        public Rebel(string name, int age, string group) : base(name, age)
        {
            this.Group = group;
            this.Food = 0;
        }

        public override void BuyFood()
        {
            this.Food += 5;
        }
    }
}
