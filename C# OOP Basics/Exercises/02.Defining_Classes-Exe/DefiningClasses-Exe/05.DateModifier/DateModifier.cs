using System;
using System.Collections.Generic;
using System.Text;

namespace _05.DateModifier
{
    class DateModifier
    {
        private DateTime date;

        public DateModifier(int year, int month, int day)
        {
            this.date = new DateTime(year, month, day);
        }

        public DateTime Date
        {
            get { return this.date; }
        }

        public int FindDifference(DateModifier date)
        {
            var startDate = this.Date;
            var endDate = date.Date;

            return Math.Abs((int)(startDate - endDate).TotalDays);
        }
    }
}