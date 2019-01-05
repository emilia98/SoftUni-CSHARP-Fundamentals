namespace SoftUniRestaurant.Models.Foods
{
    // Salad - with constant value for InitialServingSize - 300
    public class Salad : Food
    {
        private const int InitialServingSize = 300;

        public Salad(string name, decimal price) : base(name, InitialServingSize, price)
        {
        }
    }
}