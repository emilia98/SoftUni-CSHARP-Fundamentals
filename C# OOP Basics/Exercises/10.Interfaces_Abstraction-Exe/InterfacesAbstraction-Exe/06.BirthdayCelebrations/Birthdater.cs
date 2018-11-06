using System;

namespace _06.BirthdayCelebrations
{
    public class Birthdater : IHasBirthday
    {
        public virtual DateTime Birthday { get;  protected set; }

        public bool IsBornInThatYear(int year)
        {
            return this.Birthday.Year == year;
        }
    }
}