namespace Travel.Entities.Items
{
    public class Toothbrush : Item
    {
        // Toothbrush – $3 value
        private static int ToothbrushValue = 3;

        public Toothbrush() : base(ToothbrushValue)
        {
        }
    }
}