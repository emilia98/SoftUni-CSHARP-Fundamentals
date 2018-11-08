namespace MordorsCruelPlan.Entities
{
    public class Mushrooms : Food
    {
        private static new int Happiness = -10;

        public Mushrooms() : base(Mushrooms.Happiness)
        {
        }
    }
}