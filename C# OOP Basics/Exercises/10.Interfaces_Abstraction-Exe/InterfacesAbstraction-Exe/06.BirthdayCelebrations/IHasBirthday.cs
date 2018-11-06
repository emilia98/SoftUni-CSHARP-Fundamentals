using System;

namespace _06.BirthdayCelebrations
{
    public interface IHasBirthday
    {
        DateTime Birthday { get; }

        bool IsBornInThatYear(int year);
    }
}