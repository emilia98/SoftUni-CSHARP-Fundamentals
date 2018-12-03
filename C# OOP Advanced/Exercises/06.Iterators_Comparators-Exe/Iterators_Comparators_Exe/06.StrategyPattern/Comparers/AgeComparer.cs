using System.Collections.Generic;

namespace _06.StrategyPattern
{
    public class AgeComparer : IComparer<IPerson>
    {
        public int Compare(IPerson x, IPerson y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}