using System.Collections.Generic;
using System.Linq;

namespace _03.OldestFamilyMember_3
{
    class Family
    {
        public List<Person> Members { get; set; } = new List<Person>();

        public Person GetOldestMember()
        {
            return this.Members.OrderByDescending(x => x.Age).First();
        }
    }
}