using MordorsCruelPlan.Entities;

namespace MordorsCruelPlan.Factory
{
    public static class FoodFactory
    {
        public static Food Get(string type)
        {
            switch(type.ToLower())
            {
                case "cram":  return new Cram();
                case "lembas": return new Lembas();
                case "apple": return new Apple();
                case "melon": return new Melon();
                case "honeycake": return new HoneyCake();
                case "mushrooms": return new Mushrooms();
                default: return new Other();
            }
        }
    }
}