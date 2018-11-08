namespace MordorsCruelPlan.Entities
{
    public abstract class Food
    {
        public int Happiness { get; private set; }

        protected Food(int happiness)
        {
            this.Happiness = happiness;
        }
    }
}