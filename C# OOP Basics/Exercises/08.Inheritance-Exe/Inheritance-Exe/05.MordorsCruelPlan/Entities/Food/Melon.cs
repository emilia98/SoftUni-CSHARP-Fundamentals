namespace MordorsCruelPlan.Entities
{
    public class Melon : Food
    {
        private static new int Happiness = 1;

        public Melon() : base(Melon.Happiness)
        {
        }
    }
}