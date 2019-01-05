namespace SoftUniRestaurant.Models.Drinks
{
    // FuzzyDrink – with constant value for FuzzyDrinkPrice - 2.50
    public class FuzzyDrink : Drink
    {
        private const decimal FuzzyDrinkPrice = 2.50m;

        public FuzzyDrink(string name, int servingSize, string brand) : base(name, servingSize, FuzzyDrinkPrice, brand)
        {
        }
    }
}