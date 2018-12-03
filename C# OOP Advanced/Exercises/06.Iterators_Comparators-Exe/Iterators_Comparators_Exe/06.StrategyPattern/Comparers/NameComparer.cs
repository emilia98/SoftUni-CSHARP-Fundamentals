using System.Collections.Generic;

namespace _06.StrategyPattern
{
    public class NameComparer : IComparer<IPerson>
    {
        public int Compare(IPerson x, IPerson y)
        {
            int nameLengthComparation = x.Name.Length.CompareTo(y.Name.Length);

            if(nameLengthComparation != 0)
            {
                return nameLengthComparation;
            }

            return x.Name.ToLower()[0].CompareTo(y.Name.ToLower()[0]);
        }
    }
}