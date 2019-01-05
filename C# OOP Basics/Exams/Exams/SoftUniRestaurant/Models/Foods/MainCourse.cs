namespace SoftUniRestaurant.Models.Foods
{
    // MainCourse - with constant value for InitialServingSize - 500
    public class MainCourse : Food
    {
        private const int InitialServingSize = 500;

        public MainCourse(string name, decimal price) : base(name, InitialServingSize, price)
        {
        }
    }
}