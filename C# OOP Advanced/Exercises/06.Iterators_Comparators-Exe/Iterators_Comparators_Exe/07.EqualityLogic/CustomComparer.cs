using System.Collections.Generic;

namespace _07.EqualityLogic
{
    class CustomComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int nameComparison = x.Name.CompareTo(y.Name);
            int ageComparison = x.Age.CompareTo(y.Age);

            if(nameComparison != 0)
            {
                return nameComparison;
            }

            if(ageComparison != 0)
            {
                return ageComparison;
            }

            return 0;
        }
    }
}
