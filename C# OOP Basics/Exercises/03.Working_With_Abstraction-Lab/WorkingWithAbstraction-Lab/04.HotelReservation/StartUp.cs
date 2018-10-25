using System;

namespace _04.HotelReservation
{
    public class StartUp
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            decimal pricePerDay = decimal.Parse(tokens[0]);
            int days = int.Parse(tokens[1]);
            string season = tokens[2];
            string discountType = "None";

            if(tokens.Length == 4)
            {
                discountType = tokens[3];
            }

            var customSeason = (Season)Enum.Parse(typeof(Season), season);
            var customDiscount = (Discount)Enum.Parse(typeof(Discount), discountType);
            var calculator = new PriceCalculator(days, pricePerDay, customSeason, customDiscount);

            Console.WriteLine($"{calculator.Calculate():f2}");
        }
    }
}