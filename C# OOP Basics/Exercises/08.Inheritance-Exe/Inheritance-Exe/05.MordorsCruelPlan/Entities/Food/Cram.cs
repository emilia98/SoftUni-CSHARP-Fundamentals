namespace MordorsCruelPlan.Entities
{
    public class Cram : Food
    {
        private static new int Happiness = 2;

        public Cram() : base(Cram.Happiness)
        {
        }
    }
}