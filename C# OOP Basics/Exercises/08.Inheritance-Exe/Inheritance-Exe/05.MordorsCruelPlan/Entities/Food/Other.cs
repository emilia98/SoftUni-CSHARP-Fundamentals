namespace MordorsCruelPlan.Entities
{
    public class Other : Food
    {
        private static new int Happiness = -1;

        public Other() : base(Other.Happiness)
        {
        }
    }
}