namespace Travel.Entities.Items
{
	public class Jewelery : Item
	{
        // Jewelery – $300 value
        private static int JeweleryValue = 300;

        public Jewelery() :base(JeweleryValue)
        {
        }
    }
}