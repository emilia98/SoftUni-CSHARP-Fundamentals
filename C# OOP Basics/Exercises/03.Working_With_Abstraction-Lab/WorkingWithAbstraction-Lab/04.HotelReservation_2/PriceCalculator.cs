namespace HotelReservation_2
{
    public static class PriceCalculator
    {
        public static decimal Calculate(
            decimal pricePerDay, int days,
            Season season, Discount discount)
        {
            return (pricePerDay * days * (int)season) * (1 - (decimal)discount / 100);
        }
    }
}