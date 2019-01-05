namespace SoftUniRestaurant.Models.Foods
{
    // Dessert – with constant value for InitialServingSize - 200
    public class Dessert : Food
    {
        private const int InitialServingSize = 200;

        public Dessert(string name, decimal price) : base(name, InitialServingSize, price)
        {
        }
    }
}