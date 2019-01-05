using SoftUniRestaurant.Models.Tables;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;

namespace SoftUniRestaurant.Models.Factories
{
    public class TableFactory
    {
        public ITable CreateFactory(string type, int tableNumber, int capacity)
        {
            switch (type)
            {
                case "Inside":
                    return new InsideTable(tableNumber, capacity);
                case "Outside":
                    return new OutsideTable(tableNumber, capacity);
            }

            return null;
        }
    }
}
