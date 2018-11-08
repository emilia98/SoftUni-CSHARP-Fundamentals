using MordorsCruelPlan.Entities;

namespace MordorsCruelPlan.Factory
{
    public static class MoodFactory
    {
        public static Mood Get(int happiness)
        {
            if (happiness < -5)
            {
                return new Angry();
            }
            else if (happiness >= -5 && happiness <= 0)
            {
                return new Sad();
            }
            else if (happiness >= 1 && happiness <= 15)
            {
                return new Happy();
            }
            else
            {
                return new JavaScript();
            }
        }
    }
}