namespace SoftUniRestaurant.Models.Drinks
{
    // Alcohol – with constant value for AlcoholPrice - 3.50
    public class Alcohol : Drink
    {
        private const decimal AlcoholPrice = 3.50m;

        public Alcohol(string name, int servingSize, string brand) : base(name, servingSize, AlcoholPrice, brand)
        {
        }
    }
}