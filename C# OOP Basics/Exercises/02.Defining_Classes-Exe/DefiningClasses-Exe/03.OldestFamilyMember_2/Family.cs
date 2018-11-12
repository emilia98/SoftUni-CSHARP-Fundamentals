using System.Collections.Generic;

namespace _03.OldestFamilyMember_2
{
    class Family
    {
        private List<Person> members = new List<Person>();

        public List<Person> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }

        public Person GetOldestMember()
        {
            int ageOfOldest = int.MinValue;
            Person oldest = null;

            foreach(var member in members)
            {
                if(member.Age > ageOfOldest)
                {
                    oldest = member;
                    ageOfOldest = member.Age;
                }
            }
            return oldest;
        }
    }
}
