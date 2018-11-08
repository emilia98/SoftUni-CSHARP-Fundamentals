using MordorsCruelPlan.Entities;
using MordorsCruelPlan.Factory;
using System;

namespace MordorsCruelPlan
{
    public class StartUp
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var foodTokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int totalHappiness = 0;

            foreach(var food in foodTokens)
            {
                var type = FoodFactory.Get(food);
                totalHappiness += type.Happiness;
            }

            Mood mood = MoodFactory.Get(totalHappiness);

            Console.WriteLine(totalHappiness);
            Console.WriteLine(mood.Type);
        }
    }
}