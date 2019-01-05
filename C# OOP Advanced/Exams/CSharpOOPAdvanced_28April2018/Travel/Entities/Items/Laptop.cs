namespace Travel.Entities.Items
{
	public class Laptop : Item
	{
        // Laptop – $3000 value
        private static int LaptopValue = 3000;

        public Laptop() : base(LaptopValue)
        {
        }
    }
}