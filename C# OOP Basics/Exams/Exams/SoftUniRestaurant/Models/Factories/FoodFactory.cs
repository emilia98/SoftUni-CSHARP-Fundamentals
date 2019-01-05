namespace SoftUniRestaurant.Models.Factories
{
    using Foods;
    using Models.Foods.Contracts;
    using System;
    using System.Linq;

    public class FoodFactory
    {
        /*
        public IFood CreateFactory(string type, string name, decimal price)
        {
            switch (type)
            {
                case "Dessert":
                    return new Dessert(name, price);
                case "Salad":
                    return new Salad(name, price);
                case "Soup":
                    return new Soup(name, price);
                case "MainCourse":
                    return new MainCourse(name, price);
            }

            return null;
        }
        */

        public Food CreateFactory(string type, string name, decimal price)
        {
            var foodType = this.GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => typeof(Food).IsAssignableFrom(t) && !t.IsAbstract && t.Name == type);

            if (foodType == null)
            {
                throw new InvalidOperationException("Invalid product type!");
            }

            try
            {
                var food = (Food)Activator.CreateInstance(foodType, name, price);
                return food;
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }

        }
    }
}