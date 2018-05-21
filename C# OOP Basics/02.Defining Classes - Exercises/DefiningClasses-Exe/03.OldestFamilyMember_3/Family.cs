using System.Collections.Generic;

class Family
{
    private List<Person> members = new List<Person>();
    private Person oldestPerson;
    private int maxAge = int.MinValue;

    public void AddMember(Person member)
    {
        if(member.Age > maxAge)
        {
            oldestPerson = member;
            maxAge = member.Age;
        }
        this.members.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.oldestPerson;
    }
}

