namespace SoftUniRestaurant.Models.Tables
{
    // InsideTable – with constant value for InitialPricePerPerson - 2.50
    public class InsideTable : Table
    {
        private const decimal InitialPricePerPerson = 2.50m;

        public InsideTable(int tableNumber, int capacity) : base(tableNumber, capacity, InitialPricePerPerson)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}