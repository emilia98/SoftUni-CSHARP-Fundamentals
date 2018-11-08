namespace MordorsCruelPlan.Entities
{
    public class Apple : Food
    {
        private static new int Happiness = 1;
        
        public Apple() : base(Apple.Happiness)
        {
        }
    }
}