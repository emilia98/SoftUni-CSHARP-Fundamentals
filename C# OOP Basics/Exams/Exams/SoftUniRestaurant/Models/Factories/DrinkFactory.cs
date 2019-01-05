using SoftUniRestaurant.Models.Drinks;
using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Factories
{
    public class DrinkFactory
    {
        public IDrink CreateFactory(string type, string name, int servingSize, string brand)
        {
            switch (type)
            {
                case "FuzzyDrink":
                    return new FuzzyDrink(name, servingSize, brand);
                case "Juice":
                    return new Juice(name, servingSize, brand);
                case "Water":
                    return new Water(name, servingSize, brand);
                case "Alcohol":
                    return new Alcohol(name, servingSize, brand);
            }

            return null;
        }
    }
}
