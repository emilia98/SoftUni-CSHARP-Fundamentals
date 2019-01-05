namespace DungeonsAndCodeWizards.Models.Bags
{
    public class Backpack : Bag
    {
        private static int capacity = 100;

        public Backpack() : base(capacity)
        {
        }
    }
}