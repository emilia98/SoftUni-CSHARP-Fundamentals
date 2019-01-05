namespace SoftUniRestaurant.Models.Tables
{
    // OutsideTable – with constant value for InitialPricePerPerson - 3.50
    public class OutsideTable : Table
    {
        private const decimal InitialPricePerPerson = 3.50m;

        public OutsideTable(int tableNumber, int capacity) : base(tableNumber, capacity, InitialPricePerPerson)
        {
        }
    }
}