using System;
using System.Collections.Generic;
using System.Text;

namespace OldestFamilyMember
{
    class Family
    {
        private List<Person> members;
        private Person oldestMember;

        public Family()
        {
            this.members = new List<Person>();
            this.oldestMember = null;
        }
        
        public void AddMember(Person member)
        {
            this.members.Add(member);

            if(this.oldestMember == null)
            {
                this.oldestMember = member;
            }
            else
            {
                if(member.Age > this.oldestMember.Age)
                {
                    this.oldestMember = member;
                }
            }
        }

        public Person GetOldestMember()
        {
            return this.oldestMember;
        }
    }
}
