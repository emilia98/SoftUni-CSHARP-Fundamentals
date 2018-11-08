namespace MordorsCruelPlan.Entities
{
    public class HoneyCake : Food
    {
        private static new int Happiness = 5;

        public HoneyCake() : base(HoneyCake.Happiness)
        {
        }
    }
}