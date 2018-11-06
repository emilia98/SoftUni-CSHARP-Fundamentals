namespace _07.FoodShortage
{
    public class Citizen : Member
    {
        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public int Food { get; private set; }

        public Citizen(string name, int age, string id, string birthdate) : base(name, age)
        {
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }

        public override void BuyFood()
        {
            this.Food = this.Food + 10;
        }
    }
}