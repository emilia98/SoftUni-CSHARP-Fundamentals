using System;
using System.Collections.Generic;
using System.Text;

namespace _04.HotelReservation
{
    class PriceCalculator
    {
        private int days;
        private decimal pricePerDay;
        private int multipliedBy;
        private int discount;

        public PriceCalculator(int days, decimal pricePerDay, Season season, Discount discount)
        {
            this.days = days;
            this.pricePerDay = pricePerDay;
            this.multipliedBy = (int)season;
            this.discount = (int)discount;
        }

        public decimal Calculate()
        {
            return this.days * this.pricePerDay * this.multipliedBy * (1 - (this.discount / 100.0m));
        }
    }
}
