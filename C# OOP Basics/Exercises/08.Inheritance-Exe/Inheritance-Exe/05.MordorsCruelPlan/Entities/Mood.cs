namespace MordorsCruelPlan.Entities
{
    public abstract class Mood
    {
        public string Type { get; private set; }

        protected Mood(string type)
        {
            this.Type = type;
        }
    }
}