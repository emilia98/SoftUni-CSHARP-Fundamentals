namespace MordorsCruelPlan.Entities
{
    public class Happy : Mood
    {
        private static string Mood = "Happy";

        public Happy() : base(Happy.Mood)
        {
        }
    }
}